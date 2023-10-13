using LICMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace LICMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> List =new List<Employee>();
            var con = new SqlConnection("Data Source=Brajesh; Initial Catalog=RitshMvcDB; Integrated Security=True;");
            con.Open();
            var command = new SqlCommand("select * from Employee order by id desc", con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id=Convert.ToInt32(reader["Id"]);
                string Name=Convert.ToString(reader["Name"]);
                string FatherName=Convert.ToString(reader["FatherName"]);
                string State=Convert.ToString(reader["State"]);
                string Email=Convert.ToString(reader["Email"]);
                List.Add(new Employee()
                {
                    Id = id,
                    Name = Name,
                    FatherName =FatherName,
                    Email = Email,
                    State = State,

                   });
             }
            con.Dispose();

             return View(List);
            
        }


        public IActionResult Insert()
        {


            return View();

             
        }
        [HttpPost]
        public IActionResult Insert( Employee employee)
        {

            string CanectionString = ("Data Source=Brajesh;Initial Catalog=RitshMvcDB; Integrated Security=True;");
            var con = new SqlConnection(CanectionString);
            string query = "insert into Employee values('" + employee.Name + "','" + employee.FatherName + "','" + employee.State + "','" + employee.Email + "')";
            con.Open();
            var Command = new SqlCommand(query, con);
            Command.ExecuteNonQuery();
            con.Dispose();



            return RedirectToAction("Index");
        }
    }
    
    
   
}


