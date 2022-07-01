using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductSystem
{
    public partial class Production_Department : Form
    {



        private static string ClientName = "无";

        private static int OrderId = -1;
        public Production_Department()
        {
            InitializeComponent();
        }


        private void Opposite()
        {
            this.toolStripButton2.Enabled = !this.toolStripButton2.Enabled;
            this.cbxItemState.Enabled = !this.cbxItemState.Enabled;
            this.button2.Enabled = !this.button2.Enabled;
            this.button3.Enabled = !this.button3.Enabled;

            this.txtItemNo.Enabled = !this.txtItemNo.Enabled;
            this.txtOrderNumber.Enabled = !this.txtOrderNumber.Enabled;
            this.txtQuantity.Enabled = !this.txtQuantity.Enabled;
            this.cbxItemState.Enabled = !this.cbxItemState.Enabled;
            this.txtProductName.Enabled = !this.txtProductName.Enabled;
            this.txtDescription.Enabled = !this.txtDescription.Enabled;
            this.cbxItemState.Enabled = !this.cbxItemState.Enabled;



        }//至反

        private void RefreshTXT()
        {
            this.toolStripLabel6.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;

            this.tostxtFind.Enabled = true;

            this.txtClientName.Enabled = false;
            this.txtClientAbbreviation.Enabled = false;
            this.txtClientContacts.Enabled = false;
            this.txtClientTelephone.Enabled = false;
            this.txtClientEmail.Enabled = false;
            this.txtClientAddress.Enabled = false;

            this.cbxOrderState.Enabled = false;
            this.dtpOrderData.Enabled = false;
            this.dtpPlannedDate.Enabled = false;
            this.dtpDeliveryDate.Enabled = false;
            this.txtOrderNotes.Enabled = false;

            this.txtItemNo.Enabled = false;
            this.txtOrderNumber.Enabled = false;
            this.txtQuantity.Enabled = false;
            this.cbxItemState.Enabled = false;
            this.txtProductName.Enabled = false;
            this.txtDescription.Enabled = false;
          
            SelectData();
            SelectOrderDetail();

            this.txtItemNo.Text = null;
            this.txtOrderNumber.Text = null;
            this.txtQuantity.Text = null;
            this.cbxItemState.Text = null;
            this.txtProductName.Text = null;
            this.txtDescription.Text = null;
            this.button1.Text = "修改";
            this.label19.Text = "mark";
           

        }//刷新状态

        private void SelectData()
        {

            if (OrderId > 0)
            {
                SelectOrderDetail();

                string sqlselectdata = "select Order_info.ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail,OrderState,OrderData,PlannedDate,DeliveryDate,OrderNotes from Order_info,Client where OrderId=" + OrderId + " and Order_info.ClientName=Client.ClientName";
                DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselectdata, null);

                try
                {
                    ClientName = db.Tables[0].Rows[0][0].ToString();
                    this.txtClientName.Text = db.Tables[0].Rows[0][0].ToString();
                    this.txtClientAbbreviation.Text = db.Tables[0].Rows[0][1].ToString();
                    this.txtClientContacts.Text = db.Tables[0].Rows[0][2].ToString();
                    this.txtClientTelephone.Text = db.Tables[0].Rows[0][3].ToString();
                    this.txtClientAddress.Text = db.Tables[0].Rows[0][4].ToString();
                    this.txtClientEmail.Text = db.Tables[0].Rows[0][5].ToString();
                    this.cbxOrderState.Text = db.Tables[0].Rows[0][6].ToString();
                    this.dtpOrderData.Text = db.Tables[0].Rows[0][7].ToString();
                    this.dtpPlannedDate.Text = db.Tables[0].Rows[0][8].ToString();
                    this.dtpDeliveryDate.Text = db.Tables[0].Rows[0][9].ToString();
                    this.txtOrderNotes.Text = db.Tables[0].Rows[0][10].ToString();
                }
                catch (Exception) {
                    ;
                }


            }
            else
            {
                
            }
        }//获取数据

        private void SelectOrderDetail()
        {
            string sqlselect = "select OrderDetail.ItemNo as 货号,ProductName as 产品名称, Description as 详细信息,OrderNumber as 订单数量,ProductNumber as 库存数量, Quantity as 单价,ItemState as 货物状态,Mark as 标识 from OrderDetail,Product where OrderId=" + OrderId + " and OrderDetail.ItemNo=Product.ItemNo;";
            DataSet da = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dataGridView1.DataSource = da.Tables[0];
        }//获取订单详细信息数据





        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void From生产部_Load(object sender, EventArgs e)
        {

            string selectmax2 = "SELECT COUNT(OrderId) FROM Order_info;";
            DataSet db2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, selectmax2, null);
            int infomax = Convert.ToInt16(db2.Tables[0].Rows[0][0].ToString());
            OrderId = infomax;

            RefreshTXT();//刷新状态
            SelectData();//获取数据
            SelectOrderDetail();
            string sqlselect = "select OrderDetail.ItemNo as 货号,ProductName as 产品名称, Description as 详细信息,OrderNumber as 订单数量,ProductNumber as 库存数量, Quantity as 单价,ItemState as 货物状态,Mark as 标识 from OrderDetail,Product where OrderId="+ OrderId+" and OrderDetail.ItemNo=Product.ItemNo;";
            DataSet da = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            if (da.Tables.Count > 0)
            {
                dataGridView1.DataSource = da.Tables[0];
            }

            string sqlselectdata = "select Order_info.ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail,OrderState,OrderData,PlannedDate,DeliveryDate,OrderNotes from Order_info,Client where OrderId=" + OrderId + " and Order_info.ClientName=Client.ClientName";
            DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselectdata, null);

            if (db.Tables.Count > 0)
            {
                ClientName = db.Tables[0].Rows[0][0].ToString();
                this.txtClientName.Text = db.Tables[0].Rows[0][0].ToString();
                this.txtClientAbbreviation.Text = db.Tables[0].Rows[0][1].ToString();
                this.txtClientContacts.Text = db.Tables[0].Rows[0][2].ToString();
                this.txtClientTelephone.Text = db.Tables[0].Rows[0][3].ToString();
                this.txtClientAddress.Text = db.Tables[0].Rows[0][4].ToString();
                this.txtClientEmail.Text = db.Tables[0].Rows[0][5].ToString();
                this.cbxOrderState.Text = db.Tables[0].Rows[0][6].ToString();
                this.dtpOrderData.Text = db.Tables[0].Rows[0][7].ToString();
                this.dtpPlannedDate.Text = db.Tables[0].Rows[0][8].ToString();
                this.dtpDeliveryDate.Text = db.Tables[0].Rows[0][9].ToString();
                this.txtOrderNotes.Text = db.Tables[0].Rows[0][10].ToString();
                try
                {
                    this.txtItemNo.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    this.txtOrderNumber.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    this.txtQuantity.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    this.cbxItemState.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    this.txtProductName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    this.txtDescription.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    this.label19.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                }
                catch (Exception ex) {
                    
                }
            }
            this.dataGridView1.ReadOnly = true;//只读
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            RefreshTXT();//刷新状态
            SelectData();//获取数据
            this.dataGridView1.ReadOnly = true;//只读
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = int.Parse(this.tostxtFind.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("请输入正确的订单号");
            }
            string sqlselectorder = "select * from Order_info where OrderId=" + id + ";";
            DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselectorder, null);
     


            if (db.Tables[0].Rows.Count > 0)
            {
                OrderId = int.Parse(db.Tables[0].Rows[0][0].ToString());
                RefreshTXT();//刷新状态
                SelectData();//获取数据

            }
            else
            {
                MessageBox.Show("未查询到此订单");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshTXT();//刷新状态
            SelectData();//获取数据
            this.dataGridView1.ReadOnly = true;//只读
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opposite();
            if (this.cbxItemState.Enabled == true)
            {
                this.button1.Text = "退出修改模式";
            }
            else
            {
                this.button1.Text = "修改";
                this.label19.Text = "mark";
            }

            

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (OrderId > 0)
            {
                this.txtItemNo.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.txtOrderNumber.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.txtQuantity.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                this.cbxItemState.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                this.txtProductName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.txtDescription.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.label19.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
            else { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OrderId > 0)
            {
                if (this.label19.Text != "mark")
                {
                    string sqlupdate = "update OrderDetail set ItemState='" + this.cbxItemState.Text + "' where OrderId=" + OrderId + " and Mark=" + int.Parse(this.label19.Text) + ";";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                        MessageBox.Show("修改成功！");
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    SelectOrderDetail();
                }
                else
                {
                    MessageBox.Show("请选择货物信息");
                }
            }
            else
            {
                MessageBox.Show("请输入正确的订单号");
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AllOrder all = new AllOrder();
            all.Show();
        }

        private void txtItemNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxItemState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
