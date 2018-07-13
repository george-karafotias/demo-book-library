using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class BookCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int BookCategoryID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string BookCategoryName { get; set; }
    }
}