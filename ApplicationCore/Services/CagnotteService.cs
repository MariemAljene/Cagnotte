using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CagnotteService : Service<Cagnotte>, ICagnotteService
    {
        public CagnotteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Cagnotte> CagnotteEncoreValide()
        {

            return GetAll().Where(t => t.DateLimite<DateTime.Now);
        }

        public int MontantCollecte(Cagnotte cagnotte)
        {
            int total = 0; 
            foreach(Participation participation in cagnotte.participations)
            {
                total += participation.Montant;
            }
            return total;
        } 

    }
}
