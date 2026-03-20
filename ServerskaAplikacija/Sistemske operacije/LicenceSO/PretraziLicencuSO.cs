using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.LicenceSO
{
    public class PretraziLicencuSO: SOBase
    {
        private readonly Licenca l;

        public Licenca Result { get; set; }

        public PretraziLicencuSO(Licenca l)
        {
            this.l = l;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = $"l.idSertifikat = {l.sertifikat.IdSertifikata} and l.idUcitelj = {l.ucitelj.Id}";
            l.SelectCondition = condition;
            List<IEntity> lista = broker.GetByCondition(l);
            Result = lista.Cast<Licenca>().FirstOrDefault();

            if (Result == null)
            {
                throw new Exception("Sistem ne može da nađe licencu");
            }
        }
    }
}
