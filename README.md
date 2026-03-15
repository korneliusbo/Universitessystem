Jeg aner ikke hvorfor det ble lagd en mappe kalt .idea/idea.Bibliotek/.idea, men jeg tørr ikke å fjerne den i tilfelle det ødelegger noe


OBLIGATORISK OPPGAVE 1 I IS-110
UNIVERSITETSSYSTEM I C#

OPPGAVEBESKRIVELSE:

Du skal utvikle en C# Console applikasjon som modellerer et universitetssystem. Fokuset er objektorientert design, god struktur og riktig bruk av C# konstruksjoner.

Applikasjonen skal håndtere:

    Brukere: studenter (inkludert utvekslingsstudenter fra andre universiteter) og ansatte

    Kurs: oppretting, påmelding, og oversikt

    Bibliotek: utlån/innlevering, tilgjengelighet, og historikk

 
Funskjonaliteter som må implementeres:
1) Brukere, applikasjonen skal støtte minst disse rollene:

Student

    StudentID

    Navn

    E-post
    Liste over kurs studenten er meldt opp i

Utvekslingsstudent 

    Hjemuniversitet

    Land

    Periode (fra–til)

Ansatt

    AnsattID

    Navn

    E-post

    Stilling (f.eks. foreleser, bibliotekar, administrasjon)

    Avdeling

 

 
2) Kurs, applikasjonen skal kunne:

    Opprette kurs (kode, navn, studiepoeng, maks antall plasser)

    Melde student på kurs (sjekk kapasitet)

    Melde student av kurs

    Liste kurs og deltakere

    Søke etter kurs basert på kriterier (kode og navn)

 
3) Bibliotek, applikasjonen skal kunne:

    Registrere bøker/medier (id, tittel, forfatter, år, antall eksemplarer)

    Låne ut og levere inn (Lån må knyttes til en bruker enten student eller ansatt).

    Hindre utlån hvis ingen eksemplarer er tilgjengelig

    Vise aktive lån og historikk

 
Applikasjonen skal ha følgende menyen:

[1] Opprett kurs

[2] Meld student til kurs

[3] Print kurs og deltagere

[4] Søk på kurs

[5] Søk på bok

[6] Lån bok

[7] Returner bok

[8] Registrer bok

[0] Avslutt 
