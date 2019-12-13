using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system
{
    interface IUpdate
    //Created to meet the requirement of Interface Segregation Principal, 
    //as not all UI elements update such as Book.cs and Magazine.cs. The update method could subsequently be removed from these
    {
        void Update();
    }
}