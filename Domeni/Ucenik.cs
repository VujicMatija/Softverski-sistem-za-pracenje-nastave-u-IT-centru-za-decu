using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    public class Ucenik: IEntity
    {
        public int IdUcenika{ get; set; }
        public string ImeUcenika { get; set; }
        public string PrezimeUcenika { get; set; }
        public Pol PolUcenika { get; set; }
        public string ImeRoditelja{ get; set; }
        public string PrezimeRoditelja { get; set; }
        public string TelefonRoditelja{ get; set; }
        public DateTime DatumRodjenjaUcenika { get; set; }
        public string TelefonUcenika{ get; set; }
        public string EmailUcenika { get; set; }
        public string SelectValues { get; set; } = " * ";
        public string TableName => "Ucenik";
       
        public string Values => $" '{ImeUcenika}', '{PrezimeUcenika}', '{PolUcenika}', '{ImeRoditelja}', '{PrezimeRoditelja}', '{TelefonRoditelja}', '{DatumRodjenjaUcenika}', '{TelefonUcenika}', '{EmailUcenika}' ";

        public string Join { get; set; }=  "u join UcenikGrupa ug on (u.idUcenik = ug.idUcenik) join GrupaUcenika gu on (gu.idGrupa = ug.idGrupaUcenika)";

        public string Set => $"set imeUcenika = '{ImeUcenika}', prezimeUcenika = '{PrezimeUcenika}', " +                    $"polUcenika = '{PolUcenika}', imeRoditelja = '{ImeRoditelja}', prezimeRoditelja = '{PrezimeRoditelja}'," +              
            $" telefonRoditelja = '{TelefonRoditelja}', datumRodjenjaUcenika = '{DatumRodjenjaUcenika}'," +                    
            $" telefonUcenika = '{TelefonUcenika}', emailUcenika = '{EmailUcenika}'";
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        public string DefaultValues => "";

        public override string ToString()
        {
            return $"{ImeUcenika} {ImeRoditelja.Substring(0,1)}. {PrezimeUcenika}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Ucenik ucenik && ucenik.IdUcenika == IdUcenika && ucenik.ImeUcenika == ImeUcenika && ucenik.PrezimeUcenika == PrezimeUcenika;
        }

        public override int GetHashCode()
        {
            return IdUcenika.GetHashCode();
        }

        public BindingList<Ucenik> popuniListu(SqlDataReader reader)
        {
            BindingList<Ucenik> result = new BindingList<Ucenik>();
            while (reader.Read())
            {
                Ucenik u = new Ucenik
                {
                    IdUcenika = (int)reader["idUcenik"],
                    ImeUcenika = (string)reader["imeUcenika"],
                    PrezimeUcenika = (string)reader["prezimeUcenika"],
                    ImeRoditelja = (string)reader["imeRoditelja"],
                    PrezimeRoditelja = (string)reader["prezimeRoditelja"],
                    PolUcenika = Enum.Parse<Pol>((string)reader["polUcenika"]),
                    TelefonRoditelja = (string)reader["telefonRoditelja"],
                    DatumRodjenjaUcenika = (DateTime)reader["datumRodjenjaUcenika"],
                    TelefonUcenika = (string)reader["telefonUcenika"],
                    EmailUcenika = (string)reader["emailUcenika"]
                };

                result.Add(u);
            }
            return result;
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                Ucenik u = new Ucenik
                {
                    IdUcenika = (int)reader["idUcenik"],
                    ImeUcenika = (string)reader["imeUcenika"],
                    PrezimeUcenika = (string)reader["prezimeUcenika"],
                    ImeRoditelja = (string)reader["imeRoditelja"],
                    PrezimeRoditelja = (string)reader["prezimeRoditelja"],
                    PolUcenika = Enum.Parse<Pol>((string)reader["polUcenika"]),
                    TelefonRoditelja = (string)reader["telefonRoditelja"],
                    DatumRodjenjaUcenika = (DateTime)reader["datumRodjenjaUcenika"],
                    TelefonUcenika = (string)reader["telefonUcenika"],
                    EmailUcenika = (string)reader["emailUcenika"]
                };

                result.Add(u);
            }
            return result;
        }
    }
}
