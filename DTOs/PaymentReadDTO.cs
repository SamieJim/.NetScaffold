using System.ComponentModel.DataAnnotations;

namespace Payment.DTOs
{
    public class TransactionReadDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}