using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{
    public class CurrentTime : IUserInterfaceElement, IUpdate  //Single Responsibility - Responsible only for the time
    //Open/Closed using inheritance from interfaces
    {
        private DateTime time;

        public CurrentTime()
        {
            time = System.DateTime.Now;
        }
        public void Display()
        {
            Console.WriteLine($"Time: {time.ToString("HH:mm:ss")}");
        }
        public void Update()
        {
            time = System.DateTime.Now;
        }
    }
}