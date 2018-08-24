namespace YaTzu
{
    partial class ShowBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowBox));
            this.panelAlert = new System.Windows.Forms.Panel();
            this.btnAlertOK = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelConfirm = new System.Windows.Forms.Panel();
            this.btnConfirmCancel = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnConfirmOK = new Bunifu.Framework.UI.BunifuImageButton();
            this.lbMsg = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelAlert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAlertOK)).BeginInit();
            this.panelConfirm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAlert
            // 
            this.panelAlert.Controls.Add(this.btnAlertOK);
            this.panelAlert.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAlert.Location = new System.Drawing.Point(0, 240);
            this.panelAlert.Name = "panelAlert";
            this.panelAlert.Size = new System.Drawing.Size(400, 60);
            this.panelAlert.TabIndex = 0;
            // 
            // btnAlertOK
            // 
            this.btnAlertOK.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAlertOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlertOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAlertOK.Image = ((System.Drawing.Image)(resources.GetObject("btnAlertOK.Image")));
            this.btnAlertOK.ImageActive = null;
            this.btnAlertOK.Location = new System.Drawing.Point(0, 0);
            this.btnAlertOK.Name = "btnAlertOK";
            this.btnAlertOK.Size = new System.Drawing.Size(400, 60);
            this.btnAlertOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAlertOK.TabIndex = 1;
            this.btnAlertOK.TabStop = false;
            this.btnAlertOK.Zoom = 10;
            this.btnAlertOK.Click += new System.EventHandler(this.btnAlertOK_Click);
            // 
            // panelConfirm
            // 
            this.panelConfirm.Controls.Add(this.btnConfirmCancel);
            this.panelConfirm.Controls.Add(this.btnConfirmOK);
            this.panelConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelConfirm.Location = new System.Drawing.Point(0, 180);
            this.panelConfirm.Name = "panelConfirm";
            this.panelConfirm.Size = new System.Drawing.Size(400, 60);
            this.panelConfirm.TabIndex = 1;
            // 
            // btnConfirmCancel
            // 
            this.btnConfirmCancel.BackColor = System.Drawing.Color.Salmon;
            this.btnConfirmCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirmCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmCancel.Image")));
            this.btnConfirmCancel.ImageActive = null;
            this.btnConfirmCancel.Location = new System.Drawing.Point(200, 0);
            this.btnConfirmCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirmCancel.Name = "btnConfirmCancel";
            this.btnConfirmCancel.Size = new System.Drawing.Size(200, 60);
            this.btnConfirmCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnConfirmCancel.TabIndex = 1;
            this.btnConfirmCancel.TabStop = false;
            this.btnConfirmCancel.Zoom = 0;
            this.btnConfirmCancel.Click += new System.EventHandler(this.btnConfirmCancel_Click);
            // 
            // btnConfirmOK
            // 
            this.btnConfirmOK.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnConfirmOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConfirmOK.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmOK.Image")));
            this.btnConfirmOK.ImageActive = null;
            this.btnConfirmOK.Location = new System.Drawing.Point(0, 0);
            this.btnConfirmOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirmOK.Name = "btnConfirmOK";
            this.btnConfirmOK.Size = new System.Drawing.Size(200, 60);
            this.btnConfirmOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnConfirmOK.TabIndex = 0;
            this.btnConfirmOK.TabStop = false;
            this.btnConfirmOK.Zoom = 0;
            this.btnConfirmOK.Click += new System.EventHandler(this.btnConfirmOK_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.White;
            this.lbMsg.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMsg.ForeColor = System.Drawing.Color.Black;
            this.lbMsg.Location = new System.Drawing.Point(-4, 159);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(400, 66);
            this.lbMsg.TabIndex = 11;
            this.lbMsg.Text = "msg";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(132, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // ShowBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelConfirm);
            this.Controls.Add(this.panelAlert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowBox";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShowBox_KeyDown);
            this.panelAlert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAlertOK)).EndInit();
            this.panelConfirm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAlert;
        private Bunifu.Framework.UI.BunifuImageButton btnConfirmCancel;
        private Bunifu.Framework.UI.BunifuImageButton btnConfirmOK;
        private Bunifu.Framework.UI.BunifuImageButton btnAlertOK;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelConfirm;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}