using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface IUsersRepository : IRepository<UsersModel>
    {
        Dictionary<string, string> GetRecordsbyUserName(string userName);
        int GetUserRoleId(byte userId);
        bool HasPermission(byte userId, string permissionName);
        Byte ValidateLogin(string userName, string password);
    }
}
