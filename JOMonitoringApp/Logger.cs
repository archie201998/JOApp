using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp
{
    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");

        public static void Log(Exception ex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true)) // append mode
                {
                    writer.WriteLine("========== ERROR ==========");
                    writer.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine("Message: " + ex.Message);
                    writer.WriteLine("StackTrace: " + ex.StackTrace);
                    writer.WriteLine("Source: " + ex.Source);
                    writer.WriteLine("===========================\n");
                }
            }
            catch
            {
                // In case logging fails, silently fail to avoid crashing the app
            }
        }
    }
}
