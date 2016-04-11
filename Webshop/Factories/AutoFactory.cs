using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

namespace Webshop.Factories
{
    public abstract class AutoFactory<T>
    {
        // Local reference to the ConnectionString set in the WebConfig Root file.
        private string connectionString = "";

        // Creating a List of Properties, containing information about the current Type's properties
        private List<PropertyInfo> properties = new List<PropertyInfo>();

        public AutoFactory()
        {
            // Get the ConnectionString from the WebConfig
            connectionString = ConfigurationManager.ConnectionStrings["WebshopString"].ConnectionString;
            // Get a list of properties from the current Type
            properties.AddRange(GetGenericType().GetType().GetProperties());
        }

        /// <summary>
        /// Used to create a temp instance of the current Type
        /// </summary>
        /// <returns>The temp instance of current Type</returns>
        private T GetGenericType()
        {
            T t;
            return t = Activator.CreateInstance<T>();
        }

        public void Add(T entity)
        {
            string sqlQuery = string.Format("INSERT INTO {0} (", typeof(T).Name);

            for (int i = 0; i < properties.Count; i++)
            {
                PropertyInfo property = properties[i];
                if (property.Name.ToLower().Contains("id") && i == 0) continue;

                sqlQuery += property.Name;
                sqlQuery += (i + 1 == properties.Count ? "" : ", ");
            }

            sqlQuery += ") ";
            sqlQuery += "VALUES (";

            for (int i = 0; i < properties.Count; i++)
            {
                PropertyInfo property = properties[i];
                if (property.Name.ToLower().Contains("id") && i == 0) continue;

                sqlQuery += "@" + property.Name + (i + 1 == properties.Count ? "" : ", ");
            }

            sqlQuery += ")";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            for (int i = 0; i < properties.Count; i++)
            {
                if (properties[i].Name.ToLower().Contains("id") && i == 0) continue;
                cmd.Parameters.AddWithValue("@" + properties[i].Name, properties[i].GetValue(entity));
            }

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            connection.Dispose();
            connection.Close();
        }
    }
}