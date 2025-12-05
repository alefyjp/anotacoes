using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GNOC.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; } // hash da senha

        // Relacionamento com Sector
        [ForeignKey("Sector")]
        public int? SectorId { get; set; } // pode ser null
        public Sector? Sector { get; set; } // navegação para o objeto Sector
        public string SectorName { get; set; }

        [Required, MaxLength(50)]
        public string Status { get; set; } = "active"; // active ou inactive

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string? Profile { get; set; } // ex: Admin, User
    }
}
