using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tombini.Jacopo._4H.Vettore_Negozio.Negozio;

namespace Tombini.Jacopo._4H.Vettore_Negozio
{
    class Program
    {
        static void Main(string[] args)
        {
            //istanza delle variabili 
            int conv = 0;
            double diff = 0;
            double rif = 0;
            double min = 0;
            int Ns = 0; //NuovoSupermercato, creato durato l'esecuzione del programma                 
            int Nv = 0; //VecchioSupermercato, ovvero quelli caricati da file
            bool b = false;
            double pro = 0;
            Negozio[] super;
            ////double[] prezzi;

            //lettura da file
            try
            {
                Negozi negozi = new Negozi("file.csv");
                for (int i = 0; i < negozi.cor; i++)
                {
                    super = new Negozio[20];
                    Console.WriteLine(negozi.ANegozi[i].ToString());
                    super[i] = negozi.ANegozi[i];
                    Nv = i+1;
                }
            }          
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("");

            //inserimento di nuovi supermercati
            while (b == false)
            {
                Console.WriteLine("Quanti Supermercati vuoi inserire?");
                try
                {                   
                    Ns = Convert.ToInt32(Console.ReadLine());
                    b = true;
                }
                catch (System.Exception e)
                {
                    b = false;
                }
            }

            Ns = Ns + Nv;
            super = new Negozio[Ns];
           
            //inserimento attributi di super
            for (int i = Nv; i < super.Length; i++)
            {
                super[i] = new Negozio();

                Console.WriteLine("");

                Console.WriteLine("Inserisci il nome del Supermercato " + i);
                
                super[i].nom = Console.ReadLine();

                Console.WriteLine("");

                Console.WriteLine("Inserisci l'indirizzo del Supermercato " + i);
                super[i].ind = Console.ReadLine();

                Console.WriteLine("");

                Console.WriteLine("Inserisci la città del Supermercato " + i);
                super[i].cit = Console.ReadLine();

                Console.WriteLine("");

                //ciclo per controllo validità prezzo
                b = false;
                while (b == false)
                {
                    Console.WriteLine("Prezzo del prodotto per il supermercato " + super[i].nom + " Se il prodotto non è presente inserire 0");
                    try
                    {
                        super[i].prez = Console.ReadLine();
                        pro = Double.Parse(super[i].prez);
                        b = true;
                    }
                    catch (System.Exception e)
                    {
                        b = false;
                    }
                }                       
            }

            //controllo prezzo minore
            super[0] = new Negozio();
            min = Double.Parse(super[0].prez);

            for (int i = 1; i < super.Length; i++)
            {
                if (Double.Parse(super[i].prez) < min)
                {
                    min = Double.Parse(super[i].prez);
                    conv = i;
                }
            }

            Console.WriteLine("");

            Console.WriteLine("Il prezzo minore è " + min + " nel supermercato:");
            Console.WriteLine(super[conv].nom);
            Console.WriteLine(super[conv].ind);
            Console.WriteLine(super[conv].cit);

            Console.WriteLine("");

            //inserimento valore di riferimento
            Console.Write("Inserisci valore di riferimento ");
            rif = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");

            //confronto tra valori
            for (int i = 0; i < super.Length; i++)
            {
                diff = Double.Parse(super[i].prez) - rif;
                Console.WriteLine("La differenza di prezzo del supermercato " + super[i].nom + " rispetto " + rif + " è: " + diff);
            }

            Console.WriteLine("");

            //controllo supermercati con prezzi più bassi di rif
            Console.WriteLine("I supermercati con prezzi più bassi di " + rif + " sono: ");
            for (int i = 0; i < super.Length; i++)
            {
                diff = Double.Parse(super[i].prez) - rif;
                if (diff < 0)
                {
                    Console.WriteLine(super[conv].nom);
                    Console.WriteLine(super[conv].ind);
                    Console.WriteLine(super[conv].cit);

                    Console.WriteLine(" ");
                }
            }
            Console.ReadKey();
        }
    }
}
