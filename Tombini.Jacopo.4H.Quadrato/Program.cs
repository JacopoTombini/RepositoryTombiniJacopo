using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombini.Jacopo._4H.Quadrato
{
    class Program
    {
        static void Main(string[] args)
        {
            int num=1;
            int b;
            bool m = false;

            while (num !=0)
            {
                 //Controllo validità del numero
                 m = false;
                 while(m == false)
                 {
                    Console.WriteLine("Inserisci un numero per formare un quadrato magico, 0 per uscire");
                    try
                    {
                        num = Convert.ToInt32(Console.ReadLine());
                        if (num > 0 && num < 3)
                        {
                            m = false;
                            Console.WriteLine("Inserire numero > di 2");
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            m = true;
                        }                       
                    }
                    catch (Exception e)
                    {
                        m = false;
                    }
                 }                                              
                 b = num * num;

                //Controllo per la formazione del quadrato in base al numero inserito
                if (num % 2 == 0)
                {
                    if (num % 4 == 0)
                    {
                        Quadrato4 a = new Quadrato4(num);
                        a.visualizza4();                       
                    }
                    else
                    {
                        Quadrato2 a = new Quadrato2(num);
                        a.visualizza2();
                    }
                }
                else
                {
                    Quadrato a = new Quadrato(num, 1, b);
                    a.visualizza();
                }
                Console.WriteLine(" ");
            }
            Console.ReadKey();
        }       
    }
}