using AnLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnLibrary.FormList.Form_QuanLyTaiSan
{
    public partial class TaiSan_Overview : Form
    {
        private bool isLoading = false;

        public TaiSan_Overview()
        {
            InitializeComponent();
        }

        private void TaiSan_Overview_Load(object sender, EventArgs e)
        {
            isLoading = true;
            LoadBooksToGrid();
            LoadCategoriesToGrid();
            LoadCategoriesFilter();
            //PerformSearch();
            isLoading = false;

        }
        private object ProjectBookToDisplay(Book b)
        {
            return new
            {
                b.Id,
                b.BookName,
                b.Author,
                b.Publisher,
                b.PublishYear,
                b.Description,
                isActive = b.isActive ? "Có" : "Không",
                CreatedDate = b.CreatedDate.ToString("dd-MM-yyyy HH:mm"),
                b.CreatedBy,
                b.ChangedBy,
                ChangedDate= b.ChangedDate.ToString("dd-MM-yyyy HH:mm"),
                Category = b.Category?.Categoryname
            };
        }

        private void ChangeGridHeader()
        {
            if (dgvBook.Columns.Count == 0) return; // Không làm gì nếu chưa có cột

            if (dgvBook.Columns.Contains("Id"))
                dgvBook.Columns["Id"].Visible = false;

            if (dgvBook.Columns.Contains("BookName"))
                dgvBook.Columns["BookName"].HeaderText = "Tên sách";

            if (dgvBook.Columns.Contains("Author"))
                dgvBook.Columns["Author"].HeaderText = "Tác giả";

            if (dgvBook.Columns.Contains("Publisher"))
                dgvBook.Columns["Publisher"].HeaderText = "Nhà xuất bản";

            if (dgvBook.Columns.Contains("PublishYear"))
                dgvBook.Columns["PublishYear"].HeaderText = "Năm xuất bản";

            if (dgvBook.Columns.Contains("Description"))
                dgvBook.Columns["Description"].HeaderText = "Mô tả";

            if (dgvBook.Columns.Contains("isActive"))
                dgvBook.Columns["isActive"].HeaderText = "Trạng thái";

            if (dgvBook.Columns.Contains("CreatedDate"))
                dgvBook.Columns["CreatedDate"].HeaderText = "Ngày tạo";

            if (dgvBook.Columns.Contains("CreatedBy"))
                dgvBook.Columns["CreatedBy"].HeaderText = "Người tạo";

            if (dgvBook.Columns.Contains("ChangedBy"))
                dgvBook.Columns["ChangedBy"].HeaderText = "Người sửa";

            if (dgvBook.Columns.Contains("ChangedDate"))
                dgvBook.Columns["ChangedDate"].HeaderText = "Ngày sửa";

            if (dgvBook.Columns.Contains("CategoryName")) // sửa lại đúng tên cột
                dgvBook.Columns["CategoryName"].HeaderText = "Chuyên mục";
        }
        public class BookDisplayModel
        {
            public int Id { get; set; }
            public string BookName { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public int PublishYear { get; set; }
            public string Description { get; set; }
            public bool isActive { get; set; }
            public DateTime CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public string ChangedBy { get; set; }
            public DateTime ChangedDate { get; set; }
            public string CategoryName { get; set; }
        }
        private void LoadBooksToGrid()
        {
            using (var db = new AnLibraryDbContainer())
            {
                var books = db.Books.Include("Category").ToList()
                                    .Select(b => ProjectBookToDisplay(b))
                                    .ToList();

                if (books.Any())
                {
                    dgvBook.DataSource = books;
                }
                else
                {
                    dgvBook.DataSource = new List<BookDisplayModel>();
                }
                ChangeGridHeader();
            }
        }
        private void PerformSearch()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            int? selectedCategoryId = cbCategory.SelectedIndex > 0
                ? (int?)((ComboBoxItem)cbCategory.SelectedItem).Value
                : null;

            using (var db = new AnLibraryDbContainer())
            {
                var query = db.Books.Include("Category").AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(b =>
                        b.Id.ToString().Contains(keyword) ||
                        b.BookName.ToLower().Contains(keyword) ||
                        b.Author.ToLower().Contains(keyword) ||
                        b.Publisher.ToLower().Contains(keyword) ||
                        b.PublishYear.ToString().Contains(keyword));
                }

                if (selectedCategoryId.HasValue && selectedCategoryId.Value > 0)
                {
                    query = query.Where(b => b.Category.Id == selectedCategoryId.Value);
                }

                var books = query.ToList()
                                 .Select(b => ProjectBookToDisplay(b))
                                 .ToList();

                dgvBook.DataSource = books;
                ChangeGridHeader();
            }
        }



        private void LoadCategoriesFilter()
        {
            using (var db = new AnLibraryDbContainer())
            {
                var categories = db.Categories
                    .Select(c => new ComboBoxItem { Value = c.Id, Text = c.Categoryname })
                    .ToList();

                categories.Insert(0, new ComboBoxItem { Text = "-- Tất cả --", Value = 0 });

                cbCategory.DataSource = categories;
                cbCategory.DisplayMember = "Text";
                cbCategory.ValueMember = "Value";
                cbCategory.SelectedIndex = 0;
            }
        }


        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString() => Text;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            PerformSearch();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            PerformSearch();
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            var addForm = new Category_NewEdit(); // No category provided -> New category mode
            addForm.FormClosed += (s, args) => LoadCategoriesToGrid();
            addForm.ShowDialog();

            LoadCategoriesFilter(); // Reload categories if necessary
            PerformSearch();  // Or refresh the books list
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategory.CurrentRow != null)
            {
                int categoryId = (int)dgvCategory.CurrentRow.Cells["Id"].Value;

                using (var db = new AnLibraryDbContainer())
                {
                    var category = db.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (category != null)
                    {
                        var editForm = new Category_NewEdit(category); // Pass the selected category for editing
                        editForm.FormClosed += (s, args) => LoadCategoriesToGrid();
                        editForm.ShowDialog();

                        LoadCategoriesFilter(); // Reload categories if necessary
                        PerformSearch();  // Or refresh the books list
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy chuyên mục để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chuyên mục cần chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadCategoriesToGrid()
        {
            using (var db = new AnLibraryDbContainer())
            {
                var rawList = db.Categories.ToList(); // Lấy toàn bộ dữ liệu trước

                var categoryList = rawList.Select(c => new
                {
                    c.Id,
                    c.CategoryCode,
                    c.Categoryname,
                    c.Description,
                    c.CreatedBy,
                    CreatedDate = c.CreatedDate.ToString("dd-MM-yyyy HH:mm:ss"),
                    c.ChangedBy,
                    ChangedDate = c.ChangedDate.ToString("dd-MM-yyyy HH:mm:ss")
                }).ToList();

                dgvCategory.DataSource = categoryList;

                // Tùy chỉnh tiêu đề cột
                dgvCategory.Columns["Id"].Visible = false;
                dgvCategory.Columns["CategoryCode"].HeaderText = "Mã chuyên mục";
                dgvCategory.Columns["Categoryname"].HeaderText = "Tên chuyên mục";
                dgvCategory.Columns["Description"].HeaderText = "Mô tả";
                dgvCategory.Columns["CreatedBy"].HeaderText = "Người tạo";
                dgvCategory.Columns["CreatedDate"].HeaderText = "Ngày tạo";
                dgvCategory.Columns["ChangedBy"].HeaderText = "Người sửa";
                dgvCategory.Columns["ChangedDate"].HeaderText = "Ngày sửa";
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        private void DeleteCategory()
        {
            if (dgvCategory.CurrentRow != null)
            {
                // Lấy ID của dòng đang chọn
                int id = Convert.ToInt32(dgvCategory.CurrentRow.Cells["Id"].Value);

                // Hỏi xác nhận người dùng
                var confirmResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa chuyên mục này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    using (var db = new AnLibraryDbContainer())
                    {
                        var categoryToDelete = db.Categories.FirstOrDefault(c => c.Id == id);
                        if (categoryToDelete != null)
                        {
                            db.Categories.Remove(categoryToDelete);
                            db.SaveChanges();

                            // Sau khi xóa, cập nhật lại danh sách
                            LoadCategoriesToGrid();

                            MessageBox.Show("Đã xóa chuyên mục thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy chuyên mục để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNewBook_Click(object sender, EventArgs e)
        {
            var addForm = new Book_NewEdit();
            addForm.FormClosed += (s, args) => PerformSearch();
            addForm.ShowDialog();
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBook.CurrentRow != null)
            {
                // Lấy ID của dòng đang chọn
                int id = Convert.ToInt32(dgvBook.CurrentRow.Cells["Id"].Value);

                // Hỏi xác nhận người dùng
                var confirmResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sách này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    using (var db = new AnLibraryDbContainer())
                    {
                        var bookToDelete = db.Books.FirstOrDefault(c => c.Id == id);
                        if (bookToDelete != null)
                        {
                            db.Books.Remove(bookToDelete);
                            db.SaveChanges();

                            // Sau khi xóa, cập nhật lại danh sách
                            LoadBooksToGrid();

                            MessageBox.Show("Đã xóa sách thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sách để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    PerformSearch();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count > 0)
            {
                int bookId = (int)dgvBook.SelectedRows[0].Cells["Id"].Value;
                using (var db = new AnLibraryDbContainer())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        var editForm = new Book_NewEdit(book);
                        editForm.FormClosed += (s, args) => PerformSearch();
                        editForm.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách để sửa.");
            }
        }
    }
}
