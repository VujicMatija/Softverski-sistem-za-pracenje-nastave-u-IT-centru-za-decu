using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.UcenikSO
{
    public class VratiListuSviUceniciSO : SOBase
    {
        public List<Ucenik> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Ucenik() { Join = ""});
            Result = lista.Cast<Ucenik>().ToList();
        }
    }
}
