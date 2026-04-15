// Kurs.cs
namespace Bibliotek.Klasser;

public class Kurs
{
    // Egenskaper
    public string KursId { get; set; }
    public string KursName { get; set; }
    public double Studiepoeng { get; set; }
    public int MaksPlasser { get; set; }
    public List<Student> Påmeldte { get; set; } = new List<Student>();
    
    // Pensumliste og Karakterer
    public List<Bok> Pensum { get; set; } = new List<Bok>();
    public Dictionary<string, string> Karakterer { get; set; } = new Dictionary<string, string>(); 
    // Key = StudentId, Value = Karakter (A-F)

    public string FaglærerId { get; set; } // For å sjekke hvem som underviser
    // Konstruktør
    public Kurs(string kursId, string kursName, double studiepoeng, int maksPlasser)
    {
        KursId = kursId;
        KursName = kursName;
        Studiepoeng = studiepoeng;
        MaksPlasser = maksPlasser;
    }

    public void Beskriv()
    {
        int LedigePLasser = MaksPlasser - Påmeldte.Count;
        Console.WriteLine($"Kurs ID: {KursId}, Kurs Name: {KursName}, Studiepoeng: {Studiepoeng}, Allerede påmeldt: {Påmeldte.Count}/{MaksPlasser},  Ledige PLasser: {LedigePLasser}");
    }
}