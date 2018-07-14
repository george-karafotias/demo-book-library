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

        }

        public IQueryable<Member> Members_GetData()
        {
            var db = new BookLibrary.Models.BookLibraryContext();
            return db.Members.OrderBy(member => member.MemberID);
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
    }
}