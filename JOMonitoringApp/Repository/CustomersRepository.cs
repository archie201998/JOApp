using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Tls.Crypto.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Twilio.TwiML.Voice;

internal class CustomersRepository : ICustomersRepository
{
    private GenericCommands mySqlGenericCommands;
    private GenericCommands sqlGenericCommands;
    private readonly string tableName = "tbl_CustomerMaster";


    public CustomersRepository(GenericCommands sqlGenericCommands, GenericCommands mySqlGenericCommands)
    {
        this.mySqlGenericCommands = mySqlGenericCommands;
        this.sqlGenericCommands = sqlGenericCommands;
    }

    public bool Delete(List<CustomersModel> entityList)
    {
        throw new System.NotImplementedException();
    }

    public Dictionary<string, string> GetRecordByID(int Id)
    {
        throw new System.NotImplementedException();
    }

    public DataTable GetRecords()
    {
        string query = $"SELECT id, account_name FROM {tableName}";

        var dataTable = new DataTable();
        return mySqlGenericCommands.Fill(query, dataTable);
    }

    public DataTable GetRecordsBySearch(string searchText)
    {
        throw new System.NotImplementedException();
    }

    public bool IdExist(int id)
    {
        throw new System.NotImplementedException();
    }

    public bool Insert(CustomersModel entity)
    {
        var parameter = new object[][] {
            new object[]{"@account_number", DbType.String, entity.AccountNumber},
            new object[]{"@account_name", DbType.String, entity.AccountName},
            new object[]{"@address", DbType.String, entity.Address},
            new object[]{"@contact", DbType.String, entity.Contact},
            new object[]{"@created_by", DbType.Int32, entity.CreatedBy},
        };

        string query = $"INSERT INTO {tableName} (account_number, account_name, address, contact, created_by) VALUES (@account_number, @account_name, @address, @contact, @created_by)";
        return mySqlGenericCommands.ExecuteNonQuery(query, parameter);

    }

    public bool Update(CustomersModel entity)
    {
        var parameter = new object[][] {
            new object[]{"@id", DbType.Int32, entity.Id},
            new object[]{"@account_number", DbType.String, entity.AccountNumber},
            new object[]{"@account_name", DbType.String, entity.AccountName},
            new object[]{"@address", DbType.String, entity.Address},
            new object[]{"@contact", DbType.String, entity.Contact},
            new object[]{"@updated_by", DbType.Int32, entity.CreatedBy},
        };


        string query = $"UPDATE {tableName} SET account_number=@account_number, account_name=@account_name, address=@address, contact = @contact, updated_by=@updated_by WHERE id = @id";

        return mySqlGenericCommands.ExecuteNonQuery(query, parameter);

    }

    public DataTable GetCustomersName(string searchKey)
    {
        var parameters = new object[][]
        {
            new object[] { "@search_key", DbType.String, $"%{searchKey}%" }
        };

        string query = $"SELECT id, account_number, account_name FROM {tableName} WHERE account_name LIKE @search_key OR account_number LIKE @search_key";

        var dataTable = new DataTable();
        return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
    }


    //This will fetch the records from the main database
    public DataTable GetRecordsBySearchByAccountNumber(string searchKey)
    {
        var parameters = new object[][]
        {
            new object[] { "@search_key", DbType.String, $"%{searchKey}%" }
        };


        string query = $"SELECT TOP(10) CustomerID AS id, AccountNo AS account_number, AccountName AS account_name, Address AS address, MeterNumber AS meter_no, MeterBrand meter_brand  FROM {tableName} WHERE AccountNo LIKE @search_key OR AccountName like @search_key";

        var dataTable = new DataTable();
        return sqlGenericCommands.SQLFillBySearch(query, dataTable, parameters);
    }

    public DataTable GetRecordsBySearchByAccountName(string searchKey)
    {
        var parameters = new object[][]
        {
            new object[] { "@search_key", DbType.String, $"%{searchKey}%" }
        };

        string query = $"SELECT TOP(10) CustomerID AS id, AccountNo AS account_number, AccountName AS account_name, Address AS address, MeterNumber AS meter_no, MeterBrand meter_brand  FROM {tableName} WHERE AccountName LIKE @search_key ";

        var dataTable = new DataTable();
        return sqlGenericCommands.SQLFillBySearch(query, dataTable, parameters);
    }

    public DataTable GetRecordsBySearchByAccountNumberAndAccountName(string searchKey)
    {
        var parameters = new object[][]
        {
            new object[] { "@search_key", DbType.String, $"%{searchKey}%" }
        };

        string query = $"SELECT id, account_number, account_name, address FROM {tableName} WHERE account_number LIKE @search_key OR account_name LIKE @search_key";

        var dataTable = new DataTable();
        return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
    }

    public DataTable GetMasterListFromMainDB()
    {

        string query = $"SELECT * FROM {tableName}";

        var dataTable = new DataTable();
        return sqlGenericCommands.MainDB_Fill(query, dataTable);
    }

    public Dictionary<string, string> GetCustomerAccountDetails(string accountNumber)
    {
        var parameters = new object[][]
        {
           new object[] { "@account_number", DbType.String, accountNumber }
        };

        string query = $"SELECT Category, MeterSize, AccountName, AccountNo, ORNumber FROM tbl_CustomerMaster WHERE AccountNo = @account_number";

        var dataTable = new DataTable();
        dataTable = sqlGenericCommands.SQLFillBySearch(query, dataTable, parameters);

        var result = new Dictionary<string, string>();
        if (dataTable.Rows.Count > 0)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                result[column.ColumnName] = dataTable.Rows[0][column].ToString();
            }
        }

        return result;
    }

    public Dictionary<string, string> GetCustomerMeterDetails(string accountNumber)
    {
        var parameters = new object[][]
        {
           new object[] { "@account_number", DbType.String, accountNumber }
        };

        string query = $"SELECT MeterNumber, MeterBrand, MeterSize, LastReading FROM vue_CustomerMaster WHERE AccountNo = @account_number";

        var dataTable = new DataTable();
        dataTable = sqlGenericCommands.SQLFillBySearch(query, dataTable, parameters);

        var result = new Dictionary<string, string>();
        if (dataTable.Rows.Count > 0)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                result[column.ColumnName] = dataTable.Rows[0][column].ToString();


            }
        }

        return result;
    }

    public Dictionary<string, string> GetPaymentDetails(int customerId)
    {
        var parameters = new object[][]
        {
           new object[] { "@customer_id", DbType.Int32, customerId }
        };

        string query = $"SELECT ORNumber, SUM(Amount) AS Total FROM txn_PaymentDetailsOthers WHERE (CustomerID = @customer_id) GROUP BY ORNumber";

        var dataTable = new DataTable();
        dataTable = sqlGenericCommands.SQLFillBySearch(query, dataTable, parameters);

        var result = new Dictionary<string, string>();
        if (dataTable.Rows.Count > 0)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                result[column.ColumnName] = dataTable.Rows[0][column].ToString();

            }
        }

        return result;
    }

    public Dictionary<string, string> GetBillingDetails(string accountNumber)
    {
        var parameters = new object[][]
        {
           new object[] { "@account_number", DbType.String, accountNumber }
        };

        string query = $"SELECT TOP(1) * FROM txn_ReadingDetails WHERE AccountNo = @account_number ORDER BY ReadingDate DESC";

        var dataTable = new DataTable();
        dataTable = sqlGenericCommands.SQLFillBySearch(query, dataTable, parameters);

        var result = new Dictionary<string, string>();
        if (dataTable.Rows.Count > 0)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                result[column.ColumnName] = dataTable.Rows[0][column].ToString();
            }
        }

        return result;
    }

    public DataTable GetAverageCons(string accountNumber)
    {
        var parameters = new object[][]
        {
            new object[] { "@account_number", DbType.String, accountNumber }
        };

        string query = $"SELECT TOP(3) CurrentCons FROM txn_ReadingDetails WHERE AccountNo = @account_number ORDER BY ReadingDate DESC";

        var dataTable = new DataTable();
        return sqlGenericCommands.SQLFillBySearch(query, dataTable, parameters);
    }

    public string GetAverageConsumption(string accountNumber)
    {
        var parameters = new object[][]
        {
            new object[] { "@account_number", DbType.String, accountNumber }
        };

        string query = @"
            SELECT ROUND(AVG(CurrentCons), 2) AS AverageCons
            FROM txn_ReadingDetails
            WHERE (ReadingDate >= DATEADD(MONTH, -3, GETDATE()))
                AND (CurrentCons IS NOT NULL)
                AND (AccountNo = @account_number)";

        object result = sqlGenericCommands.ExecuteScalar(query, parameters);

        return result != null && result != DBNull.Value ? result.ToString() : "0";
    }

    public string GetPreviousReading(string accountNumber)
    {
        throw new System.NotImplementedException();
    }

    public string GetPresentReading(string accountNumber)
    {
        throw new System.NotImplementedException();
    }

    public string GetPreviousConsumption(string accountNumber)
    {
        throw new System.NotImplementedException();
    }

    public string GetPresentConsumption(string accountNumber)
    {
        throw new System.NotImplementedException();
    }

    public string GetConsumptionUponDisconnection(string accountNumber)
    {
        throw new System.NotImplementedException();
    }

    public decimal GetApplicationPaymentAmount(string orNumber)
    {
        var parameters = new object[][]
        {
            new object[] { "@or_number", DbType.String, orNumber }
        };

        string query = $"SELECT SUM(Amount) As Amount FROM txn_PaymentDetailsOthers WHERE or_number = @or_number";
        return int.Parse(sqlGenericCommands.ExecuteScalar(query, parameters));

    }

    public SqlDataReader LoadLedgerByCustomerId(int customerId, DateTime from, DateTime to)
    {
        SqlConnection conn = new SqlConnection("Server=192.168.18.201;Database=dbs_JBCSPagadian;User id=sa;Password=Pamana#777;");
        SqlCommand cmd = new SqlCommand(@"
        SELECT * 
        FROM vue_LedgerViewFinalWCons 
        WHERE CustomerId = @CustomerId 
          AND txnDate BETWEEN @From AND @To", conn);

        cmd.Parameters.AddWithValue("@CustomerId", customerId);
        cmd.Parameters.AddWithValue("@From", from);
        cmd.Parameters.AddWithValue("@To", to);

        cmd.CommandTimeout = 120;

        conn.Open();
        // Important: CommandBehavior.CloseConnection makes sure 
        // the connection closes when the reader is disposed
        return cmd.ExecuteReader(CommandBehavior.CloseConnection);
    }

    public string GetChangeMeterDate(string accountNumber)
    {
        var parameters = new object[][]
        {
            new object[] { "@account_number", DbType.String, accountNumber }
        };

        string query = $"SELECT TOP 1 FROM txn_ChangeMeter WHERE AccountNo = @account_number ORDER BY txn_ChangeMeter";

        object result = sqlGenericCommands.ExecuteScalar(query, parameters);

        return result != null && result != DBNull.Value ? result.ToString() : "0";
    }

    public DataTable GetChangeMeterDetails(string accountNumber)
    {
        var parameters = new object[][]
        {
            new object[] { "@account_number", DbType.String, accountNumber }
        };

        string query = $"SELECT AccountNo, '' AS posting_status FROM txn_ChangeMeter WHERE AccountNo = @account_number ORDER BY txnDate";

        var dataTable = new DataTable();
        dataTable = sqlGenericCommands.SQLFillBySearch(query, dataTable, parameters);

        return dataTable;
    }

    public Dictionary<string, string> GetOtherPaymentDetails(string orNumber)
    {
        var parameters = new object[][]
        {
            new object[] { "@ornumber", DbType.String, orNumber }
        };

        //string query = $"SELECT *, SUM(UnitAmount) TotalAmount FROM  txn_PaymentDetailsOthers WHERE  ORNumber = @ornumber AND ORtype = SI GROUP BY Amount";
        
        string query = $"SELECT h.eUser, h.PaymentDate, h.ORNumber, h.CustomerID, h.AccountNo, h.AccountName, SUM(d.Amount) AS TotalAmount FROM txn_PaymentHeaderOthers h INNER JOIN txn_PaymentDetailsOthers d ON h.ORNumber = d.ORNumber  WHERE d.ORNumber = @ornumber GROUP BY h.ORNumber, h.CustomerID, h.AccountNo, h.AccountName, h.eUser, h.PaymentDate ORDER BY h.ORNumber DESC";

        var dataTable = new DataTable();
        dataTable = sqlGenericCommands.SQLFillBySearch(query, dataTable, parameters);

        var result = new Dictionary<string, string>();
        if (dataTable.Rows.Count > 0)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                result[column.ColumnName] = dataTable.Rows[0][column].ToString();
            }
        }

        return result;
    }

    public bool InsertHydrantData(string jobOrderNumber, string previousReading, string afterReading, string requestedBy, string orNumber, string cashier, string date, string amount, string totalVolume)
    {
        var parameter = new object[][] {

            new object[]{"@job_order_number", DbType.String, jobOrderNumber},
            new object[]{"@previous_reading", DbType.String, previousReading},
            new object[]{"@current_reading", DbType.String, afterReading},
            new object[]{ "@requested_by", DbType.String, requestedBy},
            new object[]{"@or_number", DbType.String, orNumber},
            new object[]{"@cashier", DbType.String, cashier},
            new object[]{"@date", DbType.String, date},
            new object[]{"@amount", DbType.String, amount},
            new object[]{"@total_volume", DbType.String, totalVolume},
        };

        string query = $@"INSERT INTO tbl_hydrantwithdrawal(job_order_number, previous_reading, current_reading, requested_by, or_number, cashier, date, amount, total_volume) VALUES (@job_order_number, @previous_reading, @current_reading, @requested_by, @or_number, @cashier, @date, @amount, @total_volume)";

        return mySqlGenericCommands.ExecuteNonQuery(query, parameter);

    }

    public Dictionary<string, string> GetHydrantWithdrawalData(string jobOrder)
    {
        var recordDictionary = new Dictionary<string, string>();
        var parameters = new object[][]
         {
            new object[] { "@job_order_number", DbType.String, jobOrder }
         };

        string query = $"SELECT * FROM tbl_hydrantwithdrawal WHERE job_order_number = @job_order_number";

        DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

        if (dataTable.Rows.Count > 0)
        {
            DataRow row = dataTable.Rows[0];

            foreach (DataColumn column in dataTable.Columns)
                recordDictionary[column.ColumnName] = row[column].ToString();

            return recordDictionary;
        }
        return recordDictionary;
    }

    public bool UpdateHydrantData(string jobOrderNumber, string previousReading, string afterReading, string requestedBy, string orNumber, string cashier, string date, string amount, string totalVolume)
    {
        var parameter = new object[][] {

            new object[]{"@job_order_number", DbType.String, jobOrderNumber},
            new object[]{"@previous_reading", DbType.String, previousReading},
            new object[]{"@current_reading", DbType.String, afterReading},
            new object[]{"@requested_by", DbType.String, requestedBy},
            new object[]{"@or_number", DbType.String, orNumber},
            new object[]{"@cashier", DbType.String, cashier},
            new object[]{"@date", DbType.String, date},
            new object[]{"@amount", DbType.String, amount},
            new object[]{"@total_volume", DbType.String, totalVolume},
        };

        string query = $@"UPDATE tbl_hydrantwithdrawal SET 
                        previous_reading = @previous_reading, 
                        current_reading = @current_reading, 
                        requested_by = @requested_by, 
                        or_number = @or_number,
                        cashier = @cashier, 
                        date = @date, 
                        amount = @amount, 
                        total_volume = @total_volume WHERE job_order_number = @job_order_number";

        return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
    }
}
