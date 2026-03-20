using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.KursSO
{
    public class VratiListuKursevaSO:SOBase
    {
        private readonly Kurs kurs;
        public List<Kurs> Result { get; set; }

        public VratiListuKursevaSO(Kurs kurs)
        {
            this.kurs = kurs;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> list = broker.GetByCondition(kurs);
            Result = list.Cast<Kurs>().ToList();
        }
    }
}
