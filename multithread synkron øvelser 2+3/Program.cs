using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multithread_synkron_øvelser_2_3
{
    internal class Program
    {
        static int count;
        static int i;
        static object _lock = new object();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(MakeStars);
            t1.Start();

            Thread t2 = new Thread(MakeHavelåger);
            t2.Start();

            Console.ReadKey();
        }

        static void MakeStars()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    for (i = 0; i < 60; i++)
                    {
                        Console.Write("*");
                    }
                    count += 60;
                    Console.Write(" " + count + "\n"); 
                }
                finally
                {

                    Monitor.Exit(_lock);
                }
                Thread.Sleep(500);
            }
        }

        static void MakeHavelåger()
        {
            while (true)
            {
                Monitor.Enter(_lock);

                try
                {
                    for (i = 0; i < 60; i++)
                    {
                        Console.Write("#");
                    }
                    count += 60;
                    Console.Write(" " + count + "\n");

                }
                finally
                {
                    Monitor.Exit(_lock);
                }
                Thread.Sleep(500);
            }
        }
    }
}
