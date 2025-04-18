using AnLibrary.Class;
using AnLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AnLibrary.FormList.Form_QuanLyTaiSan.OrderItem_NewEdit;

namespace AnLibrary.FormList.Form_QuanLyTaiSan
{
    public partial class Book_NewEdit : Form
    {
        private Book _book;

        public Book_NewEdit()
        {
            InitializeComponent();
            _book = null;
            LoadCategories();
            InitializeForm();
        }

        public Book_NewEdit(Book book)
        {
            InitializeComponent();
            _book = book;
            LoadCategories();
            InitializeForm();
        }

        private void LoadCategories()
        {
            using (var db = new AnLibraryDbContainer())
            {
                var categories = db.Categories.ToList();
                cbbCategory.DataSource = categories;
                cbbCategory.DisplayMember = "Categoryname";
                cbbCategory.ValueMember = "Id";
            }
        }

        private void InitializeForm()
        {
            if (_book != null)
            {
                txtBookName.Text = _book.BookName;
                txtAuthor.Text = _book.Author;
                txtPublisher.Text = _book.Publisher;
                txtPublishYear.Text = _book.PublishYear.ToString();
                labelDescription.Text = _book.Description;
                cbbCategory.SelectedValue = _book.Category.Id;
            }
        }

        private void Book_NewEdit_Load(object sender, EventArgs e)
        {
            // Khi form được tải, thiết lập selected index cho cbbCategory nếu là tạo mới 1 sách
            if (_book == null && cbbCategory.Items.Count > 0)
            {
                cbbCategory.SelectedIndex = 0; // Chọn lại mục đầu tiên
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string bookName = txtBookName.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string publisher = txtPublisher.Text.Trim();
            string year = txtPublishYear.Text.Trim();
            string description = txtDescription.Text.Trim();
            string currentUser = AppSession.CurrentUser.Fullname;

            if (!validateBookInput()){
                return;
            }
            if (!int.TryParse(cbbCategory.SelectedValue.ToString(), out int Id))
            {
                MessageBox.Show("Giá trị chuyên mục không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            using (var db = new AnLibraryDbContainer())
            {
                Category selectedCategory = db.Categories.FirstOrDefault(c => c.Id == Id);

                if (selectedCategory == null)
                {
                    MessageBox.Show("Chuyên mục không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (_book == null)
                {
                    var newBook = new Book
                    {
                        BookName = bookName,
                        Author = author,
                        Publisher = publisher,
                        PublishYear = int.Parse(year),
                        Category = selectedCategory,
                        Description = description,
                        isActive = true
                    };

                    EntityAuditHelper.SetCreatedInfo(newBook, currentUser);
                    EntityAuditHelper.SetChangedInfo(newBook, currentUser);

                    db.Books.Add(newBook);
                }
                else
                {
                    var bookToUpdate = db.Books.FirstOrDefault(b => b.Id == _book.Id);
                    if (bookToUpdate != null)
                    {
                        bookToUpdate.BookName = bookName;
                        bookToUpdate.Author = author;
                        bookToUpdate.Publisher = publisher;
                        bookToUpdate.PublishYear = int.Parse(year);
                        bookToUpdate.Category = selectedCategory;
                        bookToUpdate.Description = description;

                        EntityAuditHelper.SetChangedInfo(bookToUpdate, currentUser);
                    }
                }

                db.SaveChanges();
            }

            MessageBox.Show("Lưu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private bool validateBookInput()
        {
            string bookName = txtBookName.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string publisher = txtPublisher.Text.Trim();
            string year = txtPublishYear.Text.Trim();
            string description = labelDescription.Text.Trim();
            string currentUser = AppSession.CurrentUser.Fullname;

            if (string.IsNullOrWhiteSpace(bookName))
            {
                MessageBox.Show("Vui lòng nhập tên sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(publisher))
            {
                MessageBox.Show("Vui lòng nhập tên nhà xuất bản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(year))
            {
                MessageBox.Show("Vui lòng nhập năm xuất bản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(year, out int publishYear))
            {
                MessageBox.Show("Năm xuất bản phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbbCategory.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chuyên mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
