using System.ComponentModel.DataAnnotations;

namespace server.DTO
{
    public class PurchaseDTO
    {
        [Key]
        public int Id { get; set; }//PK
        public string Image { get; set; }
        public int Price { get; set; }
        public int QuantityOfPurchases { get; set; }
        public string GiftName { get; set; }
        public int GiftId { get; set; }
    }
}
