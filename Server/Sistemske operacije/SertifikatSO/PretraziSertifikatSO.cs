using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.SertifikatSO
{
    public class PretraziSertifikatSO:SOBase
    {
        private readonly Sertifikat sertifikat;

        public Sertifikat Result { get; set; }

        public PretraziSertifikatSO(Sertifikat s)
        {
            this.sertifikat = s;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = $"s.idSertifikat = {sertifikat.IdSertifikata}";
            sertifikat.SelectCondition = condition;
            List<IEntity> lista = broker.GetByCondition(sertifikat);
            Result = lista.Cast<Sertifikat>().FirstOrDefault();

        }

    }
}
