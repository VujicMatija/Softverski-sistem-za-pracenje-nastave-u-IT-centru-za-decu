using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.UciteljSO
{
    public class PretraziUciteljaSO : SOBase
    {
        private readonly Ucitelj u;

        public Ucitelj Result { get; set; }

        public PretraziUciteljaSO(Ucitelj u)
        {
            this.u = u;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = $"idUcitelj = {u.Id}";
            u.SelectCondition = condition;
            List<IEntity> lista = broker.GetByCondition(u);
            Result = lista.Cast<Ucitelj>().FirstOrDefault();

            if (Result == null)
            {
                throw new Exception("Ne postoji ovaj korisnik");
            }
        }
    }
}
