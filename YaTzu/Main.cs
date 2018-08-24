using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.Application.DataAccess.Common;
using System.Framework;
using System.DataLayer.Entities;
using System.DataLayer.Views;

namespace YaTzu
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            memberInitial();
            lblUser.Text = APConfig.AccountName;
            panelMember.Visible = true;
        }

        #region Panel Member
        private void memberInitial()
        {
            dgvMember.Rows.Clear();
            txtMemberAddr.Text = string.Empty;
            txtMemberName.Text = string.Empty;
            txtMemberTel.Text = string.Empty;
            txtMemberNo.Text = string.Empty;
            ckbMemberOrderDTTM.Checked = false;
            dpkMemberOrderSDTTM.Value = DateTime.Today;
            dpkMemberOrderEDTTM.Value = DateTime.Today;
            ddlMemberPage.Items.Clear();
            lblMemberTotal.Text = "0";
            lblMemberAMTTotal.Text = "0";
        }
        private void memberLoadData(int pageNum)
        {
            int total = 0;
            dgvMember.Rows.Clear();
            DataGridViewRowCollection rows = dgvMember.Rows;
            RosterInfo vRoster = new RosterInfo(APConfig.Conn);
            vRoster.Conditions = " 1=1 ";
            if (!string.IsNullOrEmpty(txtMemberName.Text))
                vRoster.Conditions += " AND " + vRoster.getCondition(RosterInfo.ncConditions.name.ToString(), txtMemberName.Text);
            if (!string.IsNullOrEmpty(txtMemberTel.Text))
                vRoster.Conditions += " AND " + vRoster.getCondition(RosterInfo.ncConditions.phoneLike.ToString(), txtMemberTel.Text);
            if (!string.IsNullOrEmpty(txtMemberAddr.Text))
                vRoster.Conditions += " AND " + vRoster.getCondition(RosterInfo.ncConditions.address.ToString(), txtMemberAddr.Text);
            if (!string.IsNullOrEmpty(txtMemberNo.Text))
                vRoster.Conditions += " AND " + vRoster.getCondition(RosterInfo.ncConditions.noLike.ToString(), txtMemberNo.Text);
            if (!string.IsNullOrEmpty(dpkMemberOrderSDTTM.Value.ToString()) && ckbMemberOrderDTTM.Checked)
                vRoster.Conditions += " AND " + vRoster.getCondition(RosterInfo.ncConditions.orderSDTTM.ToString(), dpkMemberOrderSDTTM.Value.ToString("yyyy/MM/dd"));
            if (!string.IsNullOrEmpty(dpkMemberOrderEDTTM.Value.ToString()) && ckbMemberOrderDTTM.Checked)
                vRoster.Conditions += " AND " + vRoster.getCondition(RosterInfo.ncConditions.orderEDTTM.ToString(), dpkMemberOrderEDTTM.Value.ToString("yyyy/MM/dd"));
            //組排序指令
            if (dgvMember.SortedColumn == null)
                vRoster.OrderBy = vRoster.getOptionOrderBy(RosterInfo.ncSort.Default.ToString());
            else
            {
                string sortname = dgvMember.SortedColumn.Name;
                string sortmode = APConfig.GetValueFromDescription<SortMode>(dgvMember.SortOrder.ToString()).ToString();
                vRoster.OrderBy = string.Format("{0} {1}", vRoster.getOptionOrderBy(sortname), sortmode);
            }
            //查詢頁數初始化且自動跳轉至第一頁
            if (pageNum == 0)
            {
                APConfig.loadPage(ddlMemberPage, vRoster.calculatePage(APConfig.PageCount));
                return;
            }
            //塞入資料
            lblMemberTotal.Text = vRoster.calculateCount().ToString();
            DataSet ds = APConfig.GoPage(vRoster.SQLStatement, pageNum);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rows.Add(new Object[] { dr.ItemArray[0], dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[4], dr.ItemArray[5], dr.ItemArray[3], dr.ItemArray[6], dr.ItemArray[10], dr.ItemArray[11], dr.ItemArray[12] });
            }

            //計算總金額
            vRoster.load();
            while(!vRoster.IsEof)
            {
                total += vRoster.RST_AMOUNT;
                vRoster.next();
            }
            lblMemberAMTTotal.Text = string.Format("{0} 元",total.ToString());


        }
        private void btnMemberDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMember.SelectedRows.Count > 0 && APConfig.SweetAlert(ShowBoxType.confirm, string.Format("是否確定要刪除{0}筆?", dgvMember.SelectedRows.Count)))
                {
                    List<string> sernolist = new List<string>();
                    string delSernoList = "";
                    foreach (DataGridViewRow row in dgvMember.SelectedRows)
                    {
                        sernolist.Add(string.Format("'{0}'", row.Cells["dgvMember_Serno"].Value.ToString()));
                    }
                    delSernoList = string.Join(",", sernolist);
                    Roster entRoster = new Roster(APConfig.Conn);
                    string sConditions = entRoster.getCondition(Roster.ncConditions.sernolist.ToString(), delSernoList);
                    entRoster.deleteAll(sConditions);
                    memberLoadData(ddlMemberPage.SelectedIndex + 1);
                    APConfig.SweetAlert(ShowBoxType.alert, "刪除完成");
                }
            }
            catch (Exception ex)
            {
                APConfig.SweetAlert(ShowBoxType.alert, string.Format("刪除失敗 {0}", ex.Message));
            }
        }
        private void btnMemberAdd_Click(object sender, EventArgs e)
        {
            using (var form = new MemberEdit(mode.Add))
            {
                panelMember.Visible = false;
                panelMask.Visible = true;
                var result = form.ShowDialog();
                panelMember.Visible = true;
                panelMask.Visible = false;
            }
            memberInitial();
        }
        private void btnMemberSearch_Click(object sender, EventArgs e)
        {
            memberLoadData(0);
        }
        private void btnMemberModify_Click(object sender, EventArgs e)
        {
            if (this.dgvMember.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvMember.SelectedRows[0];
                using (var form = new MemberEdit(mode.Edit, row.Cells["dgvMember_Serno"].Value.ToString()))
                {
                    panelMember.Visible = false;
                    panelMask.Visible = true;
                    var result = form.ShowDialog();
                    panelMember.Visible = true;
                    panelMask.Visible = false;
                }
                memberLoadData(ddlMemberPage.SelectedIndex + 1);
            }
        }
        private void dgvMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = this.dgvMember.SelectedRows[0];
            using (var form = new MemberEdit(mode.View, row.Cells["dgvMember_Serno"].Value.ToString()))
            {
                panelMember.Visible = false;
                panelMask.Visible = true;
                var result = form.ShowDialog();
                panelMember.Visible = true;
                panelMask.Visible = false;
            }
        }
        private void btnMemberRight_Click(object sender, EventArgs e)
        {
            if (APConfig.nextPage(ref ddlMemberPage))
                memberLoadData(ddlMemberPage.SelectedIndex + 1);
        }
        private void btnMemberLeft_Click(object sender, EventArgs e)
        {
            if (APConfig.prevPage(ref ddlMemberPage))
                memberLoadData(ddlMemberPage.SelectedIndex + 1);
        }
        private void ddlMemberPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMemberPage.SelectedIndex == -1) return;
            memberLoadData(ddlMemberPage.SelectedIndex + 1);
        }
        private void dgvMember_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == -1 || dgvMember.RowCount == 0) return;
            memberLoadData(ddlMemberPage.SelectedIndex + 1);
        }
        #endregion

        #region Main
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (APConfig.SweetAlert(ShowBoxType.confirm, "確定要離開嗎?"))
            {
                this.Close();
                Environment.Exit(Environment.ExitCode);
            }
        }
        private void btnMember_Click(object sender, EventArgs e)
        {
            panelStats.Height = btnMember.Height;
            panelStats.Top = btnMember.Top;
            ShowMainPanel(panelMember);
            lblBarTitle.Text = "會員專區";
            memberInitial();
        }
        private void ShowMainPanel(Panel showPanel)
        {
            panelMember.Visible = false;
            showPanel.Visible = true;
        }

        #endregion

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

        #region 備份
        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if (APConfig.SweetAlert(ShowBoxType.confirm, "是否確定要備份?"))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(APConfig.Conn.getConnectionString());
                    SqlCommand cmd = new SqlCommand(string.Empty, conn);
                    conn.Open();

                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_BackupData";

                    SqlParameter result = cmd.Parameters.Add("@result", SqlDbType.Int);
                    result.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    if (Convert.ToInt32(result.Value) == 1)
                        APConfig.SweetAlert(ShowBoxType.alert, "備份成功!");
                    else
                        APConfig.SweetAlert(ShowBoxType.alert, "備份失敗!");


                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception ex)
                {
                    APConfig.SweetAlert(ShowBoxType.alert, string.Format("備份失敗!{0}", ex.Message));
                }
            }
        }
        #endregion
    }
}
