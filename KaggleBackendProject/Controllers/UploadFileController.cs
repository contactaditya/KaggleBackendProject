using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.IO;
using System.Net;
using DataLayer;
using KaggleBackendProject.DataContexts;


namespace KaggleBackendProject.Controllers
{
    public class UploadFileController : Controller
    {
        //
        // GET: /UploadFile/
        public ActionResult UploadFile()
        {
            return View();
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (var dbContext = new KaggleContext())
                {
                    KaggleExcelFiles uploadfile = new KaggleExcelFiles();

                    if (file.FileName.EndsWith(".xls") || file.FileName.EndsWith(".xlsx"))
                    {

                        string fileName = System.IO.Path.GetFileName(file.FileName);
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                        file.SaveAs(Server.MapPath("~/ExcelFiles/" + fileName));

                        uploadfile.FileName = fileName;

                        dbContext.ExcelFiles.Add(uploadfile);
                        dbContext.SaveChanges();
                    }

                    else
                    {
                        TempData["error"] = "This file format is not supported. Please select either .xls or .xlsx format.";
                        return RedirectToAction("UploadFile", "UploadFile");
                    }
                }

            }
            TempData["success"] = "This file has been uploaded successfully.";
            return RedirectToAction("UploadFile", "UploadFile");
        }
	}
}