namespace ProductSystem.Add
{
    partial class AddOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrder));
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNotes = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpOrderData = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpPlannedDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxOrderState = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemState = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(111, 59);
            this.txtClientName.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(523, 30);
            this.txtClientName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "客户名称：";
            // 
            // txtOrderNotes
            // 
            this.txtOrderNotes.Location = new System.Drawing.Point(109, 164);
            this.txtOrderNotes.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderNotes.Multiline = true;
            this.txtOrderNotes.Name = "txtOrderNotes";
            this.txtOrderNotes.Size = new System.Drawing.Size(846, 60);
            this.txtOrderNotes.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 164);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "备    注：";
            // 
            // dtpOrderData
            // 
            this.dtpOrderData.Location = new System.Drawing.Point(435, 111);
            this.dtpOrderData.Margin = new System.Windows.Forms.Padding(4);
            this.dtpOrderData.Name = "dtpOrderData";
            this.dtpOrderData.Size = new System.Drawing.Size(199, 30);
            this.dtpOrderData.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(340, 116);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "下单时间：";
            // 
            // dtpPlannedDate
            // 
            this.dtpPlannedDate.Location = new System.Drawing.Point(756, 112);
            this.dtpPlannedDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPlannedDate.Name = "dtpPlannedDate";
            this.dtpPlannedDate.Size = new System.Drawing.Size(199, 30);
            this.dtpPlannedDate.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(661, 116);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "预计交期：";
            // 
            // cbxOrderState
            // 
            this.cbxOrderState.AutoCompleteCustomSource.AddRange(new string[] {
            "配置原材料",
            "生产中",
            "成品已入库",
            "已发货"});
            this.cbxOrderState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrderState.FormattingEnabled = true;
            this.cbxOrderState.Items.AddRange(new object[] {
            "配置原材料",
            "生产中",
            "成品已入库",
            "已发货"});
            this.cbxOrderState.Location = new System.Drawing.Point(111, 112);
            this.cbxOrderState.Margin = new System.Windows.Forms.Padding(4);
            this.cbxOrderState.Name = "cbxOrderState";
            this.cbxOrderState.Size = new System.Drawing.Size(199, 28);
            this.cbxOrderState.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 116);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "订单状态：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 243);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "订单详细内容：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNo,
            this.OrderNumber,
            this.Quantity,
            this.ItemState});
            this.dataGridView1.Location = new System.Drawing.Point(19, 263);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(931, 181);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ItemNo
            // 
            this.ItemNo.HeaderText = "货号";
            this.ItemNo.MinimumWidth = 6;
            this.ItemNo.Name = "ItemNo";
            this.ItemNo.Width = 125;
            // 
            // OrderNumber
            // 
            this.OrderNumber.HeaderText = "订单数量";
            this.OrderNumber.MinimumWidth = 6;
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "单价";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 125;
            // 
            // ItemState
            // 
            this.ItemState.HeaderText = "货物状态";
            this.ItemState.Items.AddRange(new object[] {
            "未生产",
            "生产中",
            "已入库"});
            this.ItemState.MinimumWidth = 6;
            this.ItemState.Name = "ItemState";
            this.ItemState.Width = 125;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(707, 463);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 31);
            this.button1.TabIndex = 22;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(850, 463);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 31);
            this.button2.TabIndex = 23;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(90, 463);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "请仔细添加！";
            // 
            // AddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(968, 520);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOrderNotes);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpOrderData);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpPlannedDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxOrderState);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddOrder";
            this.Text = "新增订单";
            this.Load += new System.EventHandler(this.AddOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNotes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpOrderData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpPlannedDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxOrderState;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemState;
        private System.Windows.Forms.Label label2;
    }
}