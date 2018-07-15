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
    public partial class AddBorrowing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BooksLogic bl = new BooksLogic();
                List<Book> notBorrowedBooks = bl.GetNotBorrowedBooks();

                if (notBorrowedBooks.Count == 0)
                {
                    CannotAddBorrowing.Visible = true;
                    CanAddBorrowing.Visible = false;
                }
                else
                {
                    CanAddBorrowing.Visible = true;
                    CannotAddBorrowing.Visible = false;

                    var db = new BookLibraryContext();
                    FillInMemberControl(db);
                    FillInBookControl(db);
                    FromDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                }

                ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();
            }
        }

        protected void FillInBookControl(BookLibraryContext db)
        {
            if (Request.Params.AllKeys.Contains("bookID"))
            {
                int bookID = Convert.ToInt32(Request["bookID"]);
                Book book = db.Books.Single(b => b.BookID == bookID);
                BookTextBox.Text = book.ISBN + " " + book.Title;

                BookListLabel.Visible = false;
                BookList.Visible = false;
                BookTextBoxLabel.Visible = true;
                BookTextBox.Visible = true;
            }
            else
            {
                BookList.DataValueField = "BookID";
                BookList.DataTextField = "DisplayName";
             
                BooksLogic bl = new BooksLogic();
                List<Book> notBorrowedBooks = bl.GetNotBorrowedBooks();
                /*
                foreach (Book b in notBorrowedBooks)
                {
                    b.DisplayName = b.ISBN + " " + b.Title;
                }
                */
                BookList.DataSource = notBorrowedBooks;
                BookList.DataBind();

                BookListLabel.Visible = true;
                BookList.Visible = true;
                BookTextBoxLabel.Visible = false;
                BookTextBox.Visible = false;
            }
        }

        protected void FillInMemberControl(BookLibraryContext db)
        {
            if (Request.Params.AllKeys.Contains("memberID"))
            {
                int memberID = Convert.ToInt32(Request["memberID"]);
                Member member = db.Members.Single(m => m.MemberID == memberID);
                MemberTextBox.Text = member.FirstName + " " + member.LastName;

                MemberListLabel.Visible = false;
                MemberList.Visible = false;
                MemberTextBoxLabel.Visible = true;
                MemberTextBox.Visible = true;
            }
            else
            {
                MemberList.DataValueField = "MemberID";
                MemberList.DataTextField = "DisplayName";
                /*
                foreach (Member m in db.Members)
                {
                    m.DisplayName = m.FirstName + " " + m.LastName;
                }
                */
                MemberList.DataSource = db.Members.ToList();
                MemberList.DataBind();

                MemberListLabel.Visible = true;
                MemberList.Visible = true;
                MemberTextBoxLabel.Visible = false;
                MemberTextBox.Visible = false;
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

        private int GetMemberID()
        {
            int memberID;
            if (Request.Params.AllKeys.Contains("memberID"))
            {
                memberID = Convert.ToInt32(Request["memberID"]);
            }
            else
            {
                memberID = Convert.ToInt32(MemberList.SelectedValue);
            }
            return memberID;
        }

        private int GetBookID()
        {
            int bookID;
            if (Request.Params.AllKeys.Contains("bookID"))
            {
                bookID = Convert.ToInt32(Request["bookID"]);
            }
            else
            {
                bookID = Convert.ToInt32(BookList.SelectedValue);
            }
            return bookID;
        }

        protected void SaveBorrowingButton_Click(object sender, EventArgs e)
        {
            BorrowingsLogic bl = new BorrowingsLogic();
            bool saveSuccess = bl.AddBorrowing(GetMemberID(), GetBookID(), FromDate.Text);
            if (saveSuccess)
            {
                ReturnToSender();
            }
            else
            {
                FailureText.Text = "Unable to add the borrowing to database.";
                ErrorMessage.Visible = true;
            }
        }
    }
}