using Bunifu.Framework.UI;
using System.Application.Common;
using System.Framework;
using System.DataLayer.Entities;
using System.DataLayer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YaTzu
{
    public partial class MemberEdit : Form
    {
        public mode mode;
        public string serno;
        public MemberEdit(mode pmode, string pserno = "")
        {
            InitializeComponent();
            serno = pserno;
            mode = pmode;
            initView();
        }
        private void initView()
        {
            if (mode == mode.Add)
            {
                btnOK.ButtonText = "新增";
                btnOK.IdleFillColor = Color.FromArgb(33, 166, 117);
                btnOK.IdleLineColor = Color.FromArgb(33, 166, 117);
                btnOK.ActiveFillColor = Color.FromArgb(33, 166, 117);
                btnOK.ActiveLineColor = Color.FromArgb(33, 166, 117);
                dpkOrderDTTM.Value = DateTime.Today;
            }
            else if (mode == mode.Edit)
            {
                btnOK.ButtonText = "修改";
                btnOK.IdleFillColor = Color.FromArgb(255, 161, 0);
                btnOK.IdleLineColor = Color.FromArgb(255, 161, 0);
                btnOK.ActiveFillColor = Color.FromArgb(255, 161, 0);
                btnOK.ActiveLineColor = Color.FromArgb(255, 161, 0);
                btnItemAdd.Visible = false;
                btnItemDel.Visible = false;
                btnClear.Visible = false;
                lblTotalCount.Visible = false;
                btnGetAddress.Visible = false;
                RosterInfo view = new RosterInfo(APConfig.Conn);
                view.Conditions = " 1=1 ";
                view.Conditions += " AND " + view.getCondition(RosterInfo.ncConditions.serno.ToString(), serno);
                view.load();
                if (view.load())
                {
                    txtNo.Text = view.RST_NO;
                    txtName.Text = view.RST_NAME;
                    txtPhone.Text = view.RST_PHONE;
                    txtMobile1.Text = view.RST_MOBILE1;
                    txtMobile2.Text = view.RST_MOBILE2;
                    txtAmount.Text = view.RST_AMOUNT.ToString();
                    txtAddr.Text = view.RST_ADDR;
                    txtComment1.Text = view.RST_COMMENT1;
                    txtComment2.Text = view.RST_COMMENT2;
                    txtComment3.Text = view.RST_COMMENT3;
                    dpkOrderDTTM.Value = view.RST_ORDERDTTM;
                }
            }
            else if (mode == mode.View)
            {
                DisableControls();
                btnOK.ButtonText = "確認";
                btnItemAdd.Visible = false;
                btnItemDel.Visible = false;
                btnClear.Visible = false;
                lblTotalCount.Visible = false;
                btnGetAddress.Visible = false;
                RosterInfo view = new RosterInfo(APConfig.Conn);
                view.Conditions = " 1=1 ";
                view.Conditions += " AND " + view.getCondition(RosterInfo.ncConditions.serno.ToString(), serno);
                view.load();
                if (view.load())
                {
                    txtNo.Text = view.RST_NO;
                    txtName.Text = view.RST_NAME;
                    txtPhone.Text = view.RST_PHONE;
                    txtMobile1.Text = view.RST_MOBILE1;
                    txtMobile2.Text = view.RST_MOBILE2;
                    txtAmount.Text = view.RST_AMOUNT.ToString();
                    txtAddr.Text = view.RST_ADDR;
                    txtComment1.Text = view.RST_COMMENT1;
                    txtComment2.Text = view.RST_COMMENT2;
                    txtComment3.Text = view.RST_COMMENT3;
                    dpkOrderDTTM.Value = view.RST_ORDERDTTM;
                }
            }
        }
        private void loadTotalCount()
        {
            lblTotalCount.Text = string.Format("總筆數: {0:n0} ", dgvItem.Rows.Count);
        }
        private void itemInfoAdd()
        {
            if (!checkAdd())
                return;

            DataGridViewRowCollection rows = dgvItem.Rows;
            rows.Add(new Object[] { txtNo.Text, txtName.Text,txtAmount.Text,dpkOrderDTTM.Value.ToShortDateString(),txtPhone.Text,txtMobile1.Text,txtMobile2.Text,txtAddr.Text,txtComment1.Text,txtComment2.Text,txtComment3.Text });
            clearPage();
            loadTotalCount();
        }
        private void DisableControls()
        {
            bool status = false;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is BunifuMetroTextbox)
                    ((BunifuMetroTextbox)ctrl).Enabled = status;
                else if (ctrl is BunifuCheckbox)
                    ((BunifuCheckbox)ctrl).Enabled = status;
                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).Enabled = status;
            }
        }


        private void dgvItem_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvItem.SelectedRows[0];
            txtNo.Text = row.Cells["dgvItem_No"].Value.ToString();
            txtName.Text = row.Cells["dgvItem_Name"].Value.ToString();
            txtPhone.Text = row.Cells["dgvItem_Phone"].Value.ToString();
            txtMobile1.Text = row.Cells["dgvItem_Mobile1"].Value.ToString();
            txtMobile2.Text = row.Cells["dgvItem_Mobile2"].Value.ToString();
            txtAmount.Text = row.Cells["dgvItem_Amount"].Value.ToString();
            txtAddr.Text = row.Cells["dgvItem_Addr"].Value.ToString();
            txtComment1.Text = row.Cells["dgvItem_Comment1"].Value.ToString();
            txtComment2.Text = row.Cells["dgvItem_Comment2"].Value.ToString();
            txtComment3.Text = row.Cells["dgvItem_Comment3"].Value.ToString();
            dpkOrderDTTM.Value = Convert.ToDateTime(row.Cells["dgvItem_OrderDTTM"].Value);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode == mode.Add)
            {
                if(dgvItem.Rows.Count==0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                int count = 0;
                foreach (DataGridViewRow row in dgvItem.Rows)
                {
                    Roster ent = new Roster(APConfig.Conn);
                    ent.RST_SERNO = My.GenSerNo();
                    ent.RST_NO = row.Cells["dgvItem_No"].Value.ToString();
                    ent.RST_NAME = row.Cells["dgvItem_Name"].Value.ToString();
                    ent.RST_PHONE = row.Cells["dgvItem_Phone"].Value.ToString();
                    ent.RST_MOBILE1 = row.Cells["dgvItem_Mobile1"].Value.ToString();
                    ent.RST_MOBILE2 = row.Cells["dgvItem_Mobile2"].Value.ToString();
                    ent.RST_AMOUNT = Convert.ToInt32(row.Cells["dgvItem_Amount"].Value.ToString());
                    ent.RST_ORDERDTTM = DateTime.Parse(row.Cells["dgvItem_OrderDTTM"].Value.ToString());
                    ent.RST_ADDR = row.Cells["dgvItem_Addr"].Value.ToString();
                    ent.RST_COMMENT1 = row.Cells["dgvItem_Comment1"].Value.ToString();
                    ent.RST_COMMENT2 = row.Cells["dgvItem_Comment2"].Value.ToString();
                    ent.RST_COMMENT3 = row.Cells["dgvItem_Comment3"].Value.ToString();
                    ent.RST_INSERTBY = APConfig.AccountName;
                    ent.RST_INSERTDTTM = DateTime.Now;
                    ent.RST_MODIFIEDBY = APConfig.AccountName;
                    ent.RST_MODIFIEDDTTM = DateTime.Now;
                    count += ent.insert();
                }
                APConfig.SweetAlert(ShowBoxType.alert, string.Format("訂單登記完成!\r\n新增 {0} 件", count.ToString()));
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (mode == mode.Edit)
            {
                Roster ent = new Roster(APConfig.Conn);
                ent.RST_SERNO = serno;
                ent.ModifyFields = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12}"
                    , Roster.ncFields.RST_NO.ToString()
                    , Roster.ncFields.RST_NAME.ToString()
                    , Roster.ncFields.RST_PHONE.ToString()
                    , Roster.ncFields.RST_MOBILE1.ToString()
                    , Roster.ncFields.RST_MOBILE2.ToString()
                    , Roster.ncFields.RST_AMOUNT.ToString()
                    , Roster.ncFields.RST_ORDERDTTM.ToString()
                    , Roster.ncFields.RST_ADDR.ToString()
                    , Roster.ncFields.RST_COMMENT1.ToString()
                    , Roster.ncFields.RST_COMMENT2.ToString()
                    , Roster.ncFields.RST_COMMENT3.ToString()
                    , Roster.ncFields.RST_MODIFIEDBY.ToString()
                    , Roster.ncFields.RST_MODIFIEDDTTM.ToString());
                ent.RST_NO = txtNo.Text;
                ent.RST_NAME = txtName.Text;
                ent.RST_PHONE = txtPhone.Text;
                ent.RST_MOBILE1 = txtMobile1.Text;
                ent.RST_MOBILE2 = txtMobile2.Text;
                ent.RST_AMOUNT = Convert.ToInt32(txtAmount.Text);
                ent.RST_ORDERDTTM = DateTime.Parse(dpkOrderDTTM.Value.ToString());
                ent.RST_ADDR = txtAddr.Text;
                ent.RST_COMMENT1 = txtComment1.Text;
                ent.RST_COMMENT2 = txtComment2.Text;
                ent.RST_COMMENT3 = txtComment3.Text;
                ent.RST_MODIFIEDBY = APConfig.AccountName;
                ent.RST_MODIFIEDDTTM = DateTime.Now;
                ent.update();
                APConfig.SweetAlert(ShowBoxType.alert, "修改完成");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (mode == mode.View)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                return;
        }
        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            itemInfoAdd();
        }
        private void btnItemDel_Click(object sender, EventArgs e)
        {
            if (APConfig.SweetAlert(ShowBoxType.confirm, "是否確定要刪除?"))
            {
                foreach (DataGridViewRow row in dgvItem.SelectedRows)
                {
                    dgvItem.Rows.RemoveAt(row.Index);
                }
            }
            loadTotalCount();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearPage();
        }
        private void clearPage()
        {
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty; 
            txtMobile1.Text= string.Empty;
            txtMobile2.Text= string.Empty;
            txtAmount.Text = string.Empty;
            txtAddr.Text = string.Empty;
            txtComment1.Text= string.Empty;
            txtComment2.Text = string.Empty;
            txtComment3.Text = string.Empty;
            txtNo.Focus();
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #region 移動介面 (Border Style = none)
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void panelBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panelBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panelBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        #endregion

        private void btnGetAddress_Click(object sender, EventArgs e)
        {
            using (var form = new PickAddress(txtAddr.Text))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                    txtAddr.Text = form.address;
            }
        }

        private bool checkAdd()
        {
            string msg = "";
            int n,count = 0;
            string[] condReqName = { "txtMobile1", "txtMobile2", "txtPhone" }; //判斷欄位三個至少填一個
            string[] condName = { "txtName", "txtNo" };   //必填欄位
            string[] condNumberName = { "txtAmount" };   //判斷數字欄位
            foreach (Control c in this.Controls)
            {
                if (c is BunifuMetroTextbox)
                {
                    BunifuMetroTextbox textBox = c as BunifuMetroTextbox;
                    if (condName.Contains(textBox.Name) && textBox.Text == string.Empty)
                    {
                        msg = "必要欄位不能為空值!";
                    }
                    else if (condReqName.Contains(textBox.Name) && textBox.Text == string.Empty)
                    {
                        count++;
                    }
                    else if (condNumberName.Contains(textBox.Name) && textBox.Text != string.Empty)
                    {
                        if (!int.TryParse(textBox.Text, out n))
                        {
                            msg = "金額欄位請輸入數字";
                        }
                    }
                }
                else if (c is BunifuDropdown)
                {
                    BunifuDropdown dropdown = c as BunifuDropdown;
                    if (dropdown.selectedIndex == -1)
                    {
                        msg = "欄位不能為空值!";
                    }
                }
            }

            if (count == condReqName.Length)
            {
                msg = "電話欄位至少輸入一欄!";
            }
            if (string.IsNullOrEmpty(msg) && mode == mode.Add)
            {
                foreach (DataGridViewRow row in dgvItem.Rows)
                {
                    if (txtNo.Text == row.Cells["dgvItem_No"].Value.ToString())
                    {
                        msg = "該訂單編號已經存在列表中!請重複確認!!";
                        break;
                    }
                }
            }
            if (string.IsNullOrEmpty(msg) && mode == mode.Add)
            {
                RosterInfo vRoster = new RosterInfo(APConfig.Conn);
                vRoster.Conditions = vRoster.getCondition(RosterInfo.ncConditions.no.ToString(), txtNo.Text);
                if (vRoster.calculateCount() > 0)
                    msg = "該訂單編號已經有資料!請重複確認!";
            }

            if (!string.IsNullOrEmpty(msg))
            {
                APConfig.SweetAlert(ShowBoxType.alert, msg);
            }
            return string.IsNullOrEmpty(msg) ? true : false;
        }
    }
}
