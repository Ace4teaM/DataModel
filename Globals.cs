using DataModel.Model.BDD;
using System.Data.SqlClient;

namespace DataModel
{
    public static class Globals
    {
        public static SqlConnectionManager<SqlConnection> SqlConnect = new SqlConnectionManager<SqlConnection>("Data Source=<MY_IP>;Initial Catalog=<MY_DATABASE>;Integrated Security=False;User=<MY_USER>;Pwd=<MY_PWD>;");
    }
}
