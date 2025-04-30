using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.JobOrder;
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
                lblEditorID.Text = $"Role ID : {selectedRoleId} ";

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
                string permission = row["permission"].ToString();
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

            if (Helper.MessageBoxConfirmCancel("Do you want to modify user role's permission(s)?"))
            {
                using (var scope = new TransactionScope())
                {
                    // Get the selected role ID
                    int roleId = Convert.ToInt32(dgvRoles.SelectedRows[0].Cells["id"].Value);

                    Factory.RoleHasPermissionRepository().DeleteRolePermissions(roleId);
                   
                    foreach (var item in clbPermissions.CheckedItems)
                    {
                        int permissionId = Factory.Permissions().GetPermissionIdByName(item.ToString());

                        bool insertRes = Factory.RoleHasPermissionRepository().Insert(RoleHasPermissionModel(selectedRoleId, permissionId));

                        if (!insertRes)
                        {
                            Helper.MessageBoxSuccess("Something went wrong. Please Contact your system administrator.");
                        }
                    }

                    Helper.MessageBoxSuccess("Role's permission(s) has been successfully updated. Please restart the system of the specific user role.");
                    LoadPermissions();
                    MarkPermissions();
                    scope.Complete();
                }
            
            }
        }

        private RoleHasPermissionModel RoleHasPermissionModel(int selectedRoleId, int permissionId)
        {

            RoleHasPermissionModel roleHasPermissionModel = new RoleHasPermissionModel();
            roleHasPermissionModel.RoleId = selectedRoleId;
            roleHasPermissionModel.PermissionId = permissionId;

            return roleHasPermissionModel;
        }


        private void clbPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
