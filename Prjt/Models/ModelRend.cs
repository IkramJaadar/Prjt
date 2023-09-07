namespace Prjt.Models
{
    public class ModelRend
    {
        public string ?Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set;}
        public string? Telephone { get; set; }
        public DateTime DateRv { get; set; }
        public DateTime DateNaissance { get; set; }
        public TimeSpan Horraire { get; set; }
      
        public int ServiceId { get; set; }
        public string? Pwd { get; set; }
        
    }
}
