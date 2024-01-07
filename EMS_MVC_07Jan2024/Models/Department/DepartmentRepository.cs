using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS_MVC_07Jan2024.Models.Department
{
    public class DepartmentRepository
    {
        public List<DepartmentModel> GetDepartments
        {
            get
            {
                //code to fetch data from database
            List<DepartmentModel> list = new List<DepartmentModel>()
            {
                 new DepartmentModel()
                    {
                        DepartmentId = 1,
                        DepartmentName = "Human Resource",
                        DepartmentCode = "HR"
                    },
                 new DepartmentModel()
                    {
                        DepartmentId = 2,
                        DepartmentName = "Department Manager",
                        DepartmentCode = "DPTR"
                    },
                 new DepartmentModel()
                    {
                        DepartmentId = 3,
                        DepartmentName = "System Admin",
                        DepartmentCode = "Admin"
                    }
            };

                return list;
            }
        }
    }
}