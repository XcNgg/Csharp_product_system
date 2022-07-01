namespace ProductSystem
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.loginbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.usertextBox = new System.Windows.Forms.TextBox();
            this.textBoxpwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginbutton
            // 
            this.loginbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loginbutton.FlatAppearance.BorderSize = 0;
            this.loginbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.loginbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbutton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbutton.ForeColor = System.Drawing.Color.White;
            this.loginbutton.Location = new System.Drawing.Point(565, 224);
            this.loginbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(161, 55);
            this.loginbutton.TabIndex = 4;
            this.loginbutton.Text = "登录";
            this.loginbutton.UseVisualStyleBackColor = false;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MistyRose;
            this.label2.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(592, 346);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Copyright © chd 2022";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // usertextBox
            // 
            this.usertextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.usertextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usertextBox.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usertextBox.Location = new System.Drawing.Point(682, 98);
            this.usertextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usertextBox.Name = "usertextBox";
            this.usertextBox.Size = new System.Drawing.Size(204, 39);
            this.usertextBox.TabIndex = 0;
            this.usertextBox.TextChanged += new System.EventHandler(this.usertextBox_TextChanged);
            // 
            // textBoxpwd
            // 
            this.textBoxpwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBoxpwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxpwd.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxpwd.Location = new System.Drawing.Point(682, 145);
            this.textBoxpwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxpwd.Name = "textBoxpwd";
            this.textBoxpwd.PasswordChar = '*';
            this.textBoxpwd.Size = new System.Drawing.Size(204, 39);
            this.textBoxpwd.TabIndex = 1;
            this.textBoxpwd.TextChanged += new System.EventHandler(this.textBoxpwd_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightCoral;
            this.label1.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(279, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "简 易 生 产 管 理 系 统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(735, 224);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 55);
            this.button1.TabIndex = 7;
            this.button1.Text = "游客";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.loginbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(971, 456);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.textBoxpwd);
            this.Controls.Add(this.usertextBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简易生产管理系统";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loginbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usertextBox;
        private System.Windows.Forms.TextBox textBoxpwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

