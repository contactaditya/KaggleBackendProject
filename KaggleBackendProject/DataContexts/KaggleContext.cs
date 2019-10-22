using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DataLayer;

namespace KaggleBackendProject.DataContexts
{
    public class KaggleContext : DbContext
    {
        public KaggleContext() : base("DefaultConnection")
        {
        }

        public DbSet<KaggleExcelFiles> ExcelFiles { get; set; }
    }
}

