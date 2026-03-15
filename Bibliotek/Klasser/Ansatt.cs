namespace Bibliotek.Klasser;

// Lager klassen Ansatt som child av Bruker-klassen
public class Ansatt : Bruker 
{
    public string Stilling { get; set; }
    public string Avdeling { get; set; }
    
    /* AnsattId bruker string isteden for int for at tallet skal skrives ut med alle siffer,
     og at den ikke skal gjøres regning med*/
    public string AnsattId { get; set; }
    
    // Lager en kort beskrivelse av Ansatt som kan kalles med beskriv()
    public override void Beskriv() 
    {
        Console.WriteLine($"Navn: {Navn}\n  Stilling: {Stilling}\n  Avdeling: {Avdeling}\n  AnsattId: {AnsattId}");
    }
}