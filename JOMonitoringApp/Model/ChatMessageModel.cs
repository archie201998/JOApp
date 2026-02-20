using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class ChatMessageModel
    {
        public int ID { get; set; }
        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public string Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsMine { get; set; }
    }
}
