Console.Write("Podaj szerokosc: ");
string xs = Console.ReadLine();
Console.Write("Podaj wysokosé: ");
string ys = Console.ReadLine();
int x = int.Parse(xs);
int y = int.Parse(ys);
for (int i = 0; i < y; i++)
{
    for (int j = 0; j < x; j++)
    {
        Console.Write("*");

    }
    Console.WriteLine();
}