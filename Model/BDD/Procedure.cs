using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using static DataModel.Globals;

namespace DataModel.Model.BDD
{
    /// <summary>
    /// Classe de base aux entités de type Procédure SQL
    /// </summary>
    public abstract class Procedure
    {
        /// <summary>
        /// Obtient le nom de la procédure SQL
        /// </summary>
        public string ProcedureName
        {
            get
            {
                var att1 = (SchemaAttribute?)GetType().GetCustomAttribute(typeof(SchemaAttribute));
                var att2 = (NameAttribute?)GetType().GetCustomAttribute(typeof(NameAttribute));

                return String.Format("{0}.{1}", att1 == null ? "dbo" : att1.SQLName, att2 == null ? GetType().Name : att2.SQLName);
            }
        }

        /// <summary>
        /// Obtient le nom de la procédure SQL
        /// </summary>
        public static string GetProcedureName<T>()
        {
            var att1 = (SchemaAttribute?)typeof(T).GetCustomAttribute(typeof(SchemaAttribute));
            var att2 = (NameAttribute?)typeof(T).GetCustomAttribute(typeof(NameAttribute));

            return String.Format("{0}.{1}", att1 == null ? "dbo" : att1.SQLName, att2 == null ? typeof(T).Name : att2.SQLName);
        }

        /// <summary>
        /// Obtient le(s) paramètres de la procédure
        /// </summary>
        public PropertyInfo[] Parameters
        {
            get
            {
                return this.GetType().GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(ParameterAttribute)) != null).ToArray();
            }
        }

        /// <summary>
        /// Obtient le(s) paramètres de la procédure
        /// </summary>
        public static PropertyInfo[] GetParameters<T>()
        {
            return typeof(T).GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => typeof(ParameterAttribute).IsAssignableFrom(a.AttributeType)) != null).ToArray();
        }

        /// <summary>
        /// Obtient le(s) paramètres d'entrées de la procédure
        /// </summary>
        public PropertyInfo[] InputParameters
        {
            get
            {
                return this.GetType().GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(InputParameterAttribute)) != null).ToArray();
            }
        }

        /// <summary>
        /// Obtient le(s) paramètres d'entrées de la procédure
        /// </summary>
        public static PropertyInfo[] GetInputParameters<T>()
        {
            return typeof(T).GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => typeof(InputParameterAttribute).IsAssignableFrom(a.AttributeType)) != null).ToArray();
        }

        /// <summary>
        /// Obtient le(s) paramètres de sorties de la procédure
        /// </summary>
        public PropertyInfo[] OutputParameters
        {
            get
            {
                return this.GetType().GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(OutputParameterAttribute)) != null).ToArray();
            }
        }

        /// <summary>
        /// Obtient le(s) paramètres de sorties de la procédure
        /// </summary>
        public static PropertyInfo[] GetOutputParameters<T>()
        {
            return typeof(T).GetProperties().Where(p => p.CustomAttributes.FirstOrDefault(a => typeof(OutputParameterAttribute).IsAssignableFrom(a.AttributeType)) != null).ToArray();
        }
        
        public static object? Parse(object? o)
        {
            if (o is string)
                return "'" + ((string)o).Replace("'", "''") + "'";
            if (o is null)
                return "NULL";
            return o;
        }

        /// <summary>
        /// Execute la procédure
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static int ExecuteWithNames<T>(Dictionary<string, object> fields) where T : Procedure, new()
        {
            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.Append("exec ");
                    query.Append(GetProcedureName<T>());

                    foreach (var field in fields)
                    {
                        query.Append(" ");
                        query.Append(String.Join(',', fields.Select(p => p.Key + " = " + Table.Parse(p.Value))));
                    }

                    var queryStr = query.ToString();
                    int result;

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
        /// Execute la procédure
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static int Execute<T>(params object?[] arguments) where T : Procedure, new()
        {
            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.Append("exec ");
                    query.Append(GetProcedureName<T>());

                    query.Append(" ");
                    query.Append(String.Join(',', arguments.Select(p => Query.Parse(p))));

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
        /// Execute la procédure
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int Execute()
        {
            var conn = SqlConnect.GetConnection();
            if (conn != null)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = ProcedureName;

                        foreach (var field in InputParameters)
                        {
                            var param = new SqlParameter(field.Name, field.GetValue(this));
                            param.Direction = System.Data.ParameterDirection.Input;
                            cmd.Parameters.Add(param);
                        }

                        foreach (var field in OutputParameters)
                        {
                            var param = new SqlParameter(field.Name, field.GetValue(this));
                            param.Direction = System.Data.ParameterDirection.Output;
                            cmd.Parameters.Add(param);
                        }

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

    }
}
