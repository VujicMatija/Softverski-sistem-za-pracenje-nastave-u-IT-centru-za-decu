using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace Domeni
{
    public class Ucitelj: IEntity
    {
        public int Id { get; set; }

        public string ImeUcitelja { get; set; }

        public string PrezimeUcitelja { get; set; }

        public string Email { get; set; }

        public string Telefon { get; set; }

        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }
        public DateTime DatumPocetkaRada { get; set; }
        

        public override string ToString()
        {
            return $"{ImeUcitelja} {PrezimeUcitelja}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Ucitelj u && u.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> res = new List<IEntity>();

            while (reader.Read())
            {
                Ucitelj ucitelj = new Ucitelj
                {
                    Id = (int)reader["idUcitelj"],
                    ImeUcitelja = (string)reader["imeUcitelja"],
                    PrezimeUcitelja = (string)reader["prezimeUcitelja"],
                    Email = (string)reader["email"],
                    Telefon = (string)reader["telefon"],
                    DatumPocetkaRada = (DateTime)reader["datumPocetkaRada"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Lozinka = (string)reader["lozinka"]

                };
                Debug.WriteLine(ucitelj.ToString());
                res.Add(ucitelj);

            }

            return res;
        }

        public string SelectValues { get; set; } = " * ";
        public string TableName => "Ucitelj";

        public string Values => $" '{ImeUcitelja}', '{PrezimeUcitelja}', '{Email}', '{Telefon}', '{KorisnickoIme}', '{Lozinka}', '{DatumPocetkaRada}' ";

        public string Join { get; set; }

        public string Set => $"SET imeUcitelja = '{ImeUcitelja}', prezimeUcitelja = '{PrezimeUcitelja}', email = '{Email}', telefon = '{Telefon}', korisnickoIme = '{KorisnickoIme}', lozinka = '{Lozinka}', datumPocetkaRada = '{DatumPocetkaRada}'";
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        public string DefaultValues => "";

    }
}
