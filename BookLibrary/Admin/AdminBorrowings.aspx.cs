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
            if (!IsPostBack)
            {
                ViewState["Active"] = true;
                ViewState["SearchText"] = "";
            }
        }

        public IQueryable<BookLibrary.Models.Borrowing> Borrowings_GetData()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            IQueryable<Borrowing> borrowings = null;
            
            if (Convert.ToBoolean(ViewState["Active"]))
            {
                borrowings = db.Borrowings.Where(b => b.To.HasValue == false).OrderBy(b => b.BorrowingID);
            }
            else
            {
                borrowings = db.Borrowings.OrderBy(b => b.BorrowingID);
            }

            string searchText = Convert.ToString(ViewState["SearchText"]);
            if (!string.IsNullOrEmpty(searchText))
            {
                borrowings = borrowings.Where(b => b.Member.FirstName.Contains(searchText) || b.Member.LastName.Contains(searchText) || b.Book.ISBN.Contains(searchText) || b.Book.Title.Contains(searchText));
            }

            return borrowings;
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
                }
            }
        }

        protected void AllBorrowings_Click(object sender, EventArgs e)
        {
            ViewState["Active"] = false;
            ReBind();
        }

        protected void ActiveBorrowings_Click(object sender, EventArgs e)
        {
            ViewState["Active"] = true;
            ReBind();
        }

        private void ReBind()
        {
            Borrowings.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            ViewState["SearchText"] = SearchText.Text;
            ReBind();
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            ViewState["SearchText"] = "";
            ReBind();
        }
    }
}