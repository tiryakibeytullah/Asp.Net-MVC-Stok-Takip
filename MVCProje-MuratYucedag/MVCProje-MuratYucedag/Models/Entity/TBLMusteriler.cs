//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCProje_MuratYucedag.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public partial class TBLMusteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMusteriler()
        {
            this.TBLSatislar = new HashSet<TBLSatislar>();
        }
    
        public int MusteriId { get; set; }

        [DisplayName("M��teri Ad�"),Required(ErrorMessage = "Bu alan� bo� ge�ilemez.."), StringLength(50,ErrorMessage ="En fazla 50 karakterlik isim giriniz...")]
        public string MusteriAd { get; set; }

        [DisplayName("M��teri Soyad�"),Required(ErrorMessage = "Bu alan� bo� ge�ilemez.."), StringLength(50, ErrorMessage = "En fazla 50 karakterlik soy isim giriniz...")]
        public string MusteriSoyad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSatislar> TBLSatislar { get; set; }
    }
}
