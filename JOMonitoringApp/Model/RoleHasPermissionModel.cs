using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    internal class RoleHasPermissionModel
    {
        public int Id { get; set; }
        public string permission { get; set; }
        public string description { get; set; }
    }
}
