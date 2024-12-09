using DataBaseLib;
using MySql.Data.MySqlClient;
using System.Data;

namespace GameServer.Database
{
    public class LoginDB
    {
        private Int64 __userPID = 0;
        private DataBaseConnection? __conn = null;
        private MySqlTransaction? __tran = null;

        public async void StartConnection(Int64 userPID)
        {
            __conn = await DataBaseConnection.GetConnectionAsync("");
            if (__conn == null)
            {
                return;
            }

            __userPID = userPID;
            return;
        }

        public void EndConnection()
        {
            try
            {
                __conn?.Close();
            }
            catch
            {

            }
        }

        public async void BeginTransaction()
        {
            __tran = await __conn.Connection.BeginTransactionAsync(IsolationLevel.ReadUncommitted);
        }

        public async void EndTransaction(bool isCommit)
        {
            if(__tran == null)
            {
                return;
            }

            if(isCommit)
            {
                await __tran.CommitAsync();
            }
            else
            {
                await __tran.RollbackAsync();
            }
        }
    }
}
