using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class ProductDTO
    {
        [Required]
        public  string ProductName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "At least needs to be more than One")]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage ="price must be grater than Zerp")]
        public double Price { get; set; }
        [Required]
        public  string Description { get; set; } = string.Empty ;
        [Required]
        public  string Type { get; set; } = string .Empty ;
        [Required]
        public string PictureUrl { get; set; } = string.Empty;
        [Required]
        public string Brand { get; set; } = string.Empty;
    }
}
