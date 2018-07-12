using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required, Display(Name = "Title")]
        public string Title { get; set; }

        [Required, Display(Name = "Category")]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual BookCategory Category { get; set; }

        [Required, Display(Name = "Author")]
        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }

        [Required, Display(Name = "Publisher")]
        public string Publisher { get; set; }

        [Required, MinLength(4), MaxLength(4), Display(Name = "Publication Year")]
        public string PublicationYear { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}