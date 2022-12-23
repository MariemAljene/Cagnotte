using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Participant
    {
        public string MailParticipant { get; set; }
        public string Nom { get; set; }
        public int ParticipantID { get; set; }
        public string Prenom { get; set; }
        public virtual IEnumerable<Participation> participations { get; set; }
    }
}
