using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Investigation;
using K4os.Compression.LZ4.Encoders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports.SROF
{
    public partial class frmJOFSTappignMaterials : Form
    {
        internal string _jobOrderNumber = string.Empty;
        public frmJOFSTappignMaterials()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgJOTappingMaterials);
            CreateTappingMaterialsColumns(dgJOTappingMaterials);
            Helper.LoadFormIcon(this);
        }

        private void CreateTappingMaterialsColumns(DataGridView dataGrid)
        {
            dataGrid.ReadOnly = false; 
            dataGrid.DefaultCellStyle.Font = new Font("Segiou", 8);
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segiou", 8, FontStyle.Regular);

            dataGrid.ColumnCount = 4;
            dataGrid.Columns[0].Name = "id";
            dataGrid.Columns[1].Name = "item_name";
            dataGrid.Columns[2].Name = "item_quantity";
            dataGrid.Columns[3].Name = "item_cost";

            dataGrid.Columns["id"].ReadOnly = true;
            dataGrid.Columns["item_name"].ReadOnly = true;
            dataGrid.Columns["item_cost"].ReadOnly = true;
            dataGrid.Columns["item_quantity"].ReadOnly = false;


            dataGrid.Columns["item_name"].HeaderText = "ITEM NAME";
            dataGrid.Columns["item_quantity"].HeaderText = "ITEM QTY";
            dataGrid.Columns["item_cost"].HeaderText = "ITEM COST";
            dataGrid.Columns["id"].Visible = false;
            dataGrid.Columns["item_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid.Columns["item_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns["item_quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            _ = new frmEstimateOfMaterials(_jobOrderNumber).ShowDialog();
        }

        private void frmJOFSTappignMaterials_Load(object sender, EventArgs e)
        {
            LoadMaterials();
            LoadDefaultMaterials();
        }

        private void LoadMaterials()
        {
            clbMaterials.Items.Clear();
            string searchKey = txtSearch.Text.Trim();
            bool inStock = cbxInStock.Checked;

            DataTable dtMaterials = Factory.MaterialsRepository().GetMaterialsBySearch(searchKey, inStock);

            foreach (DataRow item in dtMaterials.Rows)
            {
                clbMaterials.Items.Add(item["item_name"].ToString());
            }

            lblStockLeft.Text = dtMaterials.Rows.Count.ToString();
        }

        private void LoadDefaultMaterials()
        {
            dgJOTappingMaterials.Rows.Clear();
            var dtFSTappingDefaultMaterials = Factory.MaterialsRepository().GetTappingDefaultMaterials();

            foreach (DataRow item in dtFSTappingDefaultMaterials.Rows)
            {
                int materialsId = (int)item["id"];
                string itemName = item["item_name"].ToString();
                string itemQty = item["item_quantity"].ToString();
                string itemCost = item["item_cost"].ToString();

                dgJOTappingMaterials.Rows.Add(materialsId, itemName, itemQty, itemCost);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMaterials();
        }
        private void clbMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlreadyOnList())
            {

            }
        }

        private bool AlreadyOnList()
        {   

            return true;
        }

        

        private void clbMaterials_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string itemText = clbMaterials.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                Factory.MaterialsRepository().InsertJOFSMaterials(
                    new MaterialsModel() {ItemName = itemText, StockPrice = Factory.MaterialsRepository().GetStockPrice(itemText) }
                );
            }
            else
            {
                foreach (DataGridViewRow row in dgJOTappingMaterials.Rows)
                {
                    if (row.Cells[1].Value.ToString() == itemText)
                    {
                        bool res = Factory.MaterialsRepository().RemoveJOFSMaterials(new MaterialsModel() { ItemName = itemText });
                    }
                }
            }
            LoadDefaultMaterials();
        }

        private void dgJOTappingMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex].Name == "item_quantity")
            {
                try
                {
                    DataGridViewRow row = grid.Rows[e.RowIndex];
                    string id = row.Cells["id"].Value?.ToString();

                    string qtyText = grid.Rows[e.RowIndex].Cells["item_quantity"].Value?.ToString();
                    string unitText = grid.Rows[e.RowIndex].Cells["item_cost"].Value?.ToString();
                    decimal itemCost = Convert.ToDecimal(unitText);
                    if (decimal.TryParse(qtyText, out decimal quantity))
                    {
                        decimal totalCost = (quantity * itemCost) + (itemCost * Helper.DefaultMarkup); //with markup
                        //decimal totalCost = quantity * itemCost; //without markup
                        grid.Rows[e.RowIndex].Cells["item_cost"].Value = totalCost.ToString("N2");

                        var a = Factory.MaterialsRepository().UpdateTappingMaterials(new MaterialsModel
                        {
                            Id = Convert.ToInt32(id),
                            ItemName = row.Cells["item_name"].Value.ToString(),
                            InStock = Convert.ToDouble(qtyText),
                            StockPrice = Convert.ToDouble(totalCost)
                        });
                    }
                }
                catch (Exception ex)
                {
                    //Helper.MessageBoxSuccess($"Error calculating cost: {ex.Message}");
                }
            }


        }

        private void UpdateDefaultTappingMaterials()
        {
            //List<MaterialsModel> materialsList = new List<MaterialsModel>();
            //foreach (DataGridViewRow row in dgJOTappingMaterials.Rows)
            //{
            //    if (row.Cells["id"].Value != null && row.Cells["item_name"].Value != null && row.Cells["item_quantity"].Value != null)
            //    {
            //        materialsList.Add(new MaterialsModel
            //        {
            //            Id = Convert.ToInt32(row.Cells["id"].Value),
            //            ItemName = row.Cells["item_name"].Value.ToString(),
            //            q = Convert.ToDecimal(row.Cells["item_quantity"].Value),
            //            StockPrice = Convert.ToDecimal(row.Cells["item_cost"].Value)
            //        });
            //    }
            //}
            //Factory.MaterialsRepository().UpdateDefaultTappingMaterials(materialsList);
            //Helper.MessageBoxSuccess("Default Tapping Materials updated successfully.");
        }

        private void clbMaterials_ImeModeChanged(object sender, EventArgs e)
        {

        }
    }
}
