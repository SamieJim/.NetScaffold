using System.ComponentModel.DataAnnotations;

namespace Payment.DTOs
{
    public class TransactionCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}