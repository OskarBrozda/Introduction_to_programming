public class Czas24h
{
    private int liczbaSekund;

    public int Sekunda
    {
        get => liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
        set
        {
            if ((value > 0) && (value < 60))
            {
                int s = liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
                liczbaSekund = liczbaSekund - s + value;
            }
            else throw new ArgumentException("error");
        }
    }

    public int Minuta
    {
        get => (liczbaSekund / 60) % 60;
        set
        {
            if ((value > 0) && (value < 60))
            {
                int m = (liczbaSekund / 60) % 60;
                liczbaSekund = liczbaSekund - (m * 60) + value * 60;
            }
            else throw new ArgumentException("error");
        }
    }

    public int Godzina
    {
        get => liczbaSekund / 3600;
        set
        {
            if ((value > 0) && (value < 24))
            {
                int g = liczbaSekund / 3600;
                liczbaSekund = liczbaSekund - (g * 3600) + value * 3600;
            }
            else throw new ArgumentException("error");
        }
    }

    public Czas24h(int godzina, int minuta, int sekunda)
    {
        if (godzina < 0 || godzina > 23 || minuta < 0 || minuta > 60 || sekunda < 0 || sekunda > 60) throw new ArgumentException("error");
        liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;

    }

    public override string ToString() => $"{Godzina}:{Minuta:D2}:{Sekunda:D2}";
}

class Program
{
    static void Main(string[] args)
    {
        //test 1
        var t = new Czas24h(2, 15, 37);
        t.Minuta = 20;
        t.Godzina = 23;
        t.Godzina = 1;
        t.Sekunda = 15;
        t.Minuta = 10;
        t.Sekunda = 23;
        t.Sekunda = 1;
        t.Minuta = 12;
        Console.WriteLine(t); //answear

        //test 2
        var t1 = new Czas24h(2, 15, 37);
        t1.Minuta = -20;
        t1.Godzina = 23;
        Console.WriteLine(t1); //error
    }
}