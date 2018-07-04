using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace BookLibrary.Models
{
    public class BookLibraryDatabaseInitializer : DropCreateDatabaseAlways<BookLibraryContext>
    {
        protected override void Seed(BookLibraryContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "BookLibrary.Models.SeedData.BookCategories.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = true;
                    var bookCategories = csvReader.GetRecords<BookCategory>().ToArray();
                    foreach (BookCategory bookCategory in bookCategories)
                    {
                        context.BookCategories.Add(bookCategory);
                    }
                }
            }
        }
    }
}