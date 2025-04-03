using JOMonitoringApp.Interface;

namespace JOMonitoringApp
{
    internal interface IPermissions : IRepository<PermissionsModel>
    {
        bool CheckPermission(string permissionName);
        bool CheckPermission(string permissionName, int userId);
        bool CheckPermission(string permissionName, string userName);
        bool CheckPermission(string permissionName, string userName, int roleId);
        bool CheckPermission(string permissionName, string userName, int roleId, int id);
    }
}