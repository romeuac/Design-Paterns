using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Design_Paterns
{
    // =====================================
    // WE ARE ADDING TOO MUCH RESPONSABILITY TO ONE SINGLE CLASS:
    //  IT IS NO ONLY KEEPING THE ENTRIES BUT ALSO MANAGING ALL THE PERSISTENCE (SAVE , LOAD, LOAD...)
    //  lAKE THIS WE MORE REASONS TO CHANGE THE CLASS..
    // =====================================

    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry (string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // momento patern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // SERIA ENVIADO PRA PERSISTENCE
        //public void Save(string filename)
        //{
        //    File.WriteAllText(filename, ToString());
        //}

        //public static Journal Load(string filename)
        //{

        //}

        //public void Load (Uri uri)
        //{

        //}
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
            
    }

    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I met professor X today");
            j.AddEntry("I ate pizza");
            Console.WriteLine(j);

            // CRIADO O OBJ para GARANTIR PERSISTENCE em classe SEPARADA
            var p = new Persistence();
            var filename = @"C:\Users\Romeu\Desktop\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}
