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
    public partial class ProductStorage : Form
    {
        public ProductStorage()
        {
            InitializeComponent();
        }
        DataSet db = new DataSet();
        private void ProductStorage_Load(object sender, EventArgs e)
        {
            Refreshdata();

            this.textBox1.Text = null;
            this.textBox2.Text = null;
            this.textBox3.Text = null;
            this.textBox4.Text = null;
        }


        private void Refreshdata()
        {
            db.Clear();
            string sqlselectdata = "select ItemNo as'货号',ProductName as '产品名称',Description as'详细信息',ProductNumber as'数量' from Product ";
            db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselectdata, null);

            this.comboBox1.Items.Clear();
            foreach (DataRow dr in db.Tables[0].Rows)
            {
                this.comboBox1.Items.Add(dr["货号"].ToString());
            }

        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_Selectedata();

        }
        private void cbx_Selectedata()
        {
            int itemrows = 0;

            for (int i = 0; i < db.Tables[0].Rows.Count; i++)
            {
                if (this.comboBox1.Text == db.Tables[0].Rows[i]["货号"].ToString())
                {
                    itemrows = i;
                }
            }


            this.textBox1.Text = db.Tables[0].Rows[itemrows]["产品名称"].ToString();
            this.textBox2.Text = db.Tables[0].Rows[itemrows]["详细信息"].ToString();
            this.textBox3.Text = db.Tables[0].Rows[itemrows]["数量"].ToString();
        }






        private void button1_Click(object sender, EventArgs e)
        {

            if (this.comboBox1.SelectedItem.ToString() != null || this.comboBox1.SelectedItem.ToString() != "")
            {


                string ItemNo = this.comboBox1.SelectedItem.ToString();
                int ProductNumber = int.Parse(this.textBox3.Text); 
                int ProductNew = ProductNumber + int.Parse(this.textBox4.Text);
                string sqlupdate = "update Product set ProductNumber=" + ProductNew + " where ItemNo=" + ItemNo + ";";
                try
                {
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                    MessageBox.Show("入库成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Refreshdata();
                this.comboBox1.Text = ItemNo;
                cbx_Selectedata();
            
            }
            else
            {
                if (this.textBox4.Text == null || this.textBox4.Text == "")
                {
                    MessageBox.Show("请输入数量");
                }
                else
                {
                    MessageBox.Show("请选择货号");
                }
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this.comboBox1.SelectedItem.ToString() != null || this.comboBox1.SelectedItem.ToString() != "")
            {


                string ItemNo = this.comboBox1.SelectedItem.ToString();
                int ProductNumber = int.Parse(this.textBox3.Text);
                int ProductNew = ProductNumber - int.Parse(this.textBox4.Text);
                string sqlupdate = "update Product set ProductNumber=" + ProductNew + " where ItemNo=" + ItemNo + ";";
                try
                {
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null);
                    MessageBox.Show("出库成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Refreshdata();
                this.comboBox1.Text = ItemNo;
                cbx_Selectedata();

            }
            else
            {
                if (this.textBox4.Text == null || this.textBox4.Text == "")
                {
                    MessageBox.Show("请输入数量");
                }
                else
                {
                    MessageBox.Show("请选择货号");
                }

            }

        }
    }
}
