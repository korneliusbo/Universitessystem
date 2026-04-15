// Bruker.cs
namespace Bibliotek.Klasser;

public enum Rolle {Student, Faglærer, Bibliotekar, Administrasjon}

// Lager den abstrakte klassen bruker, som Ansatt- og Student-klassen vil arve fra
public abstract class Bruker
{
    // Egenskaper til Bruker klassen
    public string Navn  { get; set; }
    public string Epost   { get; set; }
    public Rolle Rolle { get; set; }
    public string Passord {private get; set; }
    
    public bool SjekkPassord(string Passord)
    {
        return this.Passord == Passord;
    }
    
    public List<Bok> LånteBøker { get; set; } = new List<Bok>();
    // Bruker abstract for å tvinge childs til å override og legge til beskrivelse
    public abstract void Beskriv();
}