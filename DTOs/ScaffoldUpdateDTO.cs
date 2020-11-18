using System.ComponentModel.DataAnnotations;

namespace Scaffolder.DTOs
{
    public class ScaffoldUpdateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}