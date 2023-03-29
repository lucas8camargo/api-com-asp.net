using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutraAPI.Models
{
    [Table("Dependentes")] // using System.ComponentModel.DataAnnotations.Schema;
    public class Dependente
    {
        [Key] // using System.ComponentModel.DataAnnotations;
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Nome { get; set; }

        [Required]
        [ForeignKey(nameof(Id))]
        public int PersonaId { get; set; }
    }
}