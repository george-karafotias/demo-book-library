using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int AuthorID { get; set; }

        [Required, Display(Name = "Name")]
        public string AuthorName { get; set; }
    }
}