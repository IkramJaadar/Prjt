
using System.ComponentModel.DataAnnotations;

namespace Prjt.Models
{
    public class Coiffeur
    {
        [Key]
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Telephone { get; set; }
        public string? Specialite { get; set; }
        public Boolean RememberMe { get; set; }
        public List<Sliders>? Sliders { get; set; }
        public List<Service>? Services { get; set; }

    }
}
