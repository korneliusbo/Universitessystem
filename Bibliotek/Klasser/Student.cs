//Student.cs
namespace Bibliotek.Klasser;

// Lager klassen Student, som child av Bruker-Klassen
public class Student : Bruker
{
    // Egenskaper til Student klassen
    public string StudentId { get; set; }

    public List<Kurs> Kurs { get; set; } = new List<Kurs>();
    
    // Lager en kort beskrivelse av Student som kan kalles med beskriv()
    public override void Beskriv() 
    {
        string KursListe = string.Join(", ", Kurs.Select(k => k.KursName));
        Console.WriteLine($"Navn: {Navn}\nAktive kurs: {KursListe}\nEpost: {Epost}\nStudentId: {StudentId}");
    }
}
