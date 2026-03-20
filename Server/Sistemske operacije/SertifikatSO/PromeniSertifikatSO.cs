using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.SertifikatSO
{
    public class PromeniSertifikatSO:SOBase
    {
        private readonly Sertifikat sertifikat;

        public PromeniSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat= sertifikat;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.UpdateByCondition(sertifikat);
        }
    }
}
