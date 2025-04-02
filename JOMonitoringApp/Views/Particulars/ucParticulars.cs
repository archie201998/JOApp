using AccountingSystem;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                textBox1.CausesValidation = false;
                textBox2.CausesValidation = false;
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
            if (!ValidateTextBox(textBox1, "Particular"))
            {
                isValid = false;
            }
            if (!ValidateTextBox(textBox2, "Description"))
            {
                isValid = false;
            }
            return isValid;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(textBox1),
                errorProvider1.GetError(textBox2),
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

    }
}
