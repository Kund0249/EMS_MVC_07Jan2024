using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS_MVC_07Jan2024.Models.Employee
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }
}