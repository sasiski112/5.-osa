using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Xml.Linq;

namespace _5._osa
{
    //internal class funktsioonid
    //{
    //    public static void Main()
    //    {
    //        ArrayList mogged = new ArrayList();
    //        mogged.Add("Mihkel");
    //        mogged.Add("Zeleboba");
    //        mogged.Add("slivi");
    //        if (mogged.Contains("yabloki zelenie"))
    //        {
    //            Console.WriteLine("yabloki zelenie on olemas");
    //        }
    //        Console.WriteLine("Nimed kokku on " + mogged.Count);

    //        mogged.Insert(1, "burmalda");
    //        Console.WriteLine("Zeleboba indeks: " + mogged.IndexOf("Zeleboba"));
    //        Console.WriteLine("slivi indeks: " + mogged.IndexOf("slivi"));

    //        foreach (string mog in mogged)
    //            Console.WriteLine(mog);
    //    }
    //    class Person
    //    {
    //        public string MMM { get; set; }
    //    }

    //}

class Person
    {
        public string MMM { get; set; }
    }

    class Program
    {
        public static void Wkers()
        {
            List<Person> workers = new List<Person>();

            workers.Add(new Person() { MMM = "Mavrodi" });
            workers.Add(new Person() { MMM = "Melnikova" });

            workers.AddRange(new List<Person>()
        {
            new Person(){ MMM = "Ivanov" },
            new Person(){ MMM = "Petrova" }
        });

            workers.Insert(1, new Person() { MMM = "Sidorov" });

            Console.WriteLine("Wokers list:");
            foreach (Person w in workers)
            {
                Console.WriteLine(w.MMM);
            }

            int index = workers.IndexOf(workers[2]);
            Console.WriteLine("\n: " + index);            

            workers.Remove(workers[0]);
            workers.RemoveAt(1);

            Console.WriteLine("\nAfter del:");
            foreach (Person w in workers)
            {
                Console.WriteLine(w.MMM);
            }

            workers.Sort((a, b) => a.MMM.CompareTo(b.MMM));

            Console.WriteLine("\nAfter sort:");
            foreach (Person w in workers)
            {
                Console.WriteLine(w.MMM);
            }
            int searchIndex = workers.BinarySearch(
                new Person() { MMM = "Petrova" },
                Comparer<Person>.Create((a, b) => a.MMM.CompareTo(b.MMM))
            );

            Console.WriteLine("\nBinarySearch индекс: " + searchIndex);
        }

        static void Main()
        {
            Wkers();
        }
    }
}