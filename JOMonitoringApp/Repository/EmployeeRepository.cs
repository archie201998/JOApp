using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp.Repository
{
    public class EmployeeRepository : IEmployeesRepository
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_employee";

        public EmployeeRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, first_name, middle_name, last_name FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(EmployeeModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(EmployeeModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<EmployeeModel> entityList)
        {
            throw new NotImplementedException();
        }
    }
}
