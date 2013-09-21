using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList
{
    public partial class Todos : System.Web.UI.Page
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
        public IQueryable<TodoList.Category> GridViewCategories_GetData()
        {
            TodoDbEntities context = new TodoDbEntities();
            var categories = context.Categories;

            return categories;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int categoryId)
        {
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            TodoDbEntities context = new TodoDbEntities();
            Category category = context.Categories.Find(categoryId);
            if (category == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Category with id {0} was not found", categoryId));
                return;
            }
            TryUpdateModel(category);
            if (ModelState.IsValid)
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }

            this.GridViewTodos.DataBind();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int categoryId)
        {
            TodoDbEntities context = new TodoDbEntities();
            Category category = context.Categories.Find(categoryId);

            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public void InsertCategory(Category category)
        {
            TodoDbEntities context = new TodoDbEntities();
            context.Categories.Add(category);

            context.SaveChanges();

            this.GridViewCategories.DataBind();
            this.GridViewTodos.DataBind();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<TodoList.TodoItem> GridViewTodos_GetData()
        {
            TodoDbEntities context = new TodoDbEntities();
            var todos = context.TodoItems.OrderBy(t => t.Title);

            return todos;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewTodos_UpdateItem(int todoId)
        {
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            TodoDbEntities context = new TodoDbEntities();
            TodoItem todo = context.TodoItems.Find(todoId);
            if (todo == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Category with id {0} was not found", todoId));
                return;
            }
            TryUpdateModel(todo);
            if (ModelState.IsValid)
            {
                context.Entry(todo).State = EntityState.Modified;
                context.SaveChanges();

            }

            this.GridViewTodos.DataBind();
            this.GridViewCategories.DataBind();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewTodos_DeleteItem(int todoId)
        {
            TodoDbEntities context = new TodoDbEntities();
            TodoItem todo = context.TodoItems.Find(todoId);

            context.TodoItems.Remove(todo);
            context.SaveChanges();
        }

        public void InsertTodoItem(TodoItem todo)
        {
            TodoDbEntities context = new TodoDbEntities();
            context.TodoItems.Add(todo);

            context.SaveChanges();

            this.GridViewTodos.DataBind();
            this.GridViewCategories.DataBind();
        }
    }
}