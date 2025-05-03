using System.ComponentModel;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using static DataModel.Globals;

namespace DataModel.Model.BDD
{
    public abstract class View : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Obtient le nom de la view SQL
        /// </summary>
        public static string GetViewName<T>()
        {
            var att1 = (SchemaAttribute?)typeof(T).GetCustomAttribute(typeof(SchemaAttribute));
            var att2 = (NameAttribute?)typeof(T).GetCustomAttribute(typeof(NameAttribute));

            return String.Format("{0}.{1}", att1 == null ? "dbo" : att1.SQLName, att2 == null ? typeof(T).Name : att2.SQLName);
        }

        /// <summary>
        /// Obtient le(s) colonnes de la view sans distinction
        /// </summary>
        public static PropertyInfo[] GetColumns<T>()
        {
            return typeof(T).GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => typeof(ColumnAttribute).IsAssignableFrom(a.AttributeType)) != null).ToArray();
        }

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
                    var value = reader.GetValue(inc);
                    if (value != DBNull.Value)
                    {
                        if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                            prop.SetValue(t, Convert.ChangeType(value, Nullable.GetUnderlyingType(prop.PropertyType)), null);
                        else
                            prop.SetValue(t, Convert.ChangeType(value, prop.PropertyType), null);
                    }
                    else if (IsNullable(prop.PropertyType))
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

        public static object? Parse(object? o)
        {
            return Query.Parse(o);
        }

        /// <summary>
        /// Lit les champs depuis la base de données
        /// </summary>
        /// <exception cref="Exception"></exception>
        public bool Reload<T>(string? where = null) where T : View, new()
        {
            bool result = false;

            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.Append("select Top(1)");

                    query.Append(" ");
                    query.Append(String.Join(',', GetColumns<T>().Select(p => "[" + p.Name + "]")));

                    query.Append(" from ");
                    query.Append(GetViewName<T>());

                    if (String.IsNullOrEmpty(where) == false)
                    {
                        query.Append(" where ");
                        query.Append(where);
                    }

                    var queryStr = query.ToString();

                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        var reader = cmd.ExecuteReader();

                        if (reader.HasRows && reader.Read())
                        {
                            for (int inc = 0; inc < reader.FieldCount; inc++)
                            {
                                var type = this.GetType();
                                var name = reader.GetName(inc);
                                var prop = type.GetProperty(name);
                                if (prop != null)
                                {
                                    var value = reader.GetValue(inc);
                                    if (value != DBNull.Value)
                                    {
                                        if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                                            prop.SetValue(this, Convert.ChangeType(value, Nullable.GetUnderlyingType(prop.PropertyType)), null);
                                        else
                                            prop.SetValue(this, Convert.ChangeType(value, prop.PropertyType), null);
                                    }
                                    else if (IsNullable(prop.PropertyType))
                                    {
                                        prop.SetValue(this, null, null);
                                    }
                                    else
                                    {
                                        throw new Exception("Can't assign null value to property");
                                    }
                                }
                            }

                            result = true;
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

            return result;
        }

        /// <summary>
        /// Lit les champs depuis la base de données
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static List<T> Select<T>(string? where = null, int limitCount = -1) where T : View, new()
        {
            var list = new List<T>();

            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.Append("select");

                    if (limitCount > 0)
                    {
                        query.Append(" Top(");
                        query.Append(limitCount);
                        query.Append(")");
                    }

                    query.Append(" ");
                    query.Append(String.Join(',', GetColumns<T>().Select(p => "[" + p.Name + "]")));

                    query.Append(" from ");
                    query.Append(GetViewName<T>());

                    if (String.IsNullOrEmpty(where) == false)
                    {
                        query.Append(" where ");
                        query.Append(where);
                    }

                    var queryStr = query.ToString();

                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        var reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                list.Add(View.Read<T>(reader));
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
        public static List<T> SelectQuery<T>(string queryStr) where T : class, new()
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
                                list.Add(View.Read<T>(reader));
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
    }
}
