﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS_MVC_07Jan2024.Models.Employee;
using EMS_MVC_07Jan2024.Models.ExtensionMethod;

namespace EMS_MVC_07Jan2024.Controllers
{

    //[HandleError] //Filter at Controller level
    public class EmployeeController : BaseController
    {
        private readonly EmployeeRepository _repository;

        public EmployeeController()
        {
            _repository = new EmployeeRepository();
        }

        //[HandleError] //Filter at Action level
        public ViewResult Index()
        {
            throw new Exception("My custome Error");
            var list = _repository.GetEmployees();
            return View(list);
        }

        public ViewResult Create()
        {
            
            return View(new EmployeeCreateModel());
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateModel model)
        {

            if (ModelState.IsValid)
            {
                string commasepvalues = model.CheckBoxOptions.ListToString("|");
                if (model.ProfileImage != null)
                {
                    //EmpImage
                    string filename = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                    model.ProfileImage.SaveAs(Server.MapPath("~/EmpImage/") + filename);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}