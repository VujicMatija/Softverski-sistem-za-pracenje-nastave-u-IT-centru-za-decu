using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.SertifikatSO
{
    public class VratiListuSviSertifikatiSO : SOBase
    {
        public List<Sertifikat> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Sertifikat() { Join = "" });
            Result = lista.Cast<Sertifikat>().ToList();
        }
    }
}
