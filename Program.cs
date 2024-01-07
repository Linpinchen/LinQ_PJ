using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Linq說明
{
    class Program
    {
        static void Main(string[] args)
        {
            int ii = 0;
            int[] iis = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] iis2 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] iis3 = new int[] { 8, 10, 9, 7, 2, 3, 5, 1, 4, 6 };
            Console.WriteLine("Hello World!");
            Console.WriteLine("XDDD ");

            // foreach (int i in iis)
            // {
            //     MyVoid(action: Prints, i);
            // }

            IEnumerable<int> values =
                from num in iis
                where num >= 5
                select num;

            Action<int> action = new Action<int>(Print2);
            Array.ForEach(iis, Print2);


            IEnumerable<int> values1 =
                from num in iis2
                where num >= 5
                orderby num
                select num;

            IEnumerable<int> values2 =
                from num in iis3
                where num >= 5
                select num;

            IEnumerable<int> ints = iis3.Where(Num => Num > 6);
            ;
            Console.WriteLine($"ints.Sum(): {ints.Sum()}");

            foreach (var i in values)
            {
                Print2(i);
            }

            Console.WriteLine("iis2-----");

            foreach (var i in values1)
            {

                Print2(i);
            }
            Console.WriteLine("iis3-----");
            foreach (var i in values2)
            {

                Print2(i);
            }

            MyVoid(action: Prints, 2222);

        }

        static void MyVoid(Action<string> action, int i)
        {
            action(i.ToString());
        }
        static void Prints(string s)
        {
            Console.WriteLine(s);
        }

        static void Print2(int i)
        {
            Console.WriteLine(i);
        }

    }
}
