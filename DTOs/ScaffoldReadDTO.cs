
using System.ComponentModel.DataAnnotations;

namespace Scaffolder.DTOs
{
    public class ScaffoldReadDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}