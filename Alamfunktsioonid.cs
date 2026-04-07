using System;
using System.Collections.Generic;
using System.Xml.Linq;

public static class Alamfunktsioonid
{
    //1. Kaloorite Kalkulaator
        public static void Calculator()
        {
            List<Toode> tooted = new List<Toode>();
            List<string> Toode_list = new List<string>();
            try
            {
                string ToodePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tooded.txt");
                foreach (string rida in File.ReadAllLines(ToodePath))
                {
                    Toode_list.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
            }
            foreach (string rida in Toode_list)
            {
                string[] osad = rida.Split(';');
                string nimi = osad[0];
                double kalorid100g = double.Parse(osad[1]);
                Toode toode = new Toode(nimi, kalorid100g);
                tooted.Add(toode);
            }
            List<Inimene> inimesed = new List<Inimene>();
            bool KasTootab = true;
            System.Console.WriteLine("Tere! See on kalorite kalkulaator!");
            while (KasTootab)
            {
                Console.Write("Sisesta oma nimi: ");
                string nimi = Console.ReadLine();
                Console.Write("Sisesta oma vanus: ");
                int vanus = int.Parse(Console.ReadLine());
                Console.Write("Sisesta oma sugu: ");
                string sugu = Console.ReadLine();
                Console.Write("Sisesta oma pikkus cm: ");
                int pikkus = int.Parse(Console.ReadLine());
                Console.Write("Sisesta oma kaal kg: ");
                float kaal = float.Parse(Console.ReadLine());
                Console.Write("Sisesta oma aktiivsustase (1-5): ");
                double aktiivsustase = double.Parse(Console.ReadLine());
                Inimene inimene = new Inimene(nimi, vanus, sugu, pikkus, kaal, aktiivsustase);
                inimesed.Add(inimene);
                Console.Write("Kas soovid veel ühe inimese andmeid sisestada? (jah/ei): ");
                string vastus = Console.ReadLine();
                if (vastus != "jah")
                {
                    KasTootab = false;
                }
            }
            foreach (Inimene inimene in inimesed)
            {
                double kkal = inimene.KkalArvutus();
                inimene.MituToode(tooted, kkal);
                System.Console.WriteLine("-----------------------------------");
                System.Console.WriteLine($"Fail päevase kalorite vajadusega {inimene.nimi} jaoks on loodud!");
                System.Console.WriteLine("-----------------------------------");
            }
        }
    //2.Maakonnad

    public static void MaakonnadJaPealinnad()
    {
        Dictionary<string, string> maakonnad = new Dictionary<string, string>()
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
            Console.WriteLine("1 - Leia maakond pealinna järgi");
            Console.WriteLine("2 - Leia pealinn maakonna järgi");
            Console.WriteLine("3 - Lisa uus kirje");
            Console.WriteLine("4 - Mäng");
            Console.WriteLine("0 - Tagasi");

            Console.Write("Valik: ");
            string valik = Console.ReadLine();

            switch (valik)
            {
                case "1":
                    LeiaMaakondPealinnaJargi(maakonnad);
                    break;

                case "2":
                    LeiaPealinnMaakonnaJargi(maakonnad);
                    break;

                case "3":
                    LisaKirje(maakonnad);
                    break;

                case "4":
                    Mang(maakonnad);
                    break;

                case "0":
                    return;
            }
        }
    }
    public static void LeiaMaakondPealinnaJargi(Dictionary<string, string> maakonnad)
    {
        Console.Write("Sisesta pealinn: ");
        string linn = Console.ReadLine();

        foreach (var paar in maakonnad)
        {
            if (paar.Value.ToLower() == linn.ToLower())
            {
                Console.WriteLine($"Maakond: {paar.Key}");
                return;
            }
        }

        Console.WriteLine("Ei leitud!");
    }
    public static void LeiaPealinnMaakonnaJargi(Dictionary<string, string> maakonnad)
    {
        Console.Write("Sisesta maakond: ");
        string mk = Console.ReadLine();

        if (maakonnad.ContainsKey(mk))
            Console.WriteLine($"Pealinn: {maakonnad[mk]}");
        else
            Console.WriteLine("Ei leitud!");
    }
    public static void LisaKirje(Dictionary<string, string> maakonnad)
    {
        Console.Write("Sisesta maakond: ");
        string mk = Console.ReadLine();

        Console.Write("Sisesta pealinn: ");
        string linn = Console.ReadLine();

        if (!maakonnad.ContainsKey(mk))
        {
            maakonnad.Add(mk, linn);
            Console.WriteLine("Lisatud!");
        }
        else
        {
            Console.WriteLine("Selline maakond juba olemas!");
        }
    }
    public static void Mang(Dictionary<string, string> maakonnad)
    {
        Random rnd = new Random();
        int oiged = 0;
        int kokku = 5;

        List<string> keys = new List<string>(maakonnad.Keys);

        for (int i = 0; i < kokku; i++)
        {
            int index = rnd.Next(keys.Count);
            string maakond = keys[index];

            Console.Write($"Mis on maakonna {maakond} pealinn? ");
            string vastus = Console.ReadLine();

            if (vastus.ToLower() == maakonnad[maakond].ToLower())
            {
                Console.WriteLine("Õige!");
                oiged++;
            }
            else
            {
                Console.WriteLine($"Vale! Õige vastus: {maakonnad[maakond]}");
            }
        }

        double protsent = (double)oiged / kokku * 100;
        Console.WriteLine($"Tulemus: {protsent}%");
    }


    //3. õpilased
    public static void OpilasedJaHinded()
        {
            List<Opilane> opilased = new List<Opilane>()
        {
            new Opilane("Mari", new List<int>{5,4,5}),
            new Opilane("Jaan", new List<int>{3,4,2}),
            new Opilane("Kati", new List<int>{5,5,5})
        };

            double maxKeskmine = 0;
            string parim = "";

            foreach (var o in opilased)
            {
                double keskmine = o.Hinded.Average();
                Console.WriteLine($"{o.Nimi} keskmine: {keskmine}");

                if (keskmine > maxKeskmine)
                {
                    maxKeskmine = keskmine;
                    parim = o.Nimi;
                }
            }

            Console.WriteLine($"Parim õpilane: {parim}");

            var sorted = opilased.OrderByDescending(o => o.Hinded.Average());
            Console.WriteLine("Sorteeritud:");
            foreach (var o in sorted)
                Console.WriteLine(o.Nimi);
        }

        //4. filmidekogu
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

            Console.Write("Sisesta žanr: ");
            string zanr = Console.ReadLine();

            var tulem = filmid.Where(f => f.Zanr == zanr);

            Console.WriteLine("Leitud filmid:");
            foreach (var f in tulem)
                Console.WriteLine(f.Pealkiri);

            var uusim = filmid.OrderByDescending(f => f.Aasta).First();
            Console.WriteLine($"Uusim film: {uusim.Pealkiri}");

            var grupp = filmid.GroupBy(f => f.Zanr);

            foreach (var g in grupp)
            {
                Console.WriteLine($"Žanr: {g.Key}");
                foreach (var f in g)
                    Console.WriteLine(" - " + f.Pealkiri);
            }
        }


        //5. massiiv
        public static void MassiiviStatistika()
        {
            Console.Write("Sisesta arvud (tühikuga): ");
            string input = Console.ReadLine();

            double[] arvud = input.Split(' ').Select(double.Parse).ToArray();

            double max = arvud.Max();
            double min = arvud.Min();
            double sum = arvud.Sum();
            double avg = arvud.Average();

            int suuremad = arvud.Count(x => x > avg);

            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Summa: {sum}");
            Console.WriteLine($"Keskmine: {avg}");
            Console.WriteLine($"Suuremad kui keskmine: {suuremad}");

            Array.Sort(arvud);
            Console.WriteLine("Sorteeritud:");
            foreach (var a in arvud)
                Console.WriteLine(a);
        }

        //6. Lemmikloomad
        public static void Lemmikloomad()
        {
            List<Lemmikloom> loomad = new List<Lemmikloom>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Nimi: ");
                string nimi = Console.ReadLine();

                Console.Write("Liik: ");
                string liik = Console.ReadLine();

                Console.Write("Vanus: ");
                int vanus = int.Parse(Console.ReadLine());

                loomad.Add(new Lemmikloom(nimi, liik, vanus));
            }

            Console.WriteLine("Kassid:");
            foreach (var l in loomad.Where(x => x.Liik.ToLower() == "kass"))
                Console.WriteLine(l.Nimi);

            Console.WriteLine($"Keskmine vanus: {loomad.Average(x => x.Vanus)}");

            var vanim = loomad.OrderByDescending(x => x.Vanus).First();
            Console.WriteLine($"Vanim: {vanim.Nimi}");
        }

        //7. valuuta
        public static void ValuutaKalkulaator()
        {
            Dictionary<string, Valuuta> valuutad = new Dictionary<string, Valuuta>()
        {
            {"USD", new Valuuta("USD", 1.1)},
            {"GBP", new Valuuta("GBP", 0.85)},
            {"JPY", new Valuuta("JPY", 130)}
        };

            Console.Write("Sisesta summa: ");
            double summa = double.Parse(Console.ReadLine());

            Console.Write("Sisesta valuuta (USD/GBP/JPY): ");
            string val = Console.ReadLine().ToUpper();

            if (valuutad.ContainsKey(val))
            {
                double eur = summa / valuutad[val].Kurss;
                Console.WriteLine($"EUR: {eur}");

                double tagasi = eur * valuutad[val].Kurss;
                Console.WriteLine($"Tagasi {val}: {tagasi}");
            }
            else
            {
                Console.WriteLine("Valuutat ei leitud!");
            }
        }
    }


    public class Opilane
    {
        public string Nimi;
        public List<int> Hinded;

        public Opilane(string nimi, List<int> hinded)
        {
            Nimi = nimi;
            Hinded = hinded;
        }
    }

    public class Film
    {
        public string Pealkiri;
        public int Aasta;
        public string Zanr;

        public Film(string p, int a, string z)
        {
            Pealkiri = p;
            Aasta = a;
            Zanr = z;
        }
    }

    public class Lemmikloom
    {
        public string Nimi;
        public string Liik;
        public int Vanus;

        public Lemmikloom(string n, string l, int v)
        {
            Nimi = n;
            Liik = l;
            Vanus = v;
        }
    }

    public class Valuuta
    {
        public string Nimi;
        public double Kurss;

        public Valuuta(string n, double k)
        {
            Nimi = n;
            Kurss = k;
        }
    }

public class Inimene
{
    public string nimi { get; set; }
    public int vanus { get; set; }
    public string sugu { get; set; }
    public int pikkus { get; set; }
    public float kaal { get; set; }
    public double aktiivsustase { get; set; }

    public Inimene(string nimi, int vanus, string sugu, int pikkus, float kaal, double aktiivsustase)
    {
        this.nimi = nimi;
        this.vanus = vanus;
        this.sugu = sugu;
        this.pikkus = pikkus;
        this.kaal = kaal;
        switch (aktiivsustase)
        {
            case 1: aktiivsustase = 1.2; break;
            case 2: aktiivsustase = 1.375; break;
            case 3: aktiivsustase = 1.55; break;
            case 4: aktiivsustase = 1.725; break;
            case 5: aktiivsustase = 1.9; break;
        }
    }

    public double KkalArvutus()
    {
        bool a = true;
        double kkal = 0;
            if (sugu.ToLower() == "mees")
            {
                kkal = 88.362 + (13.397 * kaal) + (4.799 * pikkus) - (5.677 * vanus);
            }
            else if (sugu == "naine")
            {
                kkal = 447.593 + (9.247 * kaal) + (3.098 * pikkus) - (4.330 * vanus);
            }
            else
            {
                Console.WriteLine("Kirjuta oma sugu");
            }
        

            kkal *= aktiivsustase;
            Console.WriteLine($"{nimi} päevane kalorite vajadus on: {kkal} kcal");
            return kkal;
        }
        
    
    public void MituToode(List<Toode> toodes, double kkal)
    {
        foreach (Toode toode in toodes)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{nimi}_tooded.txt");
            double grammid = Math.Round(kkal / toode.Kalorid100g * 100, 2);
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine($"{toode.nimi}: {grammid} g");
            file.Close();
        }
    }

    public class Lemmikloom
    {
        public string Nimi { get; set; }
        public string Liik { get; set; }
        public int Vanus { get; set; }

        public Lemmikloom(string nimi, string liik, int vanus)
        {
            Nimi = nimi;
            Liik = liik;
            Vanus = vanus;
        }
    }
}
