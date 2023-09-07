using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Prjt.Models
{
    public class PaymentModel
    {
        [Display(Name = "Référence")]
        public string RefDossier { get; set; }
        public int? ClientId { get; set; }
        [Display(Name = "CIN")]
        public string? CINClient { get; set; }
        [Display(Name = "Nom Complet")]
        public string? NomCompletClient { get; set; }
        [Display(Name = "Montant Paiement")]
        public Double MntPy { get; set; }
        [Display(Name = "Date Échéance")]
        public DateTime DateEcheance { get; set; }
        [Required]
        [Display(Name = "Card Number")]
        public string CardNumder { get; set; }
        public string DateExp { get; set; }
        [Display(Name = "Expiration Month")]
        public int? Month { get; set; }
        [Display(Name = "Expiration Year")]
        public int? Year { get; set; }
        [Required]
        public string CVC { get; set; }
        [Required]
        public int Amount { get; set; }
        public string ServiceName { get; internal set; }
    }

}
