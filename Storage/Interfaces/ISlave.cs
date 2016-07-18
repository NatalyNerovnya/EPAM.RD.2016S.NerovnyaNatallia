using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Interfaces
{
    public interface ISlave
    {
        void Register(UserStorage master);
        void Unregister();
        void Update(Object sender, ActionEventArgs eventArgs);
    }
}
