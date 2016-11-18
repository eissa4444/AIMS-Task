using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class BranchValidation
    {
        [Required(ErrorMessage = "The name field is required.")]
        public string b_name { get; set; }

        [Required]
        public int w_id { get; set; }
    }

    [MetadataType(typeof(BranchValidation))]
    public partial class Branch
    {
    }
}
