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
	public partial class EditBook : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                string errorPage = "~/404";
                if (Request.Params.AllKeys.Contains("id"))
                {
                    int bookID = Convert.ToInt32(Request["id"]);
                    var db = new BookLibrary.Models.BookLibraryContext();
                    Book book = db.Books.First(a => a.BookID == bookID);
                    ISBN.Text = book.ISBN;
                    BookTitle.Text = book.Title;
                    Category.SelectedValue = book.CategoryID.ToString();
                    Author.SelectedValue = book.AuthorID.ToString();
                    Publisher.Text = book.Publisher;
                    PublicationYear.Text = book.PublicationYear;
                    Price.Text = book.Price.ToString();
                }
                else
                {
                    Response.Redirect(errorPage);
                }
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

        protected void UpdateBookButton_Click(object sender, EventArgs e)
        {
            EditBooks editBooks = new EditBooks();
            bool saveSuccess = editBooks.UpdateBook(Convert.ToInt32(Request["id"]), ISBN.Text, BookTitle.Text, Category.SelectedValue, Author.SelectedValue, Publisher.Text, PublicationYear.Text, Price.Text);
            if (saveSuccess)
            {
                Response.Redirect("AdminBooks");
            }
            else
            {
                FailureText.Text = "Unable to update the book.";
                ErrorMessage.Visible = true;
            }
        }
    }
}