//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ogloszenia_Studenckie.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Konto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Konto()
        {
            this.Obserwacja = new HashSet<Obserwacja>();
            this.Ogloszenie = new HashSet<Ogloszenie>();
        }
    
        public int ID_Konto { get; set; }
        public string Nazwa { get; set; }
        public string E_Mail { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string Haslo { get; set; }
        public string Rola { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Obserwacja> Obserwacja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogloszenie> Ogloszenie { get; set; }
    }
}
