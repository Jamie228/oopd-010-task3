using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system
{
    interface IUpdateUserInterfaceElement
    //Created to meet the requirement of Interface Segregation Principal, as not all UI elements update such as Book.cs and Magazine.cs. The update method could be removed from these
    {
        void Update();
    }
}