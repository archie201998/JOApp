using JOMonitoringApp.Interface;
using Microsoft.ReportingServices.Interfaces;
using System.Data;

namespace JOMonitoringApp
{
    internal interface IMaterials : IRepository<MaterialsModel>
    {
        DataTable GetAllMaterials();
        DataTable GetMaterialsById(int itemId);
        DataTable SearchMaterials(string searchText);
    }
}