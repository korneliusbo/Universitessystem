namespace Bibliotek.Klasser;

// Lager den abstrakte klassen bruker, som Ansatt- og Student-klassen vil arve fra
public abstract class Bruker
{
    // Properties til Bruker klassen
    public string Navn  { get; set; }
    public string Epost   { get; set; }
    public List<Bok> LånteBøker { get; set; } = new List<Bok>();
    // Bruker abstract for å tvinge childs til å override og legge til beskrivelse
    public abstract void Beskriv();
}