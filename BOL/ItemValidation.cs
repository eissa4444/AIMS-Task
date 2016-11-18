using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class ItemValidation
    {

        [Required]
        public string it_name { get; set; }

        [Required]
        public int c_id { get; set; }

        [Required]
        public decimal price_a_discount { get; set; }

        [Required]
        public decimal price_b_discound { get; set; }

        [Required]
        public string it_photo { get; set; }
    }

    [MetadataType(typeof(ItemValidation))]
    public partial class Item
    {
    }
}
