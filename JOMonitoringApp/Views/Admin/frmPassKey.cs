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

namespace JOMonitoringApp.Views.Admin
{
    public partial class frmPassKey : Form
    {
        public frmPassKey()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmPassKey_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;

                this.BeginInvoke((MethodInvoker)delegate
                {
                    this.SelectNextControl(currentTextBox, true, true, true, true);

                    // Check if all boxes are filled
                    if (AllBoxesFilled())
                    {
                        string pinEntered = GetPinFromBoxes();
                        string correctPin = "284628"; // <- Your predefined PIN

                        if (pinEntered == correctPin)
                        {
                            MessageBox.Show("PIN Verified!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Helper.temporaryAdminMode = true;
                            this.DialogResult = DialogResult.OK; // Set result
                            this.Close(); // Close the form

                        }
                        else
                        {
                            MessageBox.Show("Incorrect PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Helper.temporaryAdminMode = false;
                            textBox1.Focus();

                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox6.Clear();

                        }
                    }
                });
            }
        }

        private bool AllBoxesFilled()
        {
            return !string.IsNullOrEmpty(textBox1.Text)
                && !string.IsNullOrEmpty(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text)
                && !string.IsNullOrEmpty(textBox4.Text)
                && !string.IsNullOrEmpty(textBox5.Text)
                && !string.IsNullOrEmpty(textBox6.Text);
        }

        private string GetPinFromBoxes()
        {
            return textBox1.Text + textBox2.Text + textBox3.Text +
                   textBox4.Text + textBox5.Text + textBox6.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox current = sender as TextBox;

            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl(current, true, true, true, true);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.SelectNextControl(current, false, true, true, true);
                e.Handled = true;
            }
        }
    }
}
