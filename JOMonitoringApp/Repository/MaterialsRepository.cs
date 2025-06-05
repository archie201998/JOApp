using JOMonitoringApp.Repository;
using System;
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
            string query = $"SELECT id, item_no, item_name, in_stock, is_inventory_item FROM {tableName}";
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


        public DataTable SearchMaterials(string searchText, int dateImportedId)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_key", DbType.String, $"%{searchText}%"},
                new object[] { "@date_imported_id", DbType.Int32, dateImportedId }
            };

            string query = $"SELECT * FROM {tableName} WHERE (item_no LIKE @search_key OR item_name LIKE @search_key) AND imported_date_id = @date_imported_id LIMIT 200";
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
                new object[]{"@item_cost", DbType.String, materialsModel.StockPrice},
            };

            string query = $"INSERT INTO {tableFSTappingDefaultMaterials} (item_name, item_cost) VALUES (@item_name, @item_cost)";
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

        public bool InsertMaterialsImportDate(DateTime currentDate)
        {
            var parameter = new object[][] {
                new object[]{"@date_imported", DbType.DateTime, currentDate},
            };

            string query = $"INSERT INTO tbl_materials_import_date(date_imported) VALUES (@date_imported)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public DataTable GetImportedDates()
        {
            string query = $"SELECT id, date_imported FROM tbl_materials_import_date";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public int GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM tbl_materials_import_date";
            return int.Parse(mySqlGenericCommands.ExecuteScalar(query));
        }

        public bool InsertImportedMaterials(MaterialsModel materialsModel)
        {
            var parameter = new object[][] {
                new object[]{ "@item_no", DbType.String, materialsModel.ItemNo},
                new object[]{ "@item_name", DbType.String, materialsModel.ItemName},
                new object[]{ "@in_stock", DbType.Double, materialsModel.InStock},
                new object[]{ "@is_inventory_item", DbType.String, materialsModel.IsInventoryItem},
                new object[]{ "@imported_date_id", DbType.Int32, materialsModel.DateImportedId},
            };

            string query = $"INSERT INTO tbl_materials (item_no, item_name, in_stock, is_inventory_item, imported_date_id) VALUES (@item_no, @item_name, @in_stock, @is_inventory_item, @imported_date_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public double GetStockPrice(string itemText)
        {
            var parameter = new object[][] {
                new object[]{ "@item_name", DbType.String, itemText},
            };

            string query = $"SELECT item_cost FROM tbl_materials WHERE item_name = @item_name";
            return double.Parse(mySqlGenericCommands.ExecuteScalar(query, parameter));
        }

        public bool UpdateTappingMaterials(MaterialsModel materialsModel)
        {
            var parameter = new object[][] {
                new object[]{"@id", DbType.Int32, materialsModel.Id},
                new object[]{"@item_quantity", DbType.Double, materialsModel.InStock},
                new object[]{"@item_cost", DbType.Double, materialsModel.StockPrice },
            };

            string query = $"UPDATE tbl_tapping_materials SET  item_quantity = @item_quantity, item_cost = @item_cost WHERE id = @id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }
    }
}