using System.Data.SqlClient;
using static DataModel.Globals;

namespace DataModel.Model.BDD
{
    /// <summary>
    /// Classe de base pour générer des requêtes SQL
    /// </summary>
    public static class Query
    {
        /// <summary>
        /// Vérifie si un type accepte la valeur null
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || Nullable.GetUnderlyingType(t) != null;
        }

        /// <summary>
        /// Lit les champs depuis la base de données
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static T Read<T>(SqlDataReader reader) where T : new()
        {
            var t = new T();

            for (int inc = 0; inc < reader.FieldCount; inc++)
            {
                var type = t.GetType();
                var name = reader.GetName(inc);
                var prop = type.GetProperty(name);
                if (prop != null)
                {
                    var v = reader[name];
                    var value = reader.GetValue(inc);
                    if (value != DBNull.Value)
                    {
                        if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                            prop.SetValue(t, Convert.ChangeType(value, Nullable.GetUnderlyingType(prop.PropertyType)), null);
                        else
                            prop.SetValue(t, Convert.ChangeType(value, prop.PropertyType), null);
                    }
                    else if(IsNullable(prop.PropertyType))
                    {
                        prop.SetValue(t, null, null);
                    }
                    else
                    {
                        throw new Exception("Can't assign null value to property");
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// Parse le format de l'objet en SQL string
        /// </summary>
        public static object? Parse(object? o)
        {
            if (o is null)
                return "NULL";
            if (o is DefaultAttribute.DefaultKeyWord)
                return "DEFAULT";
            if (o is bool)
                return (((bool)o) == true ? "1" : "0");
            if (o is string)
                return "'" + ((string)o).Replace("'", "''") + "'";
            if (o is DateTime)
                return "'" + ((DateTime)o).ToString("yyyy-MM-ddThh:mm:ss") + "'";
            if (o is byte[])
                return "0x"+BitConverter.ToString(o as byte[]).Replace("-","");
            return o;
        }

        /// <summary>
        /// Lit les champs depuis la base de données
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static List<T> Select<T>(string queryStr) where T : class, new()
        {
            var list = new List<T>();

            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        var reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                list.Add(Read<T>(reader));
                            }
                        }

                        reader.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (SqlConnect.CanReleaseConnexion)
                        SqlConnect.ReleaseConnection(conn);
                }
            }

            return list;
        }

        /// <summary>
        /// Lit les champs depuis la base de données
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static int Execute(string queryStr)
        {
            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (SqlConnect.CanReleaseConnexion)
                        SqlConnect.ReleaseConnection(conn);
                }
            }

            return 0;
        }
    }
}
