using System;

class Emeryturka
{
    static void Main(string[] args)
    {
        //pytanie do użytkownika (do tablicy)
        Console.Write("Podaj swoje imię, wiek i płeć (k/m): ");

        //deklaracja zmiennych
        var person = Console.ReadLine();
        var dane = person.Split(' ');
        int wiek = int.Parse(dane[1]);
        int retirementAge;
        string years;

        //deklaruje wiek emerytalny zależny od płci
        if (dane[2] == "k")
        {
            retirementAge = 60;
        }
        else
        {
            retirementAge = 65;
        }

        // deklaruję odmianę słowa lat poprzez wykorzystanie ostatnich wyfr wieku
        long lastDigit = (retirementAge-wiek) % (10);
        long SecondLastDigit = ((retirementAge - wiek) / 10) % (10);
        if(SecondLastDigit == 1)
        {
            years = "lat";
        }
        else if ((SecondLastDigit != 1) && ((lastDigit == 2) || (lastDigit == 3) || (lastDigit == 4)))
        {
            years = "lata";
        }
        else
        {
            years = "lat";
        }

        if ((retirementAge - wiek) == 1 || (retirementAge - wiek) == -1)
        {
            years = "roku";
        }
       

        //wiadomośc końcowa dla użytkownika
        if (wiek >= 0 && wiek < retirementAge)
        {
            Console.WriteLine("Witaj " + dane[0] + ", do emerytury brakuje Ci jeszcze " + (retirementAge - wiek) + " " + years + ".");
        }
        else if (wiek <= 0)
        {
            Console.WriteLine("Wiek nie może być ujemny!");
        }
        else
        {
            Console.WriteLine("Jesteś na emeryturze od " + (wiek-retirementAge) + " " + years  + ".");
        }
               
        Console.ReadKey();
    }

}