using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Chat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewMessages.DataBind();
        }

        public IQueryable<Chat.Message> ListViewMessages_GetData()
        {
            SimpleChatEntities context = new SimpleChatEntities();
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
            SimpleChatEntities context = new SimpleChatEntities();
            context.Messages.Add(new Message() { Message1 = message });
            context.SaveChanges();
        }
    }
}