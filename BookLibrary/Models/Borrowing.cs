using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class Borrowing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int BorrowingID { get; set; }

        [Required, Display(Name = "Member")]
        public int MemberID { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }

        [Required, Display(Name = "Book")]
        public int BookID { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }

        [Required, Display(Name = "From Date")]
        public DateTime From { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? To { get; set; }
    }
}