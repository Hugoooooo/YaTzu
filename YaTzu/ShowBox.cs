using System.Framework;
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
    public partial class ShowBox : Form
    {
        public ShowBoxType type;
        public ShowBox(ShowBoxType ptype,string pmsg ="")
        {
            InitializeComponent();
            type = ptype;
            lbMsg.Text = pmsg;
            if(ptype==ShowBoxType.alert)
            {
                panelAlert.Visible = true;
                panelConfirm.Visible = false;
            }
            else
            {
                panelAlert.Visible = false;
                panelConfirm.Visible = true;

            }
        }

        private void btnAlertOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConfirmOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConfirmCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && type == ShowBoxType.alert)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
