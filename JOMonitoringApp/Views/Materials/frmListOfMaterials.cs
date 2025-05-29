using AccountingSystem;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.IO;
using JOMonitoringApp.Views.Materials;
using System.Drawing;


namespace JOMonitoringApp.Views.MainForm
{
    public partial class frmListOfMaterials : Form
    {


        public frmListOfMaterials()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            CreateMaterialsColumns(dgMaterials);
            Helper.DatagridFullRowSelectStyle(dgMaterials);
        }


        private void CreateMaterialsColumns(DataGridView dataGrid)
        {
            dataGrid.ColumnCount = 5;
            dataGrid.Columns[0].Name = "id";
            dataGrid.Columns[1].Name = "item_no";
            dataGrid.Columns[2].Name = "item_name";
            dataGrid.Columns[3].Name = "in_stock";
            dataGrid.Columns[4].Name = "is_inventory_item";
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.Columns["id"].Visible = false;
            dataGrid.Columns["item_no"].HeaderText = "Item No.";
            dataGrid.Columns["item_name"].HeaderText = "Item Name";
            dataGrid.Columns["in_stock"].HeaderText = "In Stock";
            dataGrid.Columns["is_inventory_item"].HeaderText = "Inventory Item";
            dataGrid.Columns["in_stock"].DefaultCellStyle.Format = "N2";

            dataGrid.Columns["in_stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGrid.Columns["is_inventory_item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGrid.Columns["item_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void frmListOfMaterials_Load(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadMaterials()
        {
            dgMaterials.Rows.Clear();
            //int itemId = (int)dgMaterials.SelectedCells[0].Value;
            DataTable dtMaterials = Factory.MaterialsRepository().GetAllMaterials();
            foreach (DataRow item in dtMaterials.Rows)
            {
                int materialsId = (int)item["id"];
                string itemNo = item["item_no"].ToString();
                string itemName = item["item_name"].ToString();
                decimal inStock = (decimal)item["in_stock"];
                string isInventoryItem = item["is_inventory_item"].ToString();

                dgMaterials.Rows.Add(materialsId, itemNo, itemName, inStock, isInventoryItem);
            }
        }

        private void SearchMaterials()
        {
            dgMaterials.Rows.Clear();
            string searchText = txtSearch.Text.Trim();
            DataTable dtMaterials = Factory.MaterialsRepository().SearchMaterials(searchText);
            foreach (DataRow item in dtMaterials.Rows)
            {
                int materialsId = (int)item["id"];
                string itemNo = item["item_no"].ToString();
                string itemName = item["item_name"].ToString();
                decimal inStock = (decimal)item["in_stock"];
                string isInventoryItem = item["is_inventory_item"].ToString();
                dgMaterials.Rows.Add(materialsId, itemNo, itemName, inStock, isInventoryItem);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 3)
            {
                SearchMaterials();
            }
        }

        private void btnImportFile_Click_1(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application excelApp;
            Microsoft.Office.Interop.Excel.Workbook excelWB;
            Microsoft.Office.Interop.Excel.Worksheet excelWS;
            Microsoft.Office.Interop.Excel.Range excelRange;

            int excelRow= 0;
            openFileDialog1.Filter = "Excel Office | *.xls; *xlsx";
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;

            if (fileName != "")
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelWB = excelApp.Workbooks.Open(fileName);
                excelWS = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[1];
                excelRange = excelWS.UsedRange;

                int i = 0;

                for (excelRow = 2; excelRow <= excelRange.Rows.Count; excelRow++)
                {
                    i++;
                    Cursor.Current = Cursors.WaitCursor;
                    btnImportFile.Text = $"Importing ({i}) records...";   
                }

                btnImportFile.BackColor = Color.Green;
                btnImportFile.Text = "Save File";
                Cursor.Current = Cursors.Default;
                btnX.Visible = true;

                lblFileName.Text = $"{openFileDialog1.SafeFileName} ({i} records detected.)"; 
            }


            //_ = new frmImportMaterials().ShowDialog(this);
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            btnImportFile.Text = "Import File";
            btnImportFile.BackColor = Color.Red;
            lblFileName.Text = "No file selected.";
            btnX.Visible = false;
        }
    }
}
