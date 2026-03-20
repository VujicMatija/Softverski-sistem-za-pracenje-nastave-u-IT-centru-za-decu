using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.GrupaUcenikaSO
{
    public class PromeniGrupuUcenikaSO : SOBase
    {
        private readonly GrupaUcenika grupa;

        public PromeniGrupuUcenikaSO(GrupaUcenika grupaUcenika)
        {
            this.grupa = grupaUcenika;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.UpdateByCondition(grupa);
        }
    }
}
