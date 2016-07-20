using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Interfaces
{
    public interface ISlave
    {
        IUserStorage Master { get; }
        void Add();
        void Delete();
        void Register();
        void Unregister();
        void Update();
    }
}
