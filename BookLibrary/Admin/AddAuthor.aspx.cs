using BookLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary.Admin
{
    public partial class AddAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();
                AuthorName.Focus();
            }
        }

        void ReturnToSender()
        {
            object referrer = ViewState["ReferrerUrl"];
            if (referrer != null)
                Response.Redirect((string)referrer);
            else
                Response.Redirect("Default.aspx");
        }

        protected void SaveAuthorButton_Click(object sender, EventArgs e)
        {
            AuthorsLogic alogic = new AuthorsLogic();
            bool saveSuccess = alogic.AddAuthor(AuthorName.Text);
            if (saveSuccess)
            {
                ReturnToSender();
            }
            else
            {
                FailureText.Text = "Unable to add a new author to database.";
                ErrorMessage.Visible = true;
            }
        }
    }
}