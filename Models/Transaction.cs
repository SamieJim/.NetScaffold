using System.ComponentModel.DataAnnotations;

namespace Payment.Models
{
    public class Transaction
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}