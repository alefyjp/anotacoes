using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GNOC.Models
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Lista de usuários relacionados a este setor
        public ICollection<User>? Users { get; set; }
    }
}
