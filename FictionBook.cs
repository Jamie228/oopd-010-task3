using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{

    public class FictionBook : Publication, IUserInterfaceElement //Open/Closed Principle - Employs Inheritence from Publication.cs
    //Dependency Inversion - Not reliant on data in a higher class
    {
        [XmlIgnore]

        private readonly BookType bookType = new BookType();
        public string Genre { get; set; }
        public string Author { get; set; }
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

        
    }
}
