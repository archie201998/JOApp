using AccountingSystem;
using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.RolesAndPermissions
{
    public partial class frmRolesAndPermissions : Form
    {
        int selectedRoleId = 0;
        public frmRolesAndPermissions()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgvRoles);
        }

        private void frmRolesAndPermissions_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadPermissions();
            MarkPermissions();
            clbPermissions.ItemCheck += clbPermissions_ItemCheck;
        }

        private void LoadRoles()
        {
            var dtRoles = new DataTable();
            dtRoles = Factory.RolesRepository().GetRecords();
            
            HelperLoadRecords.RolesDatagridView(dgvRoles, dtRoles);
        }

        private void dgRoles_SelectionChanged(object sender, EventArgs e)
        {
            MarkPermissions();
        }

        private void MarkPermissions()
        {
            // Clear all checked items before marking new ones
            for (int i = 0; i < clbPermissions.Items.Count; i++)
                clbPermissions.SetItemChecked(i, false);

            if (dgvRoles.SelectedRows.Count > 0)
            {
                selectedRoleId = Convert.ToInt32(dgvRoles.SelectedRows[0].Cells["id"].Value);
                DataTable dtPermissions = Factory.RoleHasPermissionRepository().GetPermissionsByRolesId(selectedRoleId);

                foreach (DataRow row in dtPermissions.Rows)
                {
                    for (int i = 0; i < clbPermissions.Items.Count; i++)
                    {
                        if (clbPermissions.Items[i].ToString() == row["permission_name"].ToString())
                        {
                            clbPermissions.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }
        private void LoadPermissions()
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

                // Check if the permission is already assigned to the selected role
                //bool roleHasPermission = Factor

                if (selectedRoleId == 0)
                {

                }
                clbPermissions.Items.Add(permission);
            }
        }

        private void clbPermissions_SelectedValueChanged(object sender, EventArgs e)
        {
            if (clbPermissions.SelectedItem != null)
            {
                string selectedPermission = clbPermissions.SelectedItem.ToString();
                string description = Factory.Permissions().GetDescriptionByPermissionName(selectedPermission);
                lblPermissionDescription.Text = $"Description : {description}";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var scope = new TransactionScope())
            {
                // Get the selected role ID
                int selectedRoleId = dgvRoles.SelectedCells[0].RowIndex;
                bool deleteRes = Factory.RoleHasPermissionRepository().DeleteRolePermissions(selectedRoleId);

                if (deleteRes)
                {
                    //bool insertRoles = Factory.RoleHasPermissionRepository().Insert(RolesAndPermissionsModel(selectedRoleId));
                }

                scope.Complete();
            }
        }

        private void clbPermissions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string itemText = clbPermissions.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked)
            {
                btnSave.BackColor = Color.White;
                btnSave.Enabled = true;

            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                btnSave.BackColor = Color.DodgerBlue;
                btnSave.Enabled = true;
            }
        }

        private void clbPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
