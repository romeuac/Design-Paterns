using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Design_Paterns
{
    public enum Relationship
    {
        Parent,
        Sibling,
        Child
    }
    
    public class Person
    {
        public string Name;
        //public DateTime DateOfBirth;
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    // LOW-LEVEL
    public class Relationships : IRelationshipBrowser
    {
        // TUPLEs - tuplas - Incluir nos pacotes do NUGET o --- System.ValueTuple ---
        private List<(Person, Relationship, Person)> relations = 
            new List<(Person, Relationship, Person)>();

        public void AddParentAndChild (Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));

            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var r in relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent))
            {
                yield return r.Item3;
            }
        }

        // Public Getter for the relations field
        //public List<(Person, Relationship, Person)> Relations => relations;
    }

    class Research
    {
        //public Research(Relationships relationships)
        //{
        //    var relations = relationships.Relations;

        //    foreach (var r in relations.Where( x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
        //    {
        //        Console.WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }
        

        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1= new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }

    }
}
