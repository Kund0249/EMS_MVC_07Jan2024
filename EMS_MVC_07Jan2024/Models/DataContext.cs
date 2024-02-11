using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EMS_MVC_07Jan2024.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DBCon")
        {

        }
        public DbSet<Department.DepartmentModel> Departments { get; set; }
    }
}