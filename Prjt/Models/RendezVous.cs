namespace Prjt.Models
{
    public class RendezVous
    {
        public int Id { get; set; }
        public TimeSpan? Horraire { get; set; }
        public DateTime Date { get; set; }
        public string ?Etat { get; set; }
        public Service? services { get; set; }
        public int ServicesId { get; set; }
        public Payement? payement { get; set; }

    }
}
