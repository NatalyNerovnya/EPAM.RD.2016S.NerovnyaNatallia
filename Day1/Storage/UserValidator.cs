using Storage.Entities;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class UserValidator : IUserValidator
    {
        public bool Validate(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            if (user.FirstName == "Fool" || user.LastName == "Fool")
                return false;
            return true;
        }
    }
}
