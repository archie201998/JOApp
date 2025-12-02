using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model.GenericModel
{
    public class FilterModel
    {
        public string OrderBy { get; set; }
        public bool Descending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public int Limit => PageSize;
    }
}
