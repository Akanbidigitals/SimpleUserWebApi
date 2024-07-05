using System.ComponentModel.DataAnnotations;

namespace SimpleUserApp.Models
{
    public class SimpleUser
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Stack { get; set; } 
    }
}
