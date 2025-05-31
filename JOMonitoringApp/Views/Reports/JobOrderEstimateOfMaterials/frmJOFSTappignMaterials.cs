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
            dataGrid.DefaultCellStyle.Font = new Font("Segiou", 8);
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segiou", 8, FontStyle.Regular);
            dataGrid.EnableHeadersVisualStyles = false;

            dataGrid.ColumnCount = 2;
            dataGrid.Columns[0].Name = "id";
            dataGrid.Columns[1].Name = "item_name";

            dataGrid.Columns["item_name"].HeaderText = "ITEM NAME";
            dataGrid.Columns["id"].Visible = false;
            dataGrid.Columns["item_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid.Columns["item_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            //load items in srof table
            //delete all
            //insert dayon. 

            _ = new frmEstimateOfMaterials(_jobOrderNumber).ShowDialog();
        }

        private void frmJOFSTappignMaterials_Load(object sender, EventArgs e)
        {
            //load materials from tbl_materials 
            //implement search function. 
            //dapat naka check na daan ang checkbox if naa na didto sa grid ang items. (check if same item_code)


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

                dgJOTappingMaterials.Rows.Add(materialsId, itemName);
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
                Factory.MaterialsRepository().InsertJOFSMaterials(new MaterialsModel() {ItemName = itemText});
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

        private void clbMaterials_MouseDown(object sender, MouseEventArgs e)
        {
          
        }
    }
}
