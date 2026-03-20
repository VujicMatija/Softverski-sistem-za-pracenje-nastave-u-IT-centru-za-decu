using Domeni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.UciteljSO
{
    public class PrijaviUciteljaSO : SOBase
    {
        private readonly Ucitelj u;

        public Ucitelj Result { get; set; }

        public PrijaviUciteljaSO(Ucitelj u)
        {
            this.u = u;
        }
        protected override void ExecuteConcreteOperation()
        {
            string condition = $"korisnickoIme = '{u.KorisnickoIme}' and lozinka = '{u.Lozinka}'";
            u.SelectCondition = condition;
            List<IEntity> lista = broker.GetByCondition(u);
            Result = lista.Cast<Ucitelj>().FirstOrDefault();

            if(Result == null)
            {
                throw new Exception("Ne postoji korisnik sa ovim kredencijalima.");
            }

        }
    }
}
