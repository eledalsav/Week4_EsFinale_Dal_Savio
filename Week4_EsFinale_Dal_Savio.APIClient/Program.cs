using System;
using Week4_EsFinale_Dal_Savio.Client;

namespace Week4_EsFinale_Dal_Savio.APIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Premi un tasto quando le API sono avviate");
            Console.ReadKey();

            Menu.Start();
        }
    }
}
