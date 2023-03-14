using ERP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Controllers
    
{
    public class AdminController : Controller
    {

        AdminModel adminObj = new AdminModel();
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        //................................................................................................................................

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();

        }


        [HttpPost]
        public ActionResult AdminLogin(LoginModel admin)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=ROMANSHI;Initial Catalog=ERP;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Admin WHERE Email=@Email AND Password=@Password", conn);
                    cmd.Parameters.AddWithValue("@Email", admin.Email);
                    cmd.Parameters.AddWithValue("@Password", admin.Password);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        // Login successful
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        // Login failed
                        ModelState.AddModelError("", "Invalid email or password");
                        return View();
                    }
                }
            }
            return View();
        }
        //................................................................................................................................

        public IActionResult AdminRegi()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AdminRegi(AdminModel admin)
        {
            bool res;
            //if (ModelState.IsValid)
            //{
            adminObj = new AdminModel();
            res = adminObj.Insert(admin);
            if (res)
            {
                TempData["msg"] = "Added successfully";
            }
            //}
            else
            {
                TempData["msg"] = "Not Added. something went wrong..!!";
            }


            return View();

        }
        //................................................................................................................................



    }
}
