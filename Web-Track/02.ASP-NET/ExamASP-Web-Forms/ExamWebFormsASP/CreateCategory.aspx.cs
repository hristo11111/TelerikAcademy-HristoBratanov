using ExamWebFormsASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamWebFormsASP
{
    public partial class CreateCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateNewCategory(object sender, EventArgs e)
        {
            var newCategory = this.TextBoxEditCategory.Text;
            Category category = new Category() { CategoryName = newCategory };
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            context.Categories.Add(category);
            context.SaveChanges();
        }

        protected void CancelCategory(object sender, EventArgs e)
        {
        }
    }
}