using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnLibrary.Class;

namespace AnLibrary.FormList.Form_Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadSubForm(Form subForm)
        {
            panel3.Controls.Clear(); // Xóa subform hiện tại (nếu có)
            subForm.TopLevel = false; // Không là top-level
            subForm.FormBorderStyle = FormBorderStyle.None; // Không viền
            subForm.Dock = DockStyle.Fill; // Fill toàn bộ panel3
            panel3.Controls.Add(subForm);
            subForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Width = this.ClientSize.Width;
            lblWelcome.TextAlign = ContentAlignment.MiddleRight;
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWelcome.Left = this.ClientSize.Width - lblWelcome.Width - 50;
            if (AppSession.CurrentUser != null)
            {
                lblWelcome.Text = $"Chào mừng, {AppSession.CurrentUser.Fullname}";
            }
            else
            {
                lblWelcome.Text = "Chào mừng, Guest";
            }
        }

        private void btnNhanVienOverview_Click(object sender, EventArgs e)
        {
            var nhanVienForm = new FormList.Form_QuanLyNhanVien.NhanVien_Overview();
            LoadSubForm(nhanVienForm);
        }

        private void btnTaiSanOverview_Click(object sender, EventArgs e)
        {
            var taiSanForm = new FormList.Form_QuanLyTaiSan.TaiSan_Overview();
            LoadSubForm(taiSanForm);
        }
    }
}
