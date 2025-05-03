using System.ComponentModel;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using static DataModel.Globals;

namespace DataModel.Model.BDD
{
    /// <summary>
    /// Classe de base aux entités de type Table SQL
    /// </summary>
    public abstract class Table : IEquatable<Table>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool PrimaryKeyEquals(Table? p)
        {
            if (p is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != p.GetType())
            {
                return false;
            }

            // 
            var srcKey = this.PrimaryKey;
            var dstKey = p.PrimaryKey;

            if (
                srcKey.Length == dstKey.Length &&
                srcKey.Count(s => dstKey.FirstOrDefault(i => i.Name.Equals(s.Name) && i.GetValue(p).Equals(s.GetValue(this))) != null) == srcKey.Length
                )
                return true;

            return false;
        }

        /// <summary>
        /// Obtient le(s) champs de la clé primaire
        /// </summary>
        public PropertyInfo[] PrimaryKey
        {
            get
            {
                return this.GetType().GetProperties().Where(p=>p.CustomAttributes.FirstOrDefault(a=>a.AttributeType == typeof(PrimaryKeyAttribute)) != null).ToArray();
            }
        }

        /// <summary>
        /// Obtient le champ de la clé d'identité
        /// </summary>
        public PropertyInfo? IdentityKey
        {
            get
            {
                return this.GetType().GetProperties().FirstOrDefault(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(IdentityKeyAttribute)) != null);
            }
        }

        /// <summary>
        /// Obtient le(s) champs de la clé primaire
        /// </summary>
        public string PrimaryKeyWhere
        {
            get
            {
                return String.Join(" and ", PrimaryKey.Select(p=>p.Name + "=" + p.GetValue(this)));
            }
        }

        /// <summary>
        /// Obtient le(s) champs de la clé primaire
        /// </summary>
        public static PropertyInfo[] GetPrimaryKey<T>()
        {
            return typeof(T).GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(PrimaryKeyAttribute)) != null).ToArray();
        }

        /// <summary>
        /// Obtient le nom de la table SQL
        /// </summary>
        public static string GetTableName<T>()
        {
            var att1 = (SchemaAttribute?)typeof(T).GetCustomAttribute(typeof(SchemaAttribute));
            var att2 = (NameAttribute?)typeof(T).GetCustomAttribute(typeof(NameAttribute));

            return String.Format("{0}.{1}", att1 == null ? "dbo" : att1.SQLName, att2 == null ? typeof(T).Name : att2.SQLName);
        }

        /// <summary>
        /// Obtient le(s) champs de  la table
        /// </summary>
        public PropertyInfo[] Fields
        {
            get
            {
                return this.GetType().GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(FieldAttribute)) != null).ToArray();
            }
        }

        /// <summary>
        /// Obtient la valeur par défaut d'un champs lors de l'insertion
        /// </summary>
        public static object? GetDefault<T>(string name)
        {
            return typeof(T).GetProperties().Where(p => p.Name == name).Select(p=> p.GetCustomAttribute<DefaultAttribute>()?.Value).FirstOrDefault();
        }

        /// <summary>
        /// Obtient le(s) champs de  la table
        /// </summary>
        public static PropertyInfo[] GetFields<T>()
        {
            return typeof(T).GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(FieldAttribute)) != null).ToArray();
        }

        /// <summary>
        /// Obtient le(s) colonnes de la table sans distinction
        /// </summary>
        public static PropertyInfo[] GetColumns<T>()
        {
            return typeof(T).GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => typeof(ColumnAttribute).IsAssignableFrom(a.AttributeType)) != null).ToArray();
        }

        /// <summary>
        /// true si la clé primaire contient plusieurs champs
        /// </summary>
        public bool IsComposedPrimaryKey
        {
            get
            {
                return this.GetType().GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(PrimaryKeyAttribute)) != null).Count() > 1;
            }
        }

        /// <summary>
        /// true si la clé primaire contient plusieurs champs
        /// </summary>
        public static bool AsComposedPrimaryKey<T>()
        {
            return typeof(T).GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(PrimaryKeyAttribute)) != null).Count() > 1;
        }

        /// <summary>
        /// Lit les champs depuis la base de données
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ReadFields() 
        {
            if (PrimaryKey == null || PrimaryKey.Length == 0) throw new Exception("Table does not contains primary key");
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

        [Obsolete("Use Query.Parse insted")]
        public static object? Parse(object? o)
        {
            return Query.Parse(o);
        }

        /// <summary>
        /// Lit les champs depuis la base de données
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static List<T> Select<T>(string? where = null, int limitCount = -1) where T : Table, new()
        {
            var list = new List<T>();

            var conn = SqlConnect.GetConnection();
            if(conn != null)
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
                    query.Append(GetTableName<T>());

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
                                list.Add(Table.Read<T>(reader));
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
        [Obsolete("Use Query.Select insted")]
        public static List<T> SelectQuery<T>(string queryStr) where T : class, new()
        {
            return Query.Select<T>(queryStr);
        }

        /// <summary>
        /// Actualise une table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int Update<T>(bool reloadFields = true) where T : Table, new()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();

            foreach (var p in Fields)
            {
                fields.Add(p.Name, p.GetValue(this));
            }

            int result = Table.Update<T>(
                fields,
                PrimaryKeyWhere
            );

            // Tente de récupérer la clé primaire nouvellement insérée
            if (result > 0 && reloadFields == true) ReadFields();

            return result;
        }

        /// <summary>
        /// Actualise une table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static int Update<T>(Dictionary<string,object> fields, string? where) where T : Table, new()
        {
            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.Append("update ");
                    query.Append(GetTableName<T>());

                    query.Append(" set ");
                    query.Append(String.Join(',', fields.Select(p => p.Key + " = " + Query.Parse(p.Value))));

                    if (String.IsNullOrEmpty(where) == false)
                    {
                        query.Append(" where ");
                        query.Append(where);
                    }

                    var queryStr = query.ToString();

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

            return -1;
        }

        /// <summary>
        /// Actualise une table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static int Insert<T>(Dictionary<string, object> fields) where T : Table, new()
        {
            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.Append("insert into ");
                    query.Append(GetTableName<T>());

                    if (fields != null && fields.Count > 0)
                    {
                        query.Append(" ( ");
                        query.Append(String.Join(',', fields.Select(p => p.Key)));
                        query.Append(" ) ");

                        query.Append(" values( ");
                        query.Append(String.Join(',', fields.Select(p => Query.Parse(p.Value))));
                        query.Append(" ) ");
                    }
                    else
                    {
                        query.Append(" default values");
                    }
                    var queryStr = query.ToString();

                    using (
                        SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        /*if (fields != null && fields.Count > 0)
                        {
                            // Dans le case des données binaires ont passe la valeur à la commande
                            foreach (var bin in fields.Where(p => p.Value is byte[]))
                            {
                                var data = bin.Value as byte[];
                                cmd.Parameters.Add("@" + bin.Key, System.Data.SqlDbType.Binary, data.Length).Value = data;
                            }
                        }*/

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

            return -1;
        }

        /// <summary>
        /// Actualise une table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static int InsertOrUpdate<T>(Dictionary<string, object> fields, string? where) where T : Table, new()
        {
            var exists = Select<T>(where).Count() > 0;

            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    if (exists)
                    {
                        query.Append("update ");
                        query.Append(GetTableName<T>());

                        query.Append(" set ");
                        query.Append(String.Join(',', fields.Select(p => p.Key + " = " + Query.Parse(p.Value))));

                        if (String.IsNullOrEmpty(where) == false)
                        {
                            query.Append(" where ");
                            query.Append(where);
                        }
                    }
                    else
                    {
                        query.Append("insert into ");
                        query.Append(GetTableName<T>());

                        query.Append(" ( ");
                        query.Append(String.Join(',', fields.Select(p => p.Key)));
                        query.Append(" ) ");

                        query.Append(" values( ");
                        query.Append(String.Join(',', fields.Select(p => Query.Parse(p.Value))));
                        query.Append(" ) ");
                    }


                    var queryStr = query.ToString();

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

            return -1;
        }

        /// <summary>
        /// Insert en entrée de table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int Insert<T>(bool reloadFields=true) where T : Table, new()
        {
            try
            {
                SqlConnect.BeginSession(); // si relecture (reloadFields) des champs les requêtes doivent être dans la même session

                Dictionary<string, object> fields = new Dictionary<string, object>();

                foreach (var p in Fields)
                {
                    var value = p.GetValue(this);
                    fields.Add(p.Name, value == null ? GetDefault<T>(p.Name) : value);
                }

                int result = Table.Insert<T>(
                    fields
                );

                // Tente de récupérer la clé primaire nouvellement insérée
                if (result > 0 && reloadFields == true)
                    ReadLastInserted<T>();

                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                SqlConnect.EndSession();
            }
        }

        /// <summary>
        /// Recharge les champs de l'entité après insertion
        /// </summary>
        public bool ReadLastInserted<T>() where T : Table, new()
        {
            if (this.IdentityKey != null)
            {
                var e = Query.Select<T>("select top(1) * from " + Table.GetTableName<T>() + " where " + this.IdentityKey.Name + "=SCOPE_IDENTITY()").First();

                foreach (var p in this.Fields)
                {
                    p.SetValue(this, e.GetType().GetProperty(p.Name).GetValue(e));
                }

                foreach (var p in this.PrimaryKey)
                {
                    p.SetValue(this, e.GetType().GetProperty(p.Name).GetValue(e));
                }

                IdentityKey.SetValue(this, e.GetType().GetProperty(IdentityKey.Name).GetValue(e));

                return true;
            }

            return false;
        }

        /// <summary>
        /// Actualise en entrée de table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int Update<T>() where T : Table, new()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();

            foreach(var p in Fields)
            {
                fields.Add(p.Name,p.GetValue(this));
            }

            return Table.Update<T>(
                fields,
                PrimaryKeyWhere
            );
        }

        /// <summary>
        /// Supprime en entrée de table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int Delete<T>() where T : Table, new()
        {
            return Table.Delete<T>(
                PrimaryKeyWhere
            );
        }

        /// <summary>
        /// Supprime en entrée de table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static int Delete<T>(string? where) where T : Table, new()
        {
            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.Append("delete ");
                    query.Append(GetTableName<T>());

                    if (String.IsNullOrEmpty(where) == false)
                    {
                        query.Append(" where ");
                        query.Append(where);
                    }

                    var queryStr = query.ToString();

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

            return -1;
        }

        public bool Equals(Table? other)
        {
            return PrimaryKeyEquals(other);
        }
        
        public static bool operator ==(Table? a, Table? b)
        {
            if(object.ReferenceEquals(a, b))
                return true;
            return a.Equals(b);
        }
        public static bool operator !=(Table? a, Table? b)
        {
            if (object.ReferenceEquals(a, b))
                return false;
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
