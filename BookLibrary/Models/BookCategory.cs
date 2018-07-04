using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class BookCategory
    {
        [ScaffoldColumn(false)]
        public int BookCategoryID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string BookCategoryName { get; set; }
    }
}