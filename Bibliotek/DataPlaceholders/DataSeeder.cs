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
        var s1 = new Student
        {
            Navn = "Jonathan Villanger", Epost = "jonathan.villanger@uia.no", StudentId = "000001", Passord = "0000",
            Rolle = Rolle.Student
        };
        var s2 = new Student
        {
            Navn = "Elise Midtbø", Epost = "elise.midtboe@uia.no", StudentId = "000002", Passord = "0000",
            Rolle = Rolle.Student
        };
        var s3 = new Student
        {
            Navn = "Harry Potte", Epost = "harrypotte@uia.no", StudentId = "000003", Passord = "0000",
            Rolle = Rolle.Student
        };
        var s4 = new Student
        {
            Navn = "Sofie Berntsen", Epost = "sofie.berntsen@uia.no", StudentId = "000004", Passord = "0000",
            Rolle = Rolle.Student
        };
        var s5 = new Student
        {
            Navn = "Magnus Holm", Epost = "magnus.holm@uia.no", StudentId = "000005", Passord = "0000",
            Rolle = Rolle.Student
        };

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
        var us1 = new UtvekslingStudent
        {
            Navn = "Ola Normann", Epost = "olanormann@uia.no", StudentId = "000011", Passord = "0000",
            Rolle = Rolle.Student, Hjemuniversitet = "Uia kristiansand", Land = "Spania",
            PeriodeFra = new DateOnly(2025, 08, 12), PeriodeTil = new DateOnly(2026, 06, 15)
        };

        var spa101 = kursListe.First(k => k.KursId == "SPA101");
        spa101.Påmeldte.Add(us1);
        us1.Kurs.Add(spa101);

        // Legg til karakter for utvekslingsstudenten
        spa101.Karakterer.Add(us1.StudentId, "B");

        return new List<UtvekslingStudent> { us1 };
    }

    public static List<Ansatt> TestAnsatte()
    {
        return new List<Ansatt>
        {
            new Ansatt
            {
                Navn = "Kåre Lerkedal", Epost = "kare.lerkedal@uia.no", Avdeling = "Bibliotek",
                Stilling = "Bibliotekar", AnsattId = "102410"
            },
            new Ansatt
            {
                Navn = "Hilde Nygård", Epost = "hilde.nygaard@uia.no", Avdeling = "Administrasjon",
                Stilling = "Studieveileder", AnsattId = "102411"
            },
            new Ansatt
            {
                Navn = "Per Olsen", Epost = "per.olsen@uia.no", Avdeling = "IT", Stilling = "Foreleser",
                AnsattId = "102412"
            },
            new Ansatt
            {
                Navn = "Silje Haugen", Epost = "silje.haugen@uia.no", Avdeling = "Økonomi", Stilling = "Administrasjon",
                AnsattId = "102413"
            },
            new Ansatt
            {
                Navn = "Bjørn Kristiansen", Epost = "bjorn.kristiansen@uia.no", Avdeling = "Bibliotek",
                Stilling = "Bibliotekar", AnsattId = "102414"
            },
        };
    }

    public static List<Bok> TestBøker()
    {
        return new List<Bok>
        {
            new Bok
            {
                Tittel = "1984", Forfatter = "George Orwell", ErTilgjengelig = 2, ErUtlånt = 1, Isbn = "9788205508163"
            },
            new Bok
            {
                Tittel = "Lord of the Rings", Forfatter = "J.R.R. Tolkien", ErTilgjengelig = 2, ErUtlånt = 0,
                Isbn = "9780395974681"
            },
            new Bok
            {
                Tittel = "Pippi Langstrømpe", Forfatter = "Astrid Lindgren", ErTilgjengelig = 2, ErUtlånt = 32,
                Isbn = "9172253371"
            },
            new Bok
            {
                Tittel = "Harry Potter og de vises stein", Forfatter = "J.K. Rowling", ErTilgjengelig = 3, ErUtlånt = 1,
                Isbn = "9788202256098"
            },
            new Bok
            {
                Tittel = "The Great Gatsby", Forfatter = "F. Scott Fitzgerald", ErTilgjengelig = 2, ErUtlånt = 0,
                Isbn = "9780743273565"
            },
            new Bok
            {
                Tittel = "To Kill a Mockingbird", Forfatter = "Harper Lee", ErTilgjengelig = 2, ErUtlånt = 2,
                Isbn = "9780061935466"
            },
            new Bok
            {
                Tittel = "Sofies verden", Forfatter = "Jostein Gaarder", ErTilgjengelig = 4, ErUtlånt = 1,
                Isbn = "9788202419387"
            },
            new Bok
            {
                Tittel = "Dune", Forfatter = "Frank Herbert", ErTilgjengelig = 2, ErUtlånt = 1, Isbn = "9780441013593"
            },
            new Bok
            {
                Tittel = "Brave New World", Forfatter = "Aldous Huxley", ErTilgjengelig = 1, ErUtlånt = 1,
                Isbn = "9780060850524"
            },
            new Bok
            {
                Tittel = "Hamsun - Sult", Forfatter = "Knut Hamsun", ErTilgjengelig = 3, ErUtlånt = 0,
                Isbn = "9788205306271"
            },
            new Bok
            {
                Tittel = "Crime and Punishment", Forfatter = "Fyodor Dostoevsky", ErTilgjengelig = 2, ErUtlånt = 1,
                Isbn = "9780143107637"
            },
            new Bok
            {
                Tittel = "The Hitchhiker's Guide to the Galaxy", Forfatter = "Douglas Adams", ErTilgjengelig = 3,
                ErUtlånt = 2, Isbn = "9780345391803"
            },
            new Bok
            {
                Tittel = "Ibsen - Et dukkehjem", Forfatter = "Henrik Ibsen", ErTilgjengelig = 2, ErUtlånt = 0,
                Isbn = "9788202419394"
            },
        };
    }
}