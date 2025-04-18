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
    public partial class NhanVien_NewEdit : Form
    {
        private Account _account;
        private bool isNew;

        public NhanVien_NewEdit(Account account = null)
        {
            InitializeComponent();
            if (account == null)
            {
                _account = new Account();
                isNew = true;
            }
            else
            {
                _account = account;
                isNew = false;
            }
        }

        private void NhanVien_NewEdit_Load(object sender, EventArgs e)
        {
            if (_account != null)
            {
                txtUsername.Text = _account.Username;
                txtFullname.Text = _account.Fullname;
                txtIdNumber.Text = _account.IdNumber;
                txtAddress.Text = _account.Address;
                txtNgaySinh.Text = _account.Birthday?.ToString("yyyy-MM-dd") ?? string.Empty;
                chkActive.Checked = _account.isActive;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập Username.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIdNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập CMND/CCCD.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword1.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                return;
            }

            if (txtPassword.Text != txtPassword1.Text)
            {
                MessageBox.Show("Mật khẩu không khớp.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên.");
                return;
            }

            using (var db = new AnLibraryDbContainer())
            {
                Account account;

                if (isNew)
                {
                    account = new Account();
                    db.Accounts.Add(account); // Add vào DbSet nếu là tạo mới
                }
                else
                {
                    // Gán đối tượng cần cập nhật từ DB để theo dõi thay đổi
                    account = db.Accounts.FirstOrDefault(a => a.Username == _account.Username);
                    if (account == null)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để cập nhật.");
                        return;
                    }
                }

                // Gán lại dữ liệu từ form
                account.Username = txtUsername.Text;
                account.Password = txtPassword.Text; // Mật khẩu có thể được mã hóa trước khi lưu
                account.Fullname = txtFullname.Text;
                account.IdNumber = txtIdNumber.Text;
                account.Address = txtAddress.Text;

                if (DateTime.TryParse(txtNgaySinh.Text, out DateTime dob))
                    account.Birthday = dob;
                else
                    account.Birthday = null;

                account.isActive = chkActive.Checked;

                db.SaveChanges(); // Lưu thay đổi vào DB
            }

            MessageBox.Show("Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
