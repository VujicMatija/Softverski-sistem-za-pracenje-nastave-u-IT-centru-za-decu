using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Domeni
{
    public class EvidencijaNastave: IEntity
    {
        public int IdEvidencijeNastave { get; set; }
        public bool StatusAktivnosti { get; set; }
        public DateTime DatumPocetkaRada { get; set; }
        public Ucitelj Ucitelj { get; set; }
        public GrupaUcenika Grupa { get; set; }

        public List<StavkaEvidencijeNastave> stavkeEvidencijeNastave { get; set; }

        public string TableName => "EvidencijaNastave";

        public string Values => $"{StatusAktivnosti}, '{DatumPocetkaRada}', {Ucitelj?.Id : 0}, {Grupa?.IdGrupe : 0}";

        public string Join { get; set; } = "ev join GrupaUcenika gu on(ev.idGrupa = gu.idGrupa) join Ucitelj u on(u.idUcitelj = ev.idUcitelja) ";

        public string Set => $"SET statusAktivnosti = '{StatusAktivnosti}', datumPocetkaRada= '{DatumPocetkaRada}',  idUcitelja= {Ucitelj?.Id :0},  idGrupa= {Grupa?.IdGrupe :0}";

        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        public string DefaultValues => $"0, '1999-01-01 00:00:00.000', NULL, NULL";

        public string SelectValues { get; set; } = " * ";

        public override string ToString()
        {
            if (Ucitelj != null && Grupa != null)
                return $"{Grupa.ToString()} - {Ucitelj.ToString()}";
            else return "";
        }

        public override bool Equals(object? obj)
        {
            try
            {
                return obj is EvidencijaNastave evd
               && IdEvidencijeNastave == evd.IdEvidencijeNastave
               && Ucitelj.Id == evd.Ucitelj.Id
               && Grupa.IdGrupe == evd.Grupa.IdGrupe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public override int GetHashCode()
        {
            return IdEvidencijeNastave.GetHashCode();
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> res = new List<IEntity>();

            while (reader.Read())
            {
                EvidencijaNastave ev = new EvidencijaNastave
                {
                    IdEvidencijeNastave = reader.SafeGetDB<int>("idEvidencijaNastave"),
                    
                    StatusAktivnosti = reader.SafeGetDB<bool>("statusAktivnosti"),

                    DatumPocetkaRada = reader.SafeGetDB<DateTime>("datumPocetkaRada"),
                    Ucitelj = new Ucitelj
                    {
                        Id = reader.SafeGetDB<int>("idUcitelja"),
                        ImeUcitelja = reader.SafeGetDB<string>("imeUcitelja"),
                        PrezimeUcitelja = reader.SafeGetDB<string>("prezimeUcitelja"),
                        Email = reader.SafeGetDB<string>("email"),
                        Telefon = reader.SafeGetDB<string>("telefon"),
                        KorisnickoIme = reader.SafeGetDB<string>("korisnickoIme"),
                        Lozinka = reader.SafeGetDB<string>("lozinka"),
                        //DatumPocetkaRada = (DateTime)reader[17]
                    },
                    Grupa = new GrupaUcenika
                    {
                        IdGrupe =reader.SafeGetDB<int>("idGrupa"),
                        OznakaGrupe = reader.SafeGetDB<string>("oznakaGrupe"),
                        BrojUcenika = reader.SafeGetDB<int>("brojUcenika"),
                        Termin = reader.SafeGetDB<string>("termin"),
                        Kurs = new Kurs
                        {
                            IdKursa = reader.SafeGetDB<int>("idKurs"),
                        }
                    }
                };

                res.Add(ev);
            }

            return res;
        }

        //public List<IEntity> GetReaderList(SqlDataReader reader)
        //{
        //    List<IEntity> res = new List<IEntity>();

        //    while (reader.Read())
        //    {
        //        EvidencijaNastave ev = new EvidencijaNastave
        //        {
           
        //            IdEvidencijeNastave = (int)reader["idEvidencijaNastave"],
        //            StatusAktivnosti = (bool)reader["statusAktivnosti"],
                   
        //            DatumPocetkaRada = (DateTime)reader["datumPocetkaRada"],
        //            Ucitelj = new Ucitelj
        //            {
        //                Id = (int)reader["idUcitelja"],
        //                ImeUcitelja = (string)reader["imeUcitelja"],
        //                PrezimeUcitelja = (string)reader["prezimeUcitelja"],
        //                Email = (string)reader["email"],
        //                Telefon = (string)reader["telefon"],
        //                KorisnickoIme = (string)reader["korisnickoIme"],
        //                Lozinka = (string)reader["lozinka"],
        //                //DatumPocetkaRada = (DateTime)reader[17]
        //            },
        //            Grupa = new GrupaUcenika
        //            {
        //                IdGrupe = (int)reader["idGrupa"],
        //                OznakaGrupe = (string)reader["oznakaGrupe"],
        //                BrojUcenika = (int)reader["brojUcenika"],
        //                Termin = (string)reader["termin"],
        //                Kurs = new Kurs
        //                {
        //                    IdKursa = (int)reader["idKurs"],
        //                }
        //            }
        //        };

        //        res.Add(ev);
        //    }

        //    return res;
        //}


        
    }
}
