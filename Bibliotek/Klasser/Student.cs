namespace Bibliotek.Klasser;

// Lager klassen Student, som child av Bruker-Klassen
public class Student : Bruker
{
    /* StudentId bruker string isteden for integer for at tallet skal skrives ut med alle siffer selv om det starter på 0.
     Det gjør ikke noe for programmet siden student iden aldri vil endres og ikke skal gjøres regning med*/
    public string StudentId { get; set; }

    public List<Kurs> Kurs { get; set; } = new List<Kurs>();
    
    // Lager en kort beskrivelse av Student som kan kalles med beskriv()
    public override void Beskriv() 
    {
        string KursListe = string.Join(", ", Kurs.Select(k => k.KursName));
        Console.WriteLine($"Navn: {Navn}\nAktive kurs: {KursListe}\nEpost: {Epost}\nStudentId: {StudentId}");
    }
}
