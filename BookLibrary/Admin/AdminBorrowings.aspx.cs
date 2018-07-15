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
    public partial class AdminBorrowings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<BookLibrary.Models.Borrowing> Borrowings_GetData()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            return db.Borrowings.OrderBy(b => b.BorrowingID);
        }

        protected void ReturnBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string borrowingID = btn.CommandArgument.ToString();
            Response.Redirect("ReturnBorrowing.aspx?id=" + borrowingID);
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string borrowingID = btn.CommandArgument.ToString();
            BorrowingsLogic bl = new BorrowingsLogic();
            bool savedChanges = bl.DeleteBorrowing(Convert.ToInt32(borrowingID));

            if (savedChanges)
                Response.Redirect("AdminBorrowings");
        }

        protected void Borrowings_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Borrowing borrowing = (Borrowing)e.Row.DataItem;
                if (borrowing != null && !borrowing.To.HasValue)
                {
                    var status = (Button)e.Row.FindControl("ReturnBtn");
                    status.Visible = true;
                    //e.Row.Cells[3].Visible = true;
                }
            }
        }
    }
}