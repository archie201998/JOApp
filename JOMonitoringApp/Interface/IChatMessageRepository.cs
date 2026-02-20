using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    internal interface IChatMessageRepository : IRepository<ChatMessageModel>
    {
        int InsertMessage(ChatMessageModel chatMessage);
        List<ChatMessageModel> LoadRecentMessages(int senderId);

        List<ChatMessageModel> GetNewMessages(int lastMessageId, int senderId);

        bool CheckNewMesage(int lastChatID, int currentUserID);
    }
}
