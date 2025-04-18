using AnLibrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using AnLibrary.Class;

namespace AnLibrary.FormList.Form_QuanLyTaiSan
{
    public partial class Category_NewEdit : Form
    {
        private Category _category;

        public Category_NewEdit()
        {
            InitializeComponent();
            _category = null; // new category
            InitializeForm();
        }

        // Constructor for "Edit" category
        public Category_NewEdit(Category category)
        {
            InitializeComponent();
            _category = category; // existing category to edit
            InitializeForm();
        }

        private void InitializeForm()
        {
            if (_category != null)
            {
                // If it's an edit mode, populate the form with category data
                txtCode.Text = _category.CategoryCode;
                txtName.Text = _category.Categoryname;
                txtDescription.Text = _category.Description;
            }
            else
            {
                // If it's a new category, clear fields or set defaults
                txtCode.Text = "";
                txtName.Text = "";
                txtDescription.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string categoryCode = txtCode.Text.Trim();
            string categoryName = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string currentUser = AppSession.CurrentUser.Fullname;  // Ensure this is set properly
            bool result = true;

            if (string.IsNullOrWhiteSpace(categoryCode))
            {
                MessageBox.Show("Vui lòng nhập mã chuyên mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Vui lòng nhập tên chuyên mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_category == null)  // Check if it's a new category
            {
                result = AddNewCategory(categoryCode, categoryName, description, currentUser);
            }
            else  // If _category is not null, update the existing category
            {
                result = UpdateCategory(_category, categoryCode, categoryName, description, currentUser);
            }

            if (!result)
            {
                return;
            }
            this.Close();
            MessageBox.Show("Lưu thông tin chuyên mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool UpdateCategory(Category category, string code, string name, string description, string currentUser)
        {
            using (var db = new AnLibraryDbContainer())
            {
                var isDuplicate = db.Categories
                    .Any(c => c.CategoryCode.ToLower() == code.ToLower() && c.Id != category.Id);

                if (isDuplicate)
                {
                    MessageBox.Show("Mã chuyên mục đã tồn tại. Vui lòng chọn mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                var catToUpdate = db.Categories.FirstOrDefault(c => c.Id == category.Id);
                if (catToUpdate != null)
                {
                    catToUpdate.CategoryCode = code;
                    catToUpdate.Categoryname = name;
                    catToUpdate.Description = description;
                    EntityAuditHelper.SetCreatedInfo(catToUpdate, currentUser);

                    db.SaveChanges();
                }
            }
            return true;
        }


        private bool AddNewCategory(string categoryCode, string categoryName, string description, string currentUser)
        {
            using (var db = new AnLibraryDbContainer())
            {
                // Kiểm tra trùng lặp CategoryCode (không phân biệt hoa thường)
                bool isDuplicate = db.Categories.Any(c => c.CategoryCode.ToLower() == categoryCode.ToLower());
                if (isDuplicate)
                {
                    MessageBox.Show("Mã chuyên mục đã tồn tại. Vui lòng chọn mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Thêm mới nếu không trùng
                var newCategory = new Category
                {
                    CategoryCode = categoryCode,
                    Categoryname = categoryName,
                    Description = description,
                    CreatedBy = currentUser,
                    CreatedDate = DateTime.Now
                };

                EntityAuditHelper.SetCreatedInfo(newCategory, currentUser);

                db.Categories.Add(newCategory);
                db.SaveChanges();
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Category_NewEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
