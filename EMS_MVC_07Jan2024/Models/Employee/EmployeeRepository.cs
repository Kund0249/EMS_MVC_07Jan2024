using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EMS_MVC_07Jan2024.Models.ExtensionMethod;


namespace EMS_MVC_07Jan2024.Models.Employee
{
    public class EmployeeRepository
    {
        string CS = string.Empty;
        public EmployeeRepository()
        {
            CS = "Data Source=.;DataBase=Assignement10112023;trusted_connection=true";
        }

        public List<EmployeeModel> GetEmployees()
        {
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
            //},
            //    new EmployeeModel()
            //{
            //    Id = 4,
            //    Name = "Siya",
            //    Department = "CS",
            //    Email = "siya@gmail.com"
            //}
            //};

            List<EmployeeModel> list = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new EmployeeModel()
                        {
                            Id = Convert.ToInt32(reader["EmployeeId"]),
                            Name = reader["Name"].ToString(),
                            Department = reader["Department"].ToString(),
                            Email = (reader["EmailAddress"].ToString() == "" ? "NA" : reader["EmailAddress"].ToString())
                        });
                    }
                }
            }
            return list;
        }
    }

}