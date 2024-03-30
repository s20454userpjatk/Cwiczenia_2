using Cwiczenia_2;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Kontenerowiec kontenerowiec1;
    static Kontenerowiec kontenerowiec2;

    static void Main(string[] args)
    {
        try
        {
            kontenerowiec1 = new Kontenerowiec(20, 10, 100); // Maks. prędkość: 20 węzłów, maks. liczba kontenerów: 10, maks. waga: 100 ton
            kontenerowiec2 = new Kontenerowiec(25, 15, 150);

            // Tworzenie kontenerów
            KontenerChlodniczy kontenerChlodniczy = new KontenerChlodniczy(2000, 250, 600, 10000, "Banany", -5);
            KontenerNaPlyny kontenerNaPlyny = new KontenerNaPlyny(1500, 200, 500, 8000, true);
            KontenerNaGaz kontenerNaGaz = new KontenerNaGaz(1800, 300, 700, 9000, 100);

            // Dodawanie kontenerów do kontenerowca
            kontenerowiec1.DodajKontener(kontenerChlodniczy);
            kontenerowiec1.DodajKontener(kontenerNaPlyny);
            kontenerowiec1.DodajKontener(kontenerNaGaz);
            
            //przykladowa lista kontenerow
            /*
            List<Kontener> listaKontenerow = new List<Kontener>
            {
                new KontenerChlodniczy(2000, 250, 600, 10000, "Banany", -5),
                new KontenerNaPlyny(1500, 200, 500, 8000, true),
                new KontenerNaGaz(1800, 300, 700, 9000, 100)
            };
            */
            
            // Dodawanie kontenerów za pomocą listy
            //ZaladujListeKontenerow(kontenerowiec1,listaKontenerow);
            
            // Przeniesienie kontenera z kontenerowca1 do kontenerowca2
            //PrzeniesKontener(kontenerowiec1, kontenerowiec2, "KON-C-1");
            
            // Zastąpienie kontenera na kontenerowcu
            //Kontener nowyKontener = new KontenerNaGaz(1900, 310, 710, 9200, 101);
            //ZastapKontener(kontenerowiec1, nowyKontener, "KON-G-1");
            
            
            // Załadunek kontenera
            kontenerChlodniczy.Zaladuj(350);
            kontenerNaGaz.Zaladuj(500);
            
            kontenerowiec1.WypiszInformacje();

            // Rozładunek kontenera na gaz
            kontenerowiec1.RozladujKontener(kontenerNaGaz.NumerSeryjny);

            // Usuwanie kontenera na płyny
            kontenerowiec1.UsunKontener(kontenerNaPlyny.NumerSeryjny);

            kontenerowiec1.WypiszInformacje();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }

    static void ZaladujListeKontenerow(Kontenerowiec wybranyKontenerowiec, List<Kontener> listaKontenerow)
    {
        foreach (var kontener in listaKontenerow)
        {
            try
            {
                wybranyKontenerowiec.DodajKontener(kontener);
                Console.WriteLine($"Kontener o numerze seryjnym {kontener.NumerSeryjny} został dodany do kontenerowca.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nie udało się dodać kontenera o numerze seryjnym {kontener.NumerSeryjny} do kontenerowca: {ex.Message}");
            }
        }
    }


    static void ZastapKontener(Kontenerowiec kontenerowiec ,Kontener nowyKontener, string numerDoZastapienia)
    {
        try
        {
            kontenerowiec.UsunKontener(numerDoZastapienia);
            kontenerowiec.DodajKontener(nowyKontener);
            Console.WriteLine("Kontener został zastąpiony.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nie udało się zastąpić kontenera: {ex.Message}");
        }
    }

    static void PrzeniesKontener(Kontenerowiec zKontenerowca, Kontenerowiec doKontenerowca, string numerSeryjny)
    {
        var kontenerDoPrzeniesienia = zKontenerowca.Kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
        if (kontenerDoPrzeniesienia != null)
        {
            try
            {
                zKontenerowca.UsunKontener(numerSeryjny);
                doKontenerowca.DodajKontener(kontenerDoPrzeniesienia);
                Console.WriteLine("Kontener został przeniesiony.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nie udało się przenieść kontenera: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }
    }
}

