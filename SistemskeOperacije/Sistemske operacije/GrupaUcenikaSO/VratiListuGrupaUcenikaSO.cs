using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.GrupaUcenikaSO
{
    public class VratiListuGrupaUcenikaSO : SOBase
    {
        private readonly GrupaUcenika grupa;
        public List<GrupaUcenika> Result;

        public VratiListuGrupaUcenikaSO(GrupaUcenika grupaUcenika)
        {
            grupa = grupaUcenika;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(grupa);
            Result = lista.Cast<GrupaUcenika>().ToList();
        }
    }
}
