using MySql.Data.MySqlClient;

namespace DataBaseLib
{
    public class DataBaseConnection : IDisposable
    {
        private readonly MySqlConnection __sqlConnection;

        private bool __isDisposed = false;
        private bool __isClosed = false;

        DataBaseConnection(MySqlConnection connection)
        {
            __sqlConnection = connection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // 소멸되는 객체이기에 GC 호출을 하지 않음
        }

        protected virtual void Dispose(bool disposing)
        {
            if(__isDisposed == false)
            {
                if (disposing)
                {
                    if (__sqlConnection != null)
                    {
                        Close();
                        __sqlConnection.Dispose();
                    }
                }

                __isDisposed = true;
            }
        }

        ~DataBaseConnection()
        {
            Dispose(false);
        }

        public void Close()
        {
            if (__isClosed == false)
            {
                __sqlConnection.Close();
                __isClosed = true;
            }
        }

        public MySqlConnection Connection
        {
            get { return __sqlConnection; }
        }

        public static DataBaseConnection? GetConnection(string connectionString)
        {
            try
            {
                DataBaseConnection connection = new DataBaseConnection(new MySqlConnection(connectionString));
                connection.__sqlConnection.Open();
                return connection;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static async Task<DataBaseConnection?> GetConnectionAsync(string connectionString)
        {
            try
            {
                DataBaseConnection connection = new DataBaseConnection(new MySqlConnection(connectionString));
                await connection.__sqlConnection.OpenAsync();
                return connection;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
