using System.ComponentModel.DataAnnotations;

namespace server.DTO
{
    public class LoginDTO
    {
        [Required, MaxLength(9)]
        public string UserName { get; set; }
        [Required, MinLength(7)]
        public string Password { get; set; }
    }
}
