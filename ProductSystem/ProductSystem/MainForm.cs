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
    public partial class MainForm : Form
    {
        static string usernamestr;
        static int userpermissions;
        public MainForm()
        {
            usernamestr = "admin";
            InitializeComponent();
        }

        public MainForm(string user,int permissions)
        {
            usernamestr = user;
            userpermissions = permissions;
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            this.Text = "【产品管理系统】  | |   当前用户：【" + usernamestr+"】  | |  ";
            //权限判断
            if (userpermissions == 0)
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
            else if (userpermissions == 1 || userpermissions == 2 || userpermissions == 3)
            {
                toolStripButton2.Visible = false; 
            }
            else if (userpermissions == 4) {
                toolStripButton3.Visible = false;
                toolStripButton2.Visible = false;
            }
            switch (userpermissions)
            {
                case 0:
                    MessageBox.Show("您当前的权限为：最高管理员");
                    this.Text = this.Text += "【最高管理员】";
                    break;

                case 1:
                    MessageBox.Show("您当前的权限为：市场部");
                    this.Text = this.Text += "【市场部】";
                    break;
                case 2:
                    MessageBox.Show("您当前的权限为：生产部");
                    this.Text = this.Text += "【生产部】";
                    break;
                case 3 :
                    MessageBox.Show("您当前的权限为：物控部");
                    this.Text = this.Text += "【物控部】";
                    break;
                case 4 :
                    MessageBox.Show("您当前的权限为：游客");
                    this.Text = this.Text += "【游客】";
                    break;
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (userpermissions == 0 || userpermissions == 1)
            {
                Marketing_Department mark = new Marketing_Department();
                mark.Show();
            }
            else if (userpermissions == 2 || userpermissions == 3)
            {
                MessageBox.Show("您所属部门没有权限！");
            }
            else
            {
                MessageBox.Show("期待您加入我们！");
            }




        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //生产部门

            if (userpermissions == 0 || userpermissions == 2)
            {
                Production_Department por = new Production_Department();
                por.Show();
            }
            else if (userpermissions == 1 || userpermissions == 3)
            {
                MessageBox.Show("您所属部门没有权限！");
            }
            else
            {
                MessageBox.Show("期待您加入我们！");
            }
           

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {   //密码修改
            Currentuserpwdedit cupe = new Currentuserpwdedit(usernamestr);
            cupe.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {   //后台管理
            Manager_info   minf = new Manager_info();
            minf.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {   //物控部门
            if (userpermissions==0 || userpermissions == 3) {
                Logistics_Department logistics = new Logistics_Department();
                logistics.Show();
            }
            else if (userpermissions==2||userpermissions==1)
            {
                MessageBox.Show("您所属部门没有权限！");
            }
            else
            {
                MessageBox.Show("期待您加入我们！");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            MessageBox.Show("注销成功！");
            log.Show();
            this.Hide();
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            TouristsHome tour = new TouristsHome();
            tour.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
