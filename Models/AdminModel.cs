using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class AdminModel
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ROMANSHI;Initial Catalog=ERP;Integrated Security=True");
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string AdminName { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Enter Valid Email!")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

        public bool Insert(AdminModel admin)
        {
            SqlCommand cmd = new SqlCommand("insert into Admin values(@AdminName,@Email,@Password)", conn);
            cmd.Parameters.AddWithValue("@AdminName", admin.AdminName);
            cmd.Parameters.AddWithValue("@Email", admin.Email);
            cmd.Parameters.AddWithValue("@Password", admin.Password);
            conn.Open();

            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;

        }

        
       

    }
}