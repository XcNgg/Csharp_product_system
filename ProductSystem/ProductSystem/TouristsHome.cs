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
    public partial class TouristsHome : Form
    {



        public TouristsHome()
        {
            InitializeComponent();
        }


        private void SelectSQLData()
        {
            //  string sqlselect = "select OrderId as 订单编号,ClientName as 客户名称,OrderData as 下单时间,PlannedDate as 预计交期,DeliveryDate as 发货时间,OrderState as 订单状态,OrderNotes as 备注 from Order_info;";
            string sqlselect = "select ItemNo as 产品编号,ProductName as 产品名称,Description as 详细信息,ProductNumber as 库存数量,Price as 单价 from Product;";
            DataSet da = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
            dataGridView2.DataSource = da.Tables[0];
        }



        private void Homepage_Load(object sender, EventArgs e)
        {
            SelectSQLData();
            this.dataGridView2.DefaultCellStyle.ForeColor = Color.Black;

            
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
            // int orderId = int.Parse(this.dataGridView2.CurrentRow.Cells[0].Value.ToString());

            //switch (Role)//根据选项显示部门
            //{
            //    case 0: ; break;

            //    case 1:
    
            //        Form a = new From市场部(orderId);
            //        a.MdiParent = work.MainForm.ActiveForm;
            //        a.StartPosition = FormStartPosition.Manual;//子窗体起始位置
            //        a.Location = new Point(0, 0);//设置位置坐标
            //        a.Show();//子窗体显示
            //        break;

            //    case 2:
                   
            //        Form sc = new From生产部(orderId);
            //        sc.MdiParent = work.MainForm.ActiveForm;
            //        sc.StartPosition = FormStartPosition.Manual;//子窗体起始位置
            //        sc.Location = new Point(0, 0);//设置位置坐标
            //        sc.Show();//子窗体显示

            //        break;

            //    case 3:
            //        Form wk = new From物控部(orderId);
            //        wk.MdiParent = work.MainForm.ActiveForm;
            //        wk.StartPosition = FormStartPosition.Manual;//子窗体起始位置
            //        wk.Location = new Point(0, 0);//设置位置坐标
            //        wk.Show();//子窗体显示
            //        ; break;
            //    case 4: ; break;
            //}

        }

        private void dataGridView2_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectSQLData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Login log =new  Login();
            //log.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
