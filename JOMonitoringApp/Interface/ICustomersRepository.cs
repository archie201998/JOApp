using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface ICustomersRepository : IRepository<CustomersModel>
    {
        DataTable GetCustomersName(string searchKey);
        DataTable GetRecordsBySearchByAccountNumber(string searchKey);
        DataTable GetRecordsBySearchByAccountName(string searchKey);
        DataTable GetRecordsBySearchByAccountNumberAndAccountName(string searchKey);
        DataTable GetMasterListFromMainDB();
        Dictionary<string, string> GetCustomerMeterDetails(string accountNumber);
        Dictionary<string, string> GetCustomerAccountDetails(string accountNumber);
        Dictionary<string, string> GetBillingDetails(string accountNumber);
        Dictionary<string, string> GetPaymentDetails(int customerId);
        DataTable GetAverageCons(string accountNumber);
        string GetAverageConsumption(string accountNumber);
        string GetPreviousReading(string accountNumber);
        string GetPresentReading(string accountNumber);
        string GetPreviousConsumption(string accountNumber);
        string GetPresentConsumption(string accountNumber);
        string GetConsumptionUponDisconnection(string accountNumber);

        decimal GetApplicationPaymentAmount(string orNumber);

        Dictionary<string, string> GetOtherPaymentDetails(string orNumber);

        SqlDataReader LoadLedgerByCustomerId(int v, DateTime value1, DateTime value2);
        string GetChangeMeterDate(string accountNumber);
        DataTable GetChangeMeterDetails(string accountNumber);
        bool InsertHydrantData(string jobOrderNumber, string previousReading, string afterReading, string orNumber, string cashier, string date, string amount, string totalVolume, string totalVolume1);
        Dictionary<string, string> GetHydrantWithdrawalData(string jobOrder);
    }
}
