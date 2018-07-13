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

        }

        public IQueryable<BookLibrary.Models.Author> GetBookAuthors()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            return db.Authors.OrderBy(author => author.AuthorID);
        }

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
    }
}