using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Net;
using DataLayer;
using KaggleBackendProject.DataContexts;
using Excel;

namespace KaggleBackendProject.Controllers
{
    public class ExportFileController : Controller
    {
        //
        // GET: /ExportFile/
        public ActionResult ExportFile()
        {
            return View();
        }

          public ActionResult FileExport(HttpPostedFileBase file)
        {

      // In this method we will first read the excel file and then store it in a DataSet. Then we will read and convert that DataSet into a CSV File and store it locally in the CSV folder in the project.

            if (file != null)
            {

              Stream stream = file.InputStream;

              IExcelDataReader excelReader = null;

              if (file.FileName.EndsWith(".xls"))
              {
                  excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
              }

              else if (file.FileName.EndsWith(".xlsx"))
              {
                  excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
              }

              else
              {
                  TempData["error"] = "This file format is not supported. Please select either .xls or .xlsx format.";
                  return RedirectToAction("ExportFile", "ExportFile");
              }

              excelReader.IsFirstRowAsColumnNames = true;
              DataSet result = excelReader.AsDataSet();
              excelReader.Close();

              List<string> items = new List<string>();
              for (int i = 0; i < result.Tables.Count; i++)
              {
                  items.Add(result.Tables[i].TableName.ToString());
              }

              string csvData = "";
              int row_no = 0;

              for (int x = 0; x < result.Tables.Count; x++)
              {

                  while (row_no < result.Tables[x].Rows.Count)
                  {
                      for (int i = 0; i < result.Tables[x].Columns.Count; i++)
                      {
                          csvData += result.Tables[x].Rows[row_no][i].ToString() + ",";
                      }
                      row_no++;
                      csvData += "\n";
                  }

              }

              string fileName = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
              string fileContentType = file.ContentType;
              byte[] fileBytes = new byte[file.ContentLength];
              var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));  
              string output = fileName + ".csv"; // define your own filepath & filename
              StreamWriter csv = new StreamWriter(Server.MapPath("~/CSVFiles/" + output), false);
              csv.Write(csvData);
              csv.Close();
             
            }
            
             TempData["success"] = "This file has been exported successfully.";
             return RedirectToAction("ExportFile", "ExportFile");
        }
	}
}

      