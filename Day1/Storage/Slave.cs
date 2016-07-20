using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;

namespace Storage
{
    public class Slave : ISlave
    {
        public Slave(UserStorage master)
        {
            if (master.CountSlaves > value)
            {                
                throw new ArgumentException();
            }
            Master = master;
            Register();
        }

        public IUserStorage Master { get; private set; }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            (Master as UserStorage).CountSlaves++;
            (Master as UserStorage).actionOnAdd += Update;
            (Master as UserStorage).actionOnDelete += Update;
        }

        public void Unregister()
        {
            (Master as UserStorage).CountSlaves--;
            (Master as UserStorage).actionOnAdd -= Update;
            (Master as UserStorage).actionOnDelete -= Update;
        }

        public void Update()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream(ConfigurationSettings.AppSettings["path"], FileMode.Create))
            {
                formatter.Serialize(fs, "Slave" + Master.Slaves.FindIndex(s => s == this) + "save data");
                formatter.Serialize(fs, Master.Users);
            }
        }

    }
}
