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
            this.FilterMode = false;
            this.LastSearchTerm = "";
        }

        private string SortExpression
        {
            get
            {
                if (String.IsNullOrWhiteSpace((String)ViewState["SortExpression"]))
                    ViewState["SortExpression"] = "Name ASC";

                return (String)ViewState["SortExpression"];
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

        private bool FilterMode
        {
            get
            {
                return (bool)ViewState["FilterMode"];
            }
            set
            {
                ViewState["FilterMode"] = value;
            }
        }

        private string LastSearchTerm
        {
            get
            {
                return (String)ViewState["LastSearchTerm"];
            }
            set
            {
                ViewState["LastSearchTerm"] = value;
            }
        }

        private List<Book> GetCurrentBooks(string sortColumn, string sortDirection)
        {
            var db = new BookLibrary.Models.BookLibraryContext();

            if (string.IsNullOrEmpty(sortColumn))
                sortColumn = "BookID";
            if (string.IsNullOrEmpty(sortDirection))
                sortDirection = "ASC";

            sortDirection = sortDirection.ToUpper();

            List<Book> currentBooks = (this.FilterMode) ? GetFilteredBooks(this.LastSearchTerm) : GetAllBooks();

            if (sortColumn == "BookID")
            {
                currentBooks = (sortDirection == "ASC") ? currentBooks.OrderBy(book => book.BookID).ToList() : currentBooks.OrderByDescending(book => book.BookID).ToList();
            }
            else if (sortColumn == "ISBN")
            {
                currentBooks = (sortDirection == "ASC") ? currentBooks.OrderBy(book => book.ISBN).ToList() : currentBooks.OrderByDescending(book => book.ISBN).ToList();
            }
            else if (sortColumn == "Title")
            {
                currentBooks = (sortDirection == "ASC") ? currentBooks.OrderBy(book => book.Title).ToList() : currentBooks.OrderByDescending(book => book.Title).ToList();
            }
            else if (sortColumn == "Category.BookCategoryName")
            {
                currentBooks = (sortDirection == "ASC") ? currentBooks.OrderBy(book => book.Category.BookCategoryName).ToList() : currentBooks.OrderByDescending(book => book.Category.BookCategoryName).ToList();
            }
            else if (sortColumn == "Author.AuthorName")
            {
                currentBooks = (sortDirection == "ASC") ? currentBooks.OrderBy(book => book.Author.AuthorName).ToList() : currentBooks.OrderByDescending(book => book.Author.AuthorName).ToList();
            }
            else if (sortColumn == "Publisher")
            {
                currentBooks = (sortDirection == "ASC") ? currentBooks.OrderBy(book => book.Publisher).ToList() : currentBooks.OrderByDescending(book => book.Publisher).ToList();
            }
            else if (sortColumn == "PublicationYear")
            {
                currentBooks = (sortDirection == "ASC") ? currentBooks.OrderBy(book => book.PublicationYear).ToList() : currentBooks.OrderByDescending(book => book.PublicationYear).ToList();
            }

            return currentBooks;
        }

        protected void theGrid_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
        {
            string currentSortColumn = null;
            string currentSortDirection = null;
            currentSortColumn = this.SortExpression.Split(' ')[0];
            currentSortDirection = this.SortExpression.Split(' ')[1];

            if (e.SortExpression.Equals(currentSortColumn))
            {
                switch (currentSortDirection.ToUpper())
                {
                    case "ASC":
                        currentSortDirection = "DESC";
                        break;
                    case "DESC":
                        currentSortDirection = "ASC";
                        break;
                }
            }
            else
            {
                currentSortColumn = e.SortExpression;
                currentSortDirection = "ASC";
            }

            Books.DataSource = GetCurrentBooks(currentSortColumn, currentSortDirection);
            Books.DataBind();

            this.SortExpression = currentSortColumn + " " + currentSortDirection;
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
            BooksLogic bl = new BooksLogic();
            bool savedChanges = bl.DeleteBook(Convert.ToInt32(bookID));

            if (savedChanges)
                Response.Redirect("AdminBooks");
        }

        private List<Book> GetFilteredBooks(string termToSearch)
        {
            List<Book> books = GetAllBooks();
            List<Book> filteredBooks = books.Where(book => book.ISBN.Contains(termToSearch) || book.Title.Contains(termToSearch) || book.Author.AuthorName.Contains(termToSearch) || book.Category.BookCategoryName.Contains(termToSearch) || book.Publisher.Contains(termToSearch) || book.PublicationYear == termToSearch).ToList();
            return filteredBooks;
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string termToSearch = SearchText.Text;
            if (!string.IsNullOrEmpty(termToSearch))
            {
                Books.DataSource = GetFilteredBooks(termToSearch);
                Books.DataBind();
                this.FilterMode = true;
                this.LastSearchTerm = termToSearch;
            }
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            SetDefaultDataSource();
        }
    }
}