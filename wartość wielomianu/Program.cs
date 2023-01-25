using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Horner
{
    class Program
    {
        static void Main()
        {
            string polynomialStr = Console.ReadLine();
            int valueX = int.Parse(Console.ReadLine());
            string[] polynominalStrTab = Regex.Split(polynomialStr, @"(?=[+-])");
            double Result = 0;

            foreach (string item in polynominalStrTab)
            {
                if (String.IsNullOrEmpty(item) == true) Console.Write("");
                else if (item.Contains('^') == true)
                {
                    string[] values = item.Split("x^");
                    if (String.IsNullOrEmpty(values[0]) || values[0]=="+") values[0] = "1";
                    else if (values[0] == "-") values[0] = "-1";
                    int[] valuesInt = Array.ConvertAll(values, int.Parse);
                    Result += valuesInt[0] * Math.Pow(valueX, valuesInt[1]);
                }
                else if (item.Contains('x') == true)
                {
                    string valuesStr = item.Remove(item.Length - 1, 1);
                    if (String.IsNullOrEmpty(valuesStr) || valuesStr == "+") valuesStr = "1";
                    else if (valuesStr == "-") valuesStr = "-1";
                    int valuesInt = int.Parse(valuesStr);
                    Result += valuesInt * valueX;
                }
                else
                {
                    Result += int.Parse(item);
                }
            }

            Console.WriteLine(Result);
        }
    }
}