using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace marconi.nicholas._4i.rubricaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() //Costruttore di "MainWindow.xaml"
        {
            InitializeComponent(); //

        }
        private void NicholasWindowLoaded(object sender, RoutedEventArgs e)
        {
            int idx = 0;
            try
            { //provo ad aprire il file
                const int MAX = 100;
                StreamReader fileingresso = new StreamReader("Dati.csv"); // per collegare il file .csv a al nostro  xamel, invia i  dati 
                fileingresso.ReadLine(); // mangia direttamtente la prima riga. (quella con nome;email)
                Contatto[] Contatti = new Contatto[MAX]; // Creiamo un vettore di Contatti con una capacità massima di 100 elementi

                //for (int i = 0; i < Contatti.Length; i++) //percorre tutti gli elementi del vettore precendente
                //{
                //    Contatti[i] = new Contatto(); //creo a ogni posizione un contatto vuoto in modo che funzioni
                //}
                 idx = 0; 
            //foreach(Contatto c in Contatti)             // creo cento contatti vuoti
            //        Contatti[idx++] = new Contatto(); 

               

                //dato che creo cento posti vuoti, e non è detto che li utilizzo tutti non è ottimizzato
                while (!fileingresso.EndOfStream)  // EndOfStream mentre è in funzione è false, e quando completa il tutto è true 
                {
                    if (idx < MAX) // serve per fargli fare solamente il numero neccessario di posti
                    {

                        string riga = fileingresso.ReadLine(); //ritorna una stringa (potrebbe tornare un null...), al suo interno legge la prima riga di .csv
                                                               // ogni volta che richiamo readline mi prende una riga sottostante
                        Contatto c = new Contatto(riga); // creo un contato che gestirà direttamtente riga.     
                        Contatti[idx++] = c; //prima scrive poi incementa            
                    }
                    else
                    { break; }
                }

                //inserisce contatti vuoti ai restanti posti dell'idx
                for(; idx < MAX; idx++) {
                    Contatto c = new Contatto();
                    c.Numero = idx;
                    Contatti[idx] = c;
                }
                dgDati.ItemsSource = Contatti;
            }
            catch (Exception erore)
            {
                MessageBox.Show($"no no! \n + {erore.Message} \n alla riga numero {idx}"); //se non ci riesce mostra errore
            }

         




            //abbiamo cavato il tutto pk  facciamo fare tutto al contatto

            /*
            try
            {
                // Inizializziamo un oggetto Contatto chiamato c
                Contatto c = new Contatto(); //costruttore

                c.Numero = 1;
                c.Nome = "Nicholas";
                c.Cognome = "Marconi";
                c.Email = "Pekka.mini5@gmail.com";
                c.Telefono = "33389715677";
                c.Cap = "57923"
            ;

                // Assegniamo c all'elemento 0 del vettore Contatti
                Contatti[0] = c;

                // Creiamo un altro oggetto Contatto c1 in modo più conciso
                Contatto c1 = new Contatto
                {
                    Numero = 2,
                    Nome = "Piero",
                    Cognome = "Razzo"
                };

                // Assegniamo c1 all'elemento 1 del vettore Contatti
                Contatti[1] = c1;

                // Creiamo un altro oggetto Contatto c2 in modo più conciso
                Contatto c2 = new Contatto
                {
                    Numero = 3, // Modificato il numero
                    Nome = "Antonio",
                    Cognome = "Razzo"
                };

                // Assegniamo c2 all'elemento 2 del vettore Contatti
                Contatti[2] = c2;
            }
            catch (Exception err)
            {
                MessageBox.Show("Errore: " + err.Message); // Mostra un messaggio di errore in caso di eccezione
            }
            */



        }
        //ogni volta che prende una riga mi  richiama
        private void dgDati_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Contatto contatto = e.Row.Item as Contatto; //se trova un contatto me lo inserirsce in c, altrimenti inserisce un null
            if (contatto != null)
            {
                if(contatto.Numero == 0)
                    e.Row.Background = Brushes.Blue;
                    e.Row.Foreground = Brushes.White;
            }
            
        }
    }
}
