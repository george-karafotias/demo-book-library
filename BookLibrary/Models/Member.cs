using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class Member
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int MemberID { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "Identity")]
        public string IdentityID { get; set; }

        [Required, Display(Name = "Email")]
        public string Email { get; set; }

        [NotMapped]
        public string DisplayName => $"{FirstName} {LastName}";

        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }
}