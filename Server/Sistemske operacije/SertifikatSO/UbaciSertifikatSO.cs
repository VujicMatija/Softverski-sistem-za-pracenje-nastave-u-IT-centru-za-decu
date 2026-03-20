using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.SertifikatSO
{
    public class UbaciSertifikatSO : SOBase
    {
        private readonly Sertifikat sertifikat;

        public UbaciSertifikatSO(Sertifikat sertifikat)
        {
            this.sertifikat = sertifikat;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(sertifikat);
        }
    }
}
