using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EvidencijaNastaveSO
{
    public class VratiListuSveEvidencijeNastaveSO:SOBase
    {
        public List<EvidencijaNastave> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new EvidencijaNastave());
            Result = lista.Cast<EvidencijaNastave>().ToList();
            foreach (var item in Result)
            {

                item.stavkeEvidencijeNastave = broker.GetByCondition(new StavkaEvidencijeNastave() { SelectCondition = $" sen.idEvidencijeNastave = {item.IdEvidencijeNastave}" }).Cast<StavkaEvidencijeNastave>().ToList();
            }
        }
    }
}
