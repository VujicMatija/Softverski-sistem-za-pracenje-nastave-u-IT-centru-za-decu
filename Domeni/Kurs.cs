using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    public class Kurs: IEntity
    {
        public int IdKursa { get; set; }
        public string NazivKursa { get; set; }
        public TezinaKursa TezinaKursa { get; set; }
        public Uzrast UzrastKursa { get; set; }
        public int TrajanjeKursa{ get; set; }
        public string OznakaKursa { get; set; }

        public string TableName => "Kurs";

        public string Values => $"'{NazivKursa}', '{TezinaKursa}', '{UzrastKursa}', {TrajanjeKursa}, '{OznakaKursa}'";

        public string Join => "";

        public string Set => $" set nazivKursa = '{NazivKursa}', tezinaKursa = '{TezinaKursa}', uzrastKursa = '{UzrastKursa}', trajanjeKursa = {TrajanjeKursa} ";
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }
        public string SelectValues { get; set; } = " * ";
        public string DefaultValues => "";

        public override bool Equals(object? obj)
        {
            return obj is Kurs k && k.NazivKursa == NazivKursa;
        }
        public override string ToString()
        {
            return NazivKursa;
        }

       

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();

            while (reader.Read())
            {
                Kurs k = new Kurs
                {
                    IdKursa = (int)reader["idKurs"],
                    NazivKursa = (string)reader["nazivKursa"],
                    TezinaKursa = Enum.Parse<TezinaKursa>((string)reader["tezinaKursa"]),
                    UzrastKursa = Enum.Parse<Uzrast>((string)reader["uzrastKursa"]),
                    TrajanjeKursa = (int)reader["trajanjeKursa"],
                    OznakaKursa = (string)reader["oznakaKursa"]
                };
                result.Add(k);
            }


            return result;
        }



        public BindingList<Kurs> popuniListu(SqlDataReader reader)
        {
            BindingList<Kurs> result = new BindingList<Kurs>();

            while (reader.Read())
            {
                Kurs k = new Kurs
                {
                    IdKursa = (int)reader["idKurs"],
                    NazivKursa = (string)reader["nazivKursa"],
                    TezinaKursa = Enum.Parse<TezinaKursa>((string)reader["tezinaKursa"]),
                    UzrastKursa = Enum.Parse<Uzrast>((string)reader["uzrastKursa"]),
                    TrajanjeKursa = (int)reader["trajanjeKursa"],
                    OznakaKursa = (string)reader["oznakaKursa"]
                };
                result.Add(k);
            }


            return result;
        }
    }
}
