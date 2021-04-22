using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RicercaConcorrenteAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeri = new int[100];
            RiempiArray(ref numeri);

            Console.WriteLine("Inserisci un numero da cercare:");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine(RicercaNumeroAsync(n1, numeri).Result);

            Console.WriteLine("Inserisci un numero da cercare:");
            int n2 = int.Parse(Console.ReadLine());
            Console.WriteLine(RicercaNumeroAsync(n2, numeri).Result);


            Console.ReadLine();
        }

        private static async Task<bool> RicercaNumeroAsync(int n, int[] array)
        {
            bool trovato = false;

            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (n == array[i])
                    {
                        trovato = true;
                    }
                }
            });

            return trovato;
        }

        private static void RiempiArray(ref int[] numeri)
        {
            Random r = new Random();
            for (int n = 0; n < 100; n++)
            {
                numeri[n] = r.Next(0, 100);
            }
        }
    }
}
