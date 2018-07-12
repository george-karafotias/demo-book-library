using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary
{
    public partial class BookCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<BookLibrary.Models.BookCategory> GetBookCategories()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            return db.BookCategories;
        }
    }
}