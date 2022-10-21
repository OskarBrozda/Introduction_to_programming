using System;

class pesel
{
    static void Main(string[] arg)
    {

        //przywitanie użytkownika
        Console.WriteLine("Cześć, jak się nazywasz (imię i nazwisko)?");
        var id = Console.ReadLine();
        var dane = id.Trim().Split(" ");

        //prośba o numer pesel
        Console.Write("Witaj " + dane[0]  + ", podaj swój numer pesel: ");
        Int64 Pesel = Int64.Parse(Console.ReadLine());

        //wyodrebnienie każdej z cyfr nr pesel
        Int64 L1 = (Pesel / 10000000000) % 10;
        Int64 L2 = (Pesel / 1000000000) % 10;
        Int64 L3 = (Pesel / 100000000) % 10;
        Int64 L4 = (Pesel / 10000000) % 10;
        Int64 L5 = (Pesel / 1000000) % 10;
        Int64 L6 = (Pesel / 100000) % 10;
        Int64 L7 = (Pesel / 10000) % 10;
        Int64 L8 = (Pesel / 1000) % 10;
        Int64 L9 = (Pesel / 100) % 10;
        Int64 L10 = (Pesel / 10) % 10;
        Int64 L11 = Pesel % 10;

        //informacje o dacie urodzenia
        Int64 day = L5 * 10 + L6;
        Int64 month;
        string monthstr;
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
        Int64 year;
        string yearstr;
        string yearstr2;
        if(L1 * 10 + L2 > 22)
        {
            year = L1 * 10 + L2;
            yearstr = string.Format("{0:00}", year);
            yearstr2 = ("19" + yearstr);
        }
        else
        {
            year = L1 * 10 + L2;
            yearstr = string.Format("{0:00}", year);
            yearstr2 = ("20" + yearstr);
        }
                    
        //informacja o płci
        Int64 Sex = (Pesel / 10) % 10;
        string Sex2;
        if (Sex % 2 == 0)
        {
            Sex2 = "kobieta";
        }
        else
        {
            Sex2 = "mężczyzna";
        }
      
        //rozdzielenie nr pesel na czynniki
        //suma kontorlna
        if (L2 * 3 >= 10)
        {
            L2 = (L2 * 3) % 10;
        }
        if (L3 * 7 >= 10)
        {
            L3 = (L3 * 7) % 10;
        }
        if (L4 * 9 >= 10)
        {
            L4 = (L4 * 9) % 10;
        }
        if (L6 * 3 >= 10)
        {
            L6 = (L6 * 3) % 10;
        }
        if (L7 * 7 >= 10)
        {
            L7 = (L7 * 7) % 10;
        }
        if (L8 * 9 >= 10)
        {
            L8 = (L8 * 9) % 10;
        }
        if (L10 * 3 >= 10)
        {
            L10 = (L10 * 3) % 10;
        }

        Console.WriteLine(L1 + " " + L2 + " " + L3 + " " + L4 + " " + L5 + " " + L6 + " " + L7 + " " + L8 + " " + L9 + " " + L10);

        //sytuacja gdzie suma kontrolna wychodzi 10-0=10 -> wpisujemy 0
        double Controlsum;
        if (((L1 + L2 + L3 + L4 + L5 + L6 + L7 + L8 + L9 + L10) % 10) == 0)
        {
            Controlsum = 0;
        }
        else
        {
            Controlsum = 10 - ((L1 + L2 + L3 + L4 + L5 + L6 + L7 + L8 + L9 + L10) % 10);
        }

        //jeśli wpisano błędny pesel
        if (L11 != Controlsum)
        {
            Console.WriteLine("Błędny numer pesel. Podaj ponownie.");
        }

        //info dla użytkownika
        Console.WriteLine();
        Console.WriteLine(dane[1] + ": ");
        Console.WriteLine("Data urodzenia: " + day + "." + monthstr + "." + yearstr2);
        Console.WriteLine("Płeć: " + Sex2);


        Console.ReadKey();
    }
}
