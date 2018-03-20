using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Design_Paterns
{
    // Reviewing FACTORY PATTERN

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        public int idCounter { get; set; }

        public PersonFactory()
        {
            this.idCounter = 0;
        }

        public Person CreatePerson(string name)
        {
            return new Person() { Id = idCounter++, Name = name };
        }
    }

    class Exercise
    { 

        static void Main(string[] args)
        {
            var pFactory = new PersonFactory();
            var p1 = pFactory.CreatePerson("Oio");
            var p2 = pFactory.CreatePerson("Aia");

            Console.WriteLine($"Id0: {p1.Id}, Id1: {p2.Id}");


        }

    }
}
