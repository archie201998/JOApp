using System.Collections.Generic;
using System.Data;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;

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

    public int GetLastInsertedID(int userId)
    {
        var parameters = new object[][]
        {  new object[] { "@user_id", DbType.Int32, userId}, };

        string query = $"SELECT MAX(id) FROM {tableName} WHERE created_by = @user_id";

        return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
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

    
    //public DataTable GetRecordsBySearchByAccountNumber(string searchKey)
    //{
    //    var parameters = new object[][]
    //    {
    //        new object[] { "@search_key", DbType.String, $"%{searchKey}%" }
    //    };

    //    string query = $"SELECT id, account_number, account_name, address FROM {tableName} WHERE account_number LIKE @search_key OR account_name  like @search_key LIMIT 10";

    //    var dataTable = new DataTable();
    //    return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
    //}

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
}