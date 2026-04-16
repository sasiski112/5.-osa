using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Alamfunktsioonid
{
    // --- 1. KALOORITE KALKULAATOR ---
    public static void Calculator()
    {
        List<Toode> tooted = new List<Toode>();
        string toodePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tooded.txt");

        // Faili lugemise kontroll
        if (File.Exists(toodePath))
        {
            try
            {
                foreach (string rida in File.ReadAllLines(toodePath))
                {
                    if (string.IsNullOrWhiteSpace(rida)) continue;
                    string[] osad = rida.Split(';');
                    if (osad.Length >= 2 && double.TryParse(osad[1], out double kal))
                    {
                        tooted.Add(new Toode(osad[0], kal));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Viga faili lugemisel: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Hoiatus: Faili 'Tooded.txt' ei leitud. Toodete nimekirja ei koostata.");
        }

        List<Inimene> inimesed = new List<Inimene>();
        bool kasTootab = true;

        Console.WriteLine("=== Kalorite kalkulaator ===");

        while (kasTootab)
        {
            Console.Write("Sisesta oma nimi: ");
            string nimi = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nimi))
            {
                Console.Write("Nimi ei tohi olla tühi! Sisesta uuesti: ");
                nimi = Console.ReadLine();
            }

            int vanus = LoeInt("Sisesta oma vanus: ", 1, 120);

            Console.Write("Sisesta oma sugu (mees/naine): ");
            string sugu = Console.ReadLine()?.ToLower();
            while (sugu != "mees" && sugu != "naine")
            {
                Console.Write("Vigane sisend! Kirjuta 'mees' või 'naine': ");
                sugu = Console.ReadLine()?.ToLower();
            }

            int pikkus = LoeInt("Sisesta oma pikkus cm: ", 50, 250);
            float kaal = LoeFloat("Sisesta oma kaal kg: ", 10, 300);
            double aktiivsus = LoeDouble("Sisesta aktiivsustase (1-5): ", 1, 5);

            inimesed.Add(new Inimene(nimi, vanus, sugu, pikkus, kaal, aktiivsus));

            Console.Write("Kas soovid veel ühe inimese andmeid sisestada? (jah/ei): ");
            kasTootab = Console.ReadLine()?.ToLower() == "jah";
        }

        foreach (Inimene i in inimesed)
        {
            double kkal = i.KkalArvutus();
            i.MituToode(tooted, kkal);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Fail päevase kalorite vajadusega {i.nimi} jaoks on loodud!");
            Console.WriteLine("-----------------------------------");
        }
    }

    // --- 2. MAAKONNAD JA PEALINNAD ---
    public static void MaakonnadJaPealinnad()
    {
        Dictionary<string, string> maakonnad = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"Harjumaa", "Tallinn"},
            {"Tartumaa", "Tartu"},
            {"Pärnumaa", "Pärnu"},
            {"Ida-Virumaa", "Jõhvi"},
            {"Läänemaa", "Haapsalu"}
        };

        while (true)
        {
            Console.WriteLine("\n--- MAAKONNAD ---");
            Console.WriteLine("1 - Leia maakond pealinna järgi\n2 - Leia pealinn maakonna järgi\n3 - Lisa uus kirje\n4 - Mäng\n0 - Tagasi");
            Console.Write("Valik: ");
            string valik = Console.ReadLine();

            if (valik == "0") break;

            switch (valik)
            {
                case "1":
                    Console.Write("Sisesta pealinn: ");
                    string linn = Console.ReadLine();
                    var m = maakonnad.FirstOrDefault(x => x.Value.Equals(linn, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine(m.Key != null ? $"Maakond: {m.Key}" : "Ei leitud!");
                    break;
                case "2":
                    Console.Write("Sisesta maakond: ");
                    string mk = Console.ReadLine();
                    if (maakonnad.TryGetValue(mk, out string p)) Console.WriteLine($"Pealinn: {p}");
                    else Console.WriteLine("Ei leitud!");
                    break;
                case "3":
                    Console.Write("Uus maakond: ");
                    string uusM = Console.ReadLine();
                    Console.Write("Uus pealinn: ");
                    string uusL = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(uusM) && !maakonnad.ContainsKey(uusM))
                    {
                        maakonnad.Add(uusM, uusL);
                        Console.WriteLine("Lisatud!");
                    }
                    break;
                case "4":
                    Mang(maakonnad);
                    break;
            }
        }
    }

    private static void Mang(Dictionary<string, string> maakonnad)
    {
        Random rnd = new Random();
        var keys = maakonnad.Keys.ToList();
        int oiged = 0;
        int kordi = Math.Min(5, keys.Count);

        for (int i = 0; i < kordi; i++)
        {
            string maakond = keys[rnd.Next(keys.Count)];
            Console.Write($"Mis on maakonna {maakond} pealinn? ");
            if (Console.ReadLine().Trim().Equals(maakonnad[maakond], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Õige!");
                oiged++;
            }
            else Console.WriteLine($"Vale! Õige on {maakonnad[maakond]}");
        }
        Console.WriteLine($"Tulemus: {(double)oiged / kordi * 100}%");
    }

    // --- ABIFUNKTSIOONID SISENDI KONTROLLIKS ---
    private static int LoeInt(string tekst, int min, int max)
    {
        int tulemus;
        while (true)
        {
            Console.Write(tekst);
            if (int.TryParse(Console.ReadLine(), out tulemus) && tulemus >= min && tulemus <= max) return tulemus;
            Console.WriteLine($"Viga! Sisesta arv vahemikus {min}-{max}.");
        }
    }

    private static float LoeFloat(string tekst, float min, float max)
    {
        float tulemus;
        while (true)
        {
            Console.Write(tekst);
            if (float.TryParse(Console.ReadLine(), out tulemus) && tulemus >= min && tulemus <= max) return tulemus;
            Console.WriteLine($"Viga! Sisesta number vahemikus {min}-{max}.");
        }
    }

    private static double LoeDouble(string tekst, double min, double max)
    {
        double tulemus;
        while (true)
        {
            Console.Write(tekst);
            if (double.TryParse(Console.ReadLine(), out tulemus) && tulemus >= min && tulemus <= max) return tulemus;
            Console.WriteLine($"Viga! Sisesta number vahemikus {min}-{max}.");
        }
    }
    // --- 3. ÕPILASED JA HINDED ---
    public static void OpilasedJaHinded()
    {
        // Kasutame kontrollitud andmeid
        List<Opilane> opilased = new List<Opilane>()
        {
            new Opilane("Mari", new List<int>{5, 4, 5}),
            new Opilane("Jaan", new List<int>{3, 4, 2}),
            new Opilane("Kati", new List<int>{5, 5, 5})
        };

        if (opilased.Count == 0) return;

        double maxKeskmine = -1;
        string parim = "";

        Console.WriteLine("\n--- Õpilaste tulemused ---");
        foreach (var o in opilased)
        {
            // Kontrollime, et hinded poleks tühjad, et vältida viga Average() arvutamisel
            if (o.Hinded != null && o.Hinded.Count > 0)
            {
                double keskmine = Math.Round(o.Hinded.Average(), 2);
                Console.WriteLine($"{o.Nimi} keskmine hinne: {keskmine}");

                if (keskmine > maxKeskmine)
                {
                    maxKeskmine = keskmine;
                    parim = o.Nimi;
                }
            }
        }

        Console.WriteLine($"\nParim õpilane: {parim} (keskmine {maxKeskmine})");

        // Sorteerimine kontrolliga
        var sorted = opilased.OrderByDescending(o => o.Hinded.Any() ? o.Hinded.Average() : 0);
        Console.WriteLine("\nEdetabel:");
        foreach (var o in sorted)
            Console.WriteLine($"- {o.Nimi}");
    }

    // --- 4. FILMIDEKOGU ---
    public static void FilmideKogu()
    {
        List<Film> filmid = new List<Film>()
        {
            new Film("Matrix", 1999, "Sci-Fi"),
            new Film("Titanic", 1997, "Romance"),
            new Film("Avengers", 2019, "Action"),
            new Film("Inception", 2010, "Sci-Fi"),
            new Film("Frozen", 2013, "Animation")
        };

        Console.Write("\nSisesta otsitav žanr: ");
        string zanr = Console.ReadLine();

        // Tõstutundetu otsing
        var tulem = filmid.Where(f => f.Zanr.Equals(zanr, StringComparison.OrdinalIgnoreCase)).ToList();

        if (tulem.Any())
        {
            Console.WriteLine($"Leitud {zanr} filmid:");
            foreach (var f in tulem) Console.WriteLine($" - {f.Pealkiri} ({f.Aasta})");
        }
        else Console.WriteLine("Selles žanris filme ei leitud.");

        // Uusima filmi leidmine kontrolliga
        if (filmid.Any())
        {
            var uusim = filmid.OrderByDescending(f => f.Aasta).First();
            Console.WriteLine($"\nUusim film kogus: {uusim.Pealkiri} ({uusim.Aasta})");
        }

        // Grupeerimine
        Console.WriteLine("\nFilmid žanrite kaupa:");
        var grupid = filmid.GroupBy(f => f.Zanr);
        foreach (var g in grupid)
        {
            Console.WriteLine($"[{g.Key}]");
            foreach (var f in g) Console.WriteLine($"  * {f.Pealkiri}");
        }
    }

    // --- 5. MASSIIVI STATISTIKA ---
    public static void MassiiviStatistika()
    {
        double[] arvud;
        while (true)
        {
            Console.Write("\nSisesta arvud (eralda tühikuga): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) continue;

            string[] osad = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            arvud = new double[osad.Length];
            bool koikOk = true;

            for (int i = 0; i < osad.Length; i++)
            {
                if (!double.TryParse(osad[i].Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out arvud[i]))
                {
                    Console.WriteLine($"Vigane arv: {osad[i]}");
                    koikOk = false;
                    break;
                }
            }

            if (koikOk && arvud.Length > 0) break;
            Console.WriteLine("Sisesta vähemalt üks korrektne number.");
        }

        Console.WriteLine($"\nMax: {arvud.Max()}");
        Console.WriteLine($"Min: {arvud.Min()}");
        Console.WriteLine($"Summa: {arvud.Sum()}");
        Console.WriteLine($"Keskmine: {Math.Round(arvud.Average(), 2)}");

        double avg = arvud.Average();
        Console.WriteLine($"Arve, mis on suuremad kui keskmine: {arvud.Count(x => x > avg)}");

        Array.Sort(arvud);
        Console.WriteLine("Sorteeritud jada: " + string.Join(", ", arvud));
    }

    // --- 6. LEMMIKLOOMAD ---
    public static void Lemmikloomad()
    {
        List<Lemmikloom> loomad = new List<Lemmikloom>();
        Console.WriteLine("\n--- Lemmikloomade sisestamine (5 looma) ---");

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\nLoom nr {i + 1}:");
            Console.Write("Nimi: ");
            string nimi = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nimi)) { Console.Write("Nimi uuesti: "); nimi = Console.ReadLine(); }

            Console.Write("Liik (nt kass, koer): ");
            string liik = Console.ReadLine();

            int vanus;
            while (true)
            {
                Console.Write("Vanus: ");
                if (int.TryParse(Console.ReadLine(), out vanus) && vanus >= 0) break;
                Console.Write("Vigane vanus! ");
            }

            loomad.Add(new Lemmikloom(nimi, liik, vanus));
        }

        // Kasside filtreerimine (tõstutundetu)
        var kassid = loomad.Where(x => x.Liik.Equals("kass", StringComparison.OrdinalIgnoreCase)).ToList();
        Console.WriteLine("\nKõik nimekirjas olevad kassid:");
        if (kassid.Any()) foreach (var k in kassid) Console.WriteLine("- " + k.Nimi);
        else Console.WriteLine("Kasse ei leitud.");

        Console.WriteLine($"\nLoomade keskmine vanus: {Math.Round(loomad.Average(x => x.Vanus), 1)}");

        var vanim = loomad.OrderByDescending(x => x.Vanus).First();
        Console.WriteLine($"Vanim loom: {vanim.Nimi} ({vanim.Vanus} a.)");
    }

    // --- 7. VALUUTA KALKULAATOR ---
    public static void ValuutaKalkulaator()
    {
        Dictionary<string, Valuuta> valuutad = new Dictionary<string, Valuuta>(StringComparer.OrdinalIgnoreCase)
        {
            {"USD", new Valuuta("USD", 1.08)},
            {"GBP", new Valuuta("GBP", 0.86)},
            {"JPY", new Valuuta("JPY", 162.5)}
        };

        double summa;
        while (true)
        {
            Console.Write("\nSisesta summa: ");
            if (double.TryParse(Console.ReadLine(), out summa) && summa >= 0) break;
            Console.WriteLine("Vigane summa!");
        }

        Console.WriteLine("Valikud: USD, GBP, JPY");
        string val;
        while (true)
        {
            Console.Write("Vali valuuta: ");
            val = Console.ReadLine();
            if (valuutad.ContainsKey(val)) break;
            Console.WriteLine("Seda valuutat pole nimekirjas.");
        }

        double kurss = valuutad[val].Kurss;
        double eur = Math.Round(summa / kurss, 2);
        Console.WriteLine($"\n{summa} {val.ToUpper()} = {eur} EUR");

        // Kontrollarvutus tagasi
        Console.WriteLine($"Tagasi arvutatuna: {Math.Round(eur * kurss, 2)} {val.ToUpper()}");
    }
}



