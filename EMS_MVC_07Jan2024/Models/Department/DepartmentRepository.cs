using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EMS_MVC_07Jan2024.Models.Department
{
    public class DepartmentRepository
    {
        String CS = string.Empty;
        public DepartmentRepository()
        {
            CS = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
        }
        public List<DepartmentModel> GetDepartments
        {
            get
            {
                //code to fetch data from database
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

                List<DepartmentModel> list = null;


                using(SqlConnection con = new SqlConnection(CS))
                {
                    DataTable table = new DataTable();

                    SqlCommand cmd = new SqlCommand("spGetAllDepartments", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);

                    if(table != null)
                    {
                        if(table.Rows.Count > 0)
                        {
                            list =  new List<DepartmentModel>();

                            foreach (DataRow item in table.Rows)
                            {
                                list.Add(new DepartmentModel()
                                {
                                    DepartmentId = Convert.ToInt32(item["DepartmentId"]),
                                    DepartmentName = item["DepartmentName"].ToString(),
                                    DepartmentCode = item["DepartmentCode"].ToString()
                                });
                            }
                        }
                    }

                }

                return list;
            }
        }

        public bool Save(DepartmentModel model,out string ErrorMessage)
        {
            try
            {
                string StatusCode = string.Empty;
                ErrorMessage = string.Empty;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("[spInsertDepartment]", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DeptCode", model.DepartmentCode);
                    cmd.Parameters.AddWithValue("@DeptName", model.DepartmentName);

                    con.Open();
                    StatusCode = (string)cmd.ExecuteScalar();
                    con.Close();
                }

                if (StatusCode == "S001")
                    return true;
                else
                    ErrorMessage = "Record already exists!";

                return false;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
    }

}