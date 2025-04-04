using System.Data;
using System.Runtime.CompilerServices;

namespace MiniChatApp
{
    internal class ConvoRepository : IConvoRepository
    {
        private GenericCommands mySqlGenericCommands;

        public ConvoRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public DataTable GetAllConvo()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM tbl_convo ORDER BY id DESC LIMIT 20 ";
            mySqlGenericCommands.Fill(query, dataTable);
            return dataTable;
        }

        public bool SendMessage(string senderName, string message)
        {
            var parameters = new object[][]
            {
                new object[] { "@sender", DbType.String,  senderName },
                new object[] { "@message", DbType.String, message },
            };

            string query = $"INSERT INTO tbl_convo (sender, message) VALUES(@sender, @message)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}