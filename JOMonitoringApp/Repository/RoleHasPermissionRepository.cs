using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace JOMonitoringApp
{
    internal class RoleHasPermissionRepository : IRoleHasPermission
    {
        private GenericCommands mySqlGenericCommands;
        private string tableName = "tbl_role_has_permissions";
        private string viewTableName = "view_role_has_permissions";

        public RoleHasPermissionRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<RoleHasPermissionModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteRolePermissions(int selectedRoleId)
        {
            var parameters = new object[][]
            {
                new object[] { "@roles_id", DbType.Int32, selectedRoleId},
            };

            string query = $"DELETE FROM {tableName} WHERE roles_id = @roles_id";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetPermissionsByRolesId(int selectedRoleId)
        {
            var parameters = new object[][] { new object[] { "@role_id", DbType.Int32, selectedRoleId } };
            string query = $"SELECT * FROM {viewTableName} WHERE role_id = @role_id";
            var dataTable = new DataTable();

            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(RoleHasPermissionModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@roles_id", DbType.String ,entity.RoleId },
                new object[] { "@permissions_id", DbType.String, entity.PermissionId }
            };

            string query = $"INSERT INTO {tableName} (roles_id, permissions_id) VALUES (@roles_id, @permissions_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool RoleHasPermission(string permissionName, int userRoleId)
        {
            var parameters = new object[][]
            {
                new object[] { "@role_id", DbType.Int32, userRoleId },
                new object[] { "@permission_name", DbType.String, permissionName }
            };

            string query = $"SELECT COUNT(*) FROM {viewTableName} WHERE permission_name = @permission_name AND role_id = @role_id";

            string result = mySqlGenericCommands.ExecuteScalar(query, parameters);

            return int.TryParse(result, out int count) && count > 0;
        }

        public bool Update(RoleHasPermissionModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}