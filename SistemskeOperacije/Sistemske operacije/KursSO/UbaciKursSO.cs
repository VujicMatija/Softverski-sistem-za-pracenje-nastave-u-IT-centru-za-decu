using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.KursSO
{
    public class UbaciKursSO : SOBase
    {
        private readonly Kurs kurs;
        
        public UbaciKursSO(Kurs kurs)
        {
            this.kurs = kurs;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(kurs);
        }
    }
}
