 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marconi.nicholas._4i.rubricaWPF
{
    internal class Contatto
    {
        private int numero;
        private string nome;
        private string _cognome; //**questa qua

        public int Numero
        {
            get  //per prendere il valore sottinterso
            {
                return numero;
            }

            set //per scrivere il valore sottinteso
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    numero = value;
                }

            }
        }

        public string Nome { get; set; } //Proprety
        public string Cognome { get => _cognome; set => _cognome = value; } //prende i valori sopra **
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Citta { get; set; } //è un campo, NON USARE MAI!!!!!!!!!
        public string Cap { get; set; }
        public Contatto() { } //costruttore1 
        public Contatto(string riga)  //costruisce (costruttore) un contatto partendo da una riga csv
        {
            //costruisce un Contatto partendo dalla riga del CSV
            string[] campi = riga.Split(";"); //separo la riga che ottengo usando il ; nel quale vettore c'è un valore
            //controlla che il contatto abbia ogni valore necessario.
            if (campi.Length >= 5) //CAPISCI COSA FA
            {
                this.Nome = campi[1];
                this.Cognome = campi[2];
                this.Telefono = campi[3];
                this.Cap = campi[4];
                this.Email = campi[5];

                int PK = 0;
                int.TryParse(campi[0], out PK); //il Parse in generale prova ad interpretare la stringa che gli      //.TryParse prova a trasformarlo in un tipo che gli diciamo  prima e lo rilascia in una variabile.
                this.Numero = PK;
                this.Numero = 0;
                
            }
        }
        //public Contatto(int numero, string nome, string cognome)  //costruttore standard
        //{
        //    Numero = numero;
        //    Nome = nome;
        //    Cognome = cognome;
        //}

       
    }
}