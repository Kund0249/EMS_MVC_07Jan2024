using EMS_MVC_07Jan2024.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace EMS_MVC_07Jan2024.Models.Employee
{
 
    public class EmployeeCreateModel
    {
        public EmployeeCreateModel()
        {
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

        [Required(ErrorMessage ="Name is mandatory")]
        [RegularExpression("[a-zA-Z\\s]*",ErrorMessage ="only alphabets allowed")]
        [StringLength(20,ErrorMessage ="Maximum 20 char allowed")]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("[0-9]{10,22}")]
        public string AccountNo { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("AccountNo")]
        public string CnfAccountNo { get; set; }

        [Required]
        [Range(20000,200000)]
        public int Salary { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        public DateTime DOJ { get; set; }
        public bool IsActive { get; set; }

        public HttpPostedFileBase ProfileImage { get; set; }

        public List<SelectListItem> Departments { get; set; }

        public List<string> CheckBoxOptions { get; set;}
    }
}