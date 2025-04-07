using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using System.Data;

namespace JOMonitoringApp
{
    internal interface IRoleHasPermission : IRoleHasPermission<RoleHasPermissionModel>
    {
        bool DeleteRolePermissions(int selectedRoleId);
        DataTable GetPermissionsByRolesId(int selectedRoleId);

        bool RoleHasPermission(string permissionName, int userRoleId);
    }
}