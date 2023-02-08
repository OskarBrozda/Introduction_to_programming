using System;

namespace MinimumBoundingRectangle
{    
    class Rectangle
    {
        static void Main()
        {
            int numberOfCase = int.Parse(Console.ReadLine());
            var figureList = new List<Coordinates>();
            for (int i = 0; i < numberOfCase; i++)
            {
                var timeList = new List<Coordinates>();
                string numberOfObjectsStr;
                do
                {
                    numberOfObjectsStr = Console.ReadLine();
                }while(string.IsNullOrEmpty(numberOfObjectsStr));
                int numberOfObjects = int.Parse(numberOfObjectsStr);
                for (int j = 0; j < numberOfObjects; j++)
                {
                    string[] figure = Console.ReadLine().Split(' ');
                    if (figure[0] == "p")
                    {
                        timeList.Add(GetBoundingRectangle(int.Parse(figure[1]), int.Parse(figure[2])));
                    }
                    if (figure[0] == "c")
                    {
                        timeList.Add(GetBoundingRectangle(int.Parse(figure[1]), int.Parse(figure[2]), int.Parse(figure[3])));
                    }
                    if (figure[0] == "l")
                    {
                        timeList.Add(GetBoundingRectangle(int.Parse(figure[1]), int.Parse(figure[2]), int.Parse(figure[3]), int.Parse(figure[4])));
                    }                    
                }

                var XLeft = new SortedSet<int>();
                var YDown = new SortedSet<int>();
                var XRight = new SortedSet<int>();
                var YUp = new SortedSet<int>();

                foreach (var item in timeList)
                {
                    XLeft.Add(item.XLeft);
                    YDown.Add(item.YDown);
                    XRight.Add(item.XRight);
                    YUp.Add(item.YUp);
                }

                figureList.Add(GetBoundingRectangle(XLeft.Min(), YDown.Min(), XRight.Max(), YUp.Max()));
            }

            foreach (var item in figureList)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.XLeft, item.YDown, item.XRight, item.YUp);
            }
        }

        static Coordinates GetBoundingRectangle(params int[] Points)
        {
            Coordinates P = new Coordinates();
            P.XLeft = Points.Length==2? Points[0] : Points.Length == 3 ? Points[0] - Points[2] : Points.Length == 4 ? Points[0] < Points[2] ? Points[0] : Points[2] : throw new ArgumentException();
            P.YDown = Points.Length == 2 ? Points[1] : Points.Length == 3 ? Points[1] - Points[2] : Points.Length == 4 ? Points[1] < Points[3] ? Points[1] : Points[3] : throw new ArgumentException();
            P.XRight = Points.Length == 2 ? Points[0] : Points.Length == 3 ? Points[0] + Points[2] : Points.Length == 4 ? Points[0] > Points[2] ? Points[0] : Points[2] : throw new ArgumentException();
            P.YUp = Points.Length == 2 ? Points[1] : Points.Length == 3 ? Points[1] + Points[2] : Points.Length == 4 ? Points[1] > Points[3] ? Points[1] : Points[3] : throw new ArgumentException();
            return P;
        }       
    }

    class Coordinates
    {
        public int XLeft;
        public int YDown;
        public int XRight;
        public int YUp;
    }   
}