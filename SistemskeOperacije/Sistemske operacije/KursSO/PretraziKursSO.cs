using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.KursSO
{
    public class PretraziKursSO:SOBase
    {
        private readonly Kurs k;

        public Kurs Result { get; set; }

        public PretraziKursSO(Kurs k)
        {
            this.k = k;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = $"idKurs = {k.IdKursa}";
            k.SelectCondition = condition;
            List<IEntity> lista = broker.GetByCondition(k);
            Result = lista.Cast<Kurs>().FirstOrDefault();

            
        }
    }
}
