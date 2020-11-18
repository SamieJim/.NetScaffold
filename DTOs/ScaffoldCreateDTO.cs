using System.ComponentModel.DataAnnotations;

namespace Scaffolder.DTOs
{
    public class ScaffoldCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}