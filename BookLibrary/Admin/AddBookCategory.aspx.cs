using BookLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary.Admin
{
    public partial class AddBookCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();
                BookCategoryName.Focus();
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

        protected void SaveBookCategoryButton_Click(object sender, EventArgs e)
        {
            BookCategoriesLogic bclogic = new BookCategoriesLogic();
            bool saveSuccess = bclogic.AddBookCategory(BookCategoryName.Text);
            if (saveSuccess)
            {
                ReturnToSender();
            }
            else
            {
                FailureText.Text = "Unable to add a new book category to database.";
                ErrorMessage.Visible = true;
            }
        }
    }
}