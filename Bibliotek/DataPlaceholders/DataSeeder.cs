using Bibliotek.Klasser;

namespace Bibliotek.DataPlaceholders;

public class DataSeeder
{
    public static List<Kurs> TestKurs()
    {
        return new List<Kurs>
        {
            new Kurs("MUS101", "Musikkproduksjon", 10, 30),
            new Kurs("ENG201", "Engelsk fordypning", 10, 25),
            new Kurs("BHG101", "Barnehagelærer", 20, 40),
            new Kurs("IS101", "Programmering", 10, 120),
            new Kurs("SPA101", "Spansk", 10, 2)
        };
    }

    public static List<Student> TestStudenter(List<Kurs> kursListe)
    {
        var s1 = new Student { Navn = "Jonathan Villanger", Epost = "jonathan.villanger@uia.no", StudentId = "000001", Passord  = "0000", Rolle = Rolle.Student };
        var s2 = new Student { Navn = "Elise Midtbø", Epost = "elise.midtboe@uia.no", StudentId = "000002", Passord  = "0000", Rolle = Rolle.Student };
        var s3 = new Student { Navn = "Harry Potte", Epost = "harrypotte@uia.no", StudentId = "000003", Passord  = "0000", Rolle = Rolle.Student };
        var s4 = new Student { Navn = "Sofie Berntsen", Epost = "sofie.berntsen@uia.no", StudentId = "000004", Passord  = "0000", Rolle = Rolle.Student };
        var s5 = new Student { Navn = "Magnus Holm", Epost = "magnus.holm@uia.no", StudentId = "000005", Passord  = "0000", Rolle = Rolle.Student };

        // Finn kursene for å legge til studenter og karakterer
        var is101 = kursListe.First(k => k.KursId == "IS101");
        var mus101 = kursListe.First(k => k.KursId == "MUS101");

        // Legg til i påmeldingslisten
        is101.Påmeldte.Add(s1);
        is101.Påmeldte.Add(s4);
        mus101.Påmeldte.Add(s2);

        // Legg kurset til i studentens egen liste
        s1.Kurs.Add(is101);
        s4.Kurs.Add(is101);
        s2.Kurs.Add(mus101);

        // --- Legg til test-karakterer ---
        is101.Karakterer.Add(s1.StudentId, "A");
        is101.Karakterer.Add(s4.StudentId, "B");
        mus101.Karakterer.Add(s2.StudentId, "C");

        return new List<Student> { s1, s2, s3, s4, s5 };
    }

    public static List<UtvekslingStudent> TestUStudent(List<Kurs> kursListe)
    {
        var us1 = new UtvekslingStudent {Navn = "Ola Normann", Epost = "olanormann@uia.no", StudentId = "000011", Passord = "0000", Rolle = Rolle.Student, Hjemuniversitet = "Uia kristiansand", Land = "Spania", PeriodeFra = new DateOnly(2025, 08, 12), PeriodeTil = new DateOnly(2026, 06, 15)};

        var spa101 = kursListe.First(k => k.KursId == "SPA101");
        spa101.Påmeldte.Add(us1);
        us1.Kurs.Add(spa101);
        
        // Legg til karakter for utvekslingsstudenten
        spa101.Karakterer.Add(us1.StudentId, "B");
        
        return new List<UtvekslingStudent> { us1 };
    }

    // Resten av metodene (TestAnsatte, TestBøker) forblir uendret...
    public static List<Ansatt> TestAnsatte() { /* Din eksisterende kode */ return new List<Ansatt>(); }
    public static List<Bok> TestBøker() { /* Din eksisterende kode */ return new List<Bok>(); }
}