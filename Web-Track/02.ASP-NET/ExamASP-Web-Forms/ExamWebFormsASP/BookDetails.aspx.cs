using ExamWebFormsASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamWebFormsASP
{
    public partial class BookDetails : System.Web.UI.Page
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
        public Book ListViewBookDetails_GetData()
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var book = context.Books.Find(id);

            return book;
        }


    }
}