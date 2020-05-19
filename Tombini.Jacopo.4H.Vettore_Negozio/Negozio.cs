using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombini.Jacopo._4H.Vettore_Negozio
{
    public class Negozio
    {
        //attributi della classe
        public string nom { get; set; }
        public string ind { get; set; }
        public string cit { get; set; }
        public string prez { get; set; }

        //costruttore di default
        public Negozio()
        {
            nom = "Conad";
            ind = "via";
            cit = "jkh";
            prez = "5";
        }

        //costruttore che prende in ingresso il parametro, splitta i dati
        public Negozio(string negozio)
        {
            string[] dati = negozio.Split(';');
            if (dati.Length == 4)
            {
                nom = dati[0];
                ind = dati[1];
                cit = dati[2];
                prez = dati[3];
            }
            else
                throw new Exception("Errore");
        }

        //inserimento attributi in stringa
        public override string ToString()
        {
            return $"Nome: {nom}, Via: {ind}, Città: {cit}, Prezzo: {prez}";
        }

        //instanziamento classe Negozi 
        public class Negozi
        {
            public int maxDim = 6;

            public int cor;

            public Negozio[] ANegozi;

            //costruttore di default
            public Negozi() : this(5)
            {

            }

            //costruttore prende in ingresso dim
            public Negozi(int dim)
            {
                cor = 0;
                maxDim = dim;
                ANegozi = new Negozio[dim];
            }

            //creazione streamreader
            public Negozi(string fileName) :this(20)
            {
                StreamReader fileIn = new StreamReader(fileName);
                string riga = fileIn.ReadLine();
                string[] colonne = riga.Split(';');
                int nCol = colonne.Length; 

                while (!fileIn.EndOfStream)
                {
                    riga = fileIn.ReadLine();
                    ANegozi[cor] = (new Negozio(riga));
                    cor++;
                }
                fileIn.Close();
            }
        }
    }
}
