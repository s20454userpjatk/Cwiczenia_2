namespace Cwiczenia_2;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    public bool CzyNiebezpieczny { get; set; }

    public KontenerNaPlyny(double wagaWlasna, int wysokosc, int glebokosc, double maksLadownosc, bool czyNiebezpieczny)
        : base(wagaWlasna, wysokosc, glebokosc, maksLadownosc, "L")
    {
        CzyNiebezpieczny = czyNiebezpieczny;
    }

    public override void Zaladuj(double masa)
    {
        double dozwolonaMasa = CzyNiebezpieczny ? MaksymalnaLadownosc * 0.5 : MaksymalnaLadownosc * 0.9;
        if (masa > dozwolonaMasa)
            throw new OverfillException("Próba załadowania zbyt dużej masy."); 

        MasaLadunku = masa;
    }

    public override void Oproznij()
    {
        MasaLadunku = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"UWAGA: {message} - kontener {NumerSeryjny}");
    }
}



