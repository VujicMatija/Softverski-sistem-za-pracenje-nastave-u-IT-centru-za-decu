using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.GrupaUcenikaSO
{
    public class ObrisiGrupuUcenikaSO : SOBase
    {
        private readonly GrupaUcenika grupa;

        public ObrisiGrupuUcenikaSO(GrupaUcenika grupa)
        {
            this.grupa = grupa;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.DeleteEntity(grupa);
        }
    }
}
