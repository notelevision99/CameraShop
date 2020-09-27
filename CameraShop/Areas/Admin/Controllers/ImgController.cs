using CameraShop.DAL;
using CameraShop.HelperCode;
using CameraShop.Models;
using CameraShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CameraShop.Areas.Admin.Controllers
{
    public class ImgController : Controller
    {
        // GET: Admin/Img
        private ShopContext db = new ShopContext();
        public ActionResult Index()
        {
            ImageViewModel model = new ImageViewModel { FileAttach = null, ImgLst = new List<ImgObj>() };

            try
            {
                // Settings.  
                model.ImgLst = db.FileImgs.Select(p => new ImgObj
                {
                    FileId = p.file_id,
                    FileName = p.file_name,
                    FileContentType = p.file_ext
                }).ToList(); ;
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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
