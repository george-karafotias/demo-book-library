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
    public partial class AdminBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<BookLibrary.Models.Book> GetBooks()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            return db.Books.OrderBy(book => book.BookID);
        }

        protected void AddBookButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBook.aspx");
        }

        protected void EditBookButton_Click(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string bookID = btn.CommandArgument.ToString();
            Response.Redirect("EditBook.aspx?id=" + bookID);
        }

        protected void DeleteBookButton_Click(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string bookID = btn.CommandArgument.ToString();
            DeleteBooks deleteBooks = new DeleteBooks();
            bool savedChanges = deleteBooks.DeleteBook(Convert.ToInt32(bookID));

            if (savedChanges)
                Response.Redirect("AdminBooks");
        }
    }
}