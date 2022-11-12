//witamy użytkownika
using System.Globalization;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

//data urodzenia i wiek
Console.Write("Data urodzenia (dd.mm.yyyy): ");
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
    //do i-tej komórki tablicy a przypisz przekonwertowany i-ty string z tablicy
    tablicaInt[i] = int.Parse(tablicaStr[i]);
}

var birthDate = new DateTime(tablicaInt[2], tablicaInt[1], tablicaInt[0]);
var todayDate = DateTime.Today;
int age = ((int.Parse($"{todayDate.Year}{todayDate.Month}{todayDate.Day}") - int.Parse($"{birthDate.Year}{birthDate.Month}{birthDate.Day}"))/10000);


Console.ReadKey();

