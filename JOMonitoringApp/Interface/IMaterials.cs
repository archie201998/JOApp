using JOMonitoringApp.Interface;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Data;

namespace JOMonitoringApp
{
    internal interface IMaterials : IRepository<MaterialsModel>
    {
        DataTable GetAllMaterials();
        DataTable GetMaterialsById(int itemId);
        DataTable SearchMaterials(string searchText, int dateImportedId);
        DataTable GetTappingDefaultMaterials();
        DataTable GetMaterialsBySearch(string searchKey, bool inStock);
        bool InsertJOFSMaterials(MaterialsModel materialsModel);
        bool RemoveJOFSMaterials(MaterialsModel materialsModel);
        bool InsertMaterialsImportDate(DateTime currentDate);
        DataTable GetImportedDates();
        int GetLastInsertedId();
        bool InsertImportedMaterials(MaterialsModel materialsModel);
    }
}