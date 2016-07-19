using Storage.Entities;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Configuration;

namespace Storage
{
    public class UserStorage : IUserStorage
    {
        public event EventHandler<ActionEventArgs> Action;
        private static int countSlaves;

        public List<User> Users { get; set; }
        public IUserIdIterator IdIterator { get; private set; }
        public IUserValidator Validator { get; private set; }



        public UserStorage(IUserIdIterator iterator = null, IUserValidator validator = null)
            : base()
        {
            if (iterator != null)
                IdIterator = iterator;
            else
                IdIterator = new UserIdIterator();

            if (validator != null)
                Validator = validator;
            else
                Validator = new UserValidator();

            IdIterator.GetId();
            Users = new List<User>();
            countSlaves = Convert.ToInt32(ConfigurationSettings.AppSettings["slaves"]);
        }
        public int CountSlaves
        {
            get { return countSlaves; }
            set { countSlaves = value; }
        }

        public virtual int Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            if (!Validator.Validate(user))
                throw new ArgumentException("not valid user data");
            user.Id = IdIterator.GetUserId();
            Users.Add(user);
            OnAction(new ActionEventArgs("Add new user"));
            return user.Id;
        }

        public virtual void Delete(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            User userToDelete = Users.SingleOrDefault(u => u.Id == user.Id);
            if (userToDelete != null)
            {
                Users.Remove(userToDelete);
                OnAction(new ActionEventArgs("Delete user"));
            }
        }

        public IEnumerable<User> GetAll()
        {
            return Users.ToList();
        }

        public int[] SearchFor(Func<User, bool> criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException();
            int[] ids = Users.Where(criteria).Select(u => u.Id).ToArray();
            if (ReferenceEquals(ids, null))
                return Array.Empty<int>();
            return ids;
        }

        public void Save()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream(ConfigurationSettings.AppSettings["path"], FileMode.Create))
            {
                formatter.Serialize(fs, Users);
            }
        }

        public void Load()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
            using (StreamReader sr = new StreamReader(ConfigurationSettings.AppSettings["path"]))
            {
                List<User> users = (List<User>)formatter.Deserialize(sr);
                foreach (var user in users)
                {
                    Users.Add(user);
                }
                
                //IdIterator = new UserIdIterator(users.Last().Id);
            }
            
        }

        private void OnAction(ActionEventArgs e)
        {
            Action(this, e);
        }

    }
}
