using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{

    public class FictionBook : IUserInterfaceElement //Created to adhere to Open/Closed Principle, as if another book type should be added, then another class can be created
    {
        [XmlIgnore]

        private readonly BookType bookType = new BookType();

        static List<string> authors = new List<string>();
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string DateOfPublication { get; set; }
        public string ID { get; set; }
        public FictionBook()
        {

        }

        public FictionBook(string title, string author, string publisher, string dateOfPublication, string genre, BookType bookType)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            Genre = genre;
            bookType = BookType.Fiction;
        }

        public void Display()
        {
            Console.WriteLine(ID + ", " + Author + ", " + Title + ", " + Publisher + ", " + DateOfPublication);
        }
    }
}
