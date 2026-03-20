using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    public static class SafeGet
    {
        public static T SafeGetDB<T>(this SqlDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                if (reader.IsDBNull(ordinal)) return default(T);
                return (T)reader.GetValue(ordinal);
            }
            catch (IndexOutOfRangeException)
            {
                return default(T);
            }
        }
    }
}
