using CameraShop.DAL;
using CameraShop.HelperCode;
using CameraShop.Models;
using CameraShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace CameraShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category)
                .Include(i => i.FileImgs)
                .ToList();
            

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var product = new Product();
            product.FileImgs = new List<FileImg>();
            PopulateAssignedImageData(product);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");

            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]  
        public ActionResult Create([Bind(Include = "ProductID,ProductName,OriPrice,DiscountedPrice,CategoryID,ProductSpecification")] Product product, string[] selectedFileImgs)
        {
            if (selectedFileImgs != null)
            {
                product.FileImgs = new List<FileImg>();
                foreach (var fileimgs in selectedFileImgs)
                {
                    var fileimgToAdd = db.FileImgs.Find(int.Parse(fileimgs));
                    product.FileImgs.Add(fileimgToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedImageData(product);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Product/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
        //    return View(product);
        //}

        //-----------------------------Test: Edit/id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products
                .Include(i => i.Category)
                .Include(i => i.FileImgs)
                .Where(i => i.ProductID == id)
                .Single();
            PopulateAssignedImageData(product);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }



        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProductID,ProductName,OriPrice,DiscountedPrice,CategoryID")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
        //    return View(product);
        //}

        ///test -----------------------------httppost edit/id-----------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedFileImgs)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productToUpdate = db.Products
               .Include(i => i.Category)
               .Include(i => i.FileImgs)
               .Where(i => i.ProductID == id)
               .Single();

            if (TryUpdateModel(productToUpdate, "",
               new string[] { "ProductID", "ProductName", "OriPrice", "DiscountedPrice", "CategoryID", "ProductSpecification" }))
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(productToUpdate.Category.CategoryName))
                    {
                        productToUpdate.Category = null;
                    }

                    UpdateProductFileImgs(selectedFileImgs, productToUpdate);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateAssignedImageData(productToUpdate);
            return View(productToUpdate);
        }



        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }





        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult DownloadFile(int fileId)
        {
            // Model binding.  
            ImageViewModel model = new ImageViewModel { ImgLst = new List<ImgObj>() };

            try
            {
                // Loading dile info.  
                var fileInfo = db.FileImgs.Single(i => i.file_id == fileId);

                // Info.  
                return this.GetFile(fileInfo.file_base6, fileInfo.file_ext);
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.View(model);
        }
        private FileResult GetFile(string fileContent, string fileContentType)
        {
            // Initialization.  
            FileResult file = null;

            try
            {
                // Get file.  
                byte[] byteContent = Convert.FromBase64String(fileContent);
                file = this.File(byteContent, fileContentType);
            }
            catch (Exception ex)
            {
                // Info.  
                throw ex;
            }

            // info.  
            return file;
        }

        private void UpdateProductFileImgs(string[] selectedFileImgs, Product productToUpdate)
        {
            if (selectedFileImgs == null)
            {
                productToUpdate.FileImgs = new List<FileImg>();
                return;
            }

            var selectedFileImgsHS = new HashSet<string>(selectedFileImgs);
            var productFileImgs = new HashSet<int>
                (productToUpdate.FileImgs.Select(c => c.file_id));
            foreach (var img in db.FileImgs)
            {
                if (selectedFileImgsHS.Contains(img.file_id.ToString()))
                {
                    if (!productFileImgs.Contains(img.file_id))
                    {
                        productToUpdate.FileImgs.Add(img);
                    }
                }
                else
                {
                    if (productFileImgs.Contains(img.file_id))
                    {
                        productToUpdate.FileImgs.Remove(img);
                    }
                }
            }
        }

        private void PopulateAssignedImageData(Product product)
        {
            var allFileImgs = db.FileImgs;
            var productFileImgs = new HashSet<int>(product.FileImgs.Select(c => c.file_id));
            var viewModel = new List<AssignedImageData>();
            foreach (var img in allFileImgs)
            {
                viewModel.Add(new AssignedImageData
                {
                    file_id = img.file_id,
                    file_base6 = img.file_base6,
                    file_name = img.file_name,
                    Assigned = productFileImgs.Contains(img.file_id)
                });
            }
            ViewBag.FileImgs = viewModel;
        }
    }
}