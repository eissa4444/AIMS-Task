//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int it_id { get; set; }
        public string it_name { get; set; }
        public int c_id { get; set; }
        public decimal price_a_discount { get; set; }
        public decimal price_b_discound { get; set; }
        public string it_photo { get; set; }
    
        public virtual Category Category { get; set; }
    }
}