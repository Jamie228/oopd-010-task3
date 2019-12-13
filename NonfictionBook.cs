using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{
    public class NonfictionBook : Publication, IUserInterfaceElement //Open/Closed - Uses inheritence so new books are added through different classes
    {
        [XmlIgnore]
        static List<string> categories = new List<string>();
        BookType bookType = new BookType();
        public string Category { get; set; }
        public string Author { get; set; }
        public NonfictionBook()
        {

        }

        public NonfictionBook(string title, string author, string publisher, string dateOfPublication, string category, BookType bookType)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            Category = category;
            categories.Add(category); //Add to categories list so we can easily count how many we have
            int count = categories.Where(x => x.Equals(category)).Count(); //Using LINQ Count the number of existing books of this category
            ID = category.Substring(0, 4) + count.ToString("00");
            bookType = BookType.NonFiction;
        }

    }
}
