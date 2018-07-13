using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Logic
{
    public class EditBooks
    {
        public bool UpdateBook(int bookID, string ISBN, string title, string categoryID, string authorID, string publisher, string publicationYear, string price)
        {
            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    Book book = db.Books.SingleOrDefault(b => b.BookID == bookID);
                    book.ISBN = ISBN;
                    book.Title = title;
                    book.CategoryID = Convert.ToInt32(categoryID);
                    book.AuthorID = Convert.ToInt32(authorID);
                    book.Publisher = publisher;
                    book.PublicationYear = publicationYear;
                    if (!string.IsNullOrEmpty(price))
                    {
                        book.Price = Convert.ToDecimal(price);
                    }

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