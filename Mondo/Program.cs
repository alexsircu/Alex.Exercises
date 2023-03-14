using System;
using Mondo;

namespace Mondo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Nuovo continente
            Continente europa = new Continente("Italia");

            //Nazione creata
            Nazione italia = europa.Nazione;

            //Nuova regione
            Regione piemonte = new Regione("Piemonte", italia);
            italia.AddRegione(piemonte);

            //Nuova provincia
            Provincia torino = new Provincia("Torino", piemonte);
            piemonte.AddProvincia(torino);

            //Nuovo comune
            Comune moncalieri = new Comune("Moncalieri", torino);
            torino.AddComune(moncalieri);

            //Nuovo abitante
            Abitante alex = new Abitante("Alex", moncalieri);
            moncalieri.AddAbitante(alex);


            //Test
            Console.WriteLine($"Continente creato: {europa}");
            Console.WriteLine($"Nazione creata: {italia}");
        }
    }
}
