using AjacServiceDemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjacServiceDemo
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static Student GetStudentById(int SId)
        {
            Student student = new Student();
            string C = ConfigurationManager.ConnectionStrings["Rajesh"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(C))
            {
                SqlCommand command = new SqlCommand("GetStudentByid", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter("@SId", SId);
                command.Parameters.Add(sqlParameter);
         
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {


                    student.SId = Convert.ToInt32(dataReader["SId"]);
                    student.Name = dataReader["Name"].ToString();
                    student.Gender = dataReader["Gender"].ToString();
                    student.Marks = Convert.ToInt32(dataReader["Marks"]);

                }
            }
                return student;


            

        }
    }
}
