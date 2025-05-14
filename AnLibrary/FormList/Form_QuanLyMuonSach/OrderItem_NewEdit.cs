using AnLibrary.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnLibrary.FormList.Form_QuanLyMuonSach
{
    public partial class OrderItem_NewEdit : Form
    {
        private BookHelper _bookHelper = new BookHelper();
        private bool isLoading = false;

        public OrderItem_NewEdit()
        {
            InitializeComponent();
        }

        private void OrderItem_NewEdit_Load(object sender, EventArgs e)
        {
            isLoading = true;
            LoadBooksToGrid();
            _bookHelper.LoadCategoriesFilter(cbCategory);
            isLoading = false;
        }
        private void LoadBooksToGrid()
        {
            //using (var db = new AnLibraryDbContainer())
            //{
            //    var rawList = db.Books.Include("Category").ToList();
            //    var bookList = rawList.Select(b => new
            //    {
            //        b.Id,
            //        b.BookName,
            //        b.Author,
            //        b.Publisher,
            //        b.PublishYear,
            //        b.Description,
            //        b.isActive,
            //        CreatedDate = b.CreatedDate.ToString("dd-MM-yyyy HH:mm"),
            //        b.CreatedBy,
            //        b.ChangedBy,
            //        ChangedDate = b.ChangedDate.ToString("dd-MM-yyyy HH:mm"),
            //        CategoryName = b.Category?.Categoryname
            //    }).ToList();
            //}
            dgvBook.DataSource = _bookHelper.GetBookList();
            BookHelper.ChangeGridHeader(dgvBook);
            //ChangeGridHeader();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            PerformSearch();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
