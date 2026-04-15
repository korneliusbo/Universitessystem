// Bok.cs
using Bibliotek.Interface;

namespace Bibliotek.Klasser;

// Setter Bok.cs som child av ILånbar Interface
public class Bok : ILånbar
{
    // Egenskaper til bok
    public string Tittel { get; set; }
    public string Forfatter { get; set; }
    public int ErTilgjengelig { get; set; }
    public int ErUtlånt  { get; set; }
    public string Isbn { get; set; }

    /* Regner ut summen av Eksemplarer tilgjengelig og utlånt for å vite hvor mange kopier man skal ha.
     "=>" gjør at utregningen skjer hver gang man kaller et objekt i klassen istedenfor før objektet skal brukes*/
    public int Eksemplarer => ErTilgjengelig + ErUtlånt;
    
    // Hvordan det skal se ut hvis Beskriv() funksjonen blir kalt
    public void Beskriv()
    {
        Console.WriteLine($"Tittel: {Tittel}\n  Forfatter: {Forfatter}\n  Antall eksemplarer i Systemet: {Eksemplarer}\n  Antall tilgjengelige: {ErTilgjengelig}\n  Antall utlånt: {ErUtlånt}\n  ISBN: {Isbn}");

    }

    
    
    // Funksjon for å låne ut bok fra biblioteket. Trekker fra 1 fra ErTilgjengelig og legger til 1 i ErUtlånt
    
    // har bruker objekt som parameter
    public bool LånUt(Bruker bruker)
    {
        if (ErTilgjengelig > 0)
        {
            ErTilgjengelig--;
            ErUtlånt++;
            Console.WriteLine($"Suksess: {bruker.Navn} har lånt {Tittel}");
            return true;
        }
        Console.WriteLine($"Feilmelding: Det er desverre ikke flere eksemplarer av {Tittel}!");
        return false;
    }

    // Gjør det samme som lån ut funksjonen bare motsatt
    public bool LeverInn(Bruker bruker)
    {
        if (ErUtlånt > 0)
        {
            ErTilgjengelig++;
            ErUtlånt--;
            Console.WriteLine($"Suksess: {bruker.Navn} har levert tilbake {Tittel}!");
            return true;
        }
        else
        {
            Console.WriteLine($"Feilmelding: Vi har ikke registrert at {Tittel} er utlånt. Vennligst ta kontakt med betjening.");
            return false;
        }
    }
}