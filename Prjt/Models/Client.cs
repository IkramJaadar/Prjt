namespace Prjt.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? DateNaissance { get; set; }
        public List<Payement>? payments { get; set; }
    }
}
