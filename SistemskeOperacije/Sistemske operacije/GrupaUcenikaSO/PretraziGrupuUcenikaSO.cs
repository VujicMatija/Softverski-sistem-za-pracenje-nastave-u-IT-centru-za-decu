using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.GrupaUcenikaSO
{
    public class PretraziGrupuUcenikaSO: SOBase
    {
        private readonly GrupaUcenika grupa;

        public GrupaUcenika Result { get; set; }

        public PretraziGrupuUcenikaSO(GrupaUcenika grupa)
        {
            this.grupa = grupa;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = $" gu.idGrupa = {grupa.IdGrupe}";
            grupa.SelectCondition = condition;
            List<IEntity> lista = broker.GetByCondition(grupa);
            Result = lista.Cast<GrupaUcenika>().FirstOrDefault();

            
        }
    }
}
