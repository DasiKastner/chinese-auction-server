using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.models
{
    public class Lottery
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }// FK קישור לטבלת משתמשים
        public int GiftId { get; set; }// FK קישור לטבלת מתנות
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        [ForeignKey("GiftId")]
        public virtual Gift? Gift { get; set; }
    }
}
