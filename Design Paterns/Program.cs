using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Design_Paterns
{
    // Reviewing PROTOTYPE PATTERN - Deep Copying

    public class Point
    {
        public int X, Y;

        public Point DeepCopy()
        {
            return new Point()
            {
                X = this.X,
                Y = this.Y
            };
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return new Line()
            {
                Start = this.Start.DeepCopy(),
                End = this.End.DeepCopy()
            };
        }
    }

    class Exercise
    { 

        static void Main(string[] args)
        {
            var line = new Line();
            line.Start = new Point() { X = 1, Y = 2 };
            line.End = new Point() { X = 1, Y = 2 };

            var line2 = line.DeepCopy();
            line2.Start.X = 2;

            Console.WriteLine($"Line 1, Start - X: {line.Start.X}, Y: {line.Start.Y}");
            Console.WriteLine($"Line 2, Start - X: {line2.Start.X}, Y: {line2.Start.Y}");


        }

    }
}
