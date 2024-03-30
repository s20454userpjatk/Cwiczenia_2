namespace Cwiczenia_2;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    public double Cisnienie { get; set; }

    public KontenerNaGaz(double wagaWlasna, int wysokosc, int glebokosc, double maksLadownosc, double cisnienie)
        : base(wagaWlasna, wysokosc, glebokosc, maksLadownosc, "G")
    {
        Cisnienie = cisnienie;
    }

    public override void Zaladuj(double masa)
    {
        if (masa > MaksymalnaLadownosc)
            throw new OverfillException("Próba załadowania zbyt dużej masy."); 

        MasaLadunku = masa;
    }

    public override void Oproznij()
    {
        // Pozostaw 5% ładunku
        MasaLadunku *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"UWAGA: {message} - kontener {NumerSeryjny}");
    }
}
