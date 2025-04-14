using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Database
{
    public partial class frmDBBackup : Form
    {
        public frmDBBackup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=jo_monitoring;password=@jo_monitoring123;database=jo_monitoring;";
            string outputFile = @"C:\backups\manual_backup.sql";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    MySqlCommand showTables = new MySqlCommand("SHOW TABLES", conn);
                    using (MySqlDataReader tables = showTables.ExecuteReader())
                    {
                        while (tables.Read())
                        {
                            string table = tables[0].ToString();
                            Console.WriteLine($"Backing up table: {table}");

                            // Write DROP + CREATE TABLE
                            string createTable = GetCreateTable(conn, table);
                            writer.WriteLine($"-- Table structure for `{table}`");
                            writer.WriteLine($"DROP TABLE IF EXISTS `{table}`;");
                            writer.WriteLine(createTable + ";");
                            writer.WriteLine();

                            // Write INSERT statements
                            string selectQuery = $"SELECT * FROM `{table}`";
                            MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);
                            using (MySqlDataReader data = selectCmd.ExecuteReader())
                            {
                                while (data.Read())
                                {
                                    string insert = $"INSERT INTO `{table}` VALUES(";
                                    for (int i = 0; i < data.FieldCount; i++)
                                    {
                                        insert += data[i] == DBNull.Value ? "NULL" : $"'{MySqlHelper.EscapeString(data[i].ToString())}'";
                                        if (i < data.FieldCount - 1) insert += ", ";
                                    }
                                    insert += ");";
                                    writer.WriteLine(insert);
                                }
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }

            Console.WriteLine("✅ Manual backup completed.");
        }

        static string GetCreateTable(MySqlConnection conn, string tableName)
        {
            string result = "";
            MySqlCommand cmd = new MySqlCommand($"SHOW CREATE TABLE `{tableName}`", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    result = reader["Create Table"].ToString();
            }
            return result;
        }
    }
}
