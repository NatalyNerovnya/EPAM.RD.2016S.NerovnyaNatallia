using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using System.Configuration;

namespace Storage
{
    public class Slave : UserStorage, ISlave
    {
        private UserStorage master;

        public Slave(UserStorage master)
        {
            int value = Convert.ToInt32(ConfigurationSettings.AppSettings["slaves"]);
            if (master.CountSlaves >= value)
            {                
                throw new ArgumentException();
            }
            Register(master);
        }

        public override int Add(User user)
        {
            throw new NotImplementedException();
        }

        public override void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public void Register(UserStorage master)
        {
            master.CountSlaves++;
            master.Action += Update;
        }

        public void Unregister()
        {
            master.CountSlaves--;
            master.Action -= Update;
        }

        public void Update(Object sender, ActionEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

    }
}
