using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS_MVC_07Jan2024.Models.Department;

namespace EMS_MVC_07Jan2024.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _repository;
        public DepartmentController()
        {
            _repository = new DepartmentRepository();
        }
        //EndPoint or Action Method : Public + Non-Static
        //public string GetMessage()
        //{
        //    return "Hello from Department Controller";
        //}

        public ViewResult Index()
        {
            //object data = "Hello from Department Controller";

            //return View(data);

            //DepartmentModel department = new DepartmentModel()
            //{
            //    DepartmentId = 1,
            //    DepartmentName = "Human Resource",
            //    DepartmentCode = "HR"
            //};

            //return View(department);

            //List<DepartmentModel> list = new List<DepartmentModel>()
            //{
            //     new DepartmentModel()
            //        {
            //            DepartmentId = 1,
            //            DepartmentName = "Human Resource",
            //            DepartmentCode = "HR"
            //        },
            //     new DepartmentModel()
            //        {
            //            DepartmentId = 2,
            //            DepartmentName = "Department Manager",
            //            DepartmentCode = "DPTR"
            //        },
            //     new DepartmentModel()
            //        {
            //            DepartmentId = 3,
            //            DepartmentName = "System Admin",
            //            DepartmentCode = "Admin"
            //        }
            //};

            //return View(list);

            var data = _repository.GetDepartments;
            return View(data);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentModel model)
        {
            if (_repository.Save(model, out string ErrorMessage))
                return RedirectToAction("Index");
            else
            {
                ViewBag.Message = ErrorMessage;
                return View();
            }
        }


    }

}