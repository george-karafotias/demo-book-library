using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary.Admin
{
    public partial class AdminBookCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<BookLibrary.Models.BookCategory> GetBookCategories()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            return db.BookCategories.OrderBy(category => category.BookCategoryID);
        }

        protected void AddBookCategoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBookCategory");
        }

        protected void EditCategoryBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string bookID = btn.CommandArgument.ToString();
            Response.Redirect("EditBookCategory.aspx?id=" + bookID);
        }
    }
}