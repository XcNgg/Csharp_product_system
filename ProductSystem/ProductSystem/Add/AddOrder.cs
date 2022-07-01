using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductSystem.Add
{
    public partial class AddOrder : Form
    {

        private static int OrderId = -1;//订单ID
        public AddOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlClient = "select ClientName from Client where ClientName='" + this.txtClientName.Text + "';";
            DataSet da = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlClient, null);
            if (da.Tables[0].Rows.Count>0)
            {
            
                string sqlorderid = "select OrderId from Order_info";
                DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlorderid, null);
                OrderId = db.Tables[0].Rows.Count + 1;


            string sqlinsert = "insert into Order_info (ClientName,OrderState,OrderData,PlannedDate,OrderNotes) values ('"+this.txtClientName.Text+"','"+this.cbxOrderState.SelectedItem.ToString()+"','"+ this.dtpOrderData.Value.ToString()+"','"+ this.dtpPlannedDate.Value.ToString()+"','"+this.txtOrderNotes.Text+"');";
                try
                {
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlinsert, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
                {
                    int ItemNo = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    int OrderNumber = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    int Quantity = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    string ItemState = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    //    int ItemNo =int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
                    //int OrderNumber = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    //int Quantity = int.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString());
                    //string ItemState = dataGridView1.Rows[0].Cells[3].Value.ToString();

                    string sqlinsertOrderDetail = "insert into OrderDetail(OrderId,ItemNo,OrderNumber,Quantity,ItemState) values(" + OrderId + "," + ItemNo + "," + OrderNumber + "," + Quantity + ",'" + ItemState + "');";


                try
                {
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlinsertOrderDetail, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

            MessageBox.Show("添加成功！");


            }
            else
            {
                MessageBox.Show("请确认客户是否存在！");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();


        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
