using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.UcenikSO
{
    public class PretraziUcenikaSO:SOBase
    {
        private readonly Ucenik ucenik;

        public Ucenik Result { get; set; }

        public PretraziUcenikaSO(Ucenik ucenik)
        {
            this.ucenik = ucenik;
        }

        protected override void ExecuteConcreteOperation()
        {

            string condition = $" u.idUcenik = {ucenik.IdUcenika} ";
            ucenik.SelectCondition = condition;
            List<IEntity> lista = broker.GetByCondition(ucenik);
            Result = lista.Cast<Ucenik>().FirstOrDefault();

            if (Result == null)
            {
                throw new Exception("Ne postoji ovaj korisnik");
            }
        }
    }
}
