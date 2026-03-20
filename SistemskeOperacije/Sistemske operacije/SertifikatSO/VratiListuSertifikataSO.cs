using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.SertifikatSO
{
    public class VratiListuSertifikataSO:SOBase
    {

        private readonly Sertifikat s;
        public List<Sertifikat> Result { get; set; }

        public VratiListuSertifikataSO(Sertifikat s)
        {
            this.s = s;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> list = broker.GetByCondition(s);
            Result = list.Cast<Sertifikat>().ToList();
        }
    }
}
