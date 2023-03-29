using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutraAPI.Models
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Nome { get; set; }

        public List<Dependente>? Dependentes { get; set; } = new List<Dependente>();
    }
}