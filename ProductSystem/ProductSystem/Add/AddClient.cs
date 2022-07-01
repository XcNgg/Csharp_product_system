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
    public partial class AddClient : Form
    {
        private static int Num = 0;
        private static string ClientName = "无";
        public AddClient(int num, string clientname)
        {
            Num = num;
            ClientName = clientname;
            InitializeComponent();
        }

        private void AddClient_Load(object sender, EventArgs e)
        {


            if (Num == 0)
            {
                this.Text = "新增客户";
                this.label7.Visible = false;
                this.label8.Visible = false;
            }
            else if (Num == 1)
            {
                this.Text = "修改客户";
                this.label8.Text = ClientName;

                string sqlselect = "select ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail from Client where ClientName ='" + ClientName + "';";
                 DataSet  db =MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlselect, null);
                 this.txtClientName.Text=db.Tables[0].Rows[0][0].ToString();
                 this.txtClientAbbreviation.Text = db.Tables[0].Rows[0][1].ToString();
                 this.txtClientContacts.Text = db.Tables[0].Rows[0][2].ToString();
                 this.txtClientTelephone.Text = db.Tables[0].Rows[0][3].ToString();
                 this.txtClientAddress.Text = db.Tables[0].Rows[0][4].ToString();
                 this.txtClientEmail.Text = db.Tables[0].Rows[0][5].ToString();
               



            }
            else { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (Num == 0)
            {
                string sqlinsert = "insert into Client(ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail) values ('" + this.txtClientName.Text + "','" + this.txtClientAbbreviation.Text + "','" + this.txtClientContacts.Text + "','" + this.txtClientTelephone.Text + "','" + this.txtClientAddress.Text + "','" + this.txtClientEmail.Text + "');";
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
             else if (Num == 1)
             {


                 string sqlupdate = "update Client set ClientName='" + this.txtClientName.Text + "', ClientAbbreviation='" + this.txtClientAbbreviation.Text + "',ClientContacts='" + this.txtClientContacts.Text + "',ClientTelephone='" + this.txtClientTelephone.Text + "',ClientAddress='" + this.txtClientAddress.Text + "',ClientEmail='" + this.txtClientEmail.Text + "' where ClientName='" + ClientName + "';";
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
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("修改失败，请确认信息是否输入正确。"+System.Environment.NewLine+"错误信息："+ex.Message);
                 }



             }
             else
             { }






        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
