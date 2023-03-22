using System;

namespace Interfacce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Iran iran = new Iran("Iran");
            Bielorussia bielorussia = new Bielorussia("Bielorussia");
            Vaticano vaticano = new Vaticano("Vaticano");
            Ucraina ucraina = new Ucraina("Ucraina");    
            Brasile brasile = new Brasile("Brasile");
            Svizzera svizzera = new Svizzera("Svizzera");

            IUE italia = new Italia("Italia");  
            EuroCentralBank banca = new EuroCentralBank();

            banca.CalcolaSpread(italia);
        }
    }
}
