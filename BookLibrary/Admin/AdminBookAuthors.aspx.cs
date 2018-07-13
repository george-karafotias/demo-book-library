using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary.Admin
{
    public partial class AdminBookAuthors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDefaultDataSource();
            }
        }

        private List<Author> GetAllAuthors()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            List<Author> authors = db.Authors.ToList();
            return authors;
        }

        private void SetDefaultDataSource()
        {
            BookAuthors.DataSource = GetAllAuthors();
            BookAuthors.DataBind();
        }

        //public IQueryable<BookLibrary.Models.Author> GetBookAuthors()
        //{
        //    var db = new BookLibrary.Models.BookLibraryContext();
        //    return db.Authors.OrderBy(author => author.AuthorID);
        //}

        protected void AddAuthorButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAuthor.aspx");
        }

        protected void EditAuthorBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string authorID = btn.CommandArgument.ToString();
            Response.Redirect("EditAuthor.aspx?id=" + authorID);
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string termToSearch = SearchText.Text;
            if (!string.IsNullOrEmpty(termToSearch))
            {
                List<Author> authors = GetAllAuthors();
                List<Author> filteredAuthors = authors.Where(author => author.AuthorName.Contains(termToSearch)).ToList();
                BookAuthors.DataSource = filteredAuthors;
                BookAuthors.DataBind();
            }
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            SetDefaultDataSource();
        }
    }
}