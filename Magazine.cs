using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{
    public class Magazine : Publication, IUserInterfaceElement
    {
        [XmlIgnore]
        static List<string> categories = new List<string>();
        private readonly BookType bookType = new BookType();
        public Magazine()
        {

        }

        public Magazine(string title, string publisher, string dateOfPublication, BookType bookType)
        {
            Title = title;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            bookType = BookType.Magazine;
            ID = "M-" + title.Substring(0, 4);
        }

    }
}
