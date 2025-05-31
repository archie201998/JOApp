using JOMonitoringApp.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace JOMonitoringApp
{
    internal class MaterialsRepository : IMaterials
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_materials";

        //temporary approach
        private readonly string tableFSTappingDefaultMaterials = "tbl_tapping_materials";

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
            string query = $"SELECT id, item_no, item_name, in_stock, is_inventory_item FROM {tableName} LIMIT 100";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetMaterialsBySearch(string searchKey, bool inStocks)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
            };

            string stockFilter = inStocks ? $" AND in_stock > 0" : string.Empty;
           
            string query = $"SELECT id, item_no, item_name, in_stock, is_inventory_item FROM {tableName} WHERE (item_no LIKE @search_key OR item_name LIKE @search_key) {stockFilter}";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
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

        public DataTable GetTappingDefaultMaterials()
        {
            string query = $"SELECT * FROM {tableFSTappingDefaultMaterials}";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public bool InsertJOFSMaterials(MaterialsModel materialsModel)
        {
            var parameter = new object[][] {
                new object[]{"@item_name", DbType.String, materialsModel.ItemName},
            };

            string query = $"INSERT INTO {tableFSTappingDefaultMaterials} (item_name) VALUES (@item_name)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public bool RemoveJOFSMaterials(MaterialsModel materialsModel)
        {
            var parameter = new object[][] {
                new object[]{"@item_name", DbType.String, materialsModel.ItemName},
            };

            string query = $"DELETE FROM {tableFSTappingDefaultMaterials} WHERE item_name = @item_name";
                 
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter); 
          
        }
    }
}