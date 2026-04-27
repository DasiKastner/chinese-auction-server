using System.ComponentModel.DataAnnotations;

namespace server.DTO
{
    public class GiftDTO
    {
        public int Id { get; set; } //PK
        [MaxLength(250), Required]
        public string GiftName { get; set; }
        [Required]
        public int Price { get; set; }
        public int QuantityOfPurchases { get; set; }
        public string WinnerName { get; set; }
        public string Description { get; set; }
        [Required]
        public required string Image { get; set; }
        public string DonorName { get; set; }
        public string CategoryName { get; set; }
    }
}
