using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.SertifikatSO
{
    public class ObrisiSertifikatSO:SOBase
    {
        private readonly Sertifikat sertifikat;

        public ObrisiSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat = sertifikat;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.DeleteEntity(sertifikat);
        }
    }
}
