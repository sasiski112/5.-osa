using System;

public class Toode
{
    public string nimi { get; set; }
    public double Kalorid100g { get; set; }
    public Toode(string n, double k) { nimi = n; Kalorid100g = k; }
}

public class Inimene
{
    public string nimi { get; set; }
    public int vanus { get; set; }
    public string sugu { get; set; }
    public int pikkus { get; set; }
    public float kaal { get; set; }
    public double aktiivsustase { get; set; }

    public Inimene(string nimi, int vanus, string sugu, int pikkus, float kaal, double tase)
    {
        this.nimi = nimi;
        this.vanus = vanus;
        this.sugu = sugu;
        this.pikkus = pikkus;
        this.kaal = kaal;
        // Aktiivsustaseme määramine
        this.aktiivsustase = tase switch
        {
            1 => 1.2,
            2 => 1.375,
            3 => 1.55,
            4 => 1.725,
            5 => 1.9,
            _ => 1.2
        };
    }

    public double KkalArvutus()
    {
        double kkal = (sugu == "mees")
            ? 88.362 + (13.397 * kaal) + (4.799 * pikkus) - (5.677 * vanus)
            : 447.593 + (9.247 * kaal) + (3.098 * pikkus) - (4.330 * vanus);

        kkal *= aktiivsustase;
        Console.WriteLine($"{nimi} päevane kalorite vajadus on: {Math.Round(kkal, 2)} kcal");
        return kkal;
    }

    public void MituToode(List<Toode> toodes, double kkal)
    {
        if (toodes.Count == 0) return;
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{nimi}_tooded.txt");
        try
        {
            using (StreamWriter file = new StreamWriter(path, false))
            {
                foreach (Toode t in toodes)
                {
                    if (t.Kalorid100g > 0)
                    {
                        double grammid = Math.Round(kkal / t.Kalorid100g * 100, 2);
                        file.WriteLine($"{t.nimi}: {grammid} g");
                    }
                }
            }
        }
        catch (Exception ex) { Console.WriteLine("Viga faili kirjutamisel: " + ex.Message); }
    }
}
public class Opilane
{
    public string Nimi { get; set; }
    public List<int> Hinded { get; set; }
    public Opilane(string n, List<int> h) { Nimi = n; Hinded = h; }
}

public class Film
{
    public string Pealkiri { get; set; }
    public int Aasta { get; set; }
    public string Zanr { get; set; }
    public Film(string p, int a, string z) { Pealkiri = p; Aasta = a; Zanr = z; }
}

public class Lemmikloom
{
    public string Nimi { get; set; }
    public string Liik { get; set; }
    public int Vanus { get; set; }
    public Lemmikloom(string n, string l, int v) { Nimi = n; Liik = l; Vanus = v; }
}

public class Valuuta
{
    public string Nimi { get; set; }
    public double Kurss { get; set; }
    public Valuuta(string n, double k) { Nimi = n; Kurss = k; }
}
