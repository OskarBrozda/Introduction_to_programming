using System.Globalization;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

//deklarujemy cene pierwotną naszego lotu, bez żadnych zniżek
double firstPrice = 1000; 


//witamy użytkownika
Console.WriteLine("Witaj w systemie wyceny lotów online! Potrzebuję kilka informacji:");


//imię
Console.Write("Imię: ");
string name;
do
{
    name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
    {
        Console.Write("Pole nie może zostać puste. Podaj imię: ");
    }
} while (string.IsNullOrEmpty(name));


//nazwisko
Console.Write("Nazwisko: ");
string surname;
do
{
    surname = Console.ReadLine();
    if (string.IsNullOrEmpty(surname))
    {
        Console.Write("Pole nie może zostać puste. Podaj nazwisko: ");
    }
} while (string.IsNullOrEmpty(surname));


//data urodzenia
Console.Write("Data urodzenia (dd.mm.yyyy): ");
DateTime today = DateTime.Today;
DateTime birthDateInt;
do
{
    string birthDateStr;
    string[] tablicaStr;
    do
    {
        birthDateStr = Console.ReadLine();
        tablicaStr = birthDateStr.Split('.', StringSplitOptions.RemoveEmptyEntries);
        if (string.IsNullOrEmpty(birthDateStr))
        {
            Console.Write("Pole nie może zostać puste. Podaj datę urodzenia (dd.mm.yyyy): ");
        }
    } while (string.IsNullOrEmpty(birthDateStr));

    //konweruje datę ze string na int
    int[] tablicaInt = new int[tablicaStr.Length];
    for (int i = 0; i < tablicaStr.Length; i++)
    {
        //do i-tej komórki tablicyInt przypisz przekonwertowany i-ty string z tablicyStr
        tablicaInt[i] = int.Parse(tablicaStr[i]);
    }

    birthDateInt = new DateTime(tablicaInt[2], tablicaInt[1], tablicaInt[0]);
    if (birthDateInt > today)
    {
        Console.Write("Pole nie może zawierać daty z przyszłości. Podaj poprawną datę urodzenia (dd.mm.yyyy): ");
    }
} while (birthDateInt > today);


//kierunek lotu
Console.Write("Lot będzie krajowy, czy międzynarodowy? ");
string destinationStr;
do
{
    destinationStr = Console.ReadLine();
    if (string.IsNullOrEmpty(destinationStr))
    {
        Console.Write("Pole nie może zostać puste. Lot będzie krajowy, czy międzynarodowy? ");
    }
} while (string.IsNullOrEmpty(destinationStr));

bool destinationCountry;
if (destinationStr.Contains("kraj"))
{
    destinationCountry = true;
}
else
{
    destinationCountry = false;
}


//termin lotu
Console.Write("Data wylotu (dd.mm.yyyy): ");
DateTime flyDateInt;
do
{
    string flyDateStr;
    string[] tablica2Str;
    do
    {
        flyDateStr = Console.ReadLine();
        tablica2Str = flyDateStr.Split('.', StringSplitOptions.RemoveEmptyEntries);
        if (string.IsNullOrEmpty(flyDateStr))
        {
            Console.Write("Pole nie może zostać puste. Podaj datę wylotu (dd.mm.yyyy): ");
        }
    } while (string.IsNullOrEmpty(flyDateStr));

    //konweruję datę ze string na int
    int[] tablica2Int = new int[tablica2Str.Length];
    for (int k = 0; k < tablica2Str.Length; k++)
    {
        //do k-tej komórki tablicy2Int przypisz przekonwertowany k-ty string z tablicy2Str
        tablica2Int[k] = int.Parse(tablica2Str[k]);
    }
    flyDateInt = new DateTime(tablica2Int[2], tablica2Int[1], tablica2Int[0]);
    if (flyDateInt < today)
    {
        Console.Write("Nie można wyszukać lotu z przeszłości. Podaj poprawną datę wylotu (dd.mm.yyyy): ");
    }
} while (flyDateInt < today);


//wiek w dzień wylotu
int flyAge = flyDateInt.Year - birthDateInt.Year;
if (birthDateInt.Date > flyDateInt.AddYears(-flyAge)) flyAge--;


//stały klient
bool regularCustomer;
if (flyAge>=18)
{
    string answear;
    Console.Write("Czy jesteś stałym klientem? ");
    do
    {
        answear = Console.ReadLine();
        if (string.IsNullOrEmpty(answear))
        {
            Console.Write("Pole nie może zostać puste. Czy jesteś stałym klientem? ");
        }
    } while (string.IsNullOrEmpty(answear));

    if (answear.Contains("t") || answear.Contains("y"))
    {
        regularCustomer = true;
    } else
    {
        regularCustomer = false;
    }
}else
{
    regularCustomer = false;
}


//sezony wysokie
DateTime previousChristmas1Begin = new DateTime(flyDateInt.Year - 1, 12, 20);
DateTime previousChristmas1End = new DateTime(flyDateInt.Year, 01, 10);
DateTime nextChristmas1Begin = new DateTime(flyDateInt.Year, 12, 20);
DateTime nextChristmas1End = new DateTime(flyDateInt.Year + 1, 01, 10);
DateTime christmas2Begin = new DateTime(flyDateInt.Year, 03, 20); ;
DateTime christmas2End = new DateTime(flyDateInt.Year, 04, 10);
DateTime holidayBegin = new DateTime(flyDateInt.Year, 07, 01);
DateTime holidayEnd = new DateTime(flyDateInt.Year, 08, 31);

bool highSeason;
if (DateTime.Compare(flyDateInt, previousChristmas1Begin) >= 0 && DateTime.Compare(flyDateInt, previousChristmas1End) <= 0 ||
    DateTime.Compare(flyDateInt, nextChristmas1Begin) >= 0 && DateTime.Compare(flyDateInt, nextChristmas1End) <= 0 ||
    DateTime.Compare(flyDateInt, christmas2Begin) >= 0 && DateTime.Compare(flyDateInt, christmas2Begin) <= 0 ||
    DateTime.Compare(flyDateInt, holidayBegin) >= 0 && DateTime.Compare(flyDateInt, holidayEnd) <= 0)
{
    highSeason = true;
}else
{
    highSeason = false;
}


//program do obliczania ceny po zniżkach
double secondPrice = 0; //cena ze zniżką

if (flyAge < 2)
{
   
    if (destinationCountry == true)
    {
        secondPrice = firstPrice * 0.2;
    }
    else 
    {
        secondPrice = firstPrice * 0.3 * 0.85;
    }
    if (today.AddMonths(5) < flyDateInt)
    {
        secondPrice = secondPrice * 0.9;
    }     
}

if (flyAge >= 2 && flyAge<16)
{
    if (destinationCountry == true)
    {
        secondPrice = firstPrice * 0.9;
    }
    else if((destinationCountry == false) && (highSeason == false))
    {
        secondPrice = firstPrice * 0.9 * 0.85;
    }
    else
    {
        secondPrice = firstPrice;
    }
    if (today.AddMonths(5) < flyDateInt)
    {
        secondPrice = secondPrice * 0.9;
    }  
}

if (flyAge >= 16 && flyAge < 18)
{
    if ((destinationCountry == false) && (highSeason == false))
    {
        secondPrice = firstPrice * 0.85;
    }
    else
    {
        secondPrice = firstPrice;
    }
    if (today.AddMonths(5) < flyDateInt)
    {
        secondPrice = secondPrice * 0.9;
    }
}
if (flyAge >= 18)
{
    if ((destinationCountry == false) && (highSeason == false))
    {
        secondPrice = firstPrice * 0.85;
    }
    else 
    {
        secondPrice = firstPrice;
    }
    if (today.AddMonths(5) < flyDateInt)
    {
        secondPrice = secondPrice * 0.9;
    }
    if (regularCustomer == true)
    {
        secondPrice = secondPrice * 0.85;
    }  
}

if (flyAge < 2 && secondPrice < firstPrice * 0.2)
{
    secondPrice = firstPrice * 0.2;
}
if (flyAge >= 2 && secondPrice < firstPrice * 0.7)
{
    secondPrice = firstPrice * 0.7;
}


//odpowiedź dla użytkownika
Console.WriteLine(); //linia odstepu dla czytelności
if (destinationCountry == false)
{
    Console.WriteLine($@"Najkorzystniejsze połączenie międzynarodowe dla:
{surname} {name}, lat {flyAge}, w dniu {flyDateInt.ToString("d", new System.Globalization.CultureInfo("pl-PL"))}: {secondPrice}zł");
}
else
{
    Console.WriteLine($@"Najkorzystniejsze połączenie krajowe dla:
{surname} {name}, lat {flyAge}, w dniu {flyDateInt.ToString("d", new System.Globalization.CultureInfo("pl-PL"))}: {secondPrice}zł");
}


Console.ReadKey();