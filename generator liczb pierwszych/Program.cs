class PrimeGenerator
{
    static void Main()
    {
        Console.WriteLine("How many cases? ");
        int numOfCases = int.Parse(Console.ReadLine());
        for (int i = 0; i < numOfCases; i++)
        {
            Console.WriteLine("From - to... ");
            var listOfPrime = new List<int>();
            string[] numbersStr = Console.ReadLine().Split(' ');
            int a = int.Parse(numbersStr[0]);
            int b = int.Parse(numbersStr[1]);
            for (int n = a; n <= b; n++)
            {
                if (isPrime(n)) listOfPrime.Add(n);
            }
            Console.Write("{ ");
            foreach (var item in listOfPrime)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");
        }        
    }

    static bool isPrime(int n)
    {
        if (n <= 1) return false;
        int k = 2;
        while (k >= 2 && k <= Math.Sqrt(n))
        {
            if (n % k == 0) return false;
            k++;
        }
        return true;
    }
}