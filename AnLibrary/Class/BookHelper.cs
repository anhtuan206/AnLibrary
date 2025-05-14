using AnLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnLibrary.Class
{
    public class BookHelper
    {
        public List<dynamic> GetBookList()
        {
            using (var db = new AnLibraryDbContainer())
            {
                var rawList = db.Books.Include("Category").ToList();
                var bookList =  rawList.Select(b => new
                {
                    b.Id,
                    b.BookName,
                    b.Author,
                    b.Publisher,
                    b.PublishYear,
                    b.Description,
                    b.isActive,
                    CreatedDate = b.CreatedDate.ToString("dd-MM-yyyy HH:mm"),
                    b.CreatedBy,
                    b.ChangedBy,
                    ChangedDate = b.ChangedDate.ToString("dd-MM-yyyy HH:mm"),
                    CategoryName = b.Category?.Categoryname
                }).ToList<dynamic>();
                return bookList;
            }
        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString() => Text;
        }
        public void LoadCategoriesFilter(ComboBox comboBox)
        {
            using (var db = new AnLibraryDbContainer())
            {
                var categories = db.Categories
                    .Select(c => new ComboBoxItem { Value = c.Id, Text = c.Categoryname })
                    .ToList();

                categories.Insert(0, new ComboBoxItem { Text = "-- Tất cả --", Value = 0 });

                comboBox.DataSource = categories;
                comboBox.DisplayMember = "Text";
                comboBox.ValueMember = "Value";
                comboBox.SelectedIndex = 0;
            }
        }

        public static void ChangeGridHeader(DataGridView dgvBook)
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
        public List<dynamic> SearchBooks(string keyword, int? selectedCategoryId)
        {
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

                var rawList = query.ToList();
                return rawList.Select(b => new
                {
                    b.Id,
                    b.BookName,
                    b.Author,
                    b.Publisher,
                    b.PublishYear,
                    b.Description,
                    b.isActive,
                    CreatedDate = b.CreatedDate.ToString("dd-MM-yyyy HH:mm"),
                    b.CreatedBy,
                    b.ChangedBy,
                    ChangedDate = b.ChangedDate.ToString("dd-MM-yyyy HH:mm"),
                    CategoryName = b.Category?.Categoryname
                }).ToList<dynamic>();
            }
        }
    }
}
