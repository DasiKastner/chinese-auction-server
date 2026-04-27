using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;


namespace server.models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }//PK
        [Required, MaxLength(250)]
        public string FullName { get; set; }
        [MaxLength(10), Required]
        public string Phone { get; set; }
        [MaxLength(3)]
        public string? Age { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [MaxLength(250), Required]
        public string Adress { get; set; }
        //FK רשימת מתנות

    }
}
