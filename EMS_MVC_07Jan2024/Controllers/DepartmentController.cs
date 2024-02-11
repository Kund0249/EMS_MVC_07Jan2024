using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EMS_MVC_07Jan2024.Models.Department;

namespace EMS_MVC_07Jan2024.Controllers
{
    
    [AllowAnonymous]
    public class DepartmentController : BaseController
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

        [OutputCache(Duration =30)]
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
            ViewBag.Title = "EMS-Department";
            var data = _repository.GetDepartments;

            //both ViewBag and ViewData are used to send the data from Controller Action to View

            //dynamic
            //auto resolve the type at run time in case of complex object
            //ViewBag.mydata = new List<string>() {"ViewBag-1","ViewBag-2","ViewBag-3" };

            //key value pair : dictionary
            //need to conver the type explicitly in case of complex object
            //ViewData["Msg"] = new List<string>() { "ViewData-1", "ViewData-2", "ViewData-3" };

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
            {
                Notification("Success", "Record Created Successfully", MessageType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Notification("Success", ErrorMessage, MessageType.error);

                return View();
            }
        }


        [HttpGet]
        public ActionResult Edit(int DepartmentID)
        {
            DepartmentModel model = _repository.GetDepartment(DepartmentID);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(DepartmentModel model)
        {
            if (_repository.Update(model, out string ErrorMessage))
            {
                //var JS = new JavaScriptSerializer();
                //var toastr = new
                //{
                //    Title = "Success Message",
                //    Message = model.DepartmentCode + " Updated!",
                //    MessageType = "success"
                //};
                ////TempData["Message"] = JS.Serialize(model.DepartmentCode + " Updated!");
                //TempData["Message"] = JS.Serialize(toastr);
                Notification("Success Message",model.DepartmentCode + " Updated!",MessageType.success);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int DepartmentID)
        {
            //delete
            if (_repository.Remove(DepartmentID, out string Message))
            {
                Notification("Success", "Record Delete Successfully", MessageType.success);
            }
            else
            {
                Notification("Error", "Record not Delete", MessageType.error);

            }
            return RedirectToAction("Index");
        }


    }

}