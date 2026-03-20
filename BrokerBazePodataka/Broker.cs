using Domeni;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerBazePodataka
{
    public class Broker
    {
        private DbConnection connection;

        public Broker()
        {
            connection = new DbConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }


        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public int Create(IEntity obj)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into {obj.TableName} values ({obj.DefaultValues}) SELECT SCOPE_IDENTITY()";
            Debug.WriteLine(command.CommandText);
            object id = command.ExecuteScalar();
            command.Dispose();
            Debug.WriteLine(">>>>>>" + Convert.ToInt32(id));
            return Convert.ToInt32(id);
        }
        public void Add(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into {entity.TableName} values({entity.Values} )";
            Debug.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select {entity.SelectValues} from {entity.TableName} {entity.Join}";
            Debug.WriteLine(command.CommandText);
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public List<IEntity> GetByCondition(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT  {entity.SelectValues} FROM {entity.TableName} {entity.Join} WHERE {entity.SelectCondition}";
            Debug.WriteLine(command.CommandText);
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public void DeleteEntity(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.SelectCondition}";
            Debug.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void UpdateByCondition(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE {entity.TableName} {entity.Set} WHERE {entity.SelectCondition}";
            Debug.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
            command.Dispose();
        }

    }
}
