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
            ISBN.Focus();
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

        protected void SaveBookButton_Click(object sender, EventArgs e)
        {
            AddBooks books = new AddBooks();
            bool saveSuccess = books.AddBook(ISBN.Text, BookTitle.Text, Category.SelectedValue, Author.SelectedValue, Publisher.Text, PublicationYear.Text, Price.Text);
            if (saveSuccess)
            {
                Response.Redirect("AdminBooks");
            }
            else
            {
                FailureText.Text = "Unable to add a new book to database.";
                ErrorMessage.Visible = true;
            }
        }
    }
}