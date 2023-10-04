using MySql.Data.MySqlClient;

namespace AnimalNursery.Repositories.Base
{
    internal class ConnectionDB
    {
        static volatile ConnectionDB Class;
        static object SyncObject = new object();
        public static ConnectionDB GetInstance
        {
            get
            {
                if (Class == null)
                    lock (SyncObject)
                    {
                        if (Class == null)
                            Class = new ConnectionDB();
                    }
                return Class;
            }
        }
        readonly MySqlConnection connection = new MySqlConnection(
            $"server=31.31.198.62;" +
            $"port=3306;" +
            $"username=u1748936_admin12;" +
            $"password=DBD-4EY-P99-vEz;" +
            $"database=u1748936_animals;" +
            $"charset=utf8");

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}
