using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProductSystem
{
    public partial class AllOrder : Form
    {

        public AllOrder()
        {
            InitializeComponent();
        }


        private void SelectSQLData()
        {
            string sqlselect = "select OrderId as 订单编号,ClientName as 客户名称,OrderData as 下单时间,PlannedDate as 预计交期,DeliveryDate as 发货时间,OrderState as 订单状态,OrderNotes as 备注 from Order_info";
            DataSet da = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dataGridView2.DataSource = da.Tables[0];
        }



        private void Homepage_Load(object sender, EventArgs e)
        {
            SelectSQLData();

           // this.label1.Text = "欢迎登陆系统  \n         加油！       打工人！";
            this.dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             int orderId = int.Parse(this.dataGridView2.CurrentRow.Cells[0].Value.ToString());

        }

        private void dataGridView2_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectSQLData();
        }
    }
}
