using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace server.models
{
    public class User
    {
        [Key]
        public int Id { get; set; }//PK
        [Required,MaxLength(9)]
        public string UserName { get; set; }
        [Required,MinLength(7)]
        public string Password { get; set; }
        [Required,MaxLength(250)]
        public string FullName { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [MaxLength(250), Required]
        public string Adress { get; set; }
        [MaxLength(3)]
        public string? Age { get; set; }
        [MaxLength(10), Required]
        public string Phone { get; set; }
        [DefaultValue("user"),Required]
        public string  Role { get; set; }
   

    }
}
