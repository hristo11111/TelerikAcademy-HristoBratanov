using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;

namespace WebFormsTemplate
{
    public partial class Edit_messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Message> GetMessages()
        {
            ChatIdentityEntities context = new ChatIdentityEntities();
            var messages = context.Messages;

            return messages;
        }


        protected void CancelButton_Click(object sender, EventArgs e)
        {

        }

        public void ListViewMessages_UpdateItem(int messageId)
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