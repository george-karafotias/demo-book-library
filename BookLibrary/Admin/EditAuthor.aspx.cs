using BookLibrary.Logic;
using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary.Admin
{
    public partial class EditAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errorPage = "~/404";
                ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();

                if (Request.Params.AllKeys.Contains("id"))
                {
                    int authorID = Convert.ToInt32(Request["id"]);
                    var db = new BookLibrary.Models.BookLibraryContext();
                    Author author = db.Authors.First(a => a.AuthorID == authorID);
                    AuthorName.Text = author.AuthorName;
                    AuthorName.Focus();
                }
                else
                {
                    Response.Redirect(errorPage);
                }
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

        protected void UpdateAuthorButton_Click(object sender, EventArgs e)
        {
            AuthorsLogic alogic = new AuthorsLogic();
            bool saveSuccess = alogic.UpdateAuthor(Convert.ToInt32(Request["id"]), AuthorName.Text);
            if (saveSuccess)
            {
                ReturnToSender();
            }
            else
            {
                FailureText.Text = "Unable to update the author.";
                ErrorMessage.Visible = true;
            }
        }
    }
}