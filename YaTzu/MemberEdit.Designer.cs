namespace YaTzu
{
    partial class MemberEdit
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberEdit));
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelBar = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.txtComment1 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label17 = new System.Windows.Forms.Label();
            this.dgvItem = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.dgvItem_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_OrderDTTM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_Mobile1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_Mobile2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_Addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_Comment1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_Comment2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem_Comment3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.dpkOrderDTTM = new Bunifu.Framework.UI.BunifuDatepicker();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNo = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnClear = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnItemDel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnItemAdd = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnOK = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMobile1 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMobile2 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGetAddress = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtAddr = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAmount = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComment2 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtComment3 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(103, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "訂單資料";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelBar.Controls.Add(this.lblClose);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(593, 32);
            this.panelBar.TabIndex = 66;
            this.panelBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBar_MouseDown);
            this.panelBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBar_MouseMove);
            this.panelBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBar_MouseUp);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(544, 5);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(24, 23);
            this.lblClose.TabIndex = 64;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // txtComment1
            // 
            this.txtComment1.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtComment1.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtComment1.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtComment1.BorderThickness = 2;
            this.txtComment1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComment1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment1.ForeColor = System.Drawing.Color.Black;
            this.txtComment1.isPassword = false;
            this.txtComment1.Location = new System.Drawing.Point(117, 317);
            this.txtComment1.Margin = new System.Windows.Forms.Padding(4);
            this.txtComment1.Name = "txtComment1";
            this.txtComment1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtComment1.Size = new System.Drawing.Size(441, 30);
            this.txtComment1.TabIndex = 9;
            this.txtComment1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(28, 323);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 19);
            this.label17.TabIndex = 80;
            this.label17.Text = "商品備註1:";
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvItem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(183)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvItem_No,
            this.dgvItem_Name,
            this.dgvItem_Amount,
            this.dgvItem_OrderDTTM,
            this.dgvItem_Phone,
            this.dgvItem_Mobile1,
            this.dgvItem_Mobile2,
            this.dgvItem_Addr,
            this.dgvItem_Comment1,
            this.dgvItem_Comment2,
            this.dgvItem_Comment3});
            this.dgvItem.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(183)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItem.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvItem.DoubleBuffered = true;
            this.dgvItem.EnableHeadersVisualStyles = false;
            this.dgvItem.HeaderBgColor = System.Drawing.Color.Gray;
            this.dgvItem.HeaderForeColor = System.Drawing.Color.White;
            this.dgvItem.Location = new System.Drawing.Point(26, 482);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(183)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.RowHeadersWidth = 50;
            this.dgvItem.RowTemplate.Height = 24;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(532, 234);
            this.dgvItem.TabIndex = 87;
            this.dgvItem.DoubleClick += new System.EventHandler(this.dgvItem_DoubleClick);
            // 
            // dgvItem_No
            // 
            this.dgvItem_No.HeaderText = "訂單編號";
            this.dgvItem_No.Name = "dgvItem_No";
            this.dgvItem_No.ReadOnly = true;
            this.dgvItem_No.Width = 200;
            // 
            // dgvItem_Name
            // 
            this.dgvItem_Name.HeaderText = "客戶姓名";
            this.dgvItem_Name.Name = "dgvItem_Name";
            this.dgvItem_Name.ReadOnly = true;
            this.dgvItem_Name.Width = 130;
            // 
            // dgvItem_Amount
            // 
            this.dgvItem_Amount.HeaderText = "訂單金額";
            this.dgvItem_Amount.Name = "dgvItem_Amount";
            this.dgvItem_Amount.ReadOnly = true;
            // 
            // dgvItem_OrderDTTM
            // 
            this.dgvItem_OrderDTTM.HeaderText = "訂單日期";
            this.dgvItem_OrderDTTM.Name = "dgvItem_OrderDTTM";
            this.dgvItem_OrderDTTM.ReadOnly = true;
            // 
            // dgvItem_Phone
            // 
            this.dgvItem_Phone.HeaderText = "住家電話";
            this.dgvItem_Phone.Name = "dgvItem_Phone";
            this.dgvItem_Phone.ReadOnly = true;
            this.dgvItem_Phone.Visible = false;
            // 
            // dgvItem_Mobile1
            // 
            this.dgvItem_Mobile1.HeaderText = "手機號碼1";
            this.dgvItem_Mobile1.Name = "dgvItem_Mobile1";
            this.dgvItem_Mobile1.ReadOnly = true;
            this.dgvItem_Mobile1.Visible = false;
            // 
            // dgvItem_Mobile2
            // 
            this.dgvItem_Mobile2.HeaderText = "手機號碼2";
            this.dgvItem_Mobile2.Name = "dgvItem_Mobile2";
            this.dgvItem_Mobile2.ReadOnly = true;
            this.dgvItem_Mobile2.Visible = false;
            // 
            // dgvItem_Addr
            // 
            this.dgvItem_Addr.HeaderText = "客戶地址";
            this.dgvItem_Addr.Name = "dgvItem_Addr";
            this.dgvItem_Addr.ReadOnly = true;
            this.dgvItem_Addr.Visible = false;
            // 
            // dgvItem_Comment1
            // 
            this.dgvItem_Comment1.HeaderText = "備註1";
            this.dgvItem_Comment1.Name = "dgvItem_Comment1";
            this.dgvItem_Comment1.ReadOnly = true;
            this.dgvItem_Comment1.Visible = false;
            // 
            // dgvItem_Comment2
            // 
            this.dgvItem_Comment2.HeaderText = "備註2";
            this.dgvItem_Comment2.Name = "dgvItem_Comment2";
            this.dgvItem_Comment2.ReadOnly = true;
            this.dgvItem_Comment2.Visible = false;
            // 
            // dgvItem_Comment3
            // 
            this.dgvItem_Comment3.HeaderText = "備註3";
            this.dgvItem_Comment3.Name = "dgvItem_Comment3";
            this.dgvItem_Comment3.ReadOnly = true;
            this.dgvItem_Comment3.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(313, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 91;
            this.label4.Text = "訂單日期:";
            // 
            // dpkOrderDTTM
            // 
            this.dpkOrderDTTM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.dpkOrderDTTM.BorderRadius = 0;
            this.dpkOrderDTTM.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dpkOrderDTTM.ForeColor = System.Drawing.Color.DimGray;
            this.dpkOrderDTTM.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkOrderDTTM.FormatCustom = null;
            this.dpkOrderDTTM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dpkOrderDTTM.Location = new System.Drawing.Point(398, 237);
            this.dpkOrderDTTM.Name = "dpkOrderDTTM";
            this.dpkOrderDTTM.Size = new System.Drawing.Size(160, 35);
            this.dpkOrderDTTM.TabIndex = 91;
            this.dpkOrderDTTM.Value = new System.DateTime(2018, 6, 30, 3, 42, 0, 0);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCount.Location = new System.Drawing.Point(450, 735);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(0, 19);
            this.lblTotalCount.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "訂單編碼:";
            // 
            // txtNo
            // 
            this.txtNo.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtNo.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtNo.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtNo.BorderThickness = 2;
            this.txtNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNo.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNo.ForeColor = System.Drawing.Color.Black;
            this.txtNo.isPassword = false;
            this.txtNo.Location = new System.Drawing.Point(117, 127);
            this.txtNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNo.Name = "txtNo";
            this.txtNo.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtNo.Size = new System.Drawing.Size(160, 30);
            this.txtNo.TabIndex = 2;
            this.txtNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnClear
            // 
            this.btnClear.ActiveBorderThickness = 1;
            this.btnClear.ActiveCornerRadius = 30;
            this.btnClear.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.ActiveForecolor = System.Drawing.Color.White;
            this.btnClear.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.ButtonText = "清除";
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnClear.IdleBorderThickness = 1;
            this.btnClear.IdleCornerRadius = 30;
            this.btnClear.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.IdleForecolor = System.Drawing.Color.White;
            this.btnClear.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.Location = new System.Drawing.Point(478, 432);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 42);
            this.btnClear.TabIndex = 113;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnItemDel
            // 
            this.btnItemDel.ActiveBorderThickness = 1;
            this.btnItemDel.ActiveCornerRadius = 30;
            this.btnItemDel.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(78)))), ((int)(((byte)(113)))));
            this.btnItemDel.ActiveForecolor = System.Drawing.Color.White;
            this.btnItemDel.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(78)))), ((int)(((byte)(113)))));
            this.btnItemDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnItemDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnItemDel.BackgroundImage")));
            this.btnItemDel.ButtonText = "刪除";
            this.btnItemDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemDel.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnItemDel.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnItemDel.IdleBorderThickness = 1;
            this.btnItemDel.IdleCornerRadius = 30;
            this.btnItemDel.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(78)))), ((int)(((byte)(113)))));
            this.btnItemDel.IdleForecolor = System.Drawing.Color.White;
            this.btnItemDel.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(78)))), ((int)(((byte)(113)))));
            this.btnItemDel.Location = new System.Drawing.Point(393, 432);
            this.btnItemDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnItemDel.Name = "btnItemDel";
            this.btnItemDel.Size = new System.Drawing.Size(80, 42);
            this.btnItemDel.TabIndex = 112;
            this.btnItemDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnItemDel.Click += new System.EventHandler(this.btnItemDel_Click);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.ActiveBorderThickness = 1;
            this.btnItemAdd.ActiveCornerRadius = 30;
            this.btnItemAdd.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            this.btnItemAdd.ActiveForecolor = System.Drawing.Color.White;
            this.btnItemAdd.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            this.btnItemAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnItemAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnItemAdd.BackgroundImage")));
            this.btnItemAdd.ButtonText = "新增";
            this.btnItemAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemAdd.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnItemAdd.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnItemAdd.IdleBorderThickness = 1;
            this.btnItemAdd.IdleCornerRadius = 30;
            this.btnItemAdd.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            this.btnItemAdd.IdleForecolor = System.Drawing.Color.White;
            this.btnItemAdd.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(166)))), ((int)(((byte)(117)))));
            this.btnItemAdd.Location = new System.Drawing.Point(308, 432);
            this.btnItemAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Size = new System.Drawing.Size(80, 42);
            this.btnItemAdd.TabIndex = 111;
            this.btnItemAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(32, 48);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 62);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 65;
            this.pictureBox4.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.ActiveBorderThickness = 1;
            this.btnOK.ActiveCornerRadius = 30;
            this.btnOK.ActiveFillColor = System.Drawing.Color.Gray;
            this.btnOK.ActiveForecolor = System.Drawing.Color.White;
            this.btnOK.ActiveLineColor = System.Drawing.Color.Gray;
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.ButtonText = "待";
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnOK.IdleBorderThickness = 1;
            this.btnOK.IdleCornerRadius = 30;
            this.btnOK.IdleFillColor = System.Drawing.Color.Gray;
            this.btnOK.IdleForecolor = System.Drawing.Color.White;
            this.btnOK.IdleLineColor = System.Drawing.Color.Gray;
            this.btnOK.Location = new System.Drawing.Point(260, 748);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 41);
            this.btnOK.TabIndex = 64;
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtName
            // 
            this.txtName.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtName.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtName.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtName.BorderThickness = 2;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.isPassword = false;
            this.txtName.Location = new System.Drawing.Point(117, 165);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtName.Size = new System.Drawing.Size(160, 30);
            this.txtName.TabIndex = 3;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(37, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 115;
            this.label1.Text = "客戶名稱:";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtPhone.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtPhone.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtPhone.BorderThickness = 2;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.isPassword = false;
            this.txtPhone.Location = new System.Drawing.Point(398, 160);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtPhone.Size = new System.Drawing.Size(160, 30);
            this.txtPhone.TabIndex = 4;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(313, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 117;
            this.label5.Text = "住家電話:";
            // 
            // txtMobile1
            // 
            this.txtMobile1.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtMobile1.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtMobile1.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtMobile1.BorderThickness = 2;
            this.txtMobile1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMobile1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile1.ForeColor = System.Drawing.Color.Black;
            this.txtMobile1.isPassword = false;
            this.txtMobile1.Location = new System.Drawing.Point(117, 203);
            this.txtMobile1.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobile1.Name = "txtMobile1";
            this.txtMobile1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtMobile1.Size = new System.Drawing.Size(160, 30);
            this.txtMobile1.TabIndex = 5;
            this.txtMobile1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(28, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 19);
            this.label6.TabIndex = 119;
            this.label6.Text = "手機號碼1:";
            // 
            // txtMobile2
            // 
            this.txtMobile2.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtMobile2.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtMobile2.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtMobile2.BorderThickness = 2;
            this.txtMobile2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMobile2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile2.ForeColor = System.Drawing.Color.Black;
            this.txtMobile2.isPassword = false;
            this.txtMobile2.Location = new System.Drawing.Point(398, 198);
            this.txtMobile2.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobile2.Name = "txtMobile2";
            this.txtMobile2.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtMobile2.Size = new System.Drawing.Size(160, 30);
            this.txtMobile2.TabIndex = 6;
            this.txtMobile2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(304, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 19);
            this.label7.TabIndex = 121;
            this.label7.Text = "手機號碼2:";
            // 
            // btnGetAddress
            // 
            this.btnGetAddress.ActiveBorderThickness = 1;
            this.btnGetAddress.ActiveCornerRadius = 30;
            this.btnGetAddress.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(161)))), ((int)(((byte)(0)))));
            this.btnGetAddress.ActiveForecolor = System.Drawing.Color.White;
            this.btnGetAddress.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(161)))), ((int)(((byte)(0)))));
            this.btnGetAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnGetAddress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGetAddress.BackgroundImage")));
            this.btnGetAddress.ButtonText = "+";
            this.btnGetAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetAddress.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnGetAddress.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnGetAddress.IdleBorderThickness = 1;
            this.btnGetAddress.IdleCornerRadius = 30;
            this.btnGetAddress.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(161)))), ((int)(((byte)(0)))));
            this.btnGetAddress.IdleForecolor = System.Drawing.Color.White;
            this.btnGetAddress.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(161)))), ((int)(((byte)(0)))));
            this.btnGetAddress.Location = new System.Drawing.Point(518, 272);
            this.btnGetAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetAddress.Name = "btnGetAddress";
            this.btnGetAddress.Size = new System.Drawing.Size(40, 45);
            this.btnGetAddress.TabIndex = 124;
            this.btnGetAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGetAddress.Click += new System.EventHandler(this.btnGetAddress_Click);
            // 
            // txtAddr
            // 
            this.txtAddr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtAddr.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtAddr.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtAddr.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtAddr.BorderThickness = 2;
            this.txtAddr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddr.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAddr.ForeColor = System.Drawing.Color.Black;
            this.txtAddr.isPassword = false;
            this.txtAddr.Location = new System.Drawing.Point(117, 279);
            this.txtAddr.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtAddr.Size = new System.Drawing.Size(393, 30);
            this.txtAddr.TabIndex = 8;
            this.txtAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(37, 285);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 19);
            this.label13.TabIndex = 123;
            this.label13.Text = "客戶地址:";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtAmount.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtAmount.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtAmount.BorderThickness = 2;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.isPassword = false;
            this.txtAmount.Location = new System.Drawing.Point(117, 241);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtAmount.Size = new System.Drawing.Size(160, 30);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(37, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 19);
            this.label8.TabIndex = 126;
            this.label8.Text = "訂單金額:";
            // 
            // txtComment2
            // 
            this.txtComment2.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtComment2.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtComment2.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtComment2.BorderThickness = 2;
            this.txtComment2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComment2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment2.ForeColor = System.Drawing.Color.Black;
            this.txtComment2.isPassword = false;
            this.txtComment2.Location = new System.Drawing.Point(117, 355);
            this.txtComment2.Margin = new System.Windows.Forms.Padding(4);
            this.txtComment2.Name = "txtComment2";
            this.txtComment2.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtComment2.Size = new System.Drawing.Size(441, 30);
            this.txtComment2.TabIndex = 11;
            this.txtComment2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(28, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 19);
            this.label9.TabIndex = 128;
            this.label9.Text = "商品備註2:";
            // 
            // txtComment3
            // 
            this.txtComment3.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtComment3.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtComment3.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
            this.txtComment3.BorderThickness = 2;
            this.txtComment3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComment3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment3.ForeColor = System.Drawing.Color.Black;
            this.txtComment3.isPassword = false;
            this.txtComment3.Location = new System.Drawing.Point(117, 393);
            this.txtComment3.Margin = new System.Windows.Forms.Padding(4);
            this.txtComment3.Name = "txtComment3";
            this.txtComment3.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtComment3.Size = new System.Drawing.Size(441, 30);
            this.txtComment3.TabIndex = 12;
            this.txtComment3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(28, 399);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 19);
            this.label10.TabIndex = 130;
            this.label10.Text = "商品備註3:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(26, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 19);
            this.label11.TabIndex = 131;
            this.label11.Text = "*";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(26, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 19);
            this.label12.TabIndex = 132;
            this.label12.Text = "*";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(22, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 19);
            this.label14.TabIndex = 133;
            this.label14.Text = "*";
            // 
            // MemberEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(593, 802);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtComment3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtComment2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGetAddress);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtMobile2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMobile1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dpkOrderDTTM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnItemDel);
            this.Controls.Add(this.btnItemAdd);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.txtComment1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MemberEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MemberEdit";
            this.panelBar.ResumeLayout(false);
            this.panelBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnOK;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Label lblClose;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtComment1;
        private System.Windows.Forms.Label label17;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvItem;
        private Bunifu.Framework.UI.BunifuThinButton2 btnItemDel;
        private Bunifu.Framework.UI.BunifuThinButton2 btnItemAdd;
        private Bunifu.Framework.UI.BunifuThinButton2 btnClear;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuDatepicker dpkOrderDTTM;
        private System.Windows.Forms.Label lblTotalCount;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtNo;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtName;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtMobile2;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtMobile1;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtPhone;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtComment3;
        private System.Windows.Forms.Label label10;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtComment2;
        private System.Windows.Forms.Label label9;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtAmount;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuThinButton2 btnGetAddress;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtAddr;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_OrderDTTM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_Mobile1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_Mobile2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_Addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_Comment1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_Comment2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItem_Comment3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}