using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ogloszenia_Studenckie.Models
{
    public class RegisterVM
    {
        
        [Required(ErrorMessage ="Proszę podać nazwę konta",AllowEmptyStrings =false)]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Pole E-mail jest wymagane !")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
         ErrorMessage = "Please provide valid email id")]
        [DisplayName("E-Mail")]
        public string E_Mail { get; set; }
        [Required(ErrorMessage = "Proszę podać imię", AllowEmptyStrings = false)]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko", AllowEmptyStrings = false)]
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę konta", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Hasło musi mieć no najmniej 8 znaków")]
        public string Haslo { get; set; }
        [Compare("Haslo", ErrorMessage = "Confirm password dose not match.")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [DisplayName("Potwierdź hasło")]
        public string ConfirmPassword { get; set; }
    }
}