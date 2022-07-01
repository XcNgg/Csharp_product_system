using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data;

namespace ProductSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void labelclose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        private void loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                string username, password;
                string sqltext1;
                username = usertextBox.Text;
                password = textBoxpwd.Text;
                sqltext1 = "select UserPassword,UserRole from User where UserName='" + username + "'";
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null);
                if (ds.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("用户名不存在");
                }
                else
                {
                    string truepwd = ds.Tables[0].Rows[0]["UserPassword"].ToString();
                    int permissions = Convert.ToInt32(ds.Tables[0].Rows[0]["UserRole"].ToString());
                    if (truepwd.CompareTo(password) == 0)
                    {
                        MainForm mainform = new MainForm(username,permissions);

                        this.Hide();
                        usertextBox.Text = "";
                        textBoxpwd.Text = "";
                        mainform.Show();
                    }
                    else
                        MessageBox.Show("密码错误");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("登录失败！！请查看您的网络是否断开！！");
                MessageBox.Show(ex.Message);
                //throw;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void usertextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxpwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm("游客",4);
            this.Hide();
            usertextBox.Text = "";
            textBoxpwd.Text = "";
            mainform.Show();
        }
    }
}
