using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public static class Alamfunktsioonid
{
    public static double CaloorideCalculator()
    {
        double kaal, pikkus, aktiivsusTase;
        int vanus;
        string sugu;

        while (true)
        {
            try
            {
                Console.Write("Sisesta sinu kaal: ");
                kaal = Convert.ToDouble(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
                if (kaal > 30 && kaal < 350) break;
                Console.WriteLine("Sisesta korrektne arv (30-350)");
            }
            catch { Console.WriteLine("Viga! Sisesta number."); }
        }

        while (true)
        {
            try
            {
                Console.Write("Sisesta sinu pikkus: ");
                pikkus = Convert.ToDouble(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
                if (pikkus > 70 && pikkus < 250) break;
                Console.WriteLine("Sisesta korrektne arv (70-250)");
            }
            catch { Console.WriteLine("Viga! Sisesta number."); }
        }

        while (true)
        {
            try
            {
                Console.Write("Sisesta sinu vanus: ");
                vanus = Convert.ToInt32(Console.ReadLine());
                if (vanus > 5 && vanus < 120) break;
                Console.WriteLine("Sisesta korrektne arv (5-120)");
            }
            catch { Console.WriteLine("Viga! Sisesta täisarv."); }
        }

        while (true)
        {
            Console.Write("Sisesta sinu sugu (mees/naine): ");
            sugu = Console.ReadLine().ToLower().Trim();
            if (sugu == "mees" || sugu == "naine") break;
            Console.WriteLine("Viga! Kirjuta 'mees' või 'naine'.");
        }

        while (true)
        {
            try
            {
                Console.Write("Sisesta sinu aktiivsuse tase (1.2 - 1.9): ");
                aktiivsusTase = Convert.ToDouble(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
                if (aktiivsusTase >= 1.2 && aktiivsusTase <= 1.9) break;
                Console.WriteLine("Sisesta korrektne aktiivsuse tase (1.2 - 1.9)");
            }
            catch { Console.WriteLine("Viga! Sisesta number."); }
        }

        double kalorid = (sugu == "mees")
            ? (88.36 + (13.4 * kaal) + (4.8 * pikkus) - (5.7 * vanus)) * aktiivsusTase
            : (447.6 + (9.2 * kaal) + (3.1 * pikkus) - (4.3 * vanus)) * aktiivsusTase;

        Console.WriteLine($"Sinu päevane kalorite vajadus on: {kalorid:F2} kcal");

        return kalorid;
    }

    public static void MaakonnadJaPealinnad()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Dictionary<string, string> dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"Harju", "Tallinn"},
            {"Tartu", "Tartu"},
            {"Pärnu", "Pärnu"},
            {"Ida-Viru", "Jõhvi"},
            {"Lääne-Viru", "Rakvere"},
            {"Viljandi", "Viljandi"},
            {"Rapla", "Rapla"},
            {"Võru", "Võru"},
            {"Saare", "Kuressaare"},
            {"Järva", "Paide"},
            {"Valga", "Valga"},
            {"Põlva", "Põlva"},
            {"Lääne", "Haapsalu"},
            {"Jõgeva", "Jõgeva"},
            {"Hiiu", "Kärdla"}
        };

        while (true)
        {
            Console.WriteLine("\n1-Pealinn, 2-Maakond, 3-Mäng, 4-Välju");
            string v = Console.ReadLine();
            if (v == "4") break;

            if (v == "1")
            {
                Console.Write("Maakond: "); string m = Console.ReadLine();
                if (dict.ContainsKey(m))
                {
                    Console.WriteLine("Pealinn: " + dict[m]);
                }
                else 
                { 
                    Console.Write("Puudub. Lisa pealinn: "); dict[m] = Console.ReadLine(); 
                }
            }
            else if (v == "2")
            {
                Console.Write("Pealinn: "); string p = Console.ReadLine();
                var res = dict.FirstOrDefault(x => x.Value.Equals(p, StringComparison.OrdinalIgnoreCase)).Key;
                Console.WriteLine(res != null ? "Maakond: " + res : "Ei leitud");
            }
            else if (v == "3") MangiMangu(dict);
        }
    }

    private static void MangiMangu(Dictionary<string, string> dict)
    {
        Random rnd = new Random();
        var keys = dict.Keys.ToList();
        int oige = 0;
        Console.Write("Mitu küsimust? ");
        if (!int.TryParse(Console.ReadLine(), out int kokku)) return;

        for (int i = 0; i < kokku; i++)
        {
            string k = keys[rnd.Next(keys.Count)];
            Console.Write($"Mis on {k} pealinn? ");
            if (Console.ReadLine().Equals(dict[k], StringComparison.OrdinalIgnoreCase)) { Console.WriteLine("Õige!"); oige++; }
            else Console.WriteLine("Vale! Õige: " + dict[k]);
        }
        Console.WriteLine($"Tulemus: {oige}/{kokku} ({(double)oige / kokku * 100:F1}%)");
    }

    public static void OpilasedJaTooted()
    {
        List<Opilane> opilased = new List<Opilane>
        {
            new Opilane { Nimi = "Kati", Hinded = new List<int>{5,4,5} },
            new Opilane { Nimi = "Mati", Hinded = new List<int>{3,4,3} }
        };
        foreach (var o in opilased) Console.WriteLine($"{o.Nimi} keskmine: {o.Keskmine:F2}");
        Console.WriteLine("Parim õpilane: " + opilased.OrderByDescending(x => x.Keskmine).First().Nimi);

        List<Toode> tooted = new List<Toode>
        {
            new Toode { Nimi = "Sai", Hind = 1.2 },
            new Toode { Nimi = "Piim", Hind = 0.8 }
        };
        Console.WriteLine("Kalleim toode: " + tooted.OrderByDescending(t => t.Hind).First().Nimi);
    }

    public static void FilmiHaldus()
    {
        List<Film> filmid = new List<Film>
        {
            new Film { Pealkiri = "Tenet", Aasta = 2020, Zanr = "Action" },
            new Film { Pealkiri = "Shrek", Aasta = 2001, Zanr = "Komöödia" },
            new Film { Pealkiri = "Avatar", Aasta = 2009, Zanr = "Sci-Fi" }
        };
        Console.WriteLine("Viimane film: " + filmid.OrderByDescending(f => f.Aasta).First().Pealkiri);
        var grupid = filmid.GroupBy(f => f.Zanr);
        foreach (var g in grupid) Console.WriteLine($"Žanr {g.Key}: {g.Count()} filmi");
    }

    public static void ArvudeStatistika()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Sisesta arvud tühikuga:");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;
                double[] a = input.Replace(',', '.').Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToArray();
                Console.WriteLine($"Max: {a.Max()}, Min: {a.Min()}, Sum: {a.Sum()}, Avg: {a.Average():F2}");
                break;
            }
            catch { Console.WriteLine("Viga! Sisesta ainult numbreid."); }
        }
    }

    public static void LemmikloomaHaldus()
    {
        List<Lemmikloom> loomad = new List<Lemmikloom>();
        for (int i = 0; i < 3; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write("Loom nimi: "); string n = Console.ReadLine();
                    Console.Write("Liik: "); string l = Console.ReadLine();
                    Console.Write("Vanus: "); int v = int.Parse(Console.ReadLine());
                    loomad.Add(new Lemmikloom { Nimi = n, Liik = l, Vanus = v });
                    break;
                }
                catch { Console.WriteLine("Viga! Sisesta andmed uuesti."); }
            }
        }
        Console.WriteLine("Kassid: " + string.Join(", ", loomad.Where(x => x.Liik.ToLower() == "kass").Select(x => x.Nimi)));
        Console.WriteLine("Vanim: " + loomad.OrderByDescending(x => x.Vanus).First().Nimi);
    }

    public static void ValuutaKalkulaator()
    {
        var kursid = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase) { { "USD", 1.08 }, { "GBP", 0.85 } };
        while (true)
        {
            try
            {
                Console.Write("Summa (EUR): ");
                double eur = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
                Console.Write("Valuuta (USD/GBP): ");
                string v = Console.ReadLine();
                if (kursid.ContainsKey(v)) Console.WriteLine($"{eur} EUR = {eur * kursid[v]:F2} {v}");
                else Console.WriteLine("Tundmatu valuuta.");
                break;
            }
            catch { Console.WriteLine("Viga! Proovi uuesti."); }
        }
    }
}
