using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsTemplate
{
    public partial class ChatRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewMessages.DataBind();
        }

        public IQueryable<Message> ListViewMessages_GetData()
        {
            ChatIdentityEntities context = new ChatIdentityEntities();
            var messages = context.Messages;

            return messages;
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            var message = Server.HtmlEncode(this.TextBox_NewMessage.Text);
            if (message == string.Empty)
            {
                return;
            }
            ChatIdentityEntities context = new ChatIdentityEntities();
            context.Messages.Add(new Message() { Message1 = message });
            context.SaveChanges();
        }
    }
}