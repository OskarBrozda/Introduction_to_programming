using System;
using System.Collections;
using System.Globalization;


CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

//przyjmujemy wartości boków
Console.Write("Podaj długość boku a; b; c: ");
string triangle = Console.ReadLine();
string[] sideTriangleStr = triangle.Split("; ", StringSplitOptions.RemoveEmptyEntries);
double[] sideTriangle = new double[sideTriangleStr.Length];
for (int i = 0; i < sideTriangle.Length; i++)
{
    sideTriangle[i] = double.Parse(sideTriangleStr[i]);
}

//warunki wyłączenia programu
if (sideTriangle[0] <= 0 || sideTriangle[1] <= 0 || sideTriangle[2] <= 0)
{
    Console.WriteLine("Błędne dane. Długości boków muszą być dodatnie!");
    return;
}
if(sideTriangle[0] + sideTriangle[1] < sideTriangle[2] ||
   sideTriangle[1] + sideTriangle[2] < sideTriangle[0] ||
   sideTriangle[2] + sideTriangle[0] < sideTriangle[1])
{
    Console.WriteLine("Błędne dane. Trójkąta nie można zbudować!");
    return;
}

//obwód
double perimeter = Math.Round(sideTriangle[0] + sideTriangle[1] + sideTriangle[2], 2);
Console.WriteLine($"obwód = {perimeter.ToString("F", CultureInfo.InvariantCulture)}"); //zaokrąglamy do formy np 10.00


//pole
Convert.ToDecimal(perimeter);
double area = Math.Round(Math.Sqrt((perimeter / 2) *(((perimeter / 2) - sideTriangle[0]) * ((perimeter / 2) - sideTriangle[1]) * ((perimeter / 2) - sideTriangle[2]))), 2);
Console.WriteLine($"pole = {area.ToString("F", CultureInfo.InvariantCulture)}");


//typ (kąt)
Array.Sort(sideTriangle);
if (Math.Pow(sideTriangle[0], 2) + Math.Pow(sideTriangle[1], 2) < Math.Pow(sideTriangle[2], 2)) Console.WriteLine("trójkąt jest rozwartokątny");
if (Math.Pow(sideTriangle[0], 2) + Math.Pow(sideTriangle[1], 2) == Math.Pow(sideTriangle[2], 2)) Console.WriteLine("trójkąt jest prostokątny");
if (Math.Pow(sideTriangle[0], 2) + Math.Pow(sideTriangle[1], 2) > Math.Pow(sideTriangle[2], 2)) Console.WriteLine("trójkąt jest ostrokątny");


//typ (bok)
if (sideTriangle[0] == sideTriangle[1] &&
    sideTriangle[1] == sideTriangle[2])
{
    Console.WriteLine("trójkąt równoboczny");
}
else if (sideTriangle[0] == sideTriangle[1] ||
         sideTriangle[1] == sideTriangle[2] ||
         sideTriangle[2] == sideTriangle[0])
{
    Console.WriteLine("trójkąt równoramienny");
}


Console.ReadKey();
