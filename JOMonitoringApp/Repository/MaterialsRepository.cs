using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    internal class MaterialsRepository : IMaterials
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_materials";

        public MaterialsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<MaterialsModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
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

        public bool Insert(MaterialsModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(MaterialsModel entity)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetMaterialsById(int itemId)
        {
            return new DataTable();
        }

        public DataTable GetAllMaterials()
        {
            string query = $"SELECT id, item_no, material AS item_name, in_stock, is_inventory_item FROM {tableName} LIMIT 100";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable SearchMaterials(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_key", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE item_no LIKE @search_key OR  item_name LIKE @search_key LIMIT 30";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}