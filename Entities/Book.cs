using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Knijarnica_Desi.Entities
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        public string Bookname { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public List<Book> Books { get; set; }
    }
}