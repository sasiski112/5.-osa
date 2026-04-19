using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\nVali tegemus:");
            Console.WriteLine("1. Kalorite kalkulaator");
            Console.WriteLine("2. Maakonnad ja pealinnad");
            Console.WriteLine("3. Õpilaste ja toodete analüüs");
            Console.WriteLine("4. Filmihaldus");
            Console.WriteLine("5. Arvude statistika");
            Console.WriteLine("6. Lemmikloomade registreerimine");
            Console.WriteLine("7. Valuuta kalkulaator");
            Console.WriteLine("0. Välju programmist");
            Console.Write("\nSinu valik: ");

            string valik = Console.ReadLine();


            switch (valik)
            {
                case "1":
                    Console.Clear();
                    Alamfunktsioonid.CaloorideCalculator();
                    break;
                case "2":
                    Console.Clear();
                    Alamfunktsioonid.MaakonnadJaPealinnad();
                    break;
                case "3":
                    Console.Clear();
                    Alamfunktsioonid.OpilasedJaTooted();
                    break;
                case "4":
                    Console.Clear();
                    Alamfunktsioonid.FilmiHaldus();
                    break;
                case "5":
                    Console.Clear();
                    Alamfunktsioonid.ArvudeStatistika();
                    break;
                case "6":
                    Console.Clear();
                    Alamfunktsioonid.LemmikloomaHaldus();
                    break;
                case "7":
                    Console.Clear();
                    Alamfunktsioonid.ValuutaKalkulaator();
                    break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("Head aega!");
                    return;
                default:
                    Console.WriteLine("Vale valik!");
                    break;
            }
        }
    }
}
