using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;

namespace BLL
{
    public class Slave : UserService, ISlave
    {
        public Slave(IMaster master)
        {
            if (ReferenceEquals(master, null))
                throw new ArgumentNullException();

            master.ActionOnAdd += Update;
            master.ActionOnDelete += Update;
        }


        public override int Add(BllUser user)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BllUser user)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            Load();
        }
    }
}
