using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    public class Sertifikat: IEntity
    {
        public int IdSertifikata { get; set; }
        public string NazivSertifikata{ get; set; }

        public string TableName => "Sertifikat";

        public string Values => $" '{NazivSertifikata}' ";

        public string Join { get; set; } = "s join licenca l on(l.idSertifikat = s.idSertifikat) ";

        public string Set => $" set nazivSertifikata = '{NazivSertifikata}'";
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }
        public string SelectValues { get; set; } = " * ";
        public string DefaultValues => "";

        public override string ToString()
        {
            return $"{NazivSertifikata}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Sertifikat s && s.NazivSertifikata == NazivSertifikata && s.IdSertifikata == IdSertifikata; 
        }

        public override int GetHashCode()
        {
            return IdSertifikata.GetHashCode();
        }

        

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                Sertifikat s = new Sertifikat
                {
                    IdSertifikata = (int)reader["idSertifikat"],
                    NazivSertifikata = (string)reader["nazivSertifikata"]
                };
                result.Add(s);
            }

            return result;
        }

        public BindingList<Sertifikat> popuniListu(SqlDataReader reader)
        {
            BindingList<Sertifikat> result = new BindingList<Sertifikat>();
            while (reader.Read())
            {
                Sertifikat s = new Sertifikat
                {
                    IdSertifikata = (int)reader["idSertifikat"],
                    NazivSertifikata = (string)reader["nazivSertifikata"]
                };
                result.Add(s);
            }

            return result;
        }
    }
}
