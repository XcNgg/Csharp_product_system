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
    public partial class Marketing_Department : Form
    {   
        private static int OrderId = -1;//订单ID

        private static int OrderDetail = 0;//详细信息修改状态，1为修改删除，0为添加
        private static int Mark = 0;//修改用标识
        private static string ClientName="无";

        public Marketing_Department()
        {

           
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Opposite()
        {
            this.toolStripLabel1.Enabled = !this.toolStripLabel1.Enabled;
            this.toolStripLabel2.Enabled = !this.toolStripLabel2.Enabled;
            this.toolStripButton1.Enabled = !this.toolStripButton1.Enabled;
            this.toolStripButton2.Enabled = !this.toolStripButton2.Enabled;
            this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;

            this.tostxtFind.Enabled = !this.tostxtFind.Enabled;

           // this.txtClientName.Enabled = !this.txtClientName.Enabled;
           // this.txtClientAbbreviation.Enabled = !this.txtClientAbbreviation.Enabled;
           // this.txtClientContacts.Enabled = !this.txtClientContacts.Enabled;
           // this.txtClientTelephone.Enabled = !this.txtClientTelephone.Enabled;
           // this.txtClientAddress.Enabled = !this.txtClientAddress.Enabled;
           // this.txtClientEmail.Enabled = !this.txtClientEmail.Enabled;

            this.cbxOrderState.Enabled = !this.cbxOrderState.Enabled;
            this.dtpOrderData.Enabled = !this.dtpOrderData.Enabled;
            this.dtpPlannedDate.Enabled = !this.dtpPlannedDate.Enabled;
            this.dtpDeliveryDate.Enabled = !this.dtpDeliveryDate.Enabled;
            this.txtOrderNotes.Enabled = !this.txtOrderNotes.Enabled;

            this.txtItemNo.Enabled =  !this.txtItemNo.Enabled;
            this.txtOrderNumber.Enabled =! this.txtOrderNumber.Enabled;
            this.txtQuantity.Enabled = !this.txtQuantity.Enabled;
            this.cbxItemState.Enabled = !this.cbxItemState.Enabled;

            this.txtDescription.Enabled = !this.txtDescription.Enabled;
            this.button1.Enabled = !this.button1.Enabled;
            this.button2.Enabled = !this.button2.Enabled;
            this.button3.Enabled = !this.button3.Enabled;
            this.button5.Enabled = !this.button3.Enabled;
 
        }//至反

        private void RefreshTXT()
        {
            this.toolStripLabel1.Enabled = true;
            this.toolStripLabel2.Enabled = true;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton2.Enabled = true;
            this.toolStripButton3.Enabled = false;
           
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
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button3.Visible = false;
            this.button4.Visible = false;
            
            SelectData();
            SelectOrderDetail();

            this.txtItemNo.Text = null;
            this.txtOrderNumber.Text = null;
            this.txtQuantity.Text = null;
            this.cbxItemState.Text = null;
            this.txtProductName.Text = null;
            this.txtDescription.Text = null;
            this.button1.Text = "添加";
            this.button5.Enabled = true;

        }//刷新状态

        private void SelectData()
        {
            if (OrderId > 0)
            {
                SelectOrderDetail();
                string sqlselectdata = "select Order_info.ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail,OrderState,OrderData,PlannedDate,DeliveryDate,OrderNotes from Order_info,Client where OrderId=" + OrderId+"  and Order_info.ClientName=Client.ClientName";
                DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselectdata, null);
                if (db.Tables[0].Rows.Count > 0)
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
                else {
                    MessageBox.Show("当前不存在订单信息");
                }

            }
        }//获取数据

        private void SelectOrderDetail()
        {   

            string sqlselect = "SELECT ad.ItemNo AS 货号, ProductName AS 产品名称, Description AS 详细信息,OrderNumber AS 订单数量,ProductNumber AS 库存数量,Quantity AS 单价,ItemState AS 货物状态,Mark AS 标识 FROM OrderDetail AS ad, Product AS pr WHERE OrderId = " + OrderId +"  AND ad.ItemNo = pr.ItemNo; ";
            DataSet da = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dataGridView1.DataSource = da.Tables[0];
        }//获取订单详细信息数据






        private void From市场部_Load(object sender, EventArgs e)
        {

            string selectmax2 = "SELECT COUNT(OrderId) FROM Order_info;";
            DataSet db2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, selectmax2, null);
            int infomax = Convert.ToInt16(db2.Tables[0].Rows[0][0].ToString());
            OrderId = infomax;

 
            RefreshTXT();//刷新状态
            SelectData();//获取数据
            this.dataGridView1.ReadOnly = true;//只读
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            button3.ForeColor = Color.White;
            button1.ForeColor = Color.White;
            button4.ForeColor = Color.White;
            button5.ForeColor = Color.White;
            button2.ForeColor = Color.White;

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }

        private void 修改订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (OrderId > 0)
            {
            Opposite();//至反

            this.txtItemNo.Enabled = !this.txtItemNo.Enabled;
            this.txtOrderNumber.Enabled = !this.txtOrderNumber.Enabled;
            this.txtQuantity.Enabled = !this.txtQuantity.Enabled;
            this.cbxItemState.Enabled = !this.cbxItemState.Enabled;
            this.txtDescription.Enabled = !this.txtDescription.Enabled;
            this.button1.Enabled = !this.button1.Enabled;
            this.button2.Enabled = !this.button2.Enabled;
            this.button3.Enabled = !this.button3.Enabled;
            this.button2.Enabled = false;
             this.button1.Enabled = false;
            }
             else
             {
                 MessageBox.Show("请选择订单");
             }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


            if (OrderId > 0)
            {

                //string sqlupdate = "update Order_info set ClientName='" + this.txtOrderClientName.Text + "',OrderState='" + this.cbxOrderState.SelectedItem.ToString() + "',OrderData='" + this.dtpOrderDate.Value.ToString() + "',PlannedDate='" + this.dtpPlannedDate.Value.ToString() + "',DeliveryDate='" + this.dtpDeliveryDate.Value.ToString() + "',OrderNotes='" + this.txtOrderNotes.Text + "' where OrderId=" + int.Parse(this.lblOrderID.Text) + ";";

                string sqlupdate = "update Order_info set OrderState='" + this.cbxOrderState.SelectedItem.ToString() + "',OrderData='" + this.dtpOrderData.Value.ToString() + "',PlannedDate='" + this.dtpPlannedDate.Value.ToString() + "',OrderNotes='" + this.txtOrderNotes.Text + "' where OrderId=" + OrderId + ";";
                try
                {
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                

            }
            else { MessageBox.Show("请选择订单！"); }
            Opposite();//至反
            this.txtItemNo.Enabled = !this.txtItemNo.Enabled;
            this.txtOrderNumber.Enabled = !this.txtOrderNumber.Enabled;
            this.txtQuantity.Enabled = !this.txtQuantity.Enabled;
            this.cbxItemState.Enabled = !this.cbxItemState.Enabled;
            this.txtDescription.Enabled = !this.txtDescription.Enabled;
            this.button1.Enabled = false;
            this.button2.Enabled = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            RefreshTXT();//刷新状态
           
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            RefreshTXT();//刷新状态
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
            }
            else { }



        }//双击获取详细信息

        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Text = "保存";
            this.button3.Text = "删除";
            this.button3.Visible = true;
            this.button2.Enabled = false;
            this.button4.Visible = true;
            Mark =int.Parse( this.dataGridView1.CurrentRow.Cells[7].Value.ToString());//获取修改标识

            OrderDetail = 1;//获取修改状态

        }

        private void 修改订单详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OrderId > 0)
            {
                Opposite();//至反
                this.button1.Enabled = true;
                this.button1.Enabled = true;
                this.cbxOrderState.Enabled = !this.cbxOrderState.Enabled;
                this.dtpOrderData.Enabled = !this.dtpOrderData.Enabled;
                this.dtpPlannedDate.Enabled = !this.dtpPlannedDate.Enabled;
                this.dtpDeliveryDate.Enabled = !this.dtpDeliveryDate.Enabled;
                this.txtOrderNotes.Enabled = !this.txtOrderNotes.Enabled;
                this.toolStripButton1.Enabled = !this.toolStripButton1.Enabled;
               // this.txtDescription.Enabled = !this.txtDescription.Enabled;
            }
            else
            {
                MessageBox.Show("请选择订单");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("本次操作为实时保存，是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (OrderDetail == 0)
                {



                    string sqlinsert = "insert into OrderDetail(OrderId,ItemNo,OrderNumber,Quantity,ItemState) values (" + OrderId + "," + int.Parse(this.txtItemNo.Text) + "," + int.Parse(this.txtOrderNumber.Text) + "," + int.Parse(this.txtQuantity.Text) + ",'" + this.cbxItemState.Text + "');";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlinsert, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    SelectOrderDetail();

                }
                else if (OrderDetail == 1)
                {
                   string sqlupdate = "update OrderDetail set OrderNumber='" + int.Parse(this.txtOrderNumber.Text) + "',Quantity='" + int.Parse(this.txtQuantity.Text) + "',ItemState='" + this.cbxItemState.Text + "' where OrderId=" + OrderId + " and Mark=" + Mark + ";";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    OrderDetail = 0;
                    SelectOrderDetail();
                    
                    this.button1.Text = "添加";
                    this.button3.Text = "删除";
                    this.button3.Visible = false;
                    this.button2.Enabled = true;
                    this.button4.Visible = false;

                    this.txtItemNo.Enabled = !this.txtItemNo.Enabled;
                    this.txtOrderNumber.Enabled = !this.txtOrderNumber.Enabled;
                    this.txtQuantity.Enabled = !this.txtQuantity.Enabled;
                    this.cbxItemState.Enabled = !this.cbxItemState.Enabled;
                    this.txtDescription.Enabled = !this.txtDescription.Enabled;




                }
                else
                {

                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (OrderDetail == 1)
            {
                if (MessageBox.Show("本次操作为实时保存，是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqldelect = "delete from OrderDetail where OrderId =" + OrderId + " and ItemNo=" + Mark + ";";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqldelect, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    OrderDetail = 0;
                    this.button1.Text = "添加";

                    this.button3.Visible = false;
                    this.button2.Enabled = true;
                    this.button4.Visible = false;
                    SelectOrderDetail();
                }

            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            OrderDetail = 0;
            RefreshTXT();//刷新状态
        }

        private void 新增客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form a = new Add.AddClient(0,"无");
            a.ShowDialog();
        }

        private void 新增订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form a = new Add.AddOrder();
           a.ShowDialog();
        }

        private void 修改客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OrderId > 0)
            {
               Form a = new Add.AddClient(1, ClientName);
              a.ShowDialog();
            }
            else
            { MessageBox.Show("请选择订单"); }
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
                OrderId =int.Parse( db.Tables[0].Rows[0][0].ToString());
                RefreshTXT();//刷新状态
                SelectData();//获取数据

            }
            else
            {
                MessageBox.Show("未查询到此订单");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           Form a = new Select.SelectClient();
           a.Show();
        }

        private void tostxtFind_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            AllOrder all = new AllOrder();
            all.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
