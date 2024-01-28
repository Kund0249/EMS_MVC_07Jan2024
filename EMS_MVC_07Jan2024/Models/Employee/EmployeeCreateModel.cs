using EMS_MVC_07Jan2024.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EMS_MVC_07Jan2024.Models.Employee
{
  public  class Hobbi
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
    }
    public class EmployeeCreateModel
    {
        public EmployeeCreateModel()
        {
            Hobbies = new List<Hobbi>()
            {
                 new Hobbi(){Text="Music",Value="1",IsSelected=false},
                 new Hobbi(){Text="Reading",Value="2",IsSelected=false},
                 new Hobbi(){Text="Chess",Value="3",IsSelected=false},
                 new Hobbi(){Text="Watching",Value="4",IsSelected=false},
            };

           var data =  new DepartmentRepository().GetDepartments;
            Departments = new List<SelectListItem>();
            foreach (var item in data)
            {
                Departments.Add(new SelectListItem()
                {
                    Text = item.DepartmentName,
                    Value = item.DepartmentId.ToString()
                });
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public string AccountNo { get; set; }
        public string CnfAccountNo { get; set; }
        public int Salary { get; set; }
        public string ContactNo { get; set; }
        public DateTime DOJ { get; set; }
        public bool IsActive { get; set; }

        public List<Hobbi> Hobbies { get; set; }

        public HttpPostedFileBase ProfileImage { get; set; }

        public List<SelectListItem> Departments { get; set; }
    }
}