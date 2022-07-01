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
    public partial class SelectClient : Form
    {
        private static string ClientName = "无";

        public SelectClient()
        {
            InitializeComponent();
        }


        private void SelectClientdata()
        {

            string sqlselectdata = "select ClientId as'客户ID',ClientName as '客户名称',ClientAbbreviation as'客户简称',ClientContacts as'联系人',ClientTelephone as'电话',ClientAddress as'地址', ClientEmail as'邮件' from Client ";
                DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselectdata, null);

                this.dataGridView1.DataSource = db.Tables[0];
               // ClientName = db.Tables[0].Rows[0][0].ToString();

                this.txtClientName.Text = null;
                this.txtClientAbbreviation.Text = null;
                this.txtClientContacts.Text = null;
                this.txtClientTelephone.Text = null;
                this.txtClientAddress.Text = null;
                this.txtClientEmail.Text = null;

         
        }//获取数据



        private void button5_Click(object sender, EventArgs e)
        {
            if (this.txtClientName.Text == null || this.txtClientName.Text == "")
            {
                MessageBox.Show("请选择需要修改客户");
            }
            else
            {
                ClientName = this.txtClientName.Text;
            Form a = new Add.AddClient(1, ClientName);
            a.ShowDialog();
            SelectClientdata();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            Form a = new Add.AddClient(0, "无");
            a.ShowDialog();
            SelectClientdata();
        }

        private void SelectClient_Load(object sender, EventArgs e)
        {
            SelectClientdata();
            this.txtClientName.Enabled = false;
            this.txtClientAbbreviation.Enabled = false;
            this.txtClientContacts.Enabled = false;
            this.txtClientTelephone.Enabled = false;
            this.txtClientEmail.Enabled = false;
            this.txtClientAddress.Enabled = false;
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

           

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtClientName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtClientAbbreviation.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtClientContacts.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtClientTelephone.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.txtClientAddress.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            this.txtClientEmail.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }
    }
}
