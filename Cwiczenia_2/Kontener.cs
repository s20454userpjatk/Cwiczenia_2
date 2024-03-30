namespace Cwiczenia_2;

public abstract class Kontener
{
    private static Dictionary<string, int> numeracjaKontenerow = new Dictionary<string, int>();

    public double MasaLadunku { get; set; }
    public int Wysokosc { get; set; }
    public double WagaWlasna { get; set; }
    public int Glebokosc { get; set; }
    public string NumerSeryjny { get; set; }
    public double MaksymalnaLadownosc { get; set; }

    protected Kontener(double wagaWlasna, int wysokosc, int glebokosc, double maksLadownosc, string typKontenera)
    {
        WagaWlasna = wagaWlasna;
        Wysokosc = wysokosc;
        Glebokosc = glebokosc;
        MaksymalnaLadownosc = maksLadownosc;
        NumerSeryjny = GenerateSerialNumber(typKontenera);
    }

    private string GenerateSerialNumber(string typKontenera)
    {
        if (!numeracjaKontenerow.ContainsKey(typKontenera))
        {
            numeracjaKontenerow[typKontenera] = 0;
        }

        numeracjaKontenerow[typKontenera]++;
        return $"KON-{typKontenera}-{numeracjaKontenerow[typKontenera]}";
    }

    public abstract void Zaladuj(double masa);
    public abstract void Oproznij();
}
