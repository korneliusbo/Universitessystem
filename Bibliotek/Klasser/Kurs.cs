namespace Bibliotek.Klasser;

public class Kurs
{
    // Egenskaper
    public string KursId { get; set; }
    public string KursName { get; set; }
    public double Studiepoeng { get; set; }
    public int MaksPlasser { get; set; }
    public List<Student> Påmeldte { get; set; } = new List<Student>();
    
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