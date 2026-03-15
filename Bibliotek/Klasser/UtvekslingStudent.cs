namespace Bibliotek.Klasser;

public class UtvekslingStudent : Student
{
    public string Hjemuniversitet { get; set; }
    public string Land { get; set; }
    public DateOnly PeriodeFra { get; set; }
    public DateOnly PeriodeTil { get; set; }

    public override void Beskriv()
    {
        string UKursListe = string.Join(", ", Kurs.Select(k => k.KursName));
        Console.WriteLine($"Navn: {Navn}\nAktive kurs: {UKursListe}\nEpost: {Epost}\nStudentId: {StudentId}\nHjemuniversitet: {Hjemuniversitet}, {Land}\nOpphold: ({PeriodeFra:dd.MM.yyyy} - {PeriodeTil:dd.MM.yyyy})");
    }
}