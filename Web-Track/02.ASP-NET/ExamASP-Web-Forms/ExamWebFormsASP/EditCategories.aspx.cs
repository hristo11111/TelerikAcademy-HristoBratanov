using Error_Handler_Control;
using ExamWebFormsASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamWebFormsASP
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> GridViewEditCategories_GetData()
        {
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var categories = context.Categories.OrderBy(cat => cat.CategoryId);

            return categories;
        }

        protected void ShowEditMenu(object sender, EventArgs e)
        {
            LinkButton lnkEdit = (LinkButton)sender;
            var categoryId = Convert.ToInt32(lnkEdit.CommandArgument);
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var category = context.Categories.Find(categoryId);
            var categDatasource = new List<Category> { category };

            this.ListViewEditCategory.DataSource = categDatasource;
            this.ListViewEditCategory.DataBind();
        }

        protected void EditCategory(object sender, EventArgs e)
        {
            LinkButton lnkSave = (LinkButton)sender;
            var categoryId = Convert.ToInt32(lnkSave.CommandArgument);
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            using (context)
            {
                var category = context.Categories.Find(categoryId);

                var ctrl = (Control)sender;
                var lvi = (ListViewItem)ctrl.NamingContainer;
                var txt = (TextBox)lvi.FindControl("TextBoxEditCategory");

                var newCat = txt.Text;
                category.CategoryName = newCat;
                context.SaveChanges();
                this.GridViewEditCategories.DataBind();
            }
        }

        protected void CancelCategory(object sender, EventArgs e)
        {
            this.ListViewEditCategory.DataSource = null;
            this.ListViewEditCategory.DataBind();
        }

        protected void DeleteCategory(object sender, EventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)sender;
            var categoryId = Convert.ToInt32(lnkDelete.CommandArgument);
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var category = context.Categories.Include("Books").
                FirstOrDefault(c => c.CategoryId == categoryId);
            
            using (context)
            {
                try
                {
                    context.Books.RemoveRange(category.Books);
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    this.GridViewEditCategories.PageIndex = 0;
                    ErrorSuccessNotifier.AddInfoMessage("Question successfully deleted.");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void ButtonCreateCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCategory.aspx");
        }
        


        //protected void FormViewEditCategory_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        //{
        //    LinkButton lnkSave = (LinkButton)sender;
        //    var categoryId = Convert.ToInt32(lnkSave.CommandArgument);
        //    ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
        //    var category = context.Categories.Find(categoryId);

        //    var textBox = (TextBox)this.FormViewEditCategory.FindControl("TextBoxEditCategory");
        //    var newCategoryName = textBox.Text;

        //    category.CategoryName = newCategoryName;
        //    context.SaveChanges();

        //    this.FormViewEditCategory.DataBind();
        //}

        //protected void FormViewEditCategory_ModeChanged(object sender, EventArgs e)
        //{
        //    this.FormViewEditCategory.ChangeMode(FormViewMode.Edit);
        //}
    }
}