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
    public partial class Books : System.Web.UI.Page
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
        public IQueryable<Book> GridViewEditBooks_GetData()
        {
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var books = context.Books.OrderBy(b => b.BookId);

            return books;
        }

        public IQueryable<Category> LoadDropDown()
        {
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var categories = context.Categories.OrderBy(cat => cat.CategoryId);

            return categories;
        }

        protected void ShowEditMenu(object sender, EventArgs e)
        {
            LinkButton lnkEdit = (LinkButton)sender;
            var bookId = Convert.ToInt32(lnkEdit.CommandArgument);
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var book = context.Books.Find(bookId);
            var bookDatasource = new List<Book> { book };
            
            this.ListViewEditBook.DataSource = bookDatasource;
            this.ListViewEditBook.DataBind();
        }

        protected void DeleteBook(object sender, EventArgs e)
        {
            LinkButton lnkSave = (LinkButton)sender;
            var bookId = Convert.ToInt32(lnkSave.CommandArgument);
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var book = context.Books.Find(bookId);

            using (context)
            {
                context.Books.Remove(book);
                context.SaveChanges();
                this.GridViewEditBooks.PageIndex = 0;
            }
            
        }

        protected void EditBook(object sender, EventArgs e)
        {
            LinkButton lnkSave = (LinkButton)sender;
            var bookId = Convert.ToInt32(lnkSave.CommandArgument);
            ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();
            var book = context.Books.Find(bookId);
            using (context)
            {
                try
                {
                    var ctrl = (Control)sender;
                    var lvi = (ListViewItem)ctrl.NamingContainer;

                    var txtTitle = (TextBox)lvi.FindControl("TextBoxEditTitle");
                    var newTitle = txtTitle.Text;
                    book.Title = newTitle;

                    var txtAuthors = (TextBox)lvi.FindControl("TextBoxEditAuthors");
                    var newAuthors = txtAuthors.Text;
                    book.Author = newAuthors;

                    var txtIsbn = (TextBox)lvi.FindControl("TextBoxIsbn");
                    var newIsbn = txtIsbn.Text;
                    book.ISBN = newIsbn;

                    var txtWebSite = (TextBox)lvi.FindControl("TextBoxWebSite");
                    var newWeSite = txtWebSite.Text;
                    book.Url = newWeSite;

                    var txtDescription = (TextBox)lvi.FindControl("TextBoxtDescription");
                    var newDescription = txtDescription.Text;
                    book.Description = newDescription;

                    var txtCategory = (DropDownList)lvi.FindControl("DropDownCategory");
                    var newCategoryName = txtCategory.SelectedItem.Text;
                    Category newCategory = context.Categories.Where(c => c.CategoryName == newCategoryName).FirstOrDefault();
                    book.Category = newCategory;

                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Book successfully edited");
                    this.GridViewEditBooks.DataBind();
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
                
            }
        }

        //protected void ShowCreateBookForm(object sender, EventArgs e)
        //{
        //    this.ListViewCreateBook.Visible = true;
        //}
        //protected void CreateBook(object sender, EventArgs e)
        //{
        //    ExamWebFormsASPEntities1 context = new ExamWebFormsASPEntities1();

        //    Book book = new Book();
        //    using (context)
        //    {
        //        var lvi = this.ListViewCreateBook;

        //        var txtTitle = (TextBox)lvi.FindControl("TextBoxEditTitleInsert");
        //        var newTitle = txtTitle.Text;
        //        book.Title = newTitle;

        //        var txtAuthors = (TextBox)lvi.FindControl("TextBoxEditAuthorsInsert");
        //        var newAuthors = txtAuthors.Text;
        //        book.Author = newAuthors;

        //        var txtIsbn = (TextBox)lvi.FindControl("TextBoxIsbnInsert");
        //        var newIsbn = txtIsbn.Text;
        //        book.ISBN = newIsbn;

        //        var txtWebSite = (TextBox)lvi.FindControl("TextBoxWebSiteInsert");
        //        var newWeSite = txtWebSite.Text;
        //        book.Url = newWeSite;

        //        var txtDescription = (TextBox)lvi.FindControl("TextBoxtDescriptionInsert");
        //        var newDescription = txtDescription.Text;
        //        book.Description = newDescription;

        //        var txtCategory = (DropDownList)lvi.FindControl("DropDownCategoryInsert");
        //        var newCategoryName = txtCategory.SelectedItem.Text;
        //        Category newCategory = context.Categories.Where(c => c.CategoryName == newCategoryName).FirstOrDefault();
        //        book.Category = newCategory;

        //        context.SaveChanges();
        //        this.GridViewEditBooks.DataBind();
        //    }
        //}

        protected void CancelBook(object sender, EventArgs e)
        {
            this.ListViewEditBook.DataSource = null;
            this.ListViewEditBook.DataBind();
        }


    }
}