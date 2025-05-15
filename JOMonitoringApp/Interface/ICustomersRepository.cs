using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface ICustomersRepository : IRepository<CustomersModel>
    {
        int GetLastInsertedID(int userId);
        DataTable GetCustomersName(string searchKey);
        DataTable GetRecordsBySearchByAccountNumber(string searchKey);
        DataTable GetRecordsBySearchByAccountName(string searchKey);
        DataTable GetRecordsBySearchByAccountNumberAndAccountName(string searchKey);
        DataTable GetMasterListFromMainDB();
        Dictionary<string, string> GetCustomerMeterDetails(string accountNumber);
        Dictionary<string, string> GetCustomerAccountDetails(string accountNumber);
        Dictionary<string, string> GetBillingDetails(string accountNumber);


        string GetAverageConsumption(string accountNumber);
        string GetPreviousReading(string accountNumber);
        string GetPresentReading(string accountNumber);
        string GetPreviousConsumption(string accountNumber);
        string GetPresentConsumption(string accountNumber);
        string GetConsumptionUponDisconnection(string accountNumber);




    }
}
