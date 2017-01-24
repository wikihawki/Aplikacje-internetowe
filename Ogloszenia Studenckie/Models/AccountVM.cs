using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogloszenia_Studenckie.Models
{
    public class AccountVM
    {
 
        public string Nazwa { get; set; }
        public string E_Mail { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string Haslo { get; set; }
    }
}