using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class WarehouseValidation
    {

        [Required(ErrorMessage = "The name field is required.")]
        public string w_name { get; set; }
    }

    [MetadataType(typeof(WarehouseValidation))]
    public partial class Warehouse
    {
    }
}
