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
    public partial class Manager_info : Form
    {

        DataSet da = new DataSet();//用户管理数据表
        DataSet Client_data = new DataSet();//客户管理数据表
        DataSet Product_data = new DataSet();//物料管理数据表
        DataSet Order_data = new DataSet();//订单管理数据表
        DataSet OrderDetail_data = new DataSet();//订单信息管理数据表
    


        int btn_ID = -1;//0为添加，1为修改，用户管理
        int Client_ID = -1;//0为添加，1为修改，客户管理
        int Product_ID = -1;//0为添加，1为修改，物料管理
        int Order_ID = -1;//0为添加，1为修改，订单管理
        int OrderDetail_ID = -1;//0为添加，1为修改，订单信息管理



        public Manager_info()
        {
            InitializeComponent();
        }

        private void From管理员_Load(object sender, EventArgs e)
        {
            RefreshUser();
            RefreshClient();
            RefreshOrder();
            RefreshOrderDetail();
            RefreshProduct();
            this.dgvClientData.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvOrderData.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvProductData.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvUserdata.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvOrderDatailData.ForeColor = Color.Black;




        }

        #region 用户管理设置

        private void OppositeUser()
        {
            this.txtUsername.Enabled = !this.txtUsername.Enabled;
            this.txtUserpassword.Enabled = !this.txtUserpassword.Enabled;
            this.cbxUserRole.Enabled = !this.cbxUserRole.Enabled;
            this.btnUsersave.Enabled = !this.btnUsersave.Enabled;
            this.btnUseresc.Enabled =!this.btnUseresc.Enabled;

            this.btnUserinsert.Enabled = !this.btnUserinsert.Enabled;
            this.btnUserdelect.Enabled = !this.btnUserdelect.Enabled;
            this.btnUserupdate.Enabled = !this.btnUserupdate.Enabled;

        }

        private void RefreshUser()
        {
            this.txtUsername.Enabled = false;
            this.txtUserpassword.Enabled = false;
            this.cbxUserRole.Enabled = false;
            this.btnUsersave.Enabled = false;
            this.btnUseresc.Enabled = false;
            this.btnUserinsert.Enabled = true;
            this.btnUserdelect.Enabled = true;
            this.btnUserupdate.Enabled = true;

            this.dgvUserdata.ReadOnly = true;
            this.dgvUserdata.AllowUserToAddRows = false;
            this.dgvUserdata.AllowUserToDeleteRows = false;

            this.lblUserId.Text = "";
            this.lblUserId.Visible = true;
            this.lbluserIdy.Text = "";
            this.lbluserIdy.Visible = false;

            this.txtUsername.Text = null;
            this.txtUserpassword.Text = null;
            this.cbxUserRole.Text = null;
            this.label1.Text = "用户ID:";
            this.label1.Visible = true;
            SelectUser();
        }

        private void SelectUser()
        {
            da.Clear();
            string sqlselect = "select UserId as 用户ID,UserName as 用户名,UserPassword as 密码,UserRole as 用户权限 from User";
            da = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dgvUserdata.DataSource = da.Tables[0];

        }

        #endregion


        #region 客户管理设置

        private void OppositeClient()
        {
            this.txtClientName.Enabled = !this.txtClientName.Enabled;
            this.txtClientAbbreviation.Enabled = !this.txtClientAbbreviation.Enabled;
            this.txtClientEmail.Enabled = !this.txtClientEmail.Enabled;
            this.txtClientContacts.Enabled = !this.txtClientContacts.Enabled;
            this.txtClientAddress.Enabled = !this.txtClientAddress.Enabled;
            this.txtClientTelephone.Enabled = !this.txtClientTelephone.Enabled;

            this.btnClientSave.Enabled = !this.btnClientSave.Enabled;
            this.btnClientEsc.Enabled = !this.btnClientEsc.Enabled;
            this.btnClientDelect.Enabled =! this.btnClientDelect.Enabled;
            this.btnClientInsert.Enabled = !this.btnClientInsert.Enabled;
            this.btnClientUpdate.Enabled =! this.btnClientUpdate.Enabled;

        
        }

        private void RefreshClient()
        {
            this.txtClientName.Enabled = false;
            this.txtClientAbbreviation.Enabled = false;
            this.txtClientEmail.Enabled = false;
            this.txtClientContacts.Enabled = false;
            this.txtClientAddress.Enabled = false;
            this.txtClientTelephone.Enabled = false;

            this.dgvClientData.ReadOnly = true;
            this.dgvClientData.AllowUserToAddRows = false;
            this.dgvClientData.AllowUserToDeleteRows = false;

            this.btnClientSave.Enabled = false;
            this.btnClientEsc.Enabled = false;

            this.btnClientDelect.Enabled = true;
            this.btnClientInsert.Enabled = true;
            this.btnClientRefresh.Enabled = true;
            this.btnClientUpdate.Enabled = true;


            this.lblClientIDname.Text = "客户ID：";
            this.lblClientID.Text = null;
            this.lblClientIDname.Visible = true;
            this.lblClientID.Visible = true;
            SelectClient();


            this.txtClientAbbreviation.Text = null;
            this.txtClientAddress.Text = null;
            this.txtClientContacts.Text = null;
            this.txtClientEmail.Text = null;
            this.txtClientName.Text = null;
            this.txtClientTelephone.Text = null;

        
        }

        private void SelectClient()
        {
            Client_data.Clear();
            string sqlselect = "select ClientId as 客户ID,ClientName as 客户名称,ClientAbbreviation as 客户简称,ClientContacts as 联系人,ClientTelephone as 电话,ClientAddress as 地址,ClientEmail as 邮件 from Client;";
            Client_data = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dgvClientData.DataSource = Client_data.Tables[0];
           
        
        }

        #endregion


        #region 订单管理设置

        private void OppositeOrder()
        {
            this.cbxOrderState.Enabled = !this.cbxOrderState.Enabled;
            this.dtpDeliveryDate.Enabled = !this.dtpDeliveryDate.Enabled;
            this.dtpOrderDate.Enabled = !this.dtpOrderDate.Enabled;
            this.dtpPlannedDate.Enabled = !this.dtpPlannedDate.Enabled;
            this.txtOrderNotes.Enabled = !this.txtOrderNotes.Enabled;
            this.txtOrderClientName.Enabled = !this.txtOrderClientName.Enabled;

            this.btnOrderDelect.Enabled = !this.btnOrderDelect.Enabled;
            this.btnOrderEsc.Enabled = !this.btnOrderEsc.Enabled;
            this.btnOrderInsert.Enabled = !this.btnOrderInsert.Enabled;
            this.btnOrderSave.Enabled = !this.btnOrderSave.Enabled;
            this.btnOrderUpdate.Enabled = !this.btnOrderUpdate.Enabled;

 
        }

        private void RefreshOrder()
        {

            this.cbxOrderState.Enabled = false;
            this.dtpDeliveryDate.Enabled = false;
            this.dtpOrderDate.Enabled = false;
            this.dtpPlannedDate.Enabled = false;
            this.txtOrderNotes.Enabled = false;
            this.txtOrderClientName.Enabled = false;

            this.dgvOrderData.ReadOnly = true;
            this.dgvOrderData.AllowUserToAddRows = false;
            this.dgvOrderData.AllowUserToDeleteRows = false;

            this.btnOrderDelect.Enabled = true;
            this.btnOrderEsc.Enabled = false;
            this.btnOrderInsert.Enabled = true;
            this.btnOrderRefresh.Enabled = true;
            this.btnOrderSave.Enabled = false;
            this.btnOrderUpdate.Enabled = true;

            SelectOrder();

            this.txtOrderClientName.Text = null;
            this.cbxOrderState.Text = null;
            this.txtOrderNotes.Text = null;
            this.dtpDeliveryDate.Value = System.DateTime.Now;
            this.dtpOrderDate.Value = System.DateTime.Now;
            this.dtpPlannedDate.Value = System.DateTime.Now;
            this.lblOrderIDname.Text = "订单ID：";
            this.lblOrderID.Text = null;
            this.lblOrderIDname.Visible = true;
            this.lblOrderID.Visible = true;

        }

        private void SelectOrder()
        {
            Order_data.Clear();
            string sqlselect = "select OrderId as 订单ID,ClientName as 客户名称,OrderState as 订单状态,OrderData as 下单时间,PlannedDate as 预计交期,DeliveryDate as 发货时间,OrderNotes as 备注 from Order_info;";
            Order_data = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dgvOrderData.DataSource = Order_data.Tables[0];

        }

        #endregion


        #region 订单信息管理设置

        private void OppositeOrderDetail()
        {
            this.txtOrderDetailOrderID.Enabled = !this.txtOrderDetailOrderID.Enabled;
            this.txtItemNo.Enabled = !this.txtItemNo.Enabled;
            this.txtQuantity.Enabled = !this.txtQuantity.Enabled;
            this.txtOrderNumber.Enabled = !this.txtOrderNumber.Enabled;
            this.cbxItemState.Enabled = !this.cbxItemState.Enabled;

            this.btnOrderDetailDelect.Enabled = !this.btnOrderDetailDelect.Enabled;
            this.btnOrderDetailEsc.Enabled = !this.btnOrderDetailEsc.Enabled;
            this.btnOrderDetailInsert.Enabled = !this.btnOrderDetailInsert.Enabled;
            this.btnOrderDetailSave.Enabled = !this.btnOrderDetailSave.Enabled;
            this.btnOrderDetailUpdate.Enabled = !this.btnOrderDetailUpdate.Enabled;


        
        }

        private void RefreshOrderDetail()
        {
            this.txtOrderDetailOrderID.Enabled = false;
            this.txtItemNo.Enabled = false;
            this.txtQuantity.Enabled = false;
            this.txtOrderNumber.Enabled = false;
            this.cbxItemState.Enabled = false;

            this.dgvOrderDatailData.ReadOnly = true;
            this.dgvOrderDatailData.AllowUserToAddRows = false;
            this.dgvOrderDatailData.AllowUserToDeleteRows = false;

            this.btnOrderDetailDelect.Enabled = true;
            this.btnOrderDetailEsc.Enabled = false;
            this.btnOrderDetailInsert.Enabled = true;
            this.btnOrderDetailRefresh.Enabled = true;
            this.btnOrderDetailSave.Enabled = false;
           // this.btnOrderDetailSelect.Enabled = true;
            this.btnOrderDetailUpdate.Enabled = true;

            SelectOrderDetail();

            this.lblOrderDetailMarkname.Visible = true;
            this.lblOrderDetailMark.Visible = true;
            this.lblOrderDetailMarkname.Text = "标识ID：";
            this.lblOrderDetailMark.Text = null;

            this.txtOrderDetailOrderIDselect.Text = null;
            this.txtOrderDetailOrderID.Text = null;
            this.txtItemNo.Text = null;
            this.txtQuantity.Text = null;
            this.txtOrderNumber.Text = null;
            this.cbxItemState.Text = null;



        }

        private void SelectOrderDetail()
        {
            OrderDetail_data.Clear();
            string sqlselect = "select OrderId as 订单ID,ItemNo as 货号,OrderNumber as 订单数量,Quantity as 单价,ItemState as 货物状态,Mark as 标识ID from OrderDetail;";
             OrderDetail_data = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dgvOrderDatailData.DataSource = OrderDetail_data.Tables[0];

        }

        #endregion


        #region 物料管理设置
        private void OppositeProduct()
        {
            this.txtProductItemNo.Enabled = !this.txtProductItemNo.Enabled;
            this.txtProductName.Enabled = ! this.txtProductName.Enabled;
            this.txtProductNumber.Enabled = ! this.txtProductNumber.Enabled; 
            this.txtDescription.Enabled = !this.txtDescription.Enabled ;

            this.btnProductDelect.Enabled = !this.btnProductDelect.Enabled;
            this.btnProductEsc.Enabled = !this.btnProductEsc.Enabled;
            this.btnProductInsert.Enabled =! this.btnProductInsert.Enabled;
            this.btnProductSave.Enabled = ! this.btnProductSave.Enabled;
            this.btnProductUpdate.Enabled = !this.btnProductUpdate.Enabled;

        
        }

        private void RefreshProduct()
        {
            this.txtProductItemNo.Enabled = false;
            this.txtProductName.Enabled = false;
            this.txtProductNumber.Enabled = false;
            this.txtDescription.Enabled = false;

            this.dgvProductData.ReadOnly = true;
            this.dgvProductData.AllowUserToAddRows = false;
            this.dgvProductData.AllowUserToDeleteRows = false;


            this.btnProductDelect.Enabled = true;
            this.btnProductEsc.Enabled = false;
            this.btnProductInsert.Enabled = true;
            this.btnProductRefresh.Enabled = true;
            this.btnProductSave.Enabled = false;
            this.btnProductUpdate.Enabled = true;

            SelectProduct();

            this.lblProductItemNoname.Visible = false;
            this.lblProductItemNo.Visible = false;
            this.lblProductItemNo.Text = null;

            this.txtProductItemNo.Text = null;
            this.txtProductName.Text = null;
            this.txtProductNumber.Text = null;
            this.txtDescription.Text = null;

        }

        private void SelectProduct()
        {
            Product_data.Clear();
            string sqlselect = "select ItemNo as 货号,ProductName as 产品名称,Description as 详细信息,ProductNumber as 数量 from Product;";
            Product_data = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dgvProductData.DataSource = Product_data.Tables[0];
        }

        #endregion




        #region 用户管理内容
        //_________________________________________用户管理_______________________________________________________________________________

        private void btnUserinsert_Click(object sender, EventArgs e)
        {
            OppositeUser();
            this.lblUserId.Visible = false;
            this.label1.Visible = false;
            btn_ID = 0;
            this.txtUsername.Text = null;
            this.txtUserpassword.Text = null;
            this.cbxUserRole.Text = null;


        }

        private void btnUserupdate_Click(object sender, EventArgs e)
        {
            
            if (this.lblUserId.Text == null || this.lblUserId.Text == "")
            {
                MessageBox.Show("请选择要修改用户");
            }
            else
            {
                OppositeUser();
            this.lbluserIdy.Visible = true;
            this.lblUserId.Visible = false;
            this.label1.Text = "原用户ID:";
                this.lbluserIdy.Text = this.lblUserId.Text;
                btn_ID = 1;
            }


            
        }

        private void btnUsersave_Click(object sender, EventArgs e)
        {

            if (this.txtUsername.Text == null || this.txtUsername.Text == "")
            { MessageBox.Show("请输入用户名"); }
            else if (this.txtUserpassword.Text == null || this.txtUserpassword.Text == "")
            { MessageBox.Show("请输入密码"); }
            else if (this.cbxUserRole.Text == null || this.cbxUserRole.Text == "")
            { MessageBox.Show("请选择部门"); }
            else
            {

            int role = 1;
            switch (this.cbxUserRole.Text)
            {
                case "管理员":
                    role = 0;
                    break;

                case "市场部":
                    role = 1;
                    break;

                case "生产部":
                    role = 2;
                    break;

                case "物控部":
                    role = 3;
                    break;

                case "游客/测试":
                    role = 4;
                    break;

            }

           
            if (btn_ID == 0)
            {
                string sqlinsert = "insert into User(UserName,UserPassword,UserRole) values ('" + this.txtUsername.Text + "','" + this.txtUserpassword.Text + "'," + role+ ");";
                try
                {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlinsert, null);
                        MessageBox.Show("【" + this.txtUsername.Text+"】添加成功！");
                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (btn_ID == 1)
            {
                string sqlupdate = "update User set UserName='" + this.txtUsername.Text + "',UserPassword='" + this.txtUserpassword.Text + "',UserRole='" + role + "' where UserId=" + int.Parse(this.lbluserIdy.Text) + ";";
                try
                {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                        MessageBox.Show("【" + this.txtUsername.Text + "】修改成功！");
                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
            
            }
            else
            { MessageBox.Show("系统错误"); }

            RefreshUser();
            btn_ID = -1;
            }
        }

        private void btnUseresc_Click(object sender, EventArgs e)
        {
            RefreshUser();
        }

        private void dgvUserdata_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

            this.lblUserId.Text = this.dgvUserdata.CurrentRow.Cells["用户ID"].Value.ToString();
            this.txtUsername.Text = this.dgvUserdata.CurrentRow.Cells["用户名"].Value.ToString();
            this.txtUserpassword.Text = this.dgvUserdata.CurrentRow.Cells["密码"].Value.ToString();

            switch (this.dgvUserdata.CurrentRow.Cells["用户权限"].Value.ToString())
            {
                case "0":
                    this.cbxUserRole.Text = "管理员";
                    break;

                case "1":
                    this.cbxUserRole.Text = "市场部";
                    break;

                case "2":
                    this.cbxUserRole.Text = "生产部";
                    break;

                case "3":
                    this.cbxUserRole.Text = "物控部";
                    break;

                case "4":
                    this.cbxUserRole.Text = "游客/测试";
                    break;

            }


        }

        private void btnUserdelect_Click(object sender, EventArgs e)
        {
            if (this.lblUserId.Text == null || this.lblUserId.Text == "")
            {
                MessageBox.Show("请选择要删除用户");
            }
            else
            {
                this.lbluserIdy.Text = this.lblUserId.Text;
                if (MessageBox.Show("即将删除用户ID：" + this.lbluserIdy.Text + "，是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqldelect = "delete from User where UserId =" + int.Parse(this.lbluserIdy.Text) + ";";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqldelect, null);
                        MessageBox.Show("【ID:" + lbluserIdy.Text+ "】删除成功!");
                        RefreshUser();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshUser();
        }

        //_________________________________________用户管理_______________________________________________________________________________
        #endregion


        #region 客户管理内容

        private void btnClientRefresh_Click(object sender, EventArgs e)
        {
            RefreshClient();
        }

        private void btnClientInsert_Click(object sender, EventArgs e)
        {
            OppositeClient();
            this.txtClientAbbreviation.Text = null;
            this.txtClientAddress.Text = null;
            this.txtClientContacts.Text = null;
            this.txtClientEmail.Text = null;
            this.txtClientName.Text = null;
            this.txtClientTelephone.Text = null;
            Client_ID = 0;
            this.lblClientIDname.Visible = false;
            this.lblClientID.Visible = false;
            
        }

        private void btnClientUpdate_Click(object sender, EventArgs e)
        {
           
            if (this.lblClientID.Text == null || this.lblClientID.Text == "")
            {
                MessageBox.Show("请选择所要修改客户！");
            }
            else
            {
                OppositeClient();
                Client_ID = 1;
                this.lblClientIDname.Text = "原客户ID：";
 
            }
            
        }

        private void btnClientSave_Click(object sender, EventArgs e)
        {

            if (this.txtClientName.Text == null || this.txtClientName.Text == "")
            { MessageBox.Show("请输入客户名称"); }
            else
            {

                if (Client_ID == 0)
                {
                    string sqlinsert = "insert into Client (ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail) values ('" + this.txtClientName.Text + "','" + this.txtClientAbbreviation.Text + "','" + this.txtClientContacts.Text + "','" + this.txtClientTelephone.Text + "','" + this.txtClientAddress.Text + "','" + this.txtClientEmail.Text + "');";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlinsert, null);
                        MessageBox.Show("【"+ this.txtClientName.Text+"】添加成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (Client_ID == 1)
                {
                    string sqlupdate = "update Client set ClientName='" + this.txtClientName.Text + "',ClientAbbreviation='" + this.txtClientAbbreviation.Text + "',ClientContacts='" + this.txtClientContacts.Text + "',ClientTelephone='" + this.txtClientTelephone.Text + "',ClientAddress='" + this.txtClientAddress.Text + "',ClientEmail='" + this.txtClientEmail.Text + "' where ClientId=" + int.Parse(this.lblClientID.Text) + ";";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                        MessageBox.Show("【" + this.txtClientName.Text + "】修改成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                { MessageBox.Show("系统错误"); }

 
            }


            RefreshClient();
            Client_ID = -1;

        }

        private void btnClientEsc_Click(object sender, EventArgs e)
        {
            RefreshClient();
        }

        private void dgvClientData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtClientName.Text = this.dgvClientData.CurrentRow.Cells["客户名称"].Value.ToString();
            this.txtClientAbbreviation.Text = this.dgvClientData.CurrentRow.Cells["客户简称"].Value.ToString();
            this.txtClientEmail.Text = this.dgvClientData.CurrentRow.Cells["邮件"].Value.ToString();
            this.txtClientContacts.Text = this.dgvClientData.CurrentRow.Cells["联系人"].Value.ToString();
            this.txtClientTelephone.Text = this.dgvClientData.CurrentRow.Cells["电话"].Value.ToString();
            this.txtClientAddress.Text = this.dgvClientData.CurrentRow.Cells["地址"].Value.ToString();
            if (this.lblClientIDname.Text == "原客户ID：")
            { }
            else
            {
                this.lblClientID.Text = this.dgvClientData.CurrentRow.Cells["客户ID"].Value.ToString();
            }
            
        }

        private void btnClientDelect_Click(object sender, EventArgs e)
        {
            if (this.lblClientID.Text == null || this.lblClientID.Text == "")
            {
                MessageBox.Show("请选择要删除客户");
            }
            else
            {

                if (MessageBox.Show("即将删除客户ID：" + this.lblClientID.Text + "，是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqldelect = "delete from Client where ClientId =" + int.Parse(this.lblClientID.Text) + ";";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqldelect, null);
                        MessageBox.Show("删除成功!");
                        RefreshClient();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }


        #endregion


        #region 订单管理内容

        private void btnOrderRefresh_Click(object sender, EventArgs e)
        {
            RefreshOrder();
            this.dgvClientData.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnOrderInsert_Click(object sender, EventArgs e)
        {
            OppositeOrder();
            Order_ID = 0;
            this.lblOrderIDname.Visible = false;
            this.lblOrderID.Visible = false;
            this.txtOrderClientName.Text = null;
            this.txtOrderNotes.Text = null;
            this.cbxOrderState.Text = null;
            this.dtpDeliveryDate.Value = System.DateTime.Now;
            this.dtpOrderDate.Value = System.DateTime.Now;
            this.dtpPlannedDate.Value = System.DateTime.Now;
            this.dgvClientData.DefaultCellStyle.ForeColor = Color.Black;

        }

        private void btnOrderDelect_Click(object sender, EventArgs e)
        {
            


            if (this.lblOrderID.Text == null || this.lblOrderID.Text == "")
            {
                MessageBox.Show("请选择要删除订单");
            }
            else
            {
                DataSet db = new DataSet();
                string sqlselect = "select * from OrderDetail where OrderId='" + int.Parse(this.lblOrderID.Text) + "' ";
                db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
                if (db.Tables[0].Rows.Count > 0)
                { MessageBox.Show("订单货物信息已存在，请删除所有货品后再删除订单！"); }
                else
                {

                    if (MessageBox.Show("即将删除订单ID：" + this.lblOrderID.Text + "，是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string sqldelect = "delete from Order_info where OrderId =" + int.Parse(this.lblOrderID.Text) + ";";
                        try
                        {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqldelect, null);
                            MessageBox.Show("删除成功!");
                            RefreshOrder();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnOrderUpdate_Click(object sender, EventArgs e)
        {

            if (this.lblOrderID.Text == null || this.lblOrderID.Text == "")
            {
                MessageBox.Show("请选择所要修改订单！");
            }
            else
            {
                OppositeOrder();
                Order_ID = 1;
                this.lblOrderIDname.Text = "原订单ID：";

            }
            
        }

        private void btnOrderEsc_Click(object sender, EventArgs e)
        {
            RefreshOrder();
        }

        private void dgvOrderData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.cbxOrderState.Text = this.dgvOrderData.CurrentRow.Cells["订单状态"].Value.ToString();
            this.dtpDeliveryDate.Text = this.dgvOrderData.CurrentRow.Cells["发货时间"].Value.ToString();
            this.dtpOrderDate.Text = this.dgvOrderData.CurrentRow.Cells["下单时间"].Value.ToString();
            this.dtpPlannedDate.Text = this.dgvOrderData.CurrentRow.Cells["预计交期"].Value.ToString();
            this.txtOrderNotes.Text = this.dgvOrderData.CurrentRow.Cells["备注"].Value.ToString();
            this.txtOrderClientName.Text = this.dgvOrderData.CurrentRow.Cells["客户名称"].Value.ToString();
            if (this.lblOrderIDname.Text == "原订单ID：")
            { }
            else
            {
                this.lblOrderID.Text = this.dgvOrderData.CurrentRow.Cells["订单ID"].Value.ToString();
            }

        }

        private void btnOrderSave_Click(object sender, EventArgs e)
        {
           

            if (this.txtOrderClientName.Text == null || this.txtOrderClientName.Text == "")
            { MessageBox.Show("请输入客户名称！"); }
            else
            {
                DataSet db = new DataSet();
                string sqlselect = "select * from Client where ClientName='" + this.txtOrderClientName.Text + "' ";
                 db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
                if (db.Tables[0].Rows.Count==0)
            { MessageBox.Show("客户名称不存在！"); }
            else
            {

                if (Order_ID == 0)
                {
                    string sqlinsert = "insert into Order_info(ClientName,OrderState,OrderData,PlannedDate,DeliveryDate,OrderNotes) values ('" + this.txtOrderClientName.Text + "','" + this.cbxOrderState.SelectedItem.ToString() + "','" + this.dtpOrderDate.Value.ToString() + "','" + this.dtpPlannedDate.Value.ToString() + "','" + this.dtpDeliveryDate.Value.ToString() + "','" + this.txtOrderNotes.Text + "');";
                    try
                    {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlinsert, null);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (Order_ID == 1)
                {
                    string sqlupdate = "update Order_info set ClientName='" + this.txtOrderClientName.Text + "',OrderState='" + this.cbxOrderState.SelectedItem.ToString() + "',OrderData='" + this.dtpOrderDate.Value.ToString() + "',PlannedDate='" + this.dtpPlannedDate.Value.ToString() + "',DeliveryDate='" + this.dtpDeliveryDate.Value.ToString() + "',OrderNotes='" + this.txtOrderNotes.Text + "' where OrderId=" + int.Parse(this.lblOrderID.Text) + ";";
                    try
                    {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                            MessageBox.Show("【" + this.txtOrderClientName.Text + "】修改成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                { MessageBox.Show("系统错误"); }


            }
            }


            RefreshOrder();
            Order_ID = -1;

        }

        #endregion 

        
        #region 订单信息管理内容

       


        private void btnOrderDetailRefresh_Click(object sender, EventArgs e)
        {
            RefreshOrderDetail();
        }

        
        private void btnOrderDetailEsc_Click(object sender, EventArgs e)
        {
            RefreshOrderDetail();
        }

        private void btnOrderDetailInsert_Click(object sender, EventArgs e)
        {
            OppositeOrderDetail();
            OrderDetail_ID = 0;

            this.lblOrderDetailMarkname.Visible = false;
            this.lblOrderDetailMark.Visible = false;
            this.txtItemNo.Text = null;
            this.txtQuantity.Text = null;
            this.txtOrderNumber.Text = null;
            this.cbxItemState.Text = null;
            this.txtOrderDetailOrderID.ReadOnly = false;
        }

        private void btnOrderDetailUpdate_Click(object sender, EventArgs e)
        {
            if (this.lblOrderDetailMark.Text == null || this.lblOrderDetailMark.Text == "")
            {
                MessageBox.Show("请选择所要修改商品！");
            }
            else
            {
                OppositeOrderDetail();
                OrderDetail_ID = 1;
                this.lblOrderDetailMarkname.Text = "原标识ID：";

            }
        }

        private void btnOrderDetailDelect_Click(object sender, EventArgs e)
        {
            if (this.lblOrderDetailMark.Text == null || this.lblOrderDetailMark.Text == "")
            {
                MessageBox.Show("请选择要删除商品");
            }
            else if (MessageBox.Show("即将删除订单ID：" + this.lblOrderDetailMark.Text + "，是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string sqldelect = "delete from OrderDetail where Mark =" + int.Parse(this.lblOrderDetailMark.Text) + ";";
                        try
                        {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqldelect, null);
                            MessageBox.Show("删除成功!");
                            RefreshOrderDetail();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
            
        }

        private void btnOrderDetailSave_Click(object sender, EventArgs e)
        {
            if (this.txtOrderDetailOrderID.Text == null || this.txtOrderDetailOrderID.Text == "")
            { MessageBox.Show("请输入所属订单！"); }
            else if (this.txtItemNo.Text == null || this.txtItemNo.Text == "")
            { MessageBox.Show("请输入货号！"); }
            else
            {
                DataSet db = new DataSet();
                string sqlselect1 = "select * from Order_info where OrderId='" + this.txtOrderDetailOrderID.Text + "' ";
                db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect1, null);

                DataSet dc = new DataSet();
                string sqlselect2 = "select * from Product where ItemNo='" + this.txtItemNo.Text + "' ";
                 dc = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect2, null);

                if (db.Tables[0].Rows.Count == 0)
                { MessageBox.Show("所属订单不存在！"); }
                else if (dc.Tables[0].Rows.Count == 0)
                { MessageBox.Show("客户货号不存在！"); }
                else
                {

                    if (OrderDetail_ID == 0)
                    {

                        
                        string sqlinsert = "insert into OrderDetail(OrderId,ItemNo,OrderNumber,Quantity,ItemState) values ('" + this.txtOrderDetailOrderID.Text + "','" + this.txtItemNo.Text + "','" + this.txtOrderNumber.Text + "','" + this.txtQuantity.Text + "','" + this.cbxItemState.SelectedItem.ToString()+ "');";
                        try
                        {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlinsert, null);
                            RefreshOrderDetail();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (OrderDetail_ID == 1)
                    {
                        string sqlupdate = "update OrderDetail set OrderId='" + this.txtOrderDetailOrderID.Text + "',ItemNo='" + this.txtItemNo.Text + "',OrderNumber='" + this.txtOrderNumber.Text + "',Quantity='" + this.txtQuantity.Text + "',ItemState='" + this.cbxItemState.SelectedItem.ToString() + "' where Mark=" + int.Parse(this.lblOrderDetailMark.Text) + ";";
                        try
                        {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                            RefreshOrderDetail();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    { MessageBox.Show("系统错误"); }
                }
            }
            OrderDetail_ID = -1;
            RefreshOrderDetail();
        }

        private void dgvOrderDatailData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.lblOrderDetailMarkname.Text == "原标识ID：")
            { }
            else
            {
                this.lblOrderDetailMark.Text = this.dgvOrderDatailData.CurrentRow.Cells["标识ID"].Value.ToString();
            }
            this.txtOrderDetailOrderID.Text = this.dgvOrderDatailData.CurrentRow.Cells["订单ID"].Value.ToString();
            this.txtItemNo.Text = this.dgvOrderDatailData.CurrentRow.Cells["货号"].Value.ToString();
            this.txtQuantity.Text = this.dgvOrderDatailData.CurrentRow.Cells["单价"].Value.ToString();
            this.txtOrderNumber.Text = this.dgvOrderDatailData.CurrentRow.Cells["订单数量"].Value.ToString();
            this.cbxItemState.Text = this.dgvOrderDatailData.CurrentRow.Cells["货物状态"].Value.ToString();
        }
        #endregion


        #region 物料管理内容
        private void btnProductRefresh_Click(object sender, EventArgs e)
        {
            RefreshProduct();
        }

        private void btnProductInsert_Click(object sender, EventArgs e)
        {
            OppositeProduct();
            Product_ID = 0;
            this.txtProductItemNo.Text = null;
            this.txtProductName.Text = null;
            this.txtProductNumber.Text = null;
            this.txtDescription.Text = null;
        }

        private void btnProductDelect_Click(object sender, EventArgs e)
        {
            if (this.lblProductItemNo.Text == null || this.lblProductItemNo.Text == "")
            {
                MessageBox.Show("请选择要删除商品");
            }

            else
            {
                DataSet dc = new DataSet();
                string sqlselect2 = "select * from OrderDetail where ItemNo='" + this.lblProductItemNo.Text + "' ";
                dc = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect2, null);
                if (dc.Tables[0].Rows.Count> 0)
                { MessageBox.Show("订单货物信息已存在，请删除所有货品后再删除货号！"); }
                else if (MessageBox.Show("即将删除货号：" + this.lblProductItemNo.Text + "，是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqldelect = "delete from Product where ItemNo =" + int.Parse(this.lblProductItemNo.Text) + ";";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqldelect, null);
                        MessageBox.Show("货号【"+ this.lblProductItemNo.Text + "】删除成功!");
                        RefreshProduct();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnProductUpdate_Click(object sender, EventArgs e)
        {
            if (this.lblProductItemNo.Text == null || this.lblProductItemNo.Text == "")
            {
                MessageBox.Show("请选择所要修改货号！");
            }
            else
            {
                OppositeProduct();
                Product_ID = 1;
                this.lblProductItemNoname.Visible = true;
                this.lblProductItemNo.Visible = true;

            }
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {

 
              if (this.txtProductItemNo.Text == null || this.txtProductItemNo.Text == "")
            { 
                MessageBox.Show("请输入货号"); 
            
            }
            else
            {


                if (Product_ID == 0)
                {
                    DataSet ds = new DataSet();
                    string select = "select * from Product where ItemNo='" + this.txtProductItemNo.Text + "';";
                    ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, select, null);
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        MessageBox.Show("当前已存在相同货号产品！请勿重复添加");
                    }
                    else { 
                        string sqlinsert = "insert into Product(ItemNo,ProductName,Description,ProductNumber) values ('" + this.txtProductItemNo.Text + "','" + this.txtProductName.Text + "','" + this.txtDescription.Text + "','" + this.txtProductNumber.Text + "');";
                        try
                        {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlinsert, null);
                            MessageBox.Show("货号【" + this.txtProductItemNo.Text + "】添加成功！");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (Product_ID == 1)
                {
                    string sqlupdate = "update Product set ItemNo='" + this.txtProductItemNo.Text + "',ProductName='" + this.txtProductName.Text + "',Description='" + this.txtDescription.Text + "',ProductNumber='" + this.txtProductNumber.Text + "' where ItemNo='" + this.lblProductItemNo.Text + "';";
                    try
                    {
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                        MessageBox.Show("货号【" + this.txtProductItemNo.Text + "】修改成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                { MessageBox.Show("系统错误"); }


            }

            RefreshProduct();
            Product_ID = -1;
        }

        private void btnProductEsc_Click(object sender, EventArgs e)
        {
            RefreshProduct();
        }

        private void dgvProductData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (this.lblProductItemNoname.Visible == false)
            {
                this.txtProductItemNo.Text = this.dgvProductData.CurrentRow.Cells["货号"].Value.ToString();
                this.lblProductItemNo.Text = this.dgvProductData.CurrentRow.Cells["货号"].Value.ToString();
            }
            else
            {
                this.txtProductItemNo.Text = this.dgvProductData.CurrentRow.Cells["货号"].Value.ToString();
              
            }
            this.txtProductName.Text = this.dgvProductData.CurrentRow.Cells["产品名称"].Value.ToString();
            this.txtProductNumber.Text = this.dgvProductData.CurrentRow.Cells["数量"].Value.ToString();
            this.txtDescription.Text = this.dgvProductData.CurrentRow.Cells["详细信息"].Value.ToString();

        }

        #endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvUserdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClientData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void labelclose_Click(object sender, EventArgs e)
        {
            
        }

        private void labelclose_Click_1(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrderDatailData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtOrderDetailOrderIDselect_TextChanged(object sender, EventArgs e)
        {
            OrderDetail_data.Clear();
            string sqlselect = "select OrderId as 订单ID,ItemNo as 货号,OrderNumber as 订单数量,Quantity as 单价,ItemState as 货物状态,Mark as 标识ID from OrderDetail where OrderId like '%" + this.txtOrderDetailOrderIDselect.Text + "%'";
            OrderDetail_data = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dgvOrderDatailData.DataSource = OrderDetail_data.Tables[0];
            this.txtOrderDetailOrderID.Text = this.txtOrderDetailOrderIDselect.Text;
        }

        private void txtOrderDetailOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
