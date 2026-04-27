using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }//PK
        [DefaultValue("draft")]
        public string Status { get; set; }//טיוטה או רכישה
        [Required]
        public int UserId { get; set; }// FK קישור לטבלת משתמשים
        [Required]
        public int GiftId { get; set; }// FK קישור לטבלת מתנות
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        [ForeignKey("GiftId")]
        public virtual Gift? Gift { get; set; }

    }
}
