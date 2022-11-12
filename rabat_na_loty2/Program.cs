//witamy użytkownika
using System.Xml.Linq;

Console.WriteLine("Witaj w systemie rezerwacji lotów online! Podaj następujące informacje:");
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

Console.Write("Data urodzenia: ");
DateTime birthDate = new DateTime();
DateTime todayDate = new DateTime();
TimeSpan age = todayDate.Subtract(birthDate);
do
{
    birthDate = DateTime(Console.ReadLine());
    if (string.IsNullOrEmpty(name))
    {
        Console.Write("Pole nie może zostać puste. Podaj imię: ");
    }
} while (string.IsNullOrEmpty(name));