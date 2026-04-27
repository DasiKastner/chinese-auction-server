using System.ComponentModel.DataAnnotations;

namespace server.models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }//PK
        [MaxLength(250),Required]
        public string CategoryName { get; set; }
    }
}
