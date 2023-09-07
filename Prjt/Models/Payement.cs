using System.ComponentModel.DataAnnotations;

namespace Prjt.Models
{
    public class Payement
    {
        [Key]
        public int Num { get; set; }
        public double? Prix { get; set; }
        public string? NumCompte { get; set; }
        public string? NomClient { get; set; }
        public DateTime DatePayement { get; set; }
        public Client? Client { get; set; }
        public int? ClientId { get; set; }
        public RendezVous? rendezVous { get; set; }
        public int? RendezVousId { get; set; }
    }
}
