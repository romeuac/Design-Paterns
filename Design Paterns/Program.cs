using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Design_Paterns
{
    // Reviewing SINGLETON PATTERN 
    public class SingletonTester
    {
        
        public static bool IsSingleton(Func<object> func)
        {
            // todo
            var instance1 = func();
            var instance2 = func();

            //return Object.Equals(instance1, instance2);
            return instance1.Equals(instance2);
            //return ReferenceEquals(instance1, instance2);

        }

    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class PointFactory
    {
        // Garantindo que sera originado sempre o mesmo objeto pra dar True na comparacao
        private static Point origen = new Point() { X = 0, Y = 0 };

        public static Point Origen()
        {
            return origen;
        }
    }

    class Exercise
    { 

        static void Main(string[] args)
        {
            var isEqual = SingletonTester.IsSingleton(PointFactory.Origen);
            Console.WriteLine($"Is the object a singleton? {isEqual}");


        }

    }
}
