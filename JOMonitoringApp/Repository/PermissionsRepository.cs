using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    internal class PermissionsRepository : IPermissions
    {
        private GenericCommands mySqlGenericCommands;
        private object tableName = "tbl_permissions";

        public PermissionsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool CheckPermission(string permissionName)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckPermission(string permissionName, int userId)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckPermission(string permissionName, string userName)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckPermission(string permissionName, string userName, int roleId)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckPermission(string permissionName, string userName, int roleId, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<PermissionsModel> entityList)
        {
            throw new System.NotImplementedException();
        }
      
        public string GetDescriptionByPermissionName(string selectedPermission)
        {
            var parameters = new object[][]
            {
                new object[] { "@permission", DbType.String, selectedPermission }
            };

            string query = $"SELECT description FROM {tableName} WHERE permission = @permission";
            
            return mySqlGenericCommands.ExecuteScalar(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            DataTable dataTable = new DataTable();
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

        public bool Insert(PermissionsModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(PermissionsModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}