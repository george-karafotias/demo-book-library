using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookLibrary.Logic
{
    public class BooksLogic
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

        public List<Book> GetNotBorrowedBooks()
        {
            List<Book> notBorrowedBooks = new List<Book>();

            using (BookLibraryContext db = new BookLibraryContext())
            {
                var currentBorrowings = from b in db.Borrowings
                                        where !b.To.HasValue
                                        select b;

                List<int> borrowedBooksID = new List<int>();
                foreach (Borrowing b in currentBorrowings)
                {
                    borrowedBooksID.Add(b.BookID);
                }

                notBorrowedBooks = db.Books.Where(b => !borrowedBooksID.Contains(b.BookID)).ToList();
            }

            return notBorrowedBooks;
        }
    }
}