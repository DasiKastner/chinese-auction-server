using System.ComponentModel.DataAnnotations;

namespace server.DTO
{
    public class LotteryDTO
    {
        [Key]
        public int Id { get; set; }
        public string Giftname { get; set; }
        public string WinnerName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
