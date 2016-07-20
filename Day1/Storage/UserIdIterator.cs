using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class UserIdIterator : IUserIdIterator
    {
        private IEnumerator<int> iterator;
        public UserIdIterator()
        { iterator = GetId(); }

        public UserIdIterator(int index)
        {
            for(int i = 0; i <= index; i++)
            {
                GetUserId();
            }
        }

        public int GetUserId()
        {
            if (iterator.MoveNext())
            {
                return iterator.Current;
            }

            return -1;
        }

        public IEnumerator<int> GetId()
        {
            int i = 2;
            while (true)
            {
                while (!IsPrime(i))
                {
                    i++;
                }
                yield return i;
                checked
                {
                    i++;
                }
            }
        }


        public static bool IsPrime(int n)
        {
            if (n >= int.MaxValue)
                throw new ArgumentException();
            if (n < 2)
                return false;

            int sqrt = (int)Math.Pow(n, 0.5);
            for (int i = 2; i <= sqrt; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
