namespace Cwiczenia_2;

public class KontenerChlodniczy : Kontener
{
    public string RodzajProduktu { get; set; }
    public double Temperatura { get; set; }

    public KontenerChlodniczy(double wagaWlasna, int wysokosc, int glebokosc, double maksLadownosc, string rodzajProduktu, double temperatura)
        : base(wagaWlasna, wysokosc, glebokosc, maksLadownosc, "C")
    {
        RodzajProduktu = rodzajProduktu;
        Temperatura = temperatura;
    }

    public override void Zaladuj(double masa)
    {
        if (masa > MaksymalnaLadownosc)
            throw new OverfillException("Próba załadowania zbyt dużej masy.");
    
        MasaLadunku = masa;
    }

    public override void Oproznij()
    {
        MasaLadunku = 0;
    }
}



