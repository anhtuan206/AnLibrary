using AnLibrary.FormList.Form_Main;
using AnLibrary.FormList.Form_QuanLyNhanVien;
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
using AnLibrary.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AnLibrary
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CheckDatabaseConnection())
            {
                EnsureAdminAccountExists();  // Ensure admin account is there
            }
            txtUsername.Text = "admin";
            txtPassword.Text = "admin";
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // Có thể thêm mã hóa sau
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new AnLibraryDbContainer())
            {
                // Có thể dùng thêm mã hóa mật khẩu tại đây nếu cần
                var account = db.Accounts
                                .FirstOrDefault(a => a.Username == username && a.Password == password);

                if (account != null && account.isActive)
                {
                    // Lưu thông tin đăng nhập vào session
                    AppSession.CurrentUser = account;

                    //MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    // Ví dụ mở form chính:
                    var mainForm = new MainForm();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản bị khóa.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // Có thể thêm mã hóa sau

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new AnLibraryDbContainer())
            {
                // Có thể dùng thêm mã hóa mật khẩu tại đây nếu cần
                var account = db.Accounts
                                .FirstOrDefault(a => a.Username == username && a.Password == password);

                if (account != null && account.isActive)
                {
                    // Lưu thông tin đăng nhập vào session
                    AppSession.CurrentUser = account;

                    //MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    // Ví dụ mở form chính:
                    var mainForm = new MainForm();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản bị khóa.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool CheckDatabaseConnection()
        {
            try
            {
                using (var db = new AnLibraryDbContainer())
                {
                    db.Database.Connection.Open();
                    db.Database.Connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu:\n" + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void EnsureAdminAccountExists()
        {
            using (var db = new AnLibraryDbContainer())
            {
                var admin = db.Accounts.FirstOrDefault(a => a.Username == "admin");

                if (admin == null)
                {
                    var newAdmin = new Account
                    {
                        Username = "admin",
                        Password = "admin",
                        Fullname = "Administrator",
                        IdNumber = "000000000",
                        Address = "System",
                        Birthday = DateTime.Today,
                        isActive = true
                    };

                    db.Accounts.Add(newAdmin);
                    db.SaveChanges();

                }
            }
        }

    }
}
