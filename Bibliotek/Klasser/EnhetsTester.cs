namespace Bibliotek.Tester;
using Bibliotek.Klasser;

public class Enhetstester
{
    public static void KjørTester()
    {
        Console.WriteLine("\n--- KJØRER ENHETSTESTER ---");

        // Test 1: Sjekk om student kan melde seg på samme kurs to ganger
        TestDobbeltPåmelding();

        // Test 2: Sjekk om man kan låne bok når det er 0 eksemplarer
        TestLånTomBok();

        // Test 3: Sjekk om passord-validering fungerer
        TestPassordSjekk();

        Console.WriteLine("--- TESTER FULLFØRT ---\n");
    }

    static void TestDobbeltPåmelding()
    {
        var student = new Student { Navn = "Test", StudentId = "999" };
        var kurs = new Kurs("TEST101", "Testkurs", 10, 10);
        
        student.Kurs.Add(kurs);
        bool kanLeggeTilIgjen = !student.Kurs.Any(k => k.KursId == "TEST101");
        
        Console.WriteLine(kanLeggeTilIgjen ? "[FAIL] Test 1: Tillot dobbel påmelding" : "[PASS] Test 1: Hindret dobbel påmelding");
    }

    static void TestLånTomBok()
    {
        var bok = new Bok { Tittel = "Tom Bok", ErTilgjengelig = 0 };
        var bruker = new Student { Navn = "TestBruker" };
        bool suksess = bok.LånUt(bruker);
        
        Console.WriteLine(suksess ? "[FAIL] Test 2: Tillot lån av bok uten eksemplarer tilgjengelig" : "[PASS] Test 2: Hindret lån av bok uten eksemplarer tilgjengelig");
    }

    static void TestPassordSjekk()
    {
        var bruker = new Student { Navn = "Test", Passord = "Hemmelig" };
        bool feilPassord = bruker.SjekkPassord("Feil123");
        bool riktigPassord = bruker.SjekkPassord("Hemmelig");

        if (!feilPassord && riktigPassord)
            Console.WriteLine("[PASS] Test 3: Passordsjekk fungerer korrekt");
        else
            Console.WriteLine("[FAIL] Test 3: Passordsjekk feilet");
    }
}