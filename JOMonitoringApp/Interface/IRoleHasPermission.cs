using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using System.Data;

namespace JOMonitoringApp
{
    internal interface IRoleHasPermission : IRoleHasPermission<RoleHasPermissionModel>
    {
        DataTable GetPermissionsByRolesId(int selectedRoleId);
    }
}