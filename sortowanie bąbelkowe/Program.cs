using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleSort
{
    class Program
    {
        static void Main()
        {
            string[] numbersStr = Console.ReadLine().Split(' ');
            int[] numbersInt = Array.ConvertAll(numbersStr, int.Parse);
            List<int> lista = numbersInt.ToList();
            string[] decideStr = Console.ReadLine().Split(' ');
            int[] decideInt = Array.ConvertAll(decideStr, int.Parse);
            int k = 0;
            do
            {                
                for (int i = decideInt[0]; i < decideInt[1]; i++)
                {
                    if (lista[i] < lista[i + 1])
                    {
                        List<int> lista2 = new List<int>(2)
                        {
                        lista[i],
                        lista[i + 1],
                        };
                        lista2.Reverse();
                        lista.RemoveAt(i);
                        lista.RemoveAt(i);
                        lista.InsertRange(i, lista2);
                    }
                }
                k++;
            } while (k < 50);
            foreach (var item in lista)
            {
                Console.Write(item + " ");
            }
        }
    }
}