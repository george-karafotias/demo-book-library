using BookLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary.Admin
{
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();
                ISBN.Focus();
            }
        }

        public IQueryable GetBookCategories()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            IQueryable query = db.BookCategories;
            return query;
        }

        public IQueryable GetAuthors()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            IQueryable query = db.Authors;
            return query;
        }

        void ReturnToSender()
        {
            object referrer = ViewState["ReferrerUrl"];
            if (referrer != null)
                Response.Redirect((string)referrer);
            else
                Response.Redirect("Default.aspx");
        }

        protected void SaveBookButton_Click(object sender, EventArgs e)
        {
            BooksLogic bl = new BooksLogic();
            bool saveSuccess = bl.AddBook(ISBN.Text, BookTitle.Text, Category.SelectedValue, Author.SelectedValue, Publisher.Text, PublicationYear.Text, Price.Text);
            if (saveSuccess)
            {
                ReturnToSender();
            }
            else
            {
                FailureText.Text = "Unable to add a new book to database.";
                ErrorMessage.Visible = true;
            }
        }
    }
}