# RubricaWpf
**Programma C# per la creazione di una rubrica**
## Problema assegnato:
Ci è stato assegnato di creare una rubrica che, prendendo dei valori da un file .csv li ordini in modo corretto, evidenziando possibili errori.

## Creazione a grandi linee

Abbiamo creato un file .csv il quale contiene tutti i dati basilari di un contatto (nome, cognome, telefono...) ed anche una Primary Key fissa, la quale sarà il "id" del nostro contatto.
```
PK;Nome;Cognome;Telefono;CAP;EMail
0;Sanpatrizio;Giacobini;3363377865;45678;sanpatrizio.giacobini@gmail.com
1;Nicholas;Marconi;3313384563;45672;nicholas.marconi@studenti.ittsrimini.edu.it  
```
Abbiamo anche creato una classe (chiamata in questo caso contatto) la quale tramite dei get e set prende i valori da noi indicati nel file .csv e crea il contatto.
```C#
internal class Contatto
{
    private int numero;
    private string nome;
    private string _cognome;
    public int Numero
    {
        get{ return numero; }
        set{ if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException();
            else
                numero = value;
          }
    }

    public string Nome { get; set; }
    public string Cognome { get => _cognome; set => _cognome = value; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Citta; 
    public string Cap { get; set; }

    public Contatto(string riga)
    {
        string[] campi = riga.Split(";");
        if (campi.Length >= 5)
            this.Nome = campi[1];
            this.Cognome = campi[2];
            this.Telefono = campi[3];
            this.Cap = campi[4];
            this.Email = campi[5];

            int PK = 0;
            int.TryParse(campi[0], out PK);
            this.Numero = PK;
            this.Numero = 0;
    }
```
In contemporanea abbiamo creato un altro file, nel quale abbiamo creato la nostra rubrica vuota costituita da MAX 100 elementi che, prima prende ogni valore dal file .csv e lo mette nella rubrica.

```C#
public partial class MainWindow : Window
{
    public MainWindow()
    { InitializeComponent(); }

    private void NicholasWindowLoaded(object sender, RoutedEventArgs e)
    {
        int idx = 0;
        try
        {
            const int MAX = 100;
            StreamReader fileingresso = new StreamReader("Dati.csv");  
            fileingresso.ReadLine();
            Contatto[] Contatti = new Contatto[MAX];
             idx = 0;

            while (!fileingresso.EndOfStream)
            {
                if (idx < MAX)
                  string riga = fileingresso.ReadLine(); 
                  Contatto c = new Contatto(riga); 
                  Contatti[idx++] = c;         
                else
                  break;
            }

            for(; idx < MAX; idx++)
            {
                Contatto c = new Contatto();
                c.Numero = idx;
                Contatti[idx] = c;
            }
            dgDati.ItemsSource = Contatti;
        }
        catch (Exception erore)
        {
            MessageBox.Show($"no no! \n + {erore.Message} \n alla riga numero {idx}");
        }
    }
```

Poi controlla gli spazi restanti e crea dei contatti vuoti. Bisogna ricordare che ogni volta controla controlla se il contatto sia generato bene o meno e in caso colora le stringhe.

```C# 
    private void dgDati_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        Contatto contatto = e.Row.Item as Contatto;
        if (contatto != null)
            if(contatto.Numero == 0)
                e.Row.Background = Brushes.Blue;
                e.Row.Foreground = Brushes.White;
    }
```
