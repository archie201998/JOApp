using AccountingSystem;
using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.JobOrder
{
    public partial class ucJoborder : UserControl
    {
        internal int jobOrderId = 0;
        internal int statusId = 1;
        internal bool isNewAccount = true;

        internal int accountId = 0;
        internal string accountNumber = string.Empty;
        internal string accountName = string.Empty;
        internal bool isUpdate = false;

        private Dictionary<string, object> originalValues = new Dictionary<string, object>();

        internal void StoreOriginalValues()
        {
            originalValues["AccountName"] = txtAccountName.Text;
            originalValues["Date"] = dtpDate.Value;
            originalValues["JONumber"] = txtJONumber.Text;
            originalValues["MRSNumber"] = txtMRSNumber.Text;
            originalValues["WARNumber"] = txtWARNumber.Text;
            originalValues["ORNumber"] = txtORNumber.Text;
            originalValues["Amount"] = nudAmount.Value;
            originalValues["MaterialsIssuedBy"] = cmbxMaterialsIssuedBy.SelectedValue;
            originalValues["AccomplishedBy"] = cmbxAccomplishedBy.SelectedValue;
            originalValues["Particulars"] = GetSelectedParticulars();
            originalValues["Remarks"] = txtRemarks.Text;
            originalValues["Status"] = statusId;
        }

        internal bool HasDataChanged()
        {
            try
            {
                bool hasChanges = false;
                if ((string)originalValues["AccountName"] != txtAccountName.Text)
                {
                    Helper.changes += $"Account Name: {originalValues["AccountName"].ToString()} into {txtAccountName.Text}; ";
                    hasChanges = true;
                }


                if ((DateTime)originalValues["Date"] != dtpDate.Value)
                {
                    Helper.changes += $"Date : {originalValues["Date"].ToString()} into {dtpDate.Text}; ";
                    hasChanges = true;
                }

                if ((string)originalValues["JONumber"] != txtJONumber.Text)
                {
                    Helper.changes += $"JO Number: {originalValues["JONumber"].ToString()} into {txtJONumber.Text}; ";
                    hasChanges = true;
                }

                if ((string)originalValues["MRSNumber"] != txtMRSNumber.Text)
                {
                    Helper.changes += $"MRS Number: {originalValues["MRSNumber"].ToString()} into {txtMRSNumber.Text}; ";
                    hasChanges = true;
                }


                if ((string)originalValues["WARNumber"] != txtWARNumber.Text)
                {
                    Helper.changes += $"WAR Number: {originalValues["WARNumber"].ToString()} into {txtWARNumber.Text}; ";
                    return true;
                }

                if ((string)originalValues["ORNumber"] != txtORNumber.Text)
                {
                    Helper.changes += $"OR Number: {originalValues["ORNumber"].ToString()} into {txtORNumber.Text}; ";
                    hasChanges = true;
                }

                if ((decimal)originalValues["Amount"] != nudAmount.Value)
                {
                    Helper.changes += $"Amount: {originalValues["Amount"].ToString()} into {nudAmount.Value}; ";
                    hasChanges = true;
                }


                if ((int?)originalValues["MaterialsIssuedBy"] != (int?)cmbxMaterialsIssuedBy.SelectedValue)
                {
                    Helper.changes += $"Materials Issued By: {originalValues["MaterialsIssuedBy"]?.ToString() ?? "null"} into {cmbxMaterialsIssuedBy.Text}; ";
                    return true;
                }


                if ((int?)originalValues["AccomplishedBy"] != (int?)cmbxAccomplishedBy.SelectedValue)
                {
                    Helper.changes += $"Accomplished By: {originalValues["AccomplishedBy"]?.ToString() ?? "null"} into {cmbxMaterialsIssuedBy.Text}; ";
                    hasChanges = true;
                }

                if ((string)originalValues["Particulars"] != GetSelectedParticulars())
                {
                    Helper.changes += $"Particulars: {originalValues["Particulars"].ToString()} into {GetSelectedParticulars()}; ";
                    hasChanges = true;
                }


                if ((string)originalValues["Remarks"] != txtRemarks.Text)
                {
                    Helper.changes += $"Remarks: {originalValues["Remarks"].ToString()} into {txtRemarks.Text}; ";
                    hasChanges = true;
                }


                if ((string)originalValues["Status"].ToString() != statusId.ToString())
                {
                    Helper.changes += $"Status: {originalValues["Status"].ToString()} into {Helper.StatusText(statusId)}; ";
                    hasChanges = true;
                }

                return hasChanges;
            }
            catch (Exception)
            {
                Helper.MessageBoxError("Error in checking changes.");
                return false;
            }
        }

        
        public ucJoborder()
        {
            if (!DesignMode)
            {
                InitializeComponent();
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtAccountName),
                errorProvider1.GetError(dtpDate),
                errorProvider1.GetError(txtJONumber),
                errorProvider1.GetError(txtMRSNumber),
                errorProvider1.GetError(txtWARNumber),
                errorProvider1.GetError(cmbxMaterialsIssuedBy),
                errorProvider1.GetError(cmbxAccomplishedBy),
                errorProvider1.GetError(clBoxParticulars),
                errorProvider1.GetError(txtRemarks),
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void OnLoad()
        {
            LoadParticular();
            LoadEmployee();
            cmbxMaterialsIssuedBy.SelectedIndex = -1;
            cmbxAccomplishedBy.SelectedIndex = -1;
        }

        private void LoadEmployee()
        {
            HelperLoadRecords.EmployeeCombobox(cmbxMaterialsIssuedBy, EmployeesDataTable(), "id", "full_name");
            HelperLoadRecords.EmployeeCombobox(cmbxAccomplishedBy, EmployeesDataTable(), "id", "full_name");
        }

        private DataTable EmployeesDataTable()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(object)),
                new DataColumn("full_name", typeof(string)),
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);

            var datable = Factory.UsersRepository().GetRecords();

            dataTable.Rows.Add(null, string.Empty);
            foreach (DataRow row in datable.Rows)
            {
                var newRow = dataTable.NewRow();
                string fullName = Helper.GenerateFullName(row["prefix"].ToString(), row["first_name"].ToString(), row["middle_name"].ToString(), row["last_name"].ToString(), row["suffix"].ToString());
                newRow["id"] = row["id"];
                newRow["full_name"] = fullName;
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        internal CustomersModel CustomersModel()
        {
            string accountNumber = txtAccountNumber.Text.Trim();
            string accountName = txtAccountName.Text.Trim();
            string accountAddress = txtAddress.Text.Trim();
            string contact = txtContact.Text.Trim();
            int createdBy = Helper.UserId;

            return new CustomersModel()
            {
                Id = isUpdate ? accountId : 0,
                AccountNumber = accountNumber,
                AccountName = accountName,
                Address = accountAddress,
                Contact = contact,
                CreatedBy = createdBy
            };
        }

        private string GetSelectedParticulars()
        {
            StringBuilder particularsBuilder = new StringBuilder();
            bool moreThanOneItem = clBoxParticulars.CheckedItems.Count > 1;

            foreach (var item in clBoxParticulars.CheckedItems)
            {
                particularsBuilder.Append($" {item.ToString()}");

                if (moreThanOneItem)
                    particularsBuilder.Append(" \\");
            }

            string particular = particularsBuilder.ToString().TrimEnd();
            if (moreThanOneItem) particular = particular.Substring(0, particular.Length - 2);

            return particular;
        }

        internal JOLogsModel JOLogsModel()
        {
            return new JOLogsModel()
            {
                TransactionEvent = Helper.LogMessage(isUpdate) ,
                DateAndTime = DateTime.Now,
                JobOrderId = jobOrderId == 0 ? Factory.JobOrdersRepository().GetLastInsertedID(Helper.UserId) : jobOrderId,
                UserId = Helper.UserId
            };
        }

        internal JobOrdersModel JobOrderModel()
        {
            string accountNumber = txtAccountNumber.Text;
            string accountName = txtAccountName.Text;
            string address = txtAddress.Text;
            string contact = txtContact.Text;
            string jobOrderNumber = txtJONumber.Text;
            DateTime date = dtpDate.Value;
            string orNumber = txtORNumber.Text;
            decimal amount = nudAmount.Value;
            string MRIS = txtMRISNumber.Text;
            string MRS = txtMRSNumber.Text;
            string WAR = txtWARNumber.Text;
            string remarks = txtRemarks.Text;
            int preparedById = Helper.UserId;
            int? materialsIssuedById = cmbxMaterialsIssuedBy.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbxMaterialsIssuedBy.SelectedValue);
            int? accomplishedBy = cmbxAccomplishedBy.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbxAccomplishedBy.SelectedValue);
            int statusId = this.statusId;
            string particular = GetSelectedParticulars();


            return new JobOrdersModel()
            {
                ID = jobOrderId,
                AccountNumber = accountNumber,
                AccountName = accountName,
                Address = address,
                ContactNumber = contact,    
                Particulars = particular,
                PreparedBy = preparedById,
                JONUmber = jobOrderNumber,
                Date = date,
                ORNumber = orNumber,
                Amount = amount,
                MRIS = MRIS,
                MRS = MRS,
                WAR = WAR,
                Remarks = remarks,
                MaterialsIssuedBy = materialsIssuedById == 0 ? null : materialsIssuedById,
                AccomplishedBy = accomplishedBy,
                StatusId = statusId,
                UserId = Helper.UserId
            };
        }

        internal void LoadParticular()
        {
            clBoxParticulars.Items.Clear();
            var dtAccoutnableForm = Factory.ParticularsRepository().GetRecords();

            foreach (DataRow item in dtAccoutnableForm.Rows)
            {
                clBoxParticulars.Items.Add(item["particular"].ToString());
            }
        }

        private void UcJoborder_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                txtAcc1.Focus();
            }
        }

        private void TxtWARNumber_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtWARNumber);
        }

        #region Validation

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAddress, "Address.");
        }

        private void txtAddress_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAddress);
        }

        private void TxtAccountName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccountName.Text))
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAccountName, "Account Name.");
            }
            e.Cancel = false;
        }

        private void TxtAccountName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAccountName);
        }

        private void TxtJONumber_Validating(object sender, CancelEventArgs e)
        {
            int joNumber = string.IsNullOrEmpty(txtJONumber.Text.Trim()) ? 0 : Convert.ToInt32(txtJONumber.Text.Trim());
            var doesExist = Factory.JobOrdersRepository().GetViewRecordsByJONumber(joNumber);

            if (doesExist.Count != 0 && isUpdate == false)
            {
                e.Cancel = Helper.ShowErrorDuplicateEntry(errorProvider1, txtJONumber, "J.O Number");
                return;
            }

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtJONumber, "J.O Number.");
        }

        private void TxtJONumber_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtJONumber);
        }
        private void TxtWARNumber_Validating(object sender, CancelEventArgs e)
        {
            if (radAccomplished.Checked)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtWARNumber, "WAR Number.");
            }
            return;
        }

        #endregion

        private void RadPending_CheckedChanged(object sender, EventArgs e)
        {
            statusId = Convert.ToInt16(radPending.Tag);
        }

        private void RadProcessing_CheckedChanged(object sender, EventArgs e)
        {
            statusId = Convert.ToInt16(radProcessing.Tag);
        }

        private void RadCancel_CheckedChanged(object sender, EventArgs e)
        {
            statusId = Convert.ToInt16(radCancel.Tag);
        }

        private void RadAccomplished_CheckedChanged(object sender, EventArgs e)
        {
            statusId = Convert.ToInt16(radAccomplished.Tag);
        }


        internal void BtnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmSearchAccount(this).ShowDialog();
        }


        private void NumberOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        internal void UcJoborder_KeyPress(object sender, KeyPressEventArgs e)
        {
            _ = new frmSearchAccount(this).ShowDialog();
        }

        private void cbxNA_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNA.Checked)
            {
                txtAccountNumber.Clear();

                txtAcc1.Clear();
                txtAcc2.Clear();
                txtAcc3.Clear();
                txtAcc4.Clear();


                txtAcc1.ReadOnly = true;
                txtAcc2.ReadOnly = true;
                txtAcc3.ReadOnly = true;
                txtAcc4.ReadOnly = true;

                txtAccountNumber.ReadOnly = true;
                return;
            }

            txtAccountNumber.ReadOnly = false;

            txtAcc1.ReadOnly = false;
            txtAcc2.ReadOnly = false;
            txtAcc3.ReadOnly = false;
            txtAcc4.ReadOnly = false;
        }

        private void cmbxAccomplishedBy_Validating(object sender, CancelEventArgs e)
        {
            if (radAccomplished.Checked || !string.IsNullOrEmpty(txtWARNumber.Text.Trim()) || cmbxAccomplishedBy.SelectedIndex == -1)
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxAccomplishedBy, "Accomplished By.");

            e.Cancel = false;
        }

        private void cmbxAccomplishedBy_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxAccomplishedBy);
        }

        private void cmbxMaterialsIssuedBy_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMRISNumber.Text.Trim()))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxMaterialsIssuedBy, "Issued By.");

            e.Cancel = false;
        }

        private void cmbxMaterialsIssuedBy_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxMaterialsIssuedBy);
        }

        private void txtAcc1_KeyDown(object sender, KeyEventArgs e)
        {
            //NumberOnly()
        }

        private void txtAcc3_TextChanged(object sender, EventArgs e)
        {
            string searchKey = $"{txtAcc1.Text}-{txtAcc2.Text}-{txtAcc3.Text}-{txtAcc4.Text}";

            var txtBox = sender as TextBox;

            if (txtAcc1.Text.Length == 3 && txtBox == txtAcc1)
                txtAcc2.Focus();
            else if (txtAcc2.Text.Length == 3 && txtBox == txtAcc2)
                txtAcc3.Focus();
            else if (txtAcc3.Text.Length == 3 && txtBox == txtAcc3)
                txtAcc4.Focus();
            else if (txtAcc4.Text.Length == 1 && txtBox == txtAcc4)
                txtAccountName.Focus();

            txtAccountNumber.Text = searchKey == "---" ? string.Empty : searchKey;

        }

        private void clBoxParticulars_Validating(object sender, CancelEventArgs e)
        {
            int selectedParticularCount = clBoxParticulars.CheckedItems.Count;

            if (selectedParticularCount == 0)
            {
                errorProvider1.SetError(clBoxParticulars, "No particular selected.");
                e.Cancel = true;
                return;
            }
            e.Cancel = false;
        }

        private void clBoxParticulars_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(clBoxParticulars, string.Empty);
        }

        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {
            if (statusId == 3)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtRemarks, "Remarks");
                return;
            }

            e.Cancel = false;
        }

        private void txtRemarks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtRemarks);
        }
    }
}
