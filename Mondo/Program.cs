using System;
using Mondo;

namespace Mondo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Continente europa = new Continente("Europa");
            europa.CreateNazione("Italia");
            europa.CreateRegione("Piemonte");
            europa.CreateProvincia("Novara");
            europa.CreateComune("Galliate");

            europa.ChangeCoumne("Italia", "Lombardia", "Busto Arsizio", "Galliate");
        }
    }
}
