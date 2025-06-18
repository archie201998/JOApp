using AccountingSystem;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace JOMonitoringApp.Views.MainForm
{
    public partial class frmListOfMaterials : Form
    {  
        private bool _toSave = false;
        Microsoft.Office.Interop.Excel.Application excelApp;
        Microsoft.Office.Interop.Excel.Workbook excelWB;
        Microsoft.Office.Interop.Excel.Worksheet excelWS;
        Microsoft.Office.Interop.Excel.Range excelRange;
        int excelRow = 0;


        public frmListOfMaterials()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            CreateMaterialsColumns(dgMaterials);
            Helper.DatagridFullRowSelectStyle(dgMaterials);
        }

        public void UpdateMasterList()
        {
            string apiKey = "dc8a5d065a9649a696c51324e8192dca";
            string baseUrl = "http://10.100.76.101:9000";
            string endpoint = "/api/v1/Items";
            string apiUrl = baseUrl + endpoint + "?size=0&skip=0";

            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";
            request.Headers["X-Api-Key"] = apiKey;

            string responseText = "";
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                responseText = reader.ReadToEnd();
            }

            var serializer = new JavaScriptSerializer();
            dynamic items = serializer.DeserializeObject(responseText);
            foreach (var item in items)
            {
                var itemDict = item as Dictionary<string, object>;
                if (itemDict == null) continue;

                var itemCode = Convert.ToString(itemDict["itemCode"]);
                var warehouses = itemDict["itemWarehouseInfoCollection"] as List<Dictionary<string, object>>;

                foreach (var warehouse in warehouses)
                {
                    string warehouseCode = Convert.ToString(warehouse["warehouseCode"]);

                    double inStock = Convert.ToDouble(warehouse["inStock"]);
                    double averagePrice = Convert.ToDouble(warehouse["standardAveragePrice"]);

                

                    //if (warehouseCode == "SUM-INV")
                    //{
             
                    //}
                }
            }

            MessageBox.Show("Item list successfully updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            HelperLoadRecords.DateImportedCombobox(cmbxImportDate);
            SearchMaterials();
        }

      

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadMaterials()
        {
            dgMaterials.Rows.Clear();
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

            txtRecordCount.Text = dgMaterials.Rows.Count.ToString();
        }

        private void SearchMaterials()
        {
            dgMaterials.Rows.Clear();
            string searchText = txtSearch.Text.Trim();
         
            //getting the id of date
            var drv = cmbxImportDate.SelectedItem as DataRowView;
            int dateImportedId = Convert.ToInt32(drv["id"]);

            DataTable dtMaterials = Factory.MaterialsRepository().SearchMaterials(searchText, dateImportedId);
            foreach (DataRow item in dtMaterials.Rows)
            {
                int materialsId = (int)item["id"];
                string itemNo = item["item_no"].ToString();
                string itemName = item["item_name"].ToString();
                decimal inStock = (decimal)item["in_stock"];
                string isInventoryItem = item["is_inventory_item"].ToString();
                dgMaterials.Rows.Add(materialsId, itemNo, itemName, inStock, isInventoryItem);
            }
            DataTable datatable = Factory.MaterialsRepository().GetAllMaterials();
            txtRecordCount.Text = datatable.Rows.Count.ToString();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchMaterials();
        }
       
        private void btnImportFile_Click_1(object sender, EventArgs e)
        {
            if (!_toSave)
                ImportFile();
            else
                SaveImportedFile();
        }

        private void SaveImportedFile()
        {
            if (Helper.MessageBoxConfirmCancel("Do you want to save imported data?"))
            {
                int i = 0;
                bool success = false;

                var currentDate = DateTime.Now;
                Factory.MaterialsRepository().InsertMaterialsImportDate(currentDate);
                int dateImportedId = Factory.MaterialsRepository().GetLastInsertedId();

                // Calculate total rows from the Excel range
                int totalRows = excelRange.Rows.Count - 1; // Subtract 1 to exclude the header row

                for (excelRow = 2; excelRow <= excelRange.Rows.Count; excelRow++)
                {
                    i++;
                    Cursor.Current = Cursors.WaitCursor;

                    var id = Convert.ToInt32(excelRange.Cells[excelRow, 1].Value);
                    var itemNo = (excelRange.Cells[excelRow, 2].Value.ToString());
                    var itemDesc = excelRange.Cells[excelRow, 3].Value;  
                    var inStock = Convert.ToDouble(excelRange.Cells[excelRow, 4].Value);
                    var isInventoryItem = excelRange.Cells[excelRow, 5].Value;

                    var materialsModel = new MaterialsModel()
                    {
                        Id = id,
                        ItemNo = itemNo,
                        ItemName = itemDesc,
                        InStock = inStock,
                        IsInventoryItem = isInventoryItem,
                        DateImportedId = dateImportedId,
                    };

                    success = Factory.MaterialsRepository().InsertImportedMaterials(materialsModel);

                    // Progress indicator
                    double percent = (double)i / totalRows * 100;
                    btnImportFile.Text = $"Saving... {percent:0}%";
                    btnImportFile.Refresh();
                }
                if (success)
                {
                    Helper.MessageBoxSuccess($"{i} records successfully imported.");
                    SearchMaterials();
                    ResetButton();
                }

                _toSave = false;
            }
           
        }

        private void ImportFile()
        {
 
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

            _toSave = true;
        }

        private void ResetButton()
        {
            btnImportFile.Text = "Import File";
            btnImportFile.BackColor = Color.Red;
            lblFileName.Text = "No file selected.";
            btnX.Visible = false;
            _toSave = false;
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            bool cancelImport = Helper.MessageBoxConfirmCancel("Do you want to cancel importing file?");
            if (cancelImport)
            {
                ResetButton();
            }
         
        }

        private void cmbxImportDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchMaterials();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateMasterList();
        }
    }
}
