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
    public partial class EditMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errorPage = "~/404";
                ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();

                if (Request.Params.AllKeys.Contains("id"))
                {
                    int memberID = Convert.ToInt32(Request["id"]);
                    var db = new BookLibrary.Models.BookLibraryContext();
                    Member member = db.Members.First(m => m.MemberID == memberID);
                    FirstName.Text = member.FirstName;
                    LastName.Text = member.LastName;
                    IdentityID.Text = member.IdentityID;
                    Email.Text = member.Email;
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

        protected void UpdateMemberButton_Click(object sender, EventArgs e)
        {
            MembersLogic ml = new MembersLogic();
            bool savedMember = ml.UpdateMember(Convert.ToInt32(Request["id"]), FirstName.Text, LastName.Text, IdentityID.Text, Email.Text);
            if (savedMember)
            {
                ReturnToSender();
            }
            else
            {
                FailureText.Text = "Unable to update the member.";
                ErrorMessage.Visible = true;
            }
        }
    }
}