using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombini.Jacopo._4H.Impegni
{
    public class Impegno
    {
        //attributi
        public string nomeDipendente { get; set; } 
        public string mansione { get; set; }
        public string descrizioneAttivita { get; set; }
        public int durataOre { get; set; } //Stabilita a priori
        public DateTime dataInizio { get; set; }
        public int ava { get; set; }

        //costruttore
        public Impegno()
        {
            nomeDipendente = "A";
            mansione = "impiegato";
            descrizioneAttivita = "contabilità stipendi aprile";
            durataOre = 0;
            dataInizio = new DateTime(2020, 1, 1);
            ava = 0;
        }

        //costruttore
        public Impegno(string nomeDipendente, string mansione, string descrizioneAttivita, int durataOre, DateTime dataInizio)
        {
            this.nomeDipendente = nomeDipendente;
            this.mansione = mansione;
            this.descrizioneAttivita = descrizioneAttivita;
            this.durataOre = durataOre;
            this.dataInizio=dataInizio;
        }

        //metodo per scrittura dati
        public override string ToString()
        {
            return $"Dipendente: {nomeDipendente}; Masione: {mansione}; Atività: {descrizioneAttivita};\n Durata attività: {durataOre} Ore;\n Avanzamento: {ava} %;\n Data inizio: {dataInizio}";
        }
    
        public void stampa()
        {
           
        }
    }


    public class Impegni : List<Impegno>
    {

    }
}
