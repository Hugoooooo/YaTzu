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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            APConfig.LoadConfig();
            AccountInfo view = new AccountInfo(APConfig.Conn);
            view.load();

            int a = view.Count;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panelSaleSearch_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
