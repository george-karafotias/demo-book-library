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
    public partial class EditBookCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errorPage = "~/404";
                if (Request.Params.AllKeys.Contains("id"))
                {
                    int bookCategoryID = Convert.ToInt32(Request["id"]);
                    var db = new BookLibrary.Models.BookLibraryContext();
                    BookCategory bookCategory = db.BookCategories.First(a => a.BookCategoryID == bookCategoryID);
                    BookCategoryName.Text = bookCategory.BookCategoryName;
                }
                else
                {
                    Response.Redirect(errorPage);
                }
            }
        }

        protected void UpdateBookCategoryButton_Click(object sender, EventArgs e)
        {
            BookCategoriesLogic bclogic = new BookCategoriesLogic();
            bool saveSuccess = bclogic.UpdateBookCategory(Convert.ToInt32(Request["id"]), BookCategoryName.Text);
            if (saveSuccess)
            {
                Response.Redirect("AdminBookCategories");
            }
            else
            {
                FailureText.Text = "Unable to update the book category.";
                ErrorMessage.Visible = true;
            }
        }
    }
}