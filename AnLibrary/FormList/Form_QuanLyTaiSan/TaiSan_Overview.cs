using AnLibrary.Class;
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
        private BookHelper _bookHelper = new BookHelper();

        public TaiSan_Overview()
        {
            InitializeComponent();
        }

        private void TaiSan_Overview_Load(object sender, EventArgs e)
        {
            isLoading = true;
            LoadBooksToGrid();
            LoadCategoriesToGrid();
            _bookHelper.LoadCategoriesFilter(cbCategory);
            isLoading = false;

        }
        private void LoadBooksToGrid()
        {
            dgvBook.DataSource = _bookHelper.GetBookList();
            BookHelper.ChangeGridHeader(dgvBook);
        }
        private void PerformSearch()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            int? selectedCategoryId = cbCategory.SelectedIndex > 0
                ? (int?)((BookHelper.ComboBoxItem)cbCategory.SelectedItem).Value
                : null;

            dgvBook.DataSource = _bookHelper.SearchBooks(keyword, selectedCategoryId);
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
            addForm.FormClosed += (s, args) => _bookHelper.LoadCategoriesFilter(cbCategory);
            addForm.ShowDialog();
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
                        editForm.FormClosed += (s, args) => _bookHelper.LoadCategoriesFilter(cbCategory);
                        editForm.ShowDialog();

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
