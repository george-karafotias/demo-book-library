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
    public partial class ReturnBorrowing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errorPage = "~/404";
                ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();

                if (Request.Params.AllKeys.Contains("id"))
                {
                    int borrowingID = Convert.ToInt32(Request["id"]);
                    var db = new BookLibrary.Models.BookLibraryContext();
                    Borrowing borrowing = db.Borrowings.First(b => b.BorrowingID == borrowingID);
                    Member.Text = borrowing.Member.DisplayName;
                    Book.Text = borrowing.Book.DisplayName;
                    FromDate.Text = borrowing.From.ToString("MM/dd/yyyy");
                    ToDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                    ToDate.Focus();
                }
                else
                {
                    Response.Redirect(errorPage);
                }
            }
        }

        void ReturnToSender()
        {
            object referrer = ViewState["ReferrerUrl"];
            if (referrer != null)
                Response.Redirect((string)referrer);
            else
                Response.Redirect("Default.aspx");
        }

        protected void ReturnBorrowingButton_Click(object sender, EventArgs e)
        {
            BorrowingsLogic bl = new BorrowingsLogic();
            bool saveSuccess = bl.ReturnBorrowing(Convert.ToInt32(Request["id"]), ToDate.Text);
            if (saveSuccess)
            {
                ReturnToSender();
            }
            else
            {
                FailureText.Text = "Unable to return the borrowing.";
                ErrorMessage.Visible = true;
            }
        }
    }
}