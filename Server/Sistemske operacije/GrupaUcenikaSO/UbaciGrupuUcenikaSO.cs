using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.GrupaUcenikaSO
{
    public class UbaciGrupuUcenikaSO : SOBase
    {
        private readonly GrupaUcenika grupa;
        
        public UbaciGrupuUcenikaSO(GrupaUcenika grupaUcenika)
        {
            this.grupa = grupaUcenika;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(grupa);
        }
    }
}
