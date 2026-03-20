using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.KursSO
{
    public class VratiListuSviKurseviSO : SOBase
    {
        private readonly Kurs kurs = new Kurs();
        public List<Kurs> Result { get; set; }

        public VratiListuSviKurseviSO()
        {

        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(kurs);
            Result = lista.Cast<Kurs>().ToList();
        }
    }
}
