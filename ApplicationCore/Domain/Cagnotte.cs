using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain 

{
   public enum   Type
    {
        CadeauCommun,DepenseàPlusieurs,ProjetSolidaire,Autres
    }
    public class Cagnotte
    {
        public int CagnotteId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Photo { get; set; }
        [Range(0, int.MaxValue)]
        public int SommeDemandée { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Obligatoire")]
        public string Titre { get; set; }
       [NotMapped]
      public int entreprise { get; set; }
        public Type type { get; set; }
        public virtual IEnumerable<Participation> participations { get; set; }
        public virtual Entreprise Entreprise { get; set; }

    }
}
