namespace Cwiczenia_2;

public class Kontenerowiec
{
    public List<Kontener> Kontenery { get; set; } = new List<Kontener>();
    public double MaksymalnaPredkosc { get; set; }
    public int MaksymalnaLiczbaKontenerow { get; set; }
    public double MaksymalnaWaga { get; set; } // w tonach

    public Kontenerowiec(double maksPredkosc, int maksLiczba, double maksWaga)
    {
        MaksymalnaPredkosc = maksPredkosc;
        MaksymalnaLiczbaKontenerow = maksLiczba;
        MaksymalnaWaga = maksWaga;
    }

    public void DodajKontener(Kontener kontener)
    {
        if (Kontenery.Count >= MaksymalnaLiczbaKontenerow)
        {
            throw new Exception("Osiągnięto maksymalną liczbę kontenerów!");
        }

        double obecnaWaga = Kontenery.Sum(k => k.MasaLadunku + k.WagaWlasna);
        if (obecnaWaga + kontener.MasaLadunku + kontener.WagaWlasna > MaksymalnaWaga * 1000)
        {
            throw new Exception("Przekroczenie maksymalnej wagi kontenerowca!");
        }
        
        Kontenery.Add(kontener);
    }
    
    public void UsunKontener(string numerSeryjny)
    {
        var kontener = Kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
        if (kontener != null)
        {
            Kontenery.Remove(kontener);
        }
        else
        {
            throw new Exception($"Nie znaleziono kontenera o numerze seryjnym: {numerSeryjny}");
        }
    }

    public void RozladujKontener(string numerSeryjny)
    {
        var kontener = Kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
        if (kontener != null)
        {
            kontener.Oproznij();
        }
        else
        {
            throw new Exception($"Nie znaleziono kontenera o numerze seryjnym: {numerSeryjny}");
        }
    }

    public void WypiszInformacje()
    {
        Console.WriteLine($"Kontenerowiec: Maks. prędkość: {MaksymalnaPredkosc} węzłów, Maks. liczba kontenerów: {MaksymalnaLiczbaKontenerow}, Maks. waga: {MaksymalnaWaga} ton");
        foreach (var kontener in Kontenery)
        {
            Console.WriteLine($"Kontener: Numer seryjny: {kontener.NumerSeryjny}, Masa ładunku: {kontener.MasaLadunku}kg, Wysokość: {kontener.Wysokosc}cm, Głębokość: {kontener.Glebokosc}cm, Waga własna: {kontener.WagaWlasna}kg");
        }
    }
    
    
    
}