using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Logic
{
    public class BookCategoriesLogic
    {
        public bool AddBookCategory(string bookCategoryName)
        {
            Models.BookCategory bookCategory = new Models.BookCategory();
            bookCategory.BookCategoryName = bookCategoryName;

            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    db.BookCategories.Add(bookCategory);
                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                return false;
            }

            return true;
        }

        public bool UpdateBookCategory(int bookCategoryID, string bookCategoryName)
        {
            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    BookCategory bookCategory = db.BookCategories.SingleOrDefault(b => b.BookCategoryID == bookCategoryID);
                    bookCategory.BookCategoryName = bookCategoryName;
                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                return false;
            }

            return true;
        }
    }
}