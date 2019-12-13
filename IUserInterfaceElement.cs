using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace library_system
{
    interface IUserInterfaceElement //Interface Segregation as not all UI elements were updateable
    {
        void Display();
        
    }
}
