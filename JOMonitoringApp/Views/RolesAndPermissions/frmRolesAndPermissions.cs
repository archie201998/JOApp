using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.RolesAndPermissions
{
    public partial class frmRolesAndPermissions : Form
    {
        public frmRolesAndPermissions()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgvRoles);
        }

        private void frmRolesAndPermissions_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void LoadRoles()
        {
            var dtRoles = new DataTable();
            dtRoles = Factory.RolesRepository().GetRecords();
            
            HelperLoadRecords.RolesDatagridView(dgvRoles, dtRoles);
        }

        private void dgRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                int selectedRoleId = Convert.ToInt32(dgvRoles.SelectedRows[0].Cells["id"].Value);
                LoadPermissions(selectedRoleId);
            }

        }

        private void LoadPermissions(int roleId)
        {
            // Fetch permissions based on roleId (Example: using a database or predefined list)
            DataTable permissions = Factory.Permissions().GetRecords();

            // Clear existing items
            clbPermissions.Items.Clear();

            // Populate checkedListBox with permissions
            foreach (DataRow row in permissions.Rows)
            {
                int id = Convert.ToInt32(row["id"]);    
                string permission = row["permission"].ToString();
                string description = row["description"].ToString();
                clbPermissions.Items.Add(permission);
            }
        }

        private void clbPermissions_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
