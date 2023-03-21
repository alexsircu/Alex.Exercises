using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondo
{
    internal class Continente
    {
        string _name;
        Nazione _nazione; 
        public Continente(string nazioneName) 
        {
            Name = nazioneName;
        }

        public string Name { get { return _name; } set { _name = value; } }
        private Nazione NazioneObj { get { return _nazione; } set { _nazione = value; } }

        public void CreateNazione(string nazioneName)
        {
            NazioneObj = new Nazione(nazioneName);
        }

        public void CreateRegione(string regioneName)
        {
            NazioneObj.CreateRegione(regioneName);
        }

        public void CreateProvincia(string provinciaName)
        {
            NazioneObj.CreateProvincia(provinciaName);
        }

        public void CreateComune(string comuneName)
        {
            NazioneObj.CreateComune(comuneName);
        }

        private void AddNazione(Nazione nazione)
        {
            NazioneObj = nazione;
        }

        public void ChangeNazione(Continente continente)
        {
            continente.AddNazione(NazioneObj);
            NazioneObj = null;
        }

        public void ChangeCoumne(string nazioneNameDest, string regioneNameDest, string provinciaNameDest, string comuneNameDest)
        {
            Nazione nazione = new Nazione(nazioneNameDest);
            string printText = $"Aggiornamento: {Name} -> {nazioneNameDest} ->";
            nazione.ChangeComune(regioneNameDest, provinciaNameDest, comuneNameDest, printText);
        }

        public class Nazione
        {
            string _name;
            Regione _regione;

            public Nazione(string nazioneName)
            {
                Name = nazioneName;
            }

            public string Name { get { return _name; } set { _name = value; } }
            private Regione RegioneObj { get { return _regione; } set { _regione = value; } }


            public void CreateRegione(string regioneName)
            {
                RegioneObj = new Regione(regioneName, this);
            }

            public void CreateProvincia(string provinciaName)
            {
                RegioneObj.CreateProvincia(provinciaName);
            }

            public void CreateComune(string comuneName)
            {
                RegioneObj.CreateComune(comuneName);
            }

            private void AddRegione(Regione regione)
            {
                RegioneObj = regione;
            }

            public void ChangeRegione(Nazione nazione)
            {
                nazione.AddRegione(RegioneObj);
                RegioneObj = null;
            }

            public void ChangeComune(string regioneNameDest, string provinciaNameDest, string comuneNameDest, string printText)
            {
                Regione regione = new Regione(regioneNameDest, this);
                printText += $" {regioneNameDest} ->";
                regione.ChangeComune(provinciaNameDest, comuneNameDest, printText);
            }

            

            //REGIONE
            class Regione
            {
                string _name;
                Nazione _nazione;
                Provincia _provincia;
                public Regione(string nameRegione, Nazione nazione)
                {
                    Name = nameRegione;
                    Nazione = nazione;
                }

                public string Name { get { return _name; } set { _name = value; } }
                private Provincia ProvinciaObj { get { return _provincia; } set { _provincia = value; } }
                public Nazione Nazione { get { return _nazione; } set { _nazione = value; } }

                public void CreateProvincia(string provinciaName)
                {
                    ProvinciaObj = new Provincia(provinciaName, this);
                }

                public void CreateComune(string comuneName)
                {
                    ProvinciaObj.CreateComune(comuneName);
                }

                /*private void AddProvincia(Provincia provincia)
                {
                    ProvinciaObj = provincia;
                }*/

                /*public void ChangeProvincia(string provinciaNameDest)
                {
                    CreateProvincia(provinciaNameDest);
                }*/

                public void ChangeComune(string provinciaNameDest, string comuneNameDest, string printText)
                {
                    Provincia provincia = new Provincia(provinciaNameDest, this);
                    printText += $" {provinciaNameDest} ->";
                    provincia.ChangeComune(comuneNameDest, printText);
                }

                //PROVINCIA
                class Provincia
                {
                    string _nameProvincia;
                    Comune _comune;
                    Regione _regione;

                    public Provincia(string provinciaName, Regione regione)
                    {
                        Name = provinciaName;
                        Regione = regione;
                    }

                    public string Name { get { return _nameProvincia; } set { _nameProvincia = value; } }
                    private Comune ComuneObj { get { return _comune; } set { _comune = value; } }
                    public Regione Regione { get { return _regione; } set { _regione = value; } }

                    public void CreateComune(string comuneName)
                    {
                        ComuneObj = new Comune(comuneName, this);
                    }
                    /*private void AddComune(Comune comune)
                    {
                        ComuneObj = comune;
                    }*/
                    public void ChangeComune(string nameComuneDest, string printText)
                    {
                        this.CreateComune(nameComuneDest);
                        printText += $" {nameComuneDest}.";
                        Console.WriteLine(printText);
                    }

                    //COMUNE
                    class Comune
                    {
                        string _nameComune;
                        //Abitante _abitante;
                        Provincia _provincia;

                        public Comune(string comuneName, Provincia provincia)
                        {
                            Name = comuneName;
                            Provincia = provincia;
                        }

                        public string Name 
                        { 
                            get { return _nameComune; } 
                            set { _nameComune = value; } 
                        }
                        //public Abitante Abitante { get { return _abitante; } set { _abitante = value; } }
                        public Provincia Provincia { get { return _provincia; } set { _provincia = value; } }

                        /*public void AddAbitante(Abitante abitante)
                        {
                            Abitante = abitante;
                        }*/

                        /*public void RemoveAbitante(Abitante abitante)
                        {
                            Abitante = null;
                        }*/
                    }
                }
            }
        }
    }
}
