using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
