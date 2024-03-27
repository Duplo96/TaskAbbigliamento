using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskAbbigliamento.DAL;
using TaskAbbigliamento.Models;

namespace TaskAbbigliamento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listaUtenti.ItemsSource = UtenteDAL.getIstance().GetAll();
            listaCategoria.ItemsSource=CategoriumDAL.getIstance().GetAll(); 
            listaPrezzo.ItemsSource=PrezzoDAL.getIstance().GetAll();
        }
        #region Utenti
        private void Salva_Click(object sender, RoutedEventArgs e)
        {
            string? nome = this.txtNome.Text;
            string? cognome = this.txtCognome.Text;
            string? telefono = this.txtTelefono.Text;
            string? email = this.txtEmail.Text;
            string? nomeUtente = this.txtNomeUtente.Text;

            Utente u = new Utente()
            {
                Nome = nome,
                Cognome = cognome,
                Telefono = telefono,
                Email = email,
                NomeUtente = nomeUtente
            };
            if (UtenteDAL.getIstance().Insert(u))
            {
                MessageBox.Show("tutto ok");
                listaUtenti.ItemsSource = UtenteDAL.getIstance().GetAll();

            }
            else
                MessageBox.Show("Errore di inserimento");

            this.txtNome.Text = "";
            this.txtCognome.Text = "";
            this.txtTelefono.Text = "";
            this.txtEmail.Text = "";
            this.txtNomeUtente.Text = "";

        }

        private void Elimina_Click(object sender, RoutedEventArgs e)
        {
            
            Button? button = sender as Button;

            
            if (button != null && button.DataContext is Utente)
            {
          
                Utente? utenteDaEliminare = button.DataContext as Utente;

               
                if (UtenteDAL.getIstance().Delete(utenteDaEliminare))
                {
                   
                    listaUtenti.ItemsSource = UtenteDAL.getIstance().GetAll();

                  
                    MessageBox.Show("Utente eliminato con successo.");
                }
                else
                {
                   
                    MessageBox.Show("Errore durante l'eliminazione dell'utente.");
                }
            }
        }

        private void Modifica_Click(object sender, RoutedEventArgs e)
        {

            Button? button = sender as Button;


            if (button != null && button.DataContext is Utente)
            {

                Utente? utenteDaModificare= button.DataContext as Utente;


                if (UtenteDAL.getIstance().Update(utenteDaModificare))
                {

                    listaUtenti.ItemsSource = UtenteDAL.getIstance().GetAll();


                    MessageBox.Show("Utente modificato con successo.");
                }
                else
                {

                    MessageBox.Show("Errore durante la modifica dell'utente.");
                }
            }
        }
        #endregion

        #region Categoria
        private void SalvaCat_Click(object sender, RoutedEventArgs e)
        {
            string? nomeCat = this.txtNomeCategoria.Text;
        

            Categorium c = new Categorium()
            {
                NomeCategoria= nomeCat,
            };
            if (CategoriumDAL.getIstance().Insert(c))
            {
                MessageBox.Show("tutto ok");
                listaCategoria.ItemsSource = CategoriumDAL.getIstance().GetAll();

            }
            else
                MessageBox.Show("Errore di inserimento");

            this.txtNomeCategoria.Text = "";
            

        }
        private void EliminaCat_Click(object sender, RoutedEventArgs e)
        {

            Button? button = sender as Button;


            if (button != null && button.DataContext is Categorium)
            {

                Categorium? categoriaDaEliminare = button.DataContext as Categorium;


                if (CategoriumDAL.getIstance().Delete(categoriaDaEliminare))
                {

                    listaCategoria.ItemsSource = CategoriumDAL.getIstance().GetAll();


                    MessageBox.Show("Categoria eliminat con successo.");
                }
                else
                {

                    MessageBox.Show("Errore durante l'eliminazione della Categoria.");
                }
            }
        }
        private void ModificaCat_Click(object sender, RoutedEventArgs e)
        {

            Button? button = sender as Button;


            if (button != null && button.DataContext is Categorium)
            {

                Categorium? categoriaDaModificare = button.DataContext as Categorium;


                if (CategoriumDAL.getIstance().Update(categoriaDaModificare))
                {

                    listaCategoria.ItemsSource = UtenteDAL.getIstance().GetAll();


                    MessageBox.Show("Utente modificato con successo.");
                }
                else
                {

                    MessageBox.Show("Errore durante la modifica dell'utente.");
                }
            }
        }

        #endregion
        #region Prezzo

        private void SalvaPrz_Click(object sender, RoutedEventArgs e)
        {
           decimal prezzoPieno = 


         



            Prezzo v = new Prezzo()
            {

                
                
            };
            if (PrezzoDAL.getIstance().Insert(p))
            {
                MessageBox.Show("tutto ok");
                listaPrezzo.ItemsSource = PrezzoDAL.getIstance().GetAll();

            }
            else
                MessageBox.Show("Errore di inserimento");

            this.txtNomeCategoria.Text = "";


        }
        //private void EliminaPrz_Click(object sender, RoutedEventArgs e)
        //{

        //    Button? button = sender as Button;


        //    if (button != null && button.DataContext is Categorium)
        //    {

        //        Categorium? categoriaDaEliminare = button.DataContext as Categorium;


        //        if (CategoriumDAL.getIstance().Delete(categoriaDaEliminare))
        //        {

        //            listaCategoria.ItemsSource = CategoriumDAL.getIstance().GetAll();


        //            MessageBox.Show("Categoria eliminat con successo.");
        //        }
        //        else
        //        {

        //            MessageBox.Show("Errore durante l'eliminazione della Categoria.");
        //        }
        //    }
        //}
        //private void ModificaPrz_Click(object sender, RoutedEventArgs e)
        //{

        //    Button? button = sender as Button;


        //    if (button != null && button.DataContext is Categorium)
        //    {

        //        Categorium? categoriaDaModificare = button.DataContext as Categorium;


        //        if (CategoriumDAL.getIstance().Update(categoriaDaModificare))
        //        {

        //            listaCategoria.ItemsSource = UtenteDAL.getIstance().GetAll();


        //            MessageBox.Show("Utente modificato con successo.");
        //        }
        //        else
        //        {

        //            MessageBox.Show("Errore durante la modifica dell'utente.");
        //        }
        //    }
        //}


        #endregion





    }
}