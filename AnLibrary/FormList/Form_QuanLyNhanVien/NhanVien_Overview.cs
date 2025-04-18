using AnLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnLibrary.FormList.Form_QuanLyNhanVien
{
    public partial class NhanVien_Overview : Form
    {
        public NhanVien_Overview()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountEdit_Click(object sender, EventArgs e)
        {

        }

        private void NhanVien_Overview_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }
        private void LoadAccounts()
        {
            using (var db = new AnLibraryDbContainer())
            {
                var accounts = db.Accounts
                 .Select(a => new
                 {
                     a.Username,
                     a.Fullname,
                     a.IdNumber,
                     a.Address,
                     a.Birthday,
                     a.isActive
                 })
                 .ToList() // Lấy ra khỏi database trước khi định dạng
                 .Select(a => new
                 {
                     a.Username,
                     a.Fullname,
                     a.IdNumber,
                     a.Address,
                     Birthday = a.Birthday.HasValue ? a.Birthday.Value.ToString("dd-MM-yyyy") : "",
                     a.isActive
                 })
                 .ToList();

                dgvAccount.DataSource = accounts;
            }
        }

        private void btnAccountNew_Click(object sender, EventArgs e)
        {
            using (var form = new NhanVien_NewEdit(null)) // Truyền null để form hiểu là tạo mới
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAccounts(); // Reload danh sách sau khi thêm mới
                }
            }
        }
    }
}
