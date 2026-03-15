using Bibliotek.Klasser;

namespace Bibliotek.Interface;

public interface ILånbar
{
    bool LånUt(Bruker bruker);
    bool LeverInn(Bruker bruker);
    void Beskriv();
}