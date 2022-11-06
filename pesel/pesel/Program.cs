using System;

class pesel
{
    static void Main(string[] arg)
    {

        //test pustego intigera
        //Console.WriteLine("Podaj testową liczbę: ");
        //int test = int.Parse(Console.ReadLine());
        //Console.WriteLine(test == null ? "Coś tu pusto." : "Wybrałeś: " + test);


        //przywitanie użytkownika
        string id;
        Console.WriteLine("Dzień dobry, jak się nazywasz (imię i nazwisko)?");
        do
        {
            id = Console.ReadLine();

            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Pole nie może zostać puste, podaj imię i nazwisko: ");
            }
        } while (string.IsNullOrEmpty(id));

        string[] dane = new string[2];
        dane = id.Trim().Split(" ");

        //jesli ktoś poda tylko imię
        if (dane[1] == null)
        {
            do
            {
                Console.WriteLine("Podaj również nazwisko: ");
                dane[1] = Console.ReadLine();
            } while (dane[1] == null);
        }

        //deklaracja zmiennych wykorzystanych potem w do...while
        Int64 Pesel;
        Int64 L1;
        Int64 L2;
        Int64 L3;
        Int64 L4;
        Int64 L5;
        Int64 L6;
        Int64 L7;
        Int64 L8;
        Int64 L9;
        Int64 L10;
        Int64 L11;
        Int64 day;
        Int64 month;
        string monthstr;
        Int64 year;
        string yearstr;
        Int64 Sex;
        string Sex2;
        double Controlsum;


        //prośba o numer pesel
        Console.Write("Witaj " + dane[0] + ", podaj swój numer pesel: ");
        

        do
        {            
            Pesel = Int64.Parse(Console.ReadLine());
            //do
            //{
            //    if (Pesel == null)
            //    {
            //        Console.Write("Pole nie może zostać puste, podaj pesel: ");
            //    }
            //} while (Pesel == null);


            //rozdzielenie nr pesel na czynniki
            //wyodrebnienie każdej z cyfr nr pesel
            L1 = Pesel / 10000000000 % 10;
            L2 = Pesel / 1000000000 % 10;
            L3 = Pesel / 100000000 % 10;
            L4 = Pesel / 10000000 % 10;
            L5 = Pesel / 1000000 % 10;
            L6 = Pesel / 100000 % 10;
            L7 = Pesel / 10000 % 10;
            L8 = Pesel / 1000 % 10;
            L9 = Pesel / 100 % 10;
            L10 = Pesel / 10 % 10;
            L11 = Pesel % 10;

            //informacje o dacie urodzenia
            day = L5 * 10 + L6;
            if (L1 * 10 + L2 > 22)
            {
                month = L3 * 10 + L4;
                monthstr = string.Format("{0:00}", month);
            }
            else
            {
                month = L3 * 10 + L4 - 20;
                monthstr = string.Format("{0:00}", month);
            }

            if (L1 * 10 + L2 > 22)
            {
                year = L1 * 10 + L2;
                yearstr = string.Format("{0:00}", year + 1900);
            }
            else
            {
                year = L1 * 10 + L2;
                yearstr = string.Format("{0:00}", year + 2000);
            }

            //informacja o płci
            Sex = (Pesel / 10) % 10;
            if (Sex % 2 == 0)
            {
                Sex2 = "kobieta";
            }
            else
            {
                Sex2 = "mężczyzna";
            }
                        
            //suma kontorlna
            if (L2 * 3 >= 10)
            {
                L2 = (L2 * 3) % 10;
            }
            else
            {
                L2 = L2 * 3;
            }
            if (L3 * 7 >= 10)
            {
                L3 = (L3 * 7) % 10;
            }
            else
            {
                L3 = L3 * 7;
            }
            if (L4 * 9 >= 10)
            {
                L4 = (L4 * 9) % 10;
            }
            else
            {
                L4 = L4 * 9;
            }
            if (L6 * 3 >= 10)
            {
                L6 = (L6 * 3) % 10;
            }
            else
            {
                L6 = L6 * 3;
            }
            if (L7 * 7 >= 10)
            {
                L7 = (L7 * 7) % 10;
            }
            else
            {
                L7 = L7 * 7;
            }
            if (L8 * 9 >= 10)
            {
                L8 = (L8 * 9) % 10;
            }
            else
            {
                L8 = L8 * 9;
            }
            if (L10 * 3 >= 10)
            {
                L10 = (L10 * 3) % 10;
            }
            else
            {
                L10 = L10 * 3;

            }


            //sytuacja gdzie suma kontrolna wychodzi 10-0=10 -> wpisujemy 0
            if (((L1 + L2 + L3 + L4 + L5 + L6 + L7 + L8 + L9 + L10) % 10) == 0)
            {
                Controlsum = 0;
            }
            else
            {
                Controlsum = 10 - ((L1 + L2 + L3 + L4 + L5 + L6 + L7 + L8 + L9 + L10) % 10);
            }

            if (L11 != Controlsum)
            {
                Console.Write("Błędny numer pesel. Podaj ponownie: ");
            }
        } while (L11 != Controlsum);
        
           

        //PROGRAM DO OBLOCZANIA WIEKU DO EMERYTURY
        int retirementAge;
        string years;
        int wiek;
        if (L1 * 10 + L2 > 22)
        {
            wiek = (int)(2022 - (L1 * 10 + L2 + 1900));
        }
        else
        {
            wiek = (int)(2022 - (L1 * 10 + L2 + 2000));
        }

        //deklaruje wiek emerytalny zależny od płci
        if (Sex2 == "kobieta")
        {
            retirementAge = 60;
        }
        else
        {
            retirementAge = 65;
        }

        // deklaruję odmianę słowa lat poprzez wykorzystanie ostatnich wyfr wieku
        long lastDigit = (retirementAge - wiek) % (10);
        long SecondLastDigit = ((retirementAge - wiek) / 10) % (10);
        if (SecondLastDigit == 1)
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
        Console.WriteLine();
        Console.WriteLine("Podstawowe informacje o " + dane[1] +" "+ dane[0] + ": ");
        Console.WriteLine("Data urodzenia: " + day + "." + monthstr + "." + yearstr + " r.");
        Console.WriteLine("Płeć: " + Sex2);
        Console.WriteLine("Suma kontrolna pesel: ZGODNA");
        Console.WriteLine();
        Console.WriteLine("Ciekawostka:");

        //emeryturka
        if (wiek >= 0 && wiek < retirementAge)
        {
            Console.WriteLine(dane[0] + ", do emerytury brakuje Ci jeszcze " + (retirementAge - wiek) + " " + years + ".");
        }
        else if (wiek <= 0)
        {
            Console.WriteLine("Wiek nie może być ujemny!");
        }
        else
        {
            Console.WriteLine("Jesteś na emeryturze od " + (wiek - retirementAge) + " " + years + ".");
        }

        Console.ReadKey();
    }
}
