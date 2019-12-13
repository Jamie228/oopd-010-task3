using System;

namespace library_system
{
    public abstract class Publication //Open/Closed Principle - New book types can be added within the enum and separate classes created for them
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string DateOfPublication { get; set; }
        public string ID { get; set; }

        public void Display()
        {
            Console.WriteLine(ID + ", " + ", " + Title + ", " + Publisher + ", " + DateOfPublication);
        }
    }
}