using System.ComponentModel.DataAnnotations;

namespace SimpleUserApp.Models.DTO
{
    public class CreateSimpleUserDTO
    {
        public string Name { get; set; } = "";
       
        public string Email { get; set; } = "";
        public string Stack { get; set; }
    }
}
