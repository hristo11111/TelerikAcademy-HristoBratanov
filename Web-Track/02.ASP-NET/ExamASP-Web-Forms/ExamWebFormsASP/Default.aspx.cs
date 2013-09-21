using ExamWebFormsASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamWebFormsASP
{
    public partial class _Default : Page
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
        public IQueryable<ExamWebFormsASP.Models.Category> ListViewAllBooks_GetData()
        {
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var categories = context.Categories.Include("Books");

            return categories;
        }
    }
}