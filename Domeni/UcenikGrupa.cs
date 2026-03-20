using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    public class UcenikGrupa : IEntity
    {
        public Ucenik ucenik { get; set; }

        public GrupaUcenika grupaUcenika { get; set; }

        public string TableName => "UcenikGrupa";

        public string Values => $" {ucenik.IdUcenika}, {grupaUcenika.IdGrupe} ";

        public string Join => "";

        public string Set => "";

        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }
        public string SelectValues { get; set; } = " * ";
        public string DefaultValues => "";

        public override string ToString()
        {
            return $"{ucenik.ToString} - {grupaUcenika.ToString()}";
        }

        public override bool Equals(object? obj)
        {
            return obj is UcenikGrupa ug 
                && ug.ucenik.IdUcenika == ucenik.IdUcenika 
                && ug.grupaUcenika.IdGrupe == grupaUcenika.IdGrupe; 

        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> res = new List<IEntity>();
            return res;
            
        }
    }
}
