using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.GrupaUcenikaSO
{
    public class VratiListuSveGrupeUcenikaSO:SOBase
    {
        public List<GrupaUcenika> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new GrupaUcenika() { Join = " gu  join Kurs k on (gu.idKurs = k.idKurs) " });
            Result = lista.Cast<GrupaUcenika>().ToList();
        }
    }
}
