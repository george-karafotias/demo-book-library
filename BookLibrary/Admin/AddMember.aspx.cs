using BookLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary.Admin
{
    public partial class AddMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();
                FirstName.Focus();
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

        protected void SaveMemberButton_Click(object sender, EventArgs e)
        {
            MembersLogic ml = new MembersLogic();
            bool saveSuccess = ml.AddMember(FirstName.Text, LastName.Text, IdentityID.Text, Email.Text);
            if (saveSuccess)
            {
                ReturnToSender();
            }
            else
            {
                FailureText.Text = "Unable to add a new member to database.";
                ErrorMessage.Visible = true;
            }
        }
    }
}