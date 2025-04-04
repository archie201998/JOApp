using System.Data;

namespace MiniChatApp
{
    public interface IConvoRepository
    {
        DataTable GetAllConvo();
        bool SendMessage(string senderName, string message);
    }
}