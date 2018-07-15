using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary.Admin
{
    public partial class AdminMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SearchText"] = "";
            }
        }

        public IQueryable<Member> Members_GetData()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            string searchText = Convert.ToString(ViewState["SearchText"]);
            if (string.IsNullOrEmpty(searchText))
            {
                return db.Members.OrderBy(member => member.MemberID);
            }
            else
            {
                return db.Members.Where(member => member.FirstName.Contains(searchText) || member.LastName.Contains(searchText) || member.IdentityID.Contains(searchText) || member.Email.Contains(searchText)).OrderBy(member => member.MemberID);
            }
        }

        protected void AddMemberBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMember.aspx");
        }

        protected void EditMemberButton_Click(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string bookID = btn.CommandArgument.ToString();
            Response.Redirect("EditMember.aspx?id=" + bookID);
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            ViewState["SearchText"] = SearchText.Text;
            Members.DataBind();
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            ViewState["SearchText"] = "";
            Members.DataBind();
        }

        protected void AddBorrowingButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string memberID = btn.CommandArgument.ToString();
            Response.Redirect("AddBorrowing.aspx?memberID=" + memberID);
        }
    }
}