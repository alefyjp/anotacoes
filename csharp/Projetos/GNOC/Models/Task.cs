using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GNOC.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Sector")]
        public int SectorId { get; set; }
        public Sector? Sector { get; set; }
        public string SectorName { get; set; }

        [Required, MaxLength(300)]
        public string Status { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime DeliveryDate { get; set; }

        [Required, MaxLength(100)]
        public string PrioritLevel { get; set; }

        [Required]
        [ForeignKey("User")] // Relacionamento com users
        public int RequesterId { get; set; }
        public User? Requester { get; set; }
        public string RequesterName { get; set; }

        [Required]
        [ForeignKey("User")] // Relacionamento com users
        public int AgentId { get; set; }
        public User? Agent { get; set; }
        public string AgentName { get; set; }

        [Required, MaxLength(300)]
        public string Comment { get; set; }
    }
}
