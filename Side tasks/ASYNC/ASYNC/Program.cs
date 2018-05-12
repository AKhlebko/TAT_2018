using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Вводим два числа
// сразу запускаем и идем дальше

namespace ASYNC
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            BigInteger[] arrayA = new BigInteger[] { 913, 1450, 124, 3553, 676, 83, 234, 232, 347, 2345259, 65, 46 };
            int[] arrayB = new int[] { 91, 123, 124, 552, 6625, 827, 242, 233, 234, 239, 672, 112 };
            while (true)
            {
                if (i++ < 10)
                {
                    // Start computation.
                    BigInteger a = arrayA[new Random().Next(0, 12)];
                    int b = arrayB[new Random().Next(0, 12)];
                    Example(a, b);
                }
            }
        }

        static async void Example(BigInteger a, int b)
        {
            // This method runs asynchronously.
            BigInteger t = await Task.Run(() => Power(a, b));
            Console.WriteLine($"Compute: {a} ^ {b} ------" + t + "\n");
            Thread.Sleep(1000);
        }

        static BigInteger Power(BigInteger a, int b)
        {
            // Compute total count of digits in strings.
            BigInteger response = a;
            for (int i = 0; i < b; i++)
            {
                response *= a;
            }
            return response;
        }
    }
}
