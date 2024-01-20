using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS_MVC_07Jan2024.Models.Employee;

namespace EMS_MVC_07Jan2024.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _repository;

        public EmployeeController()
        {
            _repository = new EmployeeRepository();
        }
        public ViewResult Index()
        {
            //return "Request handeled by employee controller - Index Action";
            //EmployeeModel empl1 = new EmployeeModel()
            //{
            //    Id = 1,
            //    Name = "John",
            //    Department = "IT",
            //    Email = "john@gmail.com"
            //};
            //EmployeeModel empl2 = new EmployeeModel()
            //{
            //    Id = 2,
            //    Name = "Arpita",
            //    Department = "IT",
            //    Email = "arpita@gmail.com"
            //};
            //EmployeeModel empl3 = new EmployeeModel()
            //{
            //    Id = 3,
            //    Name = "Manisha",
            //    Department = "IT",
            //    Email = "manisha@gmail.com"
            //};


            //List<EmployeeModel> list = new List<EmployeeModel>()
            //{
            //    new EmployeeModel()
            //        {
            //            Id = 1,
            //            Name = "John",
            //            Department = "IT",
            //            Email = "john@gmail.com"
            //        },
            //    new EmployeeModel()
            //{
            //    Id = 2,
            //    Name = "Arpita",
            //    Department = "IT",
            //    Email = "arpita@gmail.com"
            //},
            //    new EmployeeModel()
            //{
            //    Id = 3,
            //    Name = "Manisha",
            //    Department = "IT",
            //    Email = "manisha@gmail.com"
            //}
            //};
            //list.Add(empl1);
            //list.Add(empl2);
            //list.Add(empl3);

            var list = _repository.GetEmployees();
            return View(list);
        }
    }
}