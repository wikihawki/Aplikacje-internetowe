using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogloszenia_Studenckie.Models
{
    public class LoginVM
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ReturnURL { get; set; }

        public bool isRemember { get; set; }

    }
}