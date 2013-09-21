using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsTemplate
{
    public partial class EditDeleteMessages : System.Web.UI.Page
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
        public IQueryable<Message> ListViewAdmin_GetData()
        {
            ChatIdentityEntities context = new ChatIdentityEntities();
            var messages = context.Messages;

            return messages;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewAdmin_DeleteItem(int messageId)
        {
            ChatIdentityEntities context = new ChatIdentityEntities();
            Message message = context.Messages.Find(messageId);

            if (message != null)
            {
                context.Messages.Remove(message);
                context.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewAdmin_UpdateItem(int messageId)
        {
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            ChatIdentityEntities context = new ChatIdentityEntities();
            Message message = context.Messages.Find(messageId);
            if (message == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Category with id {0} was not found", messageId));
                return;
            }
            TryUpdateModel(message);
            if (ModelState.IsValid)
            {
                context.Entry(message).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}