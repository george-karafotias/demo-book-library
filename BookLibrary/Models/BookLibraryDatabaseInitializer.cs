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
    public class BookLibraryDatabaseInitializer : DropCreateDatabaseIfModelChanges<BookLibraryContext>
    {
        protected override void Seed(BookLibraryContext context)
        {
            InitializeAuthors(context);
            InitializeBookCategories(context);
        }

        private void InitializeAuthors(BookLibraryContext context)
        {
            List<Author> authors = new List<Author>();
            authors.Add(new Author() { AuthorName = "author1"});
            authors.Add(new Author() { AuthorName = "author2" });
            foreach (Author author in authors)
            {
                context.Authors.Add(author);
            }
        }

        private void InitializeBookCategories(BookLibraryContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "BookLibrary.Models.SeedData.BookCategories.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = true;
                    csvReader.Configuration.HeaderValidated = null;
                    csvReader.Configuration.MissingFieldFound = null;
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