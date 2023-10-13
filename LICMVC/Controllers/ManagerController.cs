using LICMVC.Models;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Data.SqlClient;
namespace LICMVC.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {   
            List<Manager> list = new List<Manager>();
            var con = new SqlConnection("Data Source=Brajesh; Initial Catalog=RitshMvcDB; Integrated Security=True;");
            con.Open();
            var Command = new SqlCommand("select * from Manager",con);
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {  
                int id = Convert.ToInt32(reader["id"]);
                string MallName = Convert.ToString(reader["MallName"]);
                int ShopNo = Convert.ToInt32(reader["ShopNo"]);
                string Address = Convert.ToString(reader["Address"]);
                string State = Convert.ToString(reader["state"]);
                list.Add(new Manager() { 
                
                id = id,
                MallName =MallName,
                ShopNo =ShopNo,
                Address = Address,
                State = State,
                                
               
                });
            }
            con.Dispose();

            return View(list);
        }
        public IActionResult Insert()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Insert( Manager manager)
        {
            var con = new SqlConnection("Data Source=Brajesh; Initial Catalog=RitshMvcDB; Integrated Security=True;");
            con.Open();
            var command = new SqlCommand("insert into Manager values('" + manager.MallName + "', '" + manager.ShopNo + "','" + manager.Address + "','" +manager.State + "')", con);
            command.ExecuteNonQuery();
            con.Dispose();
            return RedirectToAction(nameof(Index));


            

        }
    }
}
