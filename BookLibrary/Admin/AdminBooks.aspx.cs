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
            if (!IsPostBack)
            {
                SetDefaultDataSource();
            }
        }

        private List<Book> GetAllBooks()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            List<Book> books = db.Books.ToList();
            return books;
        }

        private void SetDefaultDataSource()
        {
            Books.DataSource = GetAllBooks();
            Books.DataBind();
        }

        //public IQueryable<BookLibrary.Models.Book> GetBooks()
        //{
        //    var db = new BookLibrary.Models.BookLibraryContext();
        //    return db.Books.OrderBy(book => book.BookID);
        //}

        protected void AddBookButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBook.aspx");
        }

        protected void AddBookCategoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBookCategory.aspx");
        }

        protected void AddBookAuthorButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAuthor.aspx");
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

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string termToSearch = SearchText.Text;
            if (!string.IsNullOrEmpty(termToSearch))
            {
                List<Book> books = GetAllBooks();
                List<Book> filteredBooks = books.Where(book => book.ISBN.Contains(termToSearch) || book.Title.Contains(termToSearch) || book.Author.AuthorName.Contains(termToSearch) || book.Category.BookCategoryName.Contains(termToSearch) || book.Publisher.Contains(termToSearch) || book.PublicationYear == termToSearch).ToList();
                Books.DataSource = filteredBooks;
                Books.DataBind();
            }
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            SetDefaultDataSource();
        }
    }
}