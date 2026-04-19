using System;
using System.Collections.Generic;
using System.Linq;

public class Toode
{
    public string Nimi { get; set; }
    public double Hind { get; set; }
    public double Kalorid100g { get; set; }
}

public class Inimene
{
    public string Nimi { get; set; }
    public int Vanus { get; set; }
    public string Sugu { get; set; }
    public double Pikkus { get; set; }
    public double Kaal { get; set; }
    public double AktiivsusTase { get; set; }
}

public class Opilane
{
    public string Nimi { get; set; }
    public List<int> Hinded { get; set; }
    public double Keskmine => Hinded.Count > 0 ? Hinded.Average() : 0;
}

public class Film
{
    public string Pealkiri { get; set; }
    public int Aasta { get; set; }
    public string Zanr { get; set; }
}

public class Lemmikloom
{
    public string Nimi { get; set; }
    public string Liik { get; set; }
    public int Vanus { get; set; }
}
