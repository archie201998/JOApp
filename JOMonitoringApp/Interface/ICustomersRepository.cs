using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface ICustomersRepository : IRepository<CustomersModel>
    {
        int GetLastInsertedID(int userId);
        DataTable GetCustomersName(string searchKey);
    }
}
