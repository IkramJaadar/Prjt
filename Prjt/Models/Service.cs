using System.ComponentModel.DataAnnotations;

namespace Prjt.Models
{
    public class Service
    {
        [Key]
        public int NumS { get; set; }
        public string NomS { get; set; }
        public float Prix { get; set; }
        public Coiffeur? coiffeur { get; set; }
        public int? CoiffeurId { get; set; }
        public List<RendezVous>? RendezVous { get; set; }
        public Boolean isActive { get; set; }
    }
}
