using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombini.Jacopo._4H.Impegni
{
    class Program
    {
        static void Main(string[] args)
        {
            //inizializzazione variabili
            string nom, man, att;
            int dur;
            DateTime data;
            DateTime d=Convert.ToDateTime("14/03/2020");
            List<Impegno> listaI = new List<Impegno>();
            int scelta=100;
            
            //prime 3 liste
            listaI.Add(new Impegno("Ale", "Docente", "Descrizione Liste", 1,d));
            d = Convert.ToDateTime("11/02/2020");
            listaI.Add(new Impegno("Mirco", "Programmatore", "Sviluppo Liste", 2,d));
            d = Convert.ToDateTime("14/01/2020");
            listaI.Insert(0, new Impegno("Filippo", "Studente", "Studio", 3,d));
           
            //menù
            while (scelta !=0)
            {
                Console.WriteLine("////////////////////////////////////////////////////////////");
                Console.WriteLine("0- Esci dal programma");
                Console.WriteLine("1- Visualizza lista Impegni");
                Console.WriteLine("2- Aggiungi impegno");
                Console.WriteLine("3- Modifica avanzamento");
                Console.WriteLine("4- Stampa impegni conclusi");
                Console.WriteLine("5- Stampa impegni oltre a un certo avanzamento richiesto");
                Console.WriteLine("6- Stampa impegni antecedenti a data richiesta");
                Console.WriteLine("///////////////////////////////////////////////////////////");

                //richiamo funzioni 
                scelta =Convert.ToInt32(Console.ReadLine());
                switch(scelta)
                {
                    case 0:
                       break;
                    case 1:
                        visualizza();
                       break;
                    case 2:
                        inserisci();
                       break;
                    case 3:
                        modava();
                       break;
                    case 4:
                        disperc(100);
                       break;
                    case 5:
                        Console.WriteLine("Inserire nuova percentuale di completamento");
                        int a = Convert.ToInt32(Console.ReadLine());
                        disperc(a);
                       break;
                    case 6:
                        visdata();
                       break;
                }
            }

            //visualizza liste
            void visualizza()
            {
                Console.Clear();

                foreach (Impegno i in listaI)
                {
                    Console.Write("n."+listaI.IndexOf(i)+" ");
                    Console.WriteLine(i.ToString());
                    Console.WriteLine();
                }
                scelta = 100;
            }

            //inserisci nuova lista
            void inserisci()
            {
                Console.Clear();

                Console.WriteLine("inserisci il mome ");
                nom = Console.ReadLine();
                Console.WriteLine("inserisci mansione ");
                man = Console.ReadLine();
                Console.WriteLine("inserisci attività ");
                att = Console.ReadLine();
                Console.WriteLine("inserisci durata in ore ");
                dur = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("inserisci data inizio attività ");
                data = Convert.ToDateTime(Console.ReadLine());

                listaI.Add(new Impegno(nom, man, att, dur, data));
                scelta = 100;
            }

            //modifica l'avanzamento
            void modava()
            {
                Console.Clear();
                visualizza();

                int n = 0;
                int ava2 = 0;
                int ava1 = 0;

                bool b = false;
                while (b == false)
                {
                    Console.WriteLine("Quale impegno vuoi modificare?");
                    try
                    {
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Avanzamento attuale: { listaI[n].ava}");
                        b = true;
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine($"Numero massimo delle Liste: {listaI.Count}");
                        b = false;
                    }
                }
                b = false;

                while(b == false)
                {
                    Console.WriteLine("Qual é il nuovo stato di avanzamento?");
                    try
                    {
                         ava2 = Convert.ToInt32(Console.ReadLine());
                         ava1 = listaI[n].ava;

                        if (ava2 >= ava1 && ava2<= 100)
                        {
                            b = true;
                            listaI[n].ava = ava2;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Avanzamento non può essere inferiore al precedente e neanche superiore a 100");
                        b = false;
                    }
                }
                Console.Clear();
                scelta = 100;
            }
           
            //visualizza liste con impegni conclusi o oltre una certa soglia
            void disperc(int a)
            {
                Console.Clear();
                foreach (Impegno i in listaI)
                {
                    if (i.ava >= a)
                    {
                        Console.WriteLine(i.ToString());
                        Console.WriteLine();
                    }
                }
                scelta = 100;
            }

            //visualizza liste con impegni precedenti ad una certa data
            void visdata()
            {
                Console.Clear();
                Console.WriteLine("Quale data vuoi controllare?");
                DateTime da= Convert.ToDateTime(Console.ReadLine());
                foreach (Impegno k in listaI)
                {
                    int result = DateTime.Compare(k.dataInizio, da);
                   if (result <0)
                   {
                        Console.WriteLine(k.ToString());
                        Console.WriteLine();
                   }       
                }
                scelta = 100;
            }
            Console.Clear();
            Console.ReadKey();
        }
    }
}