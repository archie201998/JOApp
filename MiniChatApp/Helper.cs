
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using System.Net;
using System.Net.Sockets;
using System.Reflection;


namespace MiniChatApp
{
    public static class Helper
    {

        internal static string currentUserDisplayName = string.Empty;

        public static void LoadFormIcon(Form form)
        {
            using (var ms = new MemoryStream(Properties.Resources.icons8_chat_48))
            {
                form.Icon = new Icon(ms);
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}