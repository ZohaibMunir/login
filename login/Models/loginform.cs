using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace login.Models
{
    public class loginform
    {
        public int ID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int age { get; set; }
        public string Contact_no { get; set; }
        public string email { get; set; }


    }
}