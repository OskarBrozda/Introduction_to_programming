using System;

class program
{
 public static void Main()
    {
        int sum = 0;
        string a;
        //Console.Write("Podaj a: ");
        while ((a = Console.ReadLine()) != null)
                {
            Console.WriteLine(sum += int.Parse(a));
            //Console.Write("Podaj a: ");
        }
    }
}