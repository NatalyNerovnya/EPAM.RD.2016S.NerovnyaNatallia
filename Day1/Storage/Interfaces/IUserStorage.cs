﻿using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Interfaces
{
    public interface IUserStorage
    {
        int CountSlaves { get; set; }
        List<User> Users { get; set; }
        IUserIdIterator IdIterator { get; }
        IUserValidator Validator { get; }
        List<ISlave> Slaves { get; }

        int Add(User user);
        void Delete(User user);
        IEnumerable<User> GetAll();
        int[] SearchFor(Func<User, bool> criteria);
        void Save();
        void Load();

    }
}
