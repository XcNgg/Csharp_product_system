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
    public partial class Logistics_Department : Form
    {

        private static string ClientName = "无";
        private static int OrderId = -1;


        public Logistics_Department()
        {
            InitializeComponent();

        }


        private void Opposite()
        {
            this.toolStripButton2.Enabled = !this.toolStripButton2.Enabled;
            this.cbxItemState.Enabled = !this.cbxItemState.Enabled;
            this.button2.Enabled = !this.button2.Enabled;
            this.button3.Enabled = !this.button3.Enabled;
            this.toolStripButton1.Enabled = !this.toolStripButton1.Enabled;
            this.toolStripSplitButton1.Enabled = !this.toolStripSplitButton1.Enabled;

        }//至反

        private void RefreshTXT()
        {
            this.toolStripLabel6.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.button5.Enabled = false;

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
            this.button6.Text = "修改";
            this.toolStripButton1.Enabled = true;
            this.toolStripSplitButton1.Enabled = true;

        }//刷新状态

        private void SelectData()
        {

            if (OrderId > 0)
            {
                SelectOrderDetail();

                string sqlselectdata = "select Order_info.ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail,OrderState,OrderData,PlannedDate,DeliveryDate,OrderNotes from Order_info,Client where OrderId=" + OrderId + " and Order_info.ClientName=Client.ClientName";
                DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselectdata, null);

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



        private void From物控部_Load(object sender, EventArgs e)

        {

            string selectmax2 = "SELECT COUNT(OrderId) FROM Order_info;";
            DataSet db2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, selectmax2, null);
            int infomax = Convert.ToInt16(db2.Tables[0].Rows[0][0].ToString());
            OrderId = infomax;
            RefreshTXT();//刷新状态
            SelectData();//获取数据


            this.dataGridView1.ReadOnly = true;//只读
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
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

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {

            RefreshTXT();//刷新状态
            SelectData();//获取数据
            this.dataGridView1.ReadOnly = true;//只读
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.cbxItemState.SelectedItem.ToString() != "已发货")
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
                else
                {
                    MessageBox.Show("已发货禁止修改！");
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("请选择订单！");
               
            }
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            if (OrderId > 0)
            {
                if (this.label19.Text != "mark")
                {
                    if (this.cbxItemState.SelectedItem.ToString() == "已发货")
                    {
                        if (ProductDelivery(int.Parse(this.label19.Text)) == true)
                        {
                            string sqlupdate = "update OrderDetail set ItemState='" + this.cbxItemState.Text + "' where OrderId=" + OrderId + " and Mark=" + int.Parse(this.label19.Text) + ";";
                            try
                            {
                                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {

                        }

                        RefreshTXT();//刷新状态
                        SelectData();//获取数据
                    }
                    else
                    {
                        //string sqlupdate = "update OrderDetail set ItemState='" + this.cbxItemState.Text + "' where OrderId=" + OrderId + " and Mark=" + int.Parse(this.label19.Text) + ";";
                        string sqlupdate = "update OrderDetail set ItemState='" + this.cbxItemState.Text + "' where OrderId=" + OrderId +  ";";
                        try
                        {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    RefreshTXT();//刷新状态
                    SelectData();//获取数据
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

        private bool ProductDelivery(int mark)
        {
            //select [OrderDetail].ItemNo as 货号,ProductName as 产品名称, Description as 详细信息,OrderNumber as 订单数量,ProductNumber as 库存数量, Quantity as 单价,ItemState as 货物状态,Mark as 标识 from [OrderDetail],[Product] where OrderId=" + OrderId + " and [OrderDetail].ItemNo=[Product].ItemNo;";


            string sqlselect = "select OrderDetail.ItemNo as 货号,OrderNumber as 订单数量,ProductNumber as 库存数量 from OrderDetail,Product where  Mark=" + mark + " and OrderDetail.ItemNo=Product.ItemNo;";
            DataSet da = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            string ItemNo = da.Tables[0].Rows[0][0].ToString();
            int OrderNumber = int.Parse(da.Tables[0].Rows[0][1].ToString());
            int ProductNumber = int.Parse(da.Tables[0].Rows[0][2].ToString()); ;
            int ProductNew = ProductNumber - OrderNumber;
            if (ProductNew > 0)
            {
                string sqlupdate = "update Product set ProductNumber=" + ProductNew + " where ItemNo=" + ItemNo + ";";
                try
                {
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return true;
            }
            else
            {
                MessageBox.Show("库存不足");
                return false;
            }

        }





        private void button3_Click(object sender, EventArgs e)
        {
            RefreshTXT();//刷新状态
            SelectData();//获取数据
            this.dataGridView1.ReadOnly = true;//只读
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

        private void 新增物料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
              Form a = new Add.AddProduct(0, "无");
              a.ShowDialog();
        }

        private void 查询物料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form a = new Select.SelectProduct();
            a.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (OrderId > 0)
            {
                this.cbxOrderState.Enabled = !this.cbxOrderState.Enabled;
                this.dtpDeliveryDate.Enabled = !this.dtpDeliveryDate.Enabled;
                this.toolStripButton2.Enabled = !this.toolStripButton2.Enabled;
                this.toolStripButton1.Enabled = !this.toolStripButton1.Enabled;
                this.toolStripSplitButton1.Enabled = !this.toolStripSplitButton1.Enabled;
                this.button4.Enabled = !this.button4.Enabled;
                this.button5.Enabled = !this.button5.Enabled;

                if (this.cbxOrderState.Enabled == true)
                {
                    this.button6.Text = "退出修改模式";
                }
                else
                {
                    this.button6.Text = "修改";
                }

            }
            else { MessageBox.Show("请选择订单"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (OrderId > 0)
            {
                string sqlupdate = "update Order_info set OrderState='" + this.cbxOrderState.SelectedItem.ToString() + "',DeliveryDate='" + this.dtpDeliveryDate.Value.ToString() + "' where OrderId=" + OrderId + ";";
                try
                {
                    MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshTXT();//刷新状态
                SelectData();//获取数据

            }
            else
            {
                MessageBox.Show("请输入正确的订单号");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshTXT();//刷新状态
            SelectData();//获取数据
            this.dataGridView1.ReadOnly = true;//只读
        }

        private void 产品入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form a = new ProductStorage();
            a.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            AllOrder all =new AllOrder();
            all.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }
    }
}
