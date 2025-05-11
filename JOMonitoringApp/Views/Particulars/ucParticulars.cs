using AccountingSystem;
using System;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Particulars
{
    public partial class ucParticulars : UserControl
    {
        public ucParticulars()
        {
            InitializeComponent();
        }

        private void ucParticulars_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                txtBoxParticular.CausesValidation = false;
            }

        }

        private bool ValidateTextBox(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                Helper.ShowErrorTextBoxEmpty(errorProvider1, textBox, fieldName);
                return false;
            }
            else
            {
                Helper.ClearErrorTextBox(errorProvider1, textBox);
                return true;
            }
        }

        public bool ValidateChildren()
        {
            bool isValid = true;
            if (!ValidateTextBox(txtBoxParticular, "Particular"))
            {
                isValid = false;
            }
            return isValid;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtBoxParticular),
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

    }
}
