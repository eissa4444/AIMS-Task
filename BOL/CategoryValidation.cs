using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class CategoryValidation
    {
        [Required]
        public string c_name { get; set; }

        [Required]
        public int b_id { get; set; }

        [Required]
        public string c_photo { get; set; }
    }

    [MetadataType(typeof(CategoryValidation))]
    public partial class Category
    {
    }
}
