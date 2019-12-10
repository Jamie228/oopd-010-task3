using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{
    public class NonfictionBook : IUserInterfaceElement
    {
        [XmlIgnore]
        static List<string> categories = new List<string>();
        static List<string> authors = new List<string>();
        BookType bookType = new BookType();
        public string Category { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string DateOfPublication { get; set; }
        public string ID { get; set; }
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

        public void Display()
        {
            Console.WriteLine(ID + ", " + Author + ", " + Title + ", " + Publisher + ", " + DateOfPublication);
        }
    }
}
