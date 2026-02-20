using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace JOMonitoringApp.Repository
{
    internal class ChatMessageRepository : IChatMessageRepository
    {
        private readonly string tableName = "tbl_convo";
        private GenericCommands mySqlGenericCommands;

        public ChatMessageRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<ChatMessageModel> entityList)
        {
            throw new NotImplementedException();
        }


        public List<ChatMessageModel> LoadRecentMessages(int senderId)
        {
            List<ChatMessageModel> list = new List<ChatMessageModel>();

            string sql = @"SELECT * FROM tbl_convo
                   ORDER BY id DESC
                   LIMIT 50";

            // Assume ExecuteQuery returns DataTable
            DataTable dt = this.mySqlGenericCommands.ExecuteReader(sql, new object[0][]);

            foreach (DataRow r in dt.Rows)
            {
                DateTime parsedDate;
                DateTime.TryParse(r["created_at"].ToString(), out parsedDate);

                list.Insert(0, new ChatMessageModel
                {
                    ID = Convert.ToInt32(r["id"]),
                    Sender = r["sender"].ToString(),
                    MessageText = r["message"].ToString(),
                    CreatedAt = parsedDate,
                    IsMine = Convert.ToInt32(r["sender_id"]) == senderId
                });
            }

            return list;
        }

        public int InsertMessage(ChatMessageModel msg)
        {

            string sql = @"INSERT INTO tbl_convo(sender_id,sender, message, created_at)
               VALUES(@sender_id, @sender, @message, @created_at);
               SELECT LAST_INSERT_ID();";

            object[][] parameters = new object[][]
            {
                new object[] { "@sender", DbType.String, msg.Sender },
                new object[] { "@message", DbType.String, msg.MessageText },
                new object[] { "@sender_id", DbType.Int32, msg.SenderID },
                new object[] { "@created_at", DbType.String, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
            };

            DataTable dt = this.mySqlGenericCommands.ExecuteReader(sql, parameters);

            int insertedID = Convert.ToInt32(dt.Rows[0][0]);
            return insertedID;
        }

        public List<ChatMessageModel> GetNewMessages(int lastID, int senderId)
        {
            List<ChatMessageModel> list = new List<ChatMessageModel>();

            string sql = @"SELECT * FROM tbl_convo
                   WHERE id > @last
                   ORDER BY id ASC";

            object[][] parameters = new object[][]
            {
                 new object[] { "@last", DbType.Int32,  lastID }
            };

            DataTable dt = this.mySqlGenericCommands.ExecuteReader(sql, parameters);

            foreach (DataRow r in dt.Rows)
            {
                DateTime parsedDate;
                DateTime.TryParse(r["created_at"].ToString(), out parsedDate);

                list.Add(new ChatMessageModel
                {
                    ID = Convert.ToInt32(r["id"]),
                    Sender = r["sender"].ToString(),
                    MessageText = r["message"].ToString(),
                    CreatedAt = parsedDate,
                    IsMine = Convert.ToInt32(r["sender"]) == senderId
                });
            }

            return list;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ChatMessageModel entity)
        {
            throw new NotImplementedException();
        }

        public int InsertMessage(ChatMessageRepository chatMessage)
        {
            throw new NotImplementedException();
        }

        public bool Update(ChatMessageModel entity)
        {
            throw new NotImplementedException();
        }

        public bool CheckNewMesage(int lastChatID, int currentUserID)
        {
            string sql = @"SELECT *
                   FROM tbl_convo
                   ORDER BY id DESC
                   LIMIT 1";

            DataTable dt = mySqlGenericCommands.ExecuteReader(sql, new object[0][]);

            if (dt.Rows.Count == 0)
                return false;

            int newestID = Convert.ToInt32(dt.Rows[0]["id"]);
            string senderId = dt.Rows[0]["sender_id"].ToString();
            string message = dt.Rows[0]["message"].ToString();

            // first load — don't notify yet
            if (lastChatID == 0)
            {
                lastChatID = newestID;
                return false;
            }

            // new message detected
            if (newestID > lastChatID && Convert.ToInt32(senderId) != currentUserID)
            {

                return true;
            }

            return false;
        }
    }
}
