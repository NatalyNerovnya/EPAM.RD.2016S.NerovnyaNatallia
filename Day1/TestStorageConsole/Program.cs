using Storage;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStorageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepo = new UserRepository(new UserStorage());
            userRepo.Add(new User
            {
                FirstName = "Nataly",
                LastName = "Nerovnya",
                BirthDate = DateTime.Parse("03/29/1995"),
                Gender = Gender.Female,
                VisaRecords = null
            });

            var user = userRepo.GetAll().FirstOrDefault();

            userRepo.Add(new User
            {
                FirstName = "Vasia",
                LastName = "Pupkin",
                BirthDate = DateTime.Parse("1/1/1900"),
                Gender = Gender.Male,
                VisaRecords = null
            });

            var user2 = userRepo.GetAll().LastOrDefault();

            userRepo.Add(new User
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                BirthDate = DateTime.Parse("1/1/1300"),
                Gender = Gender.Male,
                VisaRecords = null
            });
            userRepo.Save();
            var user3 = userRepo.GetAll().LastOrDefault();
            var user4 = userRepo.SearchForUsers(u => u.Gender == (Gender)1);
            userRepo.Delete(user2);
            userRepo.GetAll();

            //For testing validation

            //userRepo.Add(new User
            //{
            //    FirstName = "Fool",
            //    LastName = "Ivanov",
            //    BirthDate = DateTime.Parse("1/3/1300"),
            //    Gender = Gender.Male,
            //    VisaRecords = null
            //});

            Console.ReadKey();
        }
    }
}
