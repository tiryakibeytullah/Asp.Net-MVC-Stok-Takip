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
    
    public partial class TBLSatislar
    {
        public int SatisId { get; set; }
        public Nullable<int> Urun { get; set; }
        public Nullable<int> Musteri { get; set; }
        public Nullable<byte> Adet { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
    
        public virtual TBLMusteriler TBLMusteriler { get; set; }
        public virtual TBLUrunler TBLUrunler { get; set; }
    }
}