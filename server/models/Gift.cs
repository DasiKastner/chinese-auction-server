using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.models
{
    public class Gift
    {
        [Key]
        public int Id { get; set; } //PK
        [MaxLength(250), Required]
        public string GiftName { get; set; }
        [Required]
        public int Price { get; set; }
        public int QuantityOfPurchases { get; set; }
        public string Description { get; set; }
        public string WinnerName { get; set; }
        [Required]
        public required string Image { get; set; }
        //קישור לטבלת קטגוריה FK
        [Required]
        public int CategoryId { get; set; }
        [Required]
        //קישור לטבלת תורם FK
        public int DonorId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        [ForeignKey("DonorId")]
        public virtual Donor? Donor { get; set; }
    }
}
