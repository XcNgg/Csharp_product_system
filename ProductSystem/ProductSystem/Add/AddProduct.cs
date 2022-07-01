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
    public partial class AddProduct : Form
    {

        private static int NumProduct = 0;//判断新增还是修改
        private static string ProductItemNo = "无";//货号空为-1
        public AddProduct(int num, string productitemNo)
        {
            InitializeComponent();
            NumProduct = num;
            ProductItemNo = productitemNo;

        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            if (NumProduct == 0)
            {
                this.Text = "新增货号";
                this.label4.Visible = false;
                this.label5.Visible = false;
            }
            else if (NumProduct == 1)
            {
                this.Text = "修改货号";
                this.label5.Text = ProductItemNo;

                string sqlselect = "select * from Product where ItemNo='" + ProductItemNo + "';";
                DataSet db = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
                this.textBox1.Text = db.Tables[0].Rows[0][0].ToString();
                this.textBox2.Text = db.Tables[0].Rows[0][1].ToString();
                this.textBox3.Text = db.Tables[0].Rows[0][2].ToString();
            }

            else { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                
                

                    if (NumProduct == 0)
                    {
                         DataSet ds = new DataSet();
                        string select = "select * from Product where ItemNo='" + this.textBox1.Text + "';";
                        ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, select, null);
                        if (ds.Tables[0].Rows.Count >= 1)
                        {
                            MessageBox.Show("当前已存在相同货号产品！请勿重复添加");
                        }
                    else {     
                    string sqlinsert = "insert into Product (ItemNo,ProductName,Description,ProductNumber) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "',0);";
                        try
                        {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlinsert, null);
                            MessageBox.Show("添加成功");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (NumProduct == 1)
                    {
                        if (ProductItemNo == "无")
                        {
                            MessageBox.Show("系统错误");

                        }
                        else
                        {
                            string sqlupdate = "update Product set ItemNo='" + this.textBox1.Text + "', ProductName='" + this.textBox2.Text + "',Description='" + this.textBox3.Text + "' where ItemNo='" + ProductItemNo + "';";
                                try
                                {
                                    if (MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlupdate, null) > 0)
                                    {
                                        MessageBox.Show("修改成功");
                                    }
                                    else
                                    {
                                        MessageBox.Show("修改失败，请确认信息是否输入正确。");
                                    }
                                    this.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("修改失败，请确认信息是否输入正确。" + System.Environment.NewLine + "错误信息：" + ex.Message);
                                }

                    }
                }

                }
            
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
