using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Logic
{
    public class AuthorsLogic
    {
        public bool AddAuthor(string authorName)
        {
            Models.Author author = new Models.Author();
            author.AuthorName = authorName;

            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                return false;
            }

            return true;
        }

        public bool UpdateAuthor(int authorID, string authorName)
        {
            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    Author author = db.Authors.SingleOrDefault(a => a.AuthorID == authorID);
                    author.AuthorName = authorName;
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