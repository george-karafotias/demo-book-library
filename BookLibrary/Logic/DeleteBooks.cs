using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookLibrary.Logic
{
    public class DeleteBooks
    {
        public bool DeleteBook(int bookID)
        {
            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    Book book = db.Books.SingleOrDefault(b => b.BookID == bookID);
                    db.Entry(book).State = EntityState.Deleted;
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