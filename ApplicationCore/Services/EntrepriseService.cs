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
    public class EntrepriseService : Service<Entreprise>, IEntrepriseService
    {
        public EntrepriseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Entreprise> TopDeuxEntreprises(Domain.Type type)
        { IEnumerable<Entreprise> entreprises = GetAll();
            IEnumerable<Entreprise> Top = null;
          foreach(Entreprise e  in entreprises)
            { foreach( Cagnotte c in e.cagnottes)
                {
                    if ( c.type == type )
                    {
                       Top.Append(e);
                    } 
                }

            }
           return Top.OrderBy(T=>T.cagnottes.Count()).Take(2);
        }
    }
}
