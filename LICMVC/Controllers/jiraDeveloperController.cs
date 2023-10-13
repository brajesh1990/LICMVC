using LICMVC.Models;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using System.Data.SqlClient;
using System.Linq;

namespace LICMVC.Controllers
{
    public class jiraDeveloperController : Controller
    {
        public IActionResult Index()
        {

            List<jiraDeveloper> List = new List<jiraDeveloper>();
            var con = new SqlConnection("Data Source=Brajesh; Initial Catalog=RitshMvcDB; Integrated Security=True;");
            con.Open();
            var command = new SqlCommand("select * from jiraDeveloper", con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string ComepanyName = Convert.ToString(reader["ComepanyName"]);

                string EmpolyeeName = Convert.ToString(reader["EmpolyeeName"]);
                string Workingtype = Convert.ToString(reader["Workingtype"]);
                string State = Convert.ToString(reader["State"]);
                List.Add(new jiraDeveloper()
                {
                    id = id,
                    ComepanyName = ComepanyName,
                    EmpolyeeName = EmpolyeeName,
                    Workingtype = Workingtype,
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
        public IActionResult Insert(jiraDeveloper jiraDeveloper)

        {
            var con = new SqlConnection("Data Source=Brajesh; Initial Catalog=RitshMvcDB; Integrated Security=True;");
            con.Open();
            var command = new SqlCommand("insert into jiraDeveloper values('" + jiraDeveloper.ComepanyName + "', '" + jiraDeveloper.EmpolyeeName + "','" + jiraDeveloper.Workingtype + "','" + jiraDeveloper.State + "')", con);
            command.ExecuteNonQuery();
            con.Dispose();
            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            jiraDeveloper jiraDeveloper = new jiraDeveloper();

            using (var con = new SqlConnection("Data Source=Brajesh; Initial Catalog=RitshMvcDB; Integrated Security=True;"))
            {
                con.Open();
                using (var Command = new SqlCommand("Select * from jiraDeveloper Where id =@id", con))
                {
                    Command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = Command.ExecuteReader();

                    if (reader.Read())
                    {
                        jiraDeveloper.id = (int)reader["id"];
                        jiraDeveloper.ComepanyName = (string)reader["ComepanyName"];
                        jiraDeveloper.EmpolyeeName = (string)reader["EmpolyeeName"];
                        jiraDeveloper.Workingtype = (string)reader["Workingtype"];
                        jiraDeveloper.State = (string)reader["State"];
                    }

                }
            }
            return View(jiraDeveloper);
        }

        [HttpPost]
        public IActionResult Edit(jiraDeveloper jiraDeveloper)
        {
            var con = new SqlConnection("Data Source=Brajesh; Initial Catalog=RitshMvcDB; Integrated Security=True;");
            con.Open();
            var command = new SqlCommand("update jiraDeveloper set ComepanyName='" + jiraDeveloper.ComepanyName + "',EmpolyeeName='" + jiraDeveloper.EmpolyeeName + "',Workingtype='" + jiraDeveloper.Workingtype + "',State='" + jiraDeveloper.State + "' where id=" + jiraDeveloper.id + "", con);

            command.ExecuteNonQuery();
            con.Dispose();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var con = new SqlConnection("Data Source=Brajesh; Initial Catalog=RitshMvcDB; Integrated Security=True;");
            con.Open();
            var command = new SqlCommand("delete jiraDeveloper Where id =" + id + "", con);

            command.ExecuteNonQuery();
            con.Dispose();
            return RedirectToAction(nameof(Index));
        }


    }
}













