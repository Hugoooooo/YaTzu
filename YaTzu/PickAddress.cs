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
    public partial class PickAddress : Form
    {
        public string address;
        public class SomeData
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }

        public PickAddress(string pAddress="")
        {
            InitializeComponent();
            txtAddr.Text = pAddress;

            CityInfo vCity = new CityInfo(APConfig.Conn);
            vCity.load();
            List<SomeData> data = new List<SomeData>();
            while (!vCity.IsEof)
            {
                data.Add(new SomeData() { Value = vCity.CTY_NO, Text = vCity.CTY_NAME });
                vCity.next();
            }
            lbxCity.DisplayMember = "Text";
            lbxCity.DataSource = data;

        }

        #region Button click
        private void btn0_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "9";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAddr.Text))
            {
                txtAddr.Text =txtAddr.Text.Substring(0, txtAddr.Text.Length - 1);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAddr.Text = "";
        }

        private void btnC11_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "縣";
        }

        private void btnC12_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "市";
        }

        private void btnC13_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "鄉";
        }

        private void btnC14_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "區";
        }

        private void btnC15_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "路";
        }

        private void btnC16_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "鎮";
        }

        private void btnC21_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "街";
        }

        private void btnC22_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "段";
        }

        private void btnC23_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "巷";
        }

        private void btnC24_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "弄";
        }

        private void btnC25_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "號";
        }

        private void btnC31_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "樓";
        }

        private void btnC32_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "之";
        }

        private void btnC33_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "鄰";
        }

        private void btnC34_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "村";
        }

        private void btnC35_Click(object sender, EventArgs e)
        {
            txtAddr.Text += "里";
        }
        #endregion

        private void lbxCity_DoubleClick(object sender, EventArgs e)
        {
            txtAddr.Text += lbxCity.GetItemText(lbxCity.SelectedItem);
            tabControl1.SelectedIndex = 1;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && lbxCity.Items.Count > 0)
            {
                lbxArea.DataSource = null;
                string No = (lbxCity.SelectedItem as SomeData).Value;
                AreaInfo vArea = new AreaInfo(APConfig.Conn);
                vArea.Conditions = vArea.getCondition(AreaInfo.ncConditions.CityNo.ToString(), No);
                vArea.load();
                List<SomeData> data = new List<SomeData>();
                while (!vArea.IsEof)
                {
                    data.Add(new SomeData() { Value = vArea.ARA_NO, Text = vArea.ARA_NAME });
                    vArea.next();
                }
                lbxArea.DisplayMember = "Text";
                lbxArea.DataSource = data;
            }
            else if (tabControl1.SelectedIndex == 2 && lbxArea.Items.Count > 0)
            {
                lbxRoad.Items.Clear();
                string No = (lbxArea.SelectedItem as SomeData).Value;
                RoadInfo vRoad = new RoadInfo(APConfig.Conn);
                vRoad.Conditions = " 1=1 ";
                vRoad.Conditions += " AND " + vRoad.getCondition(RoadInfo.ncConditions.AreaNo.ToString(), No);
                if (!string.IsNullOrEmpty(txtRoad.Text))
                    vRoad.Conditions += " AND " + vRoad.getCondition(RoadInfo.ncConditions.Name.ToString(), txtRoad.Text);
                vRoad.load();
                List<SomeData> data = new List<SomeData>();
                while (!vRoad.IsEof)
                {
                    lbxRoad.Items.Add(vRoad.ROD_NAME);
                    vRoad.next();
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                RoadSearch();
            }
        }

        private void lbxArea_DoubleClick(object sender, EventArgs e)
        {
            txtAddr.Text += lbxArea.GetItemText(lbxArea.SelectedItem);
            tabControl1.SelectedIndex = 2;
        }

        private void lbxRoad_DoubleClick(object sender, EventArgs e)
        {
            txtAddr.Text += lbxRoad.GetItemText(lbxRoad.SelectedItem);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                lbxRoad.Items.Clear();
                string No = (lbxArea.SelectedItem as SomeData).Value;
                RoadInfo vRoad = new RoadInfo(APConfig.Conn);
                vRoad.Conditions = " 1=1 ";
                vRoad.Conditions += " AND " + vRoad.getCondition(RoadInfo.ncConditions.AreaNo.ToString(), No);
                if (!string.IsNullOrEmpty(txtRoad.Text))
                    vRoad.Conditions += " AND " + vRoad.getCondition(RoadInfo.ncConditions.Name.ToString(), txtRoad.Text);
                vRoad.load();
                List<SomeData> data = new List<SomeData>();
                while (!vRoad.IsEof)
                {
                    lbxRoad.Items.Add(vRoad.ROD_NAME);
                    vRoad.next();
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                RoadSearch();
            }
          
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            address = txtAddr.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RoadSearch()
        {
            if (!string.IsNullOrEmpty(txtRoad.Text))
            {
                lbxSearch.Items.Clear();
                RoadSearchInfo view = new RoadSearchInfo(APConfig.Conn);
                view.Conditions = " 1=1 ";
                view.Conditions += " AND " + view.getCondition(RoadSearchInfo.ncConditions.Name.ToString(), txtRoad.Text);
                view.load();
                while (!view.IsEof)
                {
                    lbxSearch.Items.Add(view.CTY_NAME + view.ARA_NAME);
                    view.next();
                }
            }
        }

        private void lbxSearch_DoubleClick(object sender, EventArgs e)
        {
            txtAddr.Text += lbxSearch.GetItemText(lbxSearch.SelectedItem+txtRoad.Text);
        }

    }
}
