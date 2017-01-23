using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace Ogloszenia_Studenckie.Models
{
    public class RegisterVM
    {
        
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string E_Mail { get; set; }
        [Required]
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        [Required]
        public string Haslo { get; set; }
    }
}