using CameraShop.DAL;
using CameraShop.HelperCode;
using CameraShop.Models;
using CameraShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using PagedList;

namespace CameraShop.Areas.Admin.Controllers
{
    public class ImgController : Controller
    {
        // GET: Admin/Img
        private ShopContext db = new ShopContext();
        public ActionResult Index(string currentFilter,string searchString, int? page)
        {
            
            
            ImageViewModel model = new ImageViewModel { FileAttach = null, ImgLst = new List<ImgObj>() };
            
            
            if(!String.IsNullOrEmpty(searchString))
            {
                model.ImgLst = db.FileImgs.Where(p => p.file_name.Contains(searchString)).Select(p => new ImgObj
                {
                    FileId = p.file_id,
                    FileName = p.file_name,
                    FileContentType = p.file_ext    
                }).ToList();
                return View(model);
            }
            try
            {
                // Settings.  
                model.ImgLst = db.FileImgs.Select(p => new ImgObj
                {
                    FileId = p.file_id,
                    FileName = p.file_name,
                    FileContentType = p.file_ext
                }).ToList() ;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ImageViewModel model)
        {
            // Initialization.  
            string fileContent = string.Empty;
            string fileContentType = string.Empty;

            try
            {
                // Verification  
                if (ModelState.IsValid)
                {
                    // Converting to bytes.  
                    byte[] uploadedFile = new byte[model.FileAttach.InputStream.Length];
                    model.FileAttach.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                    // Initialization.  
                    fileContent = Convert.ToBase64String(uploadedFile);
                    fileContentType = model.FileAttach.ContentType;

                    // Saving info.  

                    var imgModel = new FileImg
                    {
                        file_name = model.FileAttach.FileName,
                        file_ext = fileContentType,
                        file_base6 = fileContent
                    };
                    db.FileImgs.Add(imgModel);
                    db.SaveChanges();

                }

                // Settings.  
                model.ImgLst = db.FileImgs.Select(p => new ImgObj
                {
                    FileId = p.file_id,
                    FileName = p.file_name,
                    FileContentType = p.file_ext
                }).ToList();
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info  
            return this.View(model);
        }

        public ActionResult DownloadFile(int fileId)
        {
            // Model binding.  
            ImageViewModel model = new ImageViewModel { FileAttach = null, ImgLst = new List<ImgObj>() };

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
       
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileImg img = db.FileImgs.Find(id);
            if(img == null)
            {
                return HttpNotFound();
            }
            return View(img);
           
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileImg img = db.FileImgs.Find(id);
            db.FileImgs.Remove(img);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      

    }
}
