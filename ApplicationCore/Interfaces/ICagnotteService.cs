using AM.ApplicationCore.Interfaces;
using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICagnotteService:IService<Cagnotte>
    {
        public IEnumerable<Cagnotte> CagnotteEncoreValide(); 
        public int MontantCollecte(Cagnotte cagnotte);
    }
}
