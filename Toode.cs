using System;

public class Toode
{
    public string nimi { get; set; }
    public double Kalorid100g { get; set; }
    public Toode(string nimi, double kalorid100g)
    {
        this.nimi = nimi;
        this.Kalorid100g = kalorid100g;
    }
}
