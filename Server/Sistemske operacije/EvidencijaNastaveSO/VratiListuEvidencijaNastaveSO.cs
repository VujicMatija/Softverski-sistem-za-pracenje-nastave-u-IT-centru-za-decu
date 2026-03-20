using Domeni;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EvidencijaNastaveSO
{
    public class VratiListuEvidencijaNastaveSO:SOBase
    {
        private readonly EvidencijaNastave evidencija;
        public List<EvidencijaNastave> Result { get; set; }

        public VratiListuEvidencijaNastaveSO(EvidencijaNastave ev)
        {
            this.evidencija = ev;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> list = broker.GetByCondition(evidencija);
            
            Result = list.Cast<EvidencijaNastave>().ToList();
            foreach(var item in Result)
            {
                
                item.stavkeEvidencijeNastave = broker.GetByCondition(new StavkaEvidencijeNastave() { SelectCondition = $" sen.idEvidencijeNastave = {item.IdEvidencijeNastave}" }).Cast<StavkaEvidencijeNastave>().ToList();
            }
        }
    }
}
