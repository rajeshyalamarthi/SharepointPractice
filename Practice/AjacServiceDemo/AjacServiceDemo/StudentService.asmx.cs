using AjacServiceDemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AjacServiceDemo
{
    /// <summary>
    /// Summary description for StudentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StudentService : System.Web.Services.WebService
    {
        Student student = new Student();
        //Student s = new Student();
        [WebMethod]
        public Student GetStudentById(int SId)
        {
            string C = ConfigurationManager.ConnectionStrings["Rajesh"].ConnectionString;
            using (SqlConnection connection=new SqlConnection(C))
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
                return student;


            }
            
        }
    }
}
