//Program.cs
using Bibliotek.Klasser;
using Bibliotek.DataPlaceholders;

// Hent testdata fra DataSeeder
List<Kurs> kursListe = DataSeeder.TestKurs();
List<Student> studentListe = DataSeeder.TestStudenter(kursListe);
List<UtvekslingStudent> uStudentListe = DataSeeder.TestUStudent(kursListe);
List<Student> alleStudenter = new List<Student>();
alleStudenter.AddRange(studentListe);
alleStudenter.AddRange(uStudentListe);
List<Ansatt> ansattListe = DataSeeder.TestAnsatte();
List<Bok> bokListe = DataSeeder.TestBøker();
List<Bruker> alleBrukere = new List<Bruker>();
alleBrukere.AddRange(alleStudenter);
alleBrukere.AddRange(ansattListe);
Bruker innloggetBruker = null;

// Hjelpefunksjon for å hindre blanke inputs
string LesBrukerInput(string melding)
{
    string input = "";
    while (string.IsNullOrWhiteSpace(input))
    {
        Console.Write(melding);
        input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
            Console.WriteLine("Feltet kan ikke være blankt, prøv igjen.");
    }
    return input;
}

// Hjelpefunksjon for å finne bruker eller ansatt for biblioteksystemet
Bruker FinnBruker(string id)
{
    return alleStudenter.FirstOrDefault(s => s.StudentId == id) 
           ?? (Bruker)ansattListe.FirstOrDefault(a => a.AnsattId == id);
}

// ENHETSTESTER
Bibliotek.Tester.Enhetstester.KjørTester();


// Login-meny
bool gyldigInnlogging = false;
Console.WriteLine("--- Universitet placeholder ---");
Console.WriteLine("Ønsker du å logge inn eller ønsker du å registrere deg?");
Console.WriteLine("[1] Login\n[2] Registrer ny bruker");
string loginEllerRegistrer = Console.ReadLine();

while (!gyldigInnlogging)
{
    switch (loginEllerRegistrer)
    {
        case "1":
        {
            string brukernavn = LesBrukerInput("Brukernavn: ");
            string passord = LesBrukerInput("Passord: ");

            innloggetBruker = alleBrukere.FirstOrDefault(b => b.Epost.Split('@')[0] == brukernavn && b.SjekkPassord(passord));

            if (innloggetBruker == null)
            {
                Console.WriteLine("Feil brukernavn eller passord!");
                break;
            }
            else
            {
                Console.WriteLine($"Velkommen, {innloggetBruker.Navn}! Brukertype: {innloggetBruker.Rolle}");
                gyldigInnlogging = true;
                break;

            }
        }
        // Registrere ny bruker
        case "2":
        {
            // Navn og passord
            Console.WriteLine("Registrer ny bruker");
            string forNavn = LesBrukerInput("Fornavn: ");
            string etterNavn = LesBrukerInput("Etternavn: ");
            string passord = LesBrukerInput("Personlig passord: NB! Ikke del passordet ditt med andre!: ");
            
            // Generere email og brukernavn utifra navn
            string generertEpost = $"{forNavn.ToLower()}.{etterNavn.ToLower()}@uia.no";
            Console.WriteLine($"Din epost blir: {generertEpost}");
            
            if (alleBrukere.Any(b => b.Epost == generertEpost))
            {
                Console.WriteLine("En bruker med denne eposten finnes allerede!");
                int tall = 1;
                while (alleBrukere.Any(b => b.Epost == generertEpost))
                {

                    generertEpost = $"{forNavn.ToLower()}.{etterNavn.ToLower()}{tall}@uia.no";
                    tall++;
                }
                Console.WriteLine($"Din epost blir isteden: {generertEpost}");
            }
            // Rolle
            Console.WriteLine($"Hvilken stilling har du?");
            var roller = Enum.GetValues<Rolle>();
            foreach (var rolle in roller)
            {
                Console.WriteLine($"  [{(int)rolle}] {rolle}");
            }
            var valgtStilling = LesBrukerInput("");
            //Her vil jeg hente ut valgt Rolle fra Enum rolle som en string. så hvis brukeren har skrevet 0 for student så skal valgtStilling = "student"
            
            
            switch (valgtStilling)
            {
                case "0":
                {
                    Rolle rolle = (Rolle)int.Parse(valgtStilling);
                    Console.WriteLine("Lager din studentID. Vennligst vent...");
                    Thread.Sleep(2000);

                    int idNummer = 1;
                    while (alleStudenter.Any(b => b.StudentId == idNummer.ToString().PadLeft(6, '0')))
                    {
                        idNummer++;
                    }

                    string generertStudentId = idNummer.ToString().PadLeft(6, '0');
                    
                    Console.WriteLine($"Oppsummering: \n" +
                                      $"Navn: {forNavn} {etterNavn}\n" +
                                      $"Epost: {generertEpost}\n" +
                                      $"StudentId: {generertStudentId}\n" +
                                      $"Stilling: {rolle}");

                    var fullførRegistrering = LesBrukerInput("\nFullfør registrering? y/n\n");
                    switch (fullførRegistrering)
                    {
                        case "y":
                        {
                            var nyStudent = new Student { Navn = $"{forNavn} {etterNavn}", Epost = generertEpost, Passord = passord, StudentId = generertStudentId, Rolle = rolle };
                            alleStudenter.Add(nyStudent);
                            alleBrukere.Add(nyStudent);
                            loginEllerRegistrer = "1";
                            break;
                        }
                        case "n":
                        {
                            Console.WriteLine("Avbrutt.");
                            break;
                        }
                    }
                    
                    break;
                }
                case "1":
                case "2":
                case "3":
                {
                    Rolle rolle = (Rolle)int.Parse(valgtStilling);
                    Console.WriteLine("Lager din AnsattID. Vennligst vent...");
                    Thread.Sleep(2000);
                    
                    int idNummer = 1;
                    while (ansattListe.Any(b => b.AnsattId == idNummer.ToString().PadLeft(6, '1')))
                    {
                        idNummer++;
                    }

                    string generertStudentId = idNummer.ToString().PadLeft(6, '1');
                    
                    Console.WriteLine($"Oppsummering: \n" +
                                      $"Navn: {forNavn} {etterNavn}\n" +
                                      $"Epost: {generertEpost}\n" +
                                      $"AnsattId: {generertStudentId}\n" +
                                      $"Stilling: {rolle}");
                    var fullførRegistrering = LesBrukerInput("\nFullfør registrering? y/n\n");
                    switch (fullførRegistrering)
                    {
                        case "y":
                        {
                            var nyAnsatt = new Ansatt { Navn = $"{forNavn} {etterNavn}", Epost = generertEpost, Passord = passord, AnsattId = generertStudentId, Rolle = rolle };
                            ansattListe.Add(nyAnsatt);
                            alleBrukere.Add(nyAnsatt);
                            loginEllerRegistrer = "1";
                            break;
                        }
                        case "n":
                        {
                            Console.WriteLine("Avbrutt.");
                            break;
                        }
                    }
                    
                    break;
                }
                    
            }

            break;
        }
            
    }
}

// Hovedmeny -starter ui programmet
 
bool kjører = true;
while (kjører)
    
{
    Console.WriteLine("\n--- Universitetssystem ---");
    Console.WriteLine($"Bruker: [{innloggetBruker.Navn}]");

    if (innloggetBruker.Rolle == Rolle.Faglærer || innloggetBruker.Rolle == Rolle.Administrasjon)
        Console.WriteLine("[1] Opprett et nytt kurs");

    if (innloggetBruker.Rolle == Rolle.Student || innloggetBruker.Rolle == Rolle.Faglærer)
        Console.WriteLine("[2] Meld student på/av kurs");

    Console.WriteLine("[3] Print kurs og deltagere");
    Console.WriteLine("[4] Søk på kurs");
    Console.WriteLine("[5] Søk på bok");

    if (innloggetBruker.Rolle == Rolle.Student || innloggetBruker.Rolle == Rolle.Faglærer)
        Console.WriteLine("[6] Lån bok");

    if (innloggetBruker.Rolle == Rolle.Student || innloggetBruker.Rolle == Rolle.Faglærer)
        Console.WriteLine("[7] Returner bok");

    if (innloggetBruker.Rolle == Rolle.Bibliotekar)
        Console.WriteLine("[8] Registrer bok");
    
    if (innloggetBruker.Rolle == Rolle.Faglærer)
        Console.WriteLine("[9] Sette karakter");

    if (innloggetBruker.Rolle == Rolle.Student)
        Console.WriteLine("[10] Se egne kurs med karakterer");
    
    if (innloggetBruker.Rolle == Rolle.Faglærer)
        Console.WriteLine("[11] sette pensum til kurs");
    
    Console.WriteLine("[0] Avslutt");

    string valg = Console.ReadLine();

    switch (valg)
    {
        // Oppretting av kurs
        case "1":
        {
            // Passer på at brukeren må være faglærer eller i administrasjon
            if (innloggetBruker.Rolle != Rolle.Faglærer || innloggetBruker.Rolle != Rolle.Administrasjon)
            {
                Console.WriteLine("Du har ikke rettighet til å gjøre endringer her.");
                break;
            }
            else
            {
                Console.WriteLine("\n--- Opprett kurs ---");
                // Definerer variablene som må fylles ut for å legge til et nytt kurs i listen
                string kursId = "";
                string kursNavn = "";
                double studiepoeng = 0;
                int maksPlasser = 0;

                // Lar brukeren skrive inn Kursets id, navn, studiepoeng og hvor mange studenter den kan romme
                Console.Write("Kurs ID: ");
                kursId = Console.ReadLine();

                Console.Write("Kurs navn: ");
                kursNavn = Console.ReadLine();

                Console.Write("Studiepoeng: ");
                studiepoeng = double.Parse(Console.ReadLine());

                Console.Write("Maks plasser: ");
                maksPlasser = int.Parse(Console.ReadLine());

                Console.WriteLine(
                    $"\nOpprett kurset '{kursNavn}' ({kursId}), {studiepoeng} stp, {maksPlasser} plasser? y/n");
                string confirm = Console.ReadLine();

                // gir brukeren mulighet til å avbryte
                if (confirm == "y")
                {
                    // legger det nye kurset til i kursListe
                    if (kursListe.Any(k => k.KursId.Equals(kursId, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine($"FEIL: Kurskode {kursId} eksisterer allerede!");
                    }
                    else
                    {
                        kursListe.Add(new Kurs(kursId, kursNavn, studiepoeng, maksPlasser));
                        Console.WriteLine("Kurs opprettet!");
                    }
                }
                else
                {
                    Console.Beep();
                    Console.WriteLine("Avbrutt.");
                }

                // en liten pause før brukeren går tilbake til hovedmenyen for å ikke disorientere brukeren
                Console.WriteLine("\nTrykk Enter for å fortsette...");
                Console.ReadLine();
                break;
            }
        }
        // Melde av/på kurs
        case "2":
            Console.Beep();
            if (innloggetBruker.Rolle == Rolle.Student)
            {
               
            }
            
            string studentId = LesBrukerInput("Student ID: ");
    
            // Ser om studentId fra LesBrukerInput er gyldig ved å hente studentId fra Alle studenter listen
            var studenten = alleStudenter.FirstOrDefault(s => s.StudentId == studentId);
            
    
            // Gir feilmelding hvis gitt studentId ikke samsvarer med noen studenter
            if (studenten == null)
            {
                Console.Beep();
                Console.WriteLine($"Fant ingen student med ID {studentId}");
                Console.WriteLine("\nTast Enter for å gå tilbake til hovedmeny...");
                Console.ReadLine();
                break;
            }
    
            studenten.Beskriv();
            Console.WriteLine($"\nDu har valgt {studenten.Navn}\n[1] Meld på kurs\n[2] Meld av kurs");
            string påAv = Console.ReadLine();
            switch (påAv)
            {
                case "1":
                {
                    // Etter studenten er valgt blir brukeren bedt om å velge kurs å melde studenten opp til
                    Console.WriteLine($"Du har valgt å melde {studenten.Navn} opp til et kurs.\n\nHer er en liste over alle kurs:");
                    foreach (var kurs in kursListe)
                    {
                        Console.WriteLine(
                            $"Kurs id: [{kurs.KursId}] {kurs.KursName} ({kurs.Påmeldte.Count}/{kurs.MaksPlasser} plasser)");
                    }

                    Console.WriteLine($"\nSkriv inn Kurs-ID på kurset du ønsker å melde {studenten.Navn} opp til:");

                    var valgKurs = LesBrukerInput("Kurs ID: ");

                    // Ser om valgKurs er en gyldig KursId fra listen
                    var valgKurset = kursListe.FirstOrDefault(s => s.KursId == valgKurs);


                    // Sier fra om valgt kurs er gyldig
                    if (valgKurset == null)
                    {
                        Console.Beep();
                        Console.WriteLine($"Fant ingen kurs med ID {valgKurs}");
                        Console.WriteLine("\nTast Enter for å gå tilbake til hovedmeny...");
                        Console.ReadLine();
                        break;
                    }

                    // Sier fra om at studenten allerede går valgt kurs
                    if (studenten.Kurs.Any(k => k.KursId == valgKurset.KursId))
                    {
                        Console.Beep();
                        Console.WriteLine($"Feilmelding: {studenten.Navn} er allerede påmeldt {valgKurset.KursName}!");
                        Console.WriteLine("\nTast Enter for å gå tilbake til hovedmeny...");
                        Console.ReadLine();
                        break;
                    }

                    // Sier fra om valgt kurs er fullt
                    if (valgKurset.Påmeldte.Count >= valgKurset.MaksPlasser)
                    {
                        Console.Beep();
                        Console.WriteLine($"{valgKurset.KursName} er allerede fult! Påmelding avbrutt.");
                        Console.WriteLine("\nTast Enter for å gå tilbake til hovedmeny...");
                        Console.ReadLine();
                        break;
                    }

                    // Hvis ingen av feilmeldings if statements ble møtt går programmet videre

                    Console.WriteLine(
                        $"Oppsummering: Du ønsker å melde {studenten.Navn} opp til: {valgKurset.KursName}?\ny/n");

                    // Brukeren må confirme valget før det går inn i systemet
                    string confirmPaamelding = Console.ReadLine();
                    if (confirmPaamelding == "y")
                    {
                        studenten.Kurs.Add(valgKurset);
                        valgKurset.Påmeldte.Add(studenten);
                        Console.WriteLine($"{studenten.Navn} er meldt på til {valgKurset.KursName}!");
                        Console.WriteLine("\nTast Enter for å gå tilbake til hovedmeny...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Avbrutt.");
                        Console.WriteLine("\nTast Enter for å gå tilbake til hovedmeny...");
                        Console.ReadLine();
                    }

                    break;
                }
                    
                // Hvis studenten ønsker å melde seg av et kurs
                case "2":
                {
                    // Feilmelding hvis studenten ikke er meldt på kurs
                    if (studenten.Kurs.Count == 0)
                    {
                        Console.Beep();
                        Console.WriteLine($"{studenten.Navn} er ikke meldt på noen kurs!");
                        Console.ReadLine();
                        break;
                    }

                    Console.WriteLine($"Her er kursene {studenten.Navn} er påmeldt;");
                    foreach (var kurs in studenten.Kurs)
                        Console.WriteLine($"{kurs.KursName}: {kurs.KursId}");
                    
                    var avmeldKurs = LesBrukerInput($"Velg Kurs ID som {studenten.Navn} skal meldes av: ");
                    var avmeldKurset = studenten.Kurs.FirstOrDefault(k => k.KursId == avmeldKurs);
                    
                    if (avmeldKurset == null)
                    {
                        Console.Beep();
                        Console.WriteLine($"Fant ingen kurs med ID: {avmeldKurs}");
                        Console.ReadLine();
                        break;
                    }

                    Console.WriteLine($"Meld {studenten.Navn} av {avmeldKurset.KursName}? y/n");
                    string confirmAvmelding = Console.ReadLine();
                    if (confirmAvmelding == "y")
                    {
                        studenten.Kurs.Remove(avmeldKurset);
                        avmeldKurset.Påmeldte.Remove(studenten);
                        Console.WriteLine($"{studenten.Navn} er nå meldt av {avmeldKurset.KursName}!");
                    }
                    else
                    {
                        Console.WriteLine("Avbrutt.");
                    }

                    Console.ReadLine();
                    break;
                }
            }
            break;
        case "3":
            Console.WriteLine("\n--- Kurs og deltagere ---");
            foreach (var kurs in kursListe)
            {
                kurs.Beskriv();
                if (kurs.Påmeldte.Count == 0)
                    Console.WriteLine("  Ingen påmeldte studenter.");
                else
                    foreach (var student in kurs.Påmeldte)
                        Console.WriteLine($"  - {student.Navn} ({student.StudentId})");
            }
            Console.ReadKey();
            break;

        case "4":
            Console.WriteLine("Du har valgt å søke etter kurs i systemet.\nSøk etter kursets navn eller kursID: ");
            
            // Tar brukerens input
            string kursSøk  = Console.ReadLine();
            
            // Ser om kursSøk stemmer med navn eller ID på noen av kursene i kursListe
            
            var kursResultater = kursListe.Where(k => k.KursId.Contains(kursSøk, StringComparison.OrdinalIgnoreCase) || k.KursName.Contains(kursSøk, StringComparison.OrdinalIgnoreCase)).ToList();

            if (kursResultater.Count == 0)
            {
                Console.Beep();
                Console.WriteLine("Ingen kurs funnet.");
                Console.ReadLine();
            }
            else
            {
                foreach (var kurs in kursResultater)
                {
                    kurs.Beskriv();
                    Console.ReadLine();
                }
            }
            
            break;

        case "5":
            
            Console.WriteLine("Du har valgt å søke etter en bok i systemet.\nSøk etter bokens navn eller bokens ISBN: ");
            
            // tar brukerens input
            string bokSøk = Console.ReadLine();
            
            var bokResultater = bokListe.Where(b => b.Tittel.Contains(bokSøk, StringComparison.OrdinalIgnoreCase) || b.Isbn.Contains(bokSøk, StringComparison.OrdinalIgnoreCase)).ToList();

            // Sier fra om søket ikke ga noen resultater
            if (bokResultater.Count == 0)
            {
                Console.Beep();
                Console.WriteLine("Ingen bok funnet.");
            }
            else
            // Skriver ut alt i listen som inneholdt bokSøk
            {
                foreach (var bok in bokResultater)
                {
                    bok.Beskriv();
                    
                }
            }
            Console.ReadLine();
            break;

        case "6":

            string brukerId = LesBrukerInput("Student/Ansatt ID: ");
            var bruker = FinnBruker(brukerId);

            if (bruker == null)
            {
                Console.WriteLine($"Fant ingen bruker med ID {brukerId}");
                break;
            }
            
            // Lar brukeren velge bok. 
            Console.WriteLine($"Velkommen, {bruker.Navn}!\nHvilken bok ønsker du å låne?");
            
            List<Bok> bokLånResultater = new List<Bok>();
            
            // while løkken gjør at det ikke kan være mer enn 1 resultat for utlån
            while (bokLånResultater.Count != 1)
            {
                string valgBok = LesBrukerInput("Tittel, nøkkelord eller ISBN: ");
                bokLånResultater = bokListe.Where(b => 
                    b.Tittel.Contains(valgBok, StringComparison.OrdinalIgnoreCase) || 
                    b.Isbn.Contains(valgBok, StringComparison.OrdinalIgnoreCase)).ToList();

                if (bokLånResultater.Count == 0)
                {
                    Console.Beep();
                    Console.WriteLine("Ingen bok funnet, prøv igjen.");
                }
                else if (bokLånResultater.Count > 1)
                {
                    Console.WriteLine($"{bokLånResultater.Count} bøker funnet, vær mer spesifikk:");
                    foreach (var bok in bokLånResultater)
                        Console.WriteLine($"  - {bok.Tittel} ISBN: {bok.Isbn}");
                }
            }
            
            

            var valgtBok = bokLånResultater.First();
            
            // Gjør at brukeren ikke kan låne 2 kopier av samme bok
            if (bruker.LånteBøker.Any(b => b.Isbn == valgtBok.Isbn))
            {
                Console.WriteLine($"{bruker.Navn} har allerede lånt {valgtBok.Tittel}!");
                Console.ReadLine();
                break;
            }
            
            valgtBok.Beskriv();
            Console.WriteLine($"\nDu ønsker å låne {valgtBok.Tittel}? Det er {valgtBok.ErTilgjengelig} eksemplarer tilgjengelig.");
            Console.WriteLine("Bekreft valg med y/n");
            string confirmBokLån = Console.ReadLine();

            if (confirmBokLån == "y")
            {
                if (valgtBok.LånUt(bruker))
                {
                    bruker.LånteBøker.Add(valgtBok);
                }
            }
            else
            {
                Console.WriteLine("Avbrutt.");
            }
            Console.WriteLine("\nTast Enter for å gå tilbake til hovedmeny...");
            Console.ReadLine();

       
            break;

        case "7":
  
            string returBruker = LesBrukerInput("Student/Ansatt ID: ");
            var returBrukeren = FinnBruker(returBruker);

            if (returBrukeren == null)
            {
                Console.WriteLine($"Fant ingen bruker med ID {returBruker}");
                break;
            }

            if (returBrukeren.LånteBøker.Count == 0)
            {
                Console.WriteLine($"{returBrukeren.Navn} har ingen lånte bøker hos oss! \nSender deg tilbake til hovedmeny...");
                Console.ReadLine();
                break;
            }
            
            
            Console.WriteLine($"Velkommen, {returBrukeren.Navn}! Du har {returBrukeren.LånteBøker.Count} lånte bøker fra oss!");
            foreach (var bok in returBrukeren.LånteBøker)
                Console.WriteLine($"  - {bok.Tittel} ISBN: {bok.Isbn}\n");
            Console.WriteLine("Hvilken bok ønsker du å returnere?");
            
            List<Bok> returBokValg = new List<Bok>();
            
            // while løkken gjør at det ikke kan være mer enn 1 resultat for utlån
            while (returBokValg.Count != 1)
            {
                string valgBok = LesBrukerInput("Tittel, nøkkelord eller ISBN: ");
                returBokValg = returBrukeren.LånteBøker.Where(b => 
                    b.Tittel.Contains(valgBok, StringComparison.OrdinalIgnoreCase) || 
                    b.Isbn.Contains(valgBok, StringComparison.OrdinalIgnoreCase)).ToList();

                if (returBokValg.Count == 0)
                {
                    Console.Beep();
                    Console.WriteLine("Ingen bok funnet, prøv igjen.");
                }
                else if (returBokValg.Count > 1)
                {
                    Console.WriteLine($"{returBokValg.Count} bøker funnet, vær mer spesifikk:");
                    foreach (var bok in returBokValg)
                        Console.WriteLine($"  - {bok.Tittel} ISBN: {bok.Isbn}");
                }
            }
            
            var valgtReturBok = returBokValg.First();
            valgtReturBok.Beskriv();
            
            Console.WriteLine($"\nDu ønsker å returnere {valgtReturBok.Tittel}?");
            Console.WriteLine("Bekreft valg med y/n");
            string confirmReturBok = Console.ReadLine();

            if (confirmReturBok == "y")
            {
                if (valgtReturBok.LeverInn(returBrukeren))
                {
                    returBrukeren.LånteBøker.Remove(valgtReturBok);
                }
            }
            else
            {
                Console.WriteLine("Avbrutt.");
            }
            Console.WriteLine("\nTast Enter for å gå tilbake til hovedmeny...");
            Console.ReadLine();
            
            break;

        case "8":

            Console.WriteLine("\n--- Registrer ny Bok ---");
            // Definerer variablene som må fylles ut for å legge til et nytt kurs i listen
            string bokTittel = "";
            string bokForfatter = "";
            int bokEksemplarer = 0;
            string bokIsbn = "";

            // Lar brukeren skrive inn Kursets id, navn, studiepoeng og hvor mange studenter den kan romme
            Console.Write("Bokens Tittel: ");
            bokTittel = Console.ReadLine();

            Console.Write("Forfatter: ");
            bokForfatter = Console.ReadLine();

            Console.Write("Eksemplarer: ");
            bokEksemplarer = int.Parse(Console.ReadLine());

            Console.Write("ISBN: ");
            bokIsbn = Console.ReadLine();

            Console.WriteLine($"\nRegistrer ny bok: \n'{bokTittel}' ({bokForfatter}), {bokEksemplarer} stk, ISBN: {bokIsbn} \ny/n");
            string bokRegister = Console.ReadLine();

            // gir brukeren mulighet til å avbryte
            if (bokRegister == "y")
            {
                // legger den nye boken inn i systemet
                bokListe.Add(new Bok {Tittel = bokTittel, Forfatter = bokForfatter, ErTilgjengelig =  bokEksemplarer, Isbn = bokIsbn, ErUtlånt = 0});
                Console.WriteLine("Bok registrert!");
            }
            else
            {
                Console.Beep();
                Console.WriteLine("Avbrutt.");
            }
            
            Console.WriteLine("\nTrykk Enter for å fortsette...");
            Console.ReadLine();
            break;
        
        case "9":
            // Tilgangskontroll
            if (innloggetBruker.Rolle != Rolle.Faglærer)
            {
                Console.WriteLine("Kun faglærere kan sette karakterer.");
                break;
            }

            Console.WriteLine("\n--- Sett karakter ---");

            // Skriver ut alle kursene (burde bare skrevet ut kursene faglærer underviser i, men vi får se om jeg gidder)
            foreach (var k in kursListe)
            {
                Console.WriteLine($"[{k.KursId}] {k.KursName}");
            }

            string valgtKursId = LesBrukerInput("Skriv Kurs ID: ");
            var kursObjekt = kursListe.FirstOrDefault(k => k.KursId.Equals(valgtKursId, StringComparison.OrdinalIgnoreCase));

            if (kursObjekt == null)
            {
                Console.WriteLine("Fant ikke kurset.");
                break;
            }

            // Sjekk om det er studenter i kurset
            if (kursObjekt.Påmeldte.Count == 0)
            {
                Console.WriteLine("Det er ingen studenter påmeldt dette kurset.");
                break;
            }

            // 4. Velg student fra kurset
            Console.WriteLine($"\nStudenter i {kursObjekt.KursName}:");
            foreach (var stud in kursObjekt.Påmeldte)
            {
                Console.WriteLine($"- [{stud.StudentId}] {stud.Navn}");
            }

            string valgtStudentId = LesBrukerInput("Skriv Student ID for å sette karakter: ");
            var studentObjekt = kursObjekt.Påmeldte.FirstOrDefault(s => s.StudentId == valgtStudentId);

            if (studentObjekt == null)
            {
                Console.WriteLine("Denne studenten er ikke påmeldt kurset.");
                break;
            }

            // 5. Sett karakter
            string karakter = LesBrukerInput($"Sett karakter for {studentObjekt.Navn} (A-F): ").ToUpper();
    
            // Lagre i kursets dictionary
            kursObjekt.Karakterer[studentObjekt.StudentId] = karakter;

            Console.WriteLine($"Suksess: {studentObjekt.Navn} fikk karakteren {karakter} i {kursObjekt.KursName}.");
            Console.WriteLine("Trykk Enter for å fortsette...");
            Console.ReadLine();
            break;
        
        // Se kurs student-brukeren er meldt opp på og karakterer
        case "10":
            if (innloggetBruker is Student studente)
            {
                Console.WriteLine($"\nKurs og karakterer for {studente.Navn}:");
        
                if (!studente.Kurs.Any())
                {
                    Console.WriteLine("Ingen kurs registrert.");
                }
                else
                {
                    foreach (var k in studente.Kurs)
                    {
                        // Henter karakter hvis den finnes, ellers viser den "-" - fy fillen c# e kresen på kæ an godtar ass
                        string karaktere = k.Karakterer.TryGetValue(studente.StudentId, out var v) ? v : "-";
                        Console.WriteLine($"- {k.KursId}: {k.KursName} | Karakter: {karaktere}");
                    }
                }
            }
            Console.ReadLine();
            break;
        
        case "11":
            if (innloggetBruker.Rolle != Rolle.Faglærer) break;
    
            string kId = LesBrukerInput("Kurs ID: ");
            var kObj = kursListe.FirstOrDefault(k => k.KursId == kId);
            string bIsbn = LesBrukerInput("Bokens ISBN for pensum: ");
            var bObj = bokListe.FirstOrDefault(b => b.Isbn == bIsbn);

            if (kObj != null && bObj != null) {
                kObj.Pensum.Add(bObj);
                Console.WriteLine($"{bObj.Tittel} er nå pensum i {kObj.KursName}");
            }
            Console.ReadLine();
            break;

        case "0":
            kjører = false;
            Console.WriteLine("Avslutter...");
            break;
        
        case "help":
            Console.WriteLine("nei du får ikke hjelp.");
            Console.ReadLine();
            break;

        default:
            Console.WriteLine("Ugyldig valg! Må være et ensifret tall!(0-9) \nTast Enter for å gå tilbake til hovedmeny.");
            Console.ReadLine();
            break;
    }
}