using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookLibrary.Logic
{
    public class BorrowingsLogic
    {
        public bool AddBorrowing(int memberID, int bookID, string fromDate)
        {
            Borrowing borrowing = new Borrowing();
            borrowing.MemberID = memberID;
            borrowing.BookID = bookID;
            DateTime fromDateObject;
            bool success = DateTime.TryParseExact(fromDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateObject);
            if (success)
            {
                borrowing.From = fromDateObject;

                try
                {
                    using (BookLibraryContext db = new BookLibraryContext())
                    {
                        db.Borrowings.Add(borrowing);
                        db.SaveChanges();
                    }
                }
                catch (Exception exc)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public bool ReturnBorrowing(int borrowingID, string toDate)
        {
            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    Borrowing borrowing = db.Borrowings.Single(b => b.BorrowingID == borrowingID);
                    if (borrowing != null)
                    {
                        DateTime toDateObject = DateTime.MinValue;
                        if (DateTime.TryParseExact(toDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out toDateObject))
                        {
                            borrowing.To = toDateObject;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                return false;
            }

            return true;
        }

        public bool DeleteBorrowing(int borrowingID)
        {
            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    Borrowing borrowing = db.Borrowings.Single(b => b.BorrowingID == borrowingID);
                    if (borrowing != null)
                    {
                        db.Entry(borrowing).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
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