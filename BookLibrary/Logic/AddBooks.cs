using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Logic
{
    public class AddBooks
    {
        public bool AddBook(string ISBN, string title, string categoryID, string authorID, string publisher, string publicationYear, string price)
        {
            Book book = new Book();
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

            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    db.Books.Add(book);
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