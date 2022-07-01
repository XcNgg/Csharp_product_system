using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductSystem.Select
{
    public partial class SelectProduct : Form
    {
        public SelectProduct()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form a = new Add.AddProduct(0, "无");
            a.ShowDialog();
        }

        private void SelectProduct_Load(object sender, EventArgs e)
        {
            this.txtDescription.Enabled = false;
            this.txtItemNo.Enabled = false;
            this.txtOrderNumber.Enabled = false;
            this.txtProductName.Enabled = false;
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                        this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            string sqlselectdata = "select ItemNo as'货号',ProductName as '产品名称',Description as'详细信息',ProductNumber as'数量' from Product;";
            DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselectdata, null);
            this.dataGridView1.DataSource = db.Tables[0];


        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtItemNo.Text == null || this.txtItemNo.Text == "")
            {
                MessageBox.Show("请选择产品货号");
            }
            else
            {
                Form a = new Add.AddProduct(1, this.txtItemNo.Text);
                a.ShowDialog();

                string sqlselectdata = "select ItemNo as'货号',ProductName as '产品名称',Description as'详细信息',ProductNumber as'数量' from Product;";
                DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselectdata, null);
                this.dataGridView1.DataSource = db.Tables[0];

            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtDescription.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtItemNo.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.txtOrderNumber.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtProductName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
