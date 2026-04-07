using System;

class StartPage
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n=== MENÜÜ ===");
            Console.WriteLine("1 - Kalorite kalkulaator");
            Console.WriteLine("2 - Maakonnad ja pealinnad");
            Console.WriteLine("3 - Õpilased ja hinded");
            Console.WriteLine("4 - Filmide kogu");
            Console.WriteLine("5 - Massiivi statistika");
            Console.WriteLine("6 - Lemmikloomad");
            Console.WriteLine("7 - Valuutakalkulaator");
            Console.WriteLine("0 - Välju");

            Console.Write("\nValik: ");
            string valik = Console.ReadLine();

            switch (valik)
            {
                case "1":
                    Alamfunktsioonid.Calculator();
                    break;
                case "2":
                    Alamfunktsioonid.MaakonnadJaPealinnad();
                    break;
                case "3":
                    Alamfunktsioonid.OpilasedJaHinded();
                    break;
                case "4":
                    Alamfunktsioonid.FilmideKogu();
                    break;
                case "5":
                    Alamfunktsioonid.MassiiviStatistika();
                    break;
                case "6":
                    Alamfunktsioonid.Lemmikloomad();
                    break;
                case "7":
                    Alamfunktsioonid.ValuutaKalkulaator();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Vale valik!");
                    break;
            }
        }
    }
}
