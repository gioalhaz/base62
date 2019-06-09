using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace base62
{
    // This is JustTest branch
    class Program
    {
        static void Main(string[] args)
        {
            Guid guid = Guid.NewGuid();
            Console.WriteLine( guid.ToString());

            //ulong ul = sha;

            BigInteger bint = new BigInteger(guid.ToByteArray().Concat(new byte[] { 0 }).ToArray());
            //BigInteger bint = new BigInteger(BitConverter.GetBytes(ul).Concat(new byte[] { 0 }).ToArray());

            Console.WriteLine(bint.ToString());

            Console.WriteLine(ToBase62(bint));
            //int size = sizeof(ulong);
        }

        static string ToBase62(BigInteger number)
        {
            var alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var n = number;
            BigInteger basis = 62;
            var ret = "";
            while (n > 0)
            {
                BigInteger temp;
                BigInteger.DivRem(n, basis, out temp);
                //ulong temp = n % basis;
                ret = alphabet[(int)temp] + ret;
                n = BigInteger.Divide(n, basis);
                //n = (n / basis);

            }
            return ret;
        }

        static string ToBase62(ulong number)
        {
            var alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var n = number;
            ulong basis = 62;
            var ret = "";
            while (n > 0)
            {
                ulong temp = n % basis;
                ret = alphabet[(int)temp] + ret;
                n = (n / basis);

            }
            return ret;
        }
    }
}
