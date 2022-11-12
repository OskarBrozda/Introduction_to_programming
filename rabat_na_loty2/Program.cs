using System.Globalization;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

//witamy użytkownika
Console.WriteLine("Witaj w systemie rezerwacji lotów online! Podaj następujące informacje:");

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
var today = DateTime.Today;
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
Console.WriteLine("Lot bedzie w krajowy, czy międzynarodowy? ");
string destination = Console.ReadLine();
//destination.Contains("kraj");

//termin lotu
Console.Write("Data termin wylotu (dd.mm.yyyy): ");
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
        Console.Write("Nie mozna wyszukac lotu z przeszłości. Podaj poprawną datę wylotu (dd.mm.yyyy): ");
    }
} while (flyDateInt < today);


//wiek w dzień wylotu
int flyAge;
if(int.Parse($"{flyDateInt.Year}{flyDateInt.Month}{flyDateInt.Day}") - int.Parse($"{birthDateInt.Year}{birthDateInt.Month}{birthDateInt.Day}")>1000000)
{
    flyAge= ((int.Parse($"{flyDateInt.Year}{flyDateInt.Month}{flyDateInt.Day}") - int.Parse($"{birthDateInt.Year}{birthDateInt.Month}{birthDateInt.Day}")) / 10000);
}
else
{
    flyAge = ((int.Parse($"{flyDateInt.Year}{flyDateInt.Month}{flyDateInt.Day}") - int.Parse($"{birthDateInt.Year}{birthDateInt.Month}{birthDateInt.Day}")) / 1000);
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


    Console.ReadKey();

