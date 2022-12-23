using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Participation
    {
        [ForeignKey("MYcagnotte")]
        public int CagnotteFK { get; set; }
        public int Montant { get; set; }
        [ForeignKey("MYparticipant")]
        public int ParticipantFK { get; set; }
        public virtual Participant MYparticipant { get; set; } 
        public virtual Cagnotte MYcagnotte { get; set; }

    }
}
