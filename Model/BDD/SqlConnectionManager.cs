using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;

namespace DataModel.Model.BDD
{
    public class SqlConnectionManager<ConnectionT> : IDisposable where ConnectionT : DbConnection, new()
    {
        /// <summary>
        /// Identifiant du thread principal
        /// </summary>
        private static int MainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

        /// <summary>
        /// La session est la session par défaut (thread principal)
        /// </summary>
        public bool IsCurrentConnexion
        {
            get
            {
                return System.Threading.Thread.CurrentThread.ManagedThreadId == MainThreadId;
            }
        }

        /// <summary>
        /// Une session est en cours
        /// </summary>
        public bool HasCurrentSession
        {
            get
            {
                return threadSessions.ContainsKey(System.Threading.Thread.CurrentThread.ManagedThreadId);
            }
        }

        /// <summary>
        /// Nombre d'increments de la session en cours
        /// </summary>
        public int CurrentSessionCount
        {
            get
            {
                return HasCurrentSession ? threadSessions[System.Threading.Thread.CurrentThread.ManagedThreadId].Item1 : 0;
            }
        }

        /// <summary>
        /// La connexion peut être libéré si il ne s'agit pas du thread principal (connexion ouverte en permanance) et si il ne s'agit pas d'une session (englobant plusieurs requêtes)
        /// </summary>
        public bool CanReleaseConnexion
        {
            get
            {
                return IsCurrentConnexion == false && HasCurrentSession == false;
            }
        }

        string ConnectionString;
        private int maxPersistantConnection = 4;
        private ConnectionT? con = null;
        private ConcurrentDictionary<int, Tuple<int,ConnectionT>> threadSessions = new ConcurrentDictionary<int, Tuple<int, ConnectionT>>();
        public int CommandTimeout = 10;
        public string ServerName;
        public string DatabaseName;
        public string DatabaseUser;
        public string DatabasePwd;

        public SqlConnectionManager(
          string ServerName,
          string DatabaseName,
          string DatabaseUser,
          string DatabasePwd)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.DatabaseUser = DatabaseUser;
            this.DatabasePwd = DatabasePwd;
            this.ConnectionString = "Server=" + ServerName + ";Database=" + DatabaseName + ";User Id=" + DatabaseUser + ";Password=" + DatabasePwd + ";";
        }

        public SqlConnectionManager(
          string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public void SetConnection(
      string ServerName,
      string DatabaseName,
      string DatabaseUser,
      string DatabasePwd)
        {
            this.CloseConnections();
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.DatabaseUser = DatabaseUser;
            this.DatabasePwd = DatabasePwd;
            this.ConnectionString = "Server=" + ServerName + ";Database=" + DatabaseName + ";User Id=" + DatabaseUser + ";Password=" + DatabasePwd + ";";
        }

        public void Test()
        {
            ConnectionT connectionT = new ConnectionT();
            try
            {
                connectionT.ConnectionString = this.ConnectionString;
                connectionT.Open();
            }
            catch
            {
                throw;
            }
            finally
            {
                connectionT.Close();
            }
        }

        public static void Test(
          string ServerName,
          string DatabaseName,
          string DatabaseUser,
          string DatabasePwd)
        {
            string str = "Server=" + ServerName + ";Database=" + DatabaseName + ";User Id=" + DatabaseUser + ";Password=" + DatabasePwd + ";";
            ConnectionT connectionT = new ConnectionT();
            connectionT.ConnectionString = str;
            connectionT.Open();
            connectionT.Close();
        }

        public void Dispose()
        {
            CloseConnections();
        }

        public void CloseConnections()
        {
            if (this.con != null && this.con.State == ConnectionState.Open)
                this.con.Close();
/*
            foreach (var c in this.conList)
            {
                if (c.State == ConnectionState.Open)
                    c.Close();
            }
            this.conList.Clear();*/

            this.con = default(ConnectionT);
        }

        public void BeginSession()
        {
            if(HasCurrentSession == false)
            {
                ConnectionT connection;
                connection = new ConnectionT();
                connection.ConnectionString = this.ConnectionString;
                connection.Open();

                threadSessions[System.Threading.Thread.CurrentThread.ManagedThreadId] = Tuple.Create<int,ConnectionT>(1, connection);

                // incremente le nombre de session actives
            }
        }

        public void EndSession()
        {
            if (HasCurrentSession)
            {
                Tuple<int, ConnectionT>? session;
                if (threadSessions.TryGetValue(System.Threading.Thread.CurrentThread.ManagedThreadId, out session))
                {
                    int sessionCount = session.Item1;

                    if (sessionCount - 1 == 0)
                    {
                        if (threadSessions.Remove(System.Threading.Thread.CurrentThread.ManagedThreadId, out session))
                        {
                            if (session.Item2.State == ConnectionState.Open)
                                session.Item2.Close();
                        }
                    }
                    else
                    {
                        threadSessions[System.Threading.Thread.CurrentThread.ManagedThreadId] = Tuple.Create<int, ConnectionT>(sessionCount - 1, session.Item2);
                    }
                }
            }
        }

        public ConnectionT GetConnection()
        {
            // si il s'agit du thread principal, on réutilise la connexion
            if (IsCurrentConnexion)
            {
                if (this.con == null)
                {
                    this.con = new ConnectionT();
                    this.con.ConnectionString = this.ConnectionString;
                }
                if (this.con.State != ConnectionState.Open)
                    this.con.Open();
                return this.con;
            }

            //si il existe une session en cours
            if (HasCurrentSession)
                return threadSessions[System.Threading.Thread.CurrentThread.ManagedThreadId].Item2;

            // si il s'agit d'un thread différent, on crée une nouvelle connexion
            ConnectionT connection;
            connection = new ConnectionT();
            connection.ConnectionString = this.ConnectionString;
            connection.Open();
 //           this.conList.Add(connection);
            return connection;
        }

        public void ReleaseConnection(ConnectionT c)
        {
/*            if (!this.conList.Contains(c))
                return;*/
            if (c.State == ConnectionState.Open)
                c.Close();
        }
    }
}
