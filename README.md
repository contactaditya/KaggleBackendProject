# Kaggle Backend Project

This is a simple MVC project that implements a page called Export File. You can go to the home page and click on Export File to access it. You can choose any .xls or .xlsx file and then click on Export button. The file gets exported to CSVFiles folder in the project folder. I have implemented my solution using ExcelDataReader. It is a cross platform open source lightweight and fast library written in C# for reading microsoft excel files. The project can be accessed at: https://github.com/ExcelDataReader/ExcelDataReader.

I have also implemented a page called Upload File. On this page you can upload any excel file and the file uploaded is stored in the ExcelFiles folder in the project folder. I have also implemented a database using Entity Framework called KaggleBackendProject which has a table called KaggleExcelFiles. In this table there are only two columns: Id and FileName. It just records the name of the file which is uploaded by the user. 
