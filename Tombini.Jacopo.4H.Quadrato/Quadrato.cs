using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombini.Jacopo._4H.Quadrato
{
    //Quadrato magico numero dispari
    public class Quadrato
    {
        int nmax;
        int vmin;
        int vmax;
        public int[,] q;
        public int r;
        public int c;
       
        //Costruttore
        public Quadrato(int numq, int vin, int vfi) //vin e vfi usate per il quadrato divisibile per 2
        {
            int nmin = 0;
            this.nmax = numq;
            c = nmax / 2;
            this.vmin = vin;
            this.vmax = vfi;
            int vatt = vmin;
            r = 0;
            this.q = new int[this.nmax, this.nmax];

            //Calcola il prossimo punto in base allo schema
            void NextP(int r2, int c2) 
            {
                int rhold = r2;
                int chold = c2;

                r2 -= 1;
                c2 += 1;

                if (r2 < nmin)
                {
                    r2 = this.nmax - 1;                    
                }
                if (c2 > this.nmax - 1)
                {
                    c2 = nmin;
                }
                if (this.q[r2, c2] > 0)
                {
                    r2 = rhold + 1;
                    c2 = chold;

                    if (r2 > this.nmax - 1)
                    {
                        r2 = nmin;
                    }
                }
                r = r2;
                c = c2;                
            }

            //Inserisce il primo numero
            this.q[r, c] = this.vmin; 
            vatt += 1;

            //Riempie il quadrato
            for (int i = vatt; i <= this.vmax; i++)
            {
                NextP(r, c);
                q[r, c] = i;                
            }
        }

        //Visualizza il quadrato in console
        public void visualizza() 
        {
              for(int i = 0; i<this.nmax; i++)
              {
                for (int j = 0; j<this.nmax; j++)
                {
                    if (this.q[i, j] <10)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" "+ this.q[i, j]);
                    if (j==this.nmax-1)
                    {
                        Console.WriteLine();
                    }
                }
              }         
        }
    }


    //Quadrato magico per numeri divisibili per 4
    public class Quadrato4
    {
        int nmax;
        public int[,] q4;
        int vatt;
       
        //Costruttore
        public Quadrato4(int n)
        {
            this.nmax = n;
            this.q4 = new int[this.nmax, this.nmax];

            //Modifica i valori dei numeri nelle diagonali dei sottoquadrati
            void cambia_diagonale(int i, int j) 
            {
                for (int x = 0; x < 4; x++)
                {
                    int a = this.q4[i + x, j + x];
                    this.q4[i + x, j + x] = (this.nmax * this.nmax) + 1 - a;
                    a = this.q4[i + 3 - x, j + x];
                    this.q4[i + 3 - x, j + x] = (this.nmax * this.nmax) + 1 - a;
                }
            }
            //Riempie il quadrato con numeri da 1 a n*n
            vatt = 1;
            for (int i = 0; i < this.nmax; i++)
            {
                for (int j = 0; j < this.nmax; j++)
                {
                    this.q4[i, j] = vatt;
                    vatt += 1;
                }
            }

            //Ciclo cambia i valori delle diagonali di tutti i sottoquadrati
            int cont1 = 0;
            int cont2 = 0;
            while (cont1 < this.nmax)
            {
                while (cont2 < this.nmax)
                {
                    cambia_diagonale(cont1, cont2);
                    cont2 = cont2 + 4;
                }
                cont1 = cont1 + 4;
            }
        }

        //Visualizza il quadrato in console
        public void visualizza4() 
        {
            for (int i = 0; i < this.nmax; i++)
            {
                for (int j = 0; j < this.nmax; j++)
                {
                    if (this.q4[i, j] < 10)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" " + this.q4[i, j]);
                    if (j == this.nmax - 1)
                    {
                            Console.WriteLine();
                    }
                }
            }
        }
        
    }

    //Quadrato magico per numeri divisibili per 2 e non per 4
    public class Quadrato2
    {
        int nmax;
        public int[,] q2;
        int k1;
        int k;

        //Costruttore
        public Quadrato2(int n)
        {
            this.nmax = n;
            this.q2 = new int[this.nmax, this.nmax];
            int v0 = this.nmax * this.nmax;
            int v1 = this.nmax / 2;
            int v2 = (this.nmax * this.nmax) / 4;
            int v3 = (this.nmax * this.nmax) / 2;
            int v4 = 3*(this.nmax * this.nmax) / 4;

            //Scambia i valori di una colonna tra due sottoquadrati
            void scambia_colonne (Quadrato h, Quadrato f, int y) 
            {
                for (int i = 0; i < this.nmax/2; i++)
                {
                    int vet1 = h.q[i, y];
                    int vet2 = f.q[i, y];
                    f.q[i, y] = vet1;
                    h.q[i, y] = vet2;
                }
            }
            //Scambia i valori di una cella tra due sottoquadrati
            void scambia_numero(Quadrato h, Quadrato f, int v,int w) 
            {
                int vet1 = h.q[v, w];
                h.q[v, w] = f.q[v, w];
                f.q[v, w] = vet1;
            }

            //Creo i sottoquadrati di ordine dispari
            Quadrato a = new Quadrato(v1, 1, v2);
            Quadrato b= new Quadrato(v1, v2+1, v3);
            Quadrato c = new Quadrato(v1, v3+1, v4);
            Quadrato d = new Quadrato(v1, v4+1, v0);
            k = ((this.nmax / 2) - 1) / 2; //Individua fattore K
            k1 = (this.nmax/2); //Dimensione sottoquadrato dispari 

            //Scambio prima colonne tra A e D
            scambia_colonne(a, d, k - 1); 
        
            if (k>1)
            {
                for (int i = 1; i < k; i++)
                {
                    scambia_colonne(c, b, k1-i); //Scambio ultime colonne tra C e B
                }              
            }
            int centro = (this.nmax / 2)/2; //Centro della colonna o riga

            scambia_numero(a, d, centro, 0);
            scambia_numero(a, d, centro, centro);

            //Trasferisco i valori dei sottoquadrati nel quadrato principale
            for (int i = 0; i < this.nmax; i++)
            {
                for (int j = 0; j < this.nmax; j++)
                {
                    if (i < this.nmax/2)
                    {
                        if (j < this.nmax / 2)
                        {
                            this.q2[i, j] = a.q[i, j];
                        }
                        else
                        {
                            this.q2[i, j] = c.q[i, j- this.nmax / 2];
                        }
                    }
                    else
                    {
                        if (j < this.nmax / 2)
                        {
                            this.q2[i, j] = d.q[i- this.nmax / 2, j];
                        }
                        else
                        {
                            this.q2[i, j] = b.q[i- this.nmax / 2, j- this.nmax / 2];
                        }
                    }
                }
            }

        }

        //Visualizza il quadrato in console
        public void visualizza2() 
        {
            for (int i = 0; i < this.nmax; i++)
            {
                for (int j = 0; j < this.nmax; j++)
                {
                    if (this.q2[i, j] < 10)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" " + this.q2[i, j]);
                    if (j == this.nmax - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}