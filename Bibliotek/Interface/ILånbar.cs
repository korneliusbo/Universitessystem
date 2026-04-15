// ILånbar.cs
using Bibliotek.Klasser;

namespace Bibliotek.Interface;

// Interface Lånbar
public interface ILånbar
{
    // Kontrakt egenskaper som alt som arver fra ILånbar er nødt til å bruke
    bool LånUt(Bruker bruker);
    bool LeverInn(Bruker bruker);
    void Beskriv();
}