using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Logic
{
    public class MembersLogic
    {
        public bool AddMember(string firstName, string lastName, string identityID, string email)
        {
            Member member = new Member();
            member.FirstName = firstName;
            member.LastName = lastName;
            member.IdentityID = identityID;
            member.Email = email;

            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    db.Members.Add(member);
                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                return false;
            }

            return true;
        }

        public bool UpdateMember(int memberID, string firstName, string lastName, string identityID, string email)
        {
            try
            {
                using (BookLibraryContext db = new BookLibraryContext())
                {
                    Member member = db.Members.SingleOrDefault(m => m.MemberID == memberID);
                    member.FirstName = firstName;
                    member.LastName = lastName;
                    member.IdentityID = identityID;
                    member.Email = email;
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