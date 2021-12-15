using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PretAjouter : Page
    {
        int jourHeure = 1;
            string userActive, numPhone, materiel;
        Client myClient;
        Materiel myMateriel;
        ObservableCollection<Materiel> listeMateriel;
        Pret myPret;
        int index = 0;
        public PretAjouter()
        {
            this.InitializeComponent();
            btnSuivant.IsEnabled = false;
            abMateriel.IsEnabled = false;

            listeMateriel = new ObservableCollection<Materiel>();
            grille.ItemsSource = listeMateriel;

        }

        private void ab1_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            ab1.ItemsSource = GestionBD.getInstance().rechercheClient(ab1.Text);
        }

        private void ab1_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            myClient = (Client)args.SelectedItem;
            btnSuivant.IsEnabled = true;
        }

        private void mySwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch.IsOn)
            {
                tbDuree.Header = "Nombre d'heures";
                jourHeure = 0;
            }
            else
            {
                tbDuree.Header = "Nombre de jours";
                jourHeure = 1;
            }
        }


        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            string retour = "";

            DateTime myDate;

            if(jourHeure == 0)
            {
                myDate = DateTime.Now.AddHours(Convert.ToInt32(tbDuree.Text));
                retour = myDate.ToString("yyyy-MM-dd");
            }
            if(jourHeure == 1)
            {
                myDate = DateTime.Now.AddDays(Convert.ToInt32(tbDuree.Text));
                retour = myDate.ToString("yyyy-MM-dd");
            }
            myPret = new Pret(myClient.IdClient, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("hh:mm"), retour, GestionBD.getInstance().getUsername(), "Emprunté");

            abMateriel.IsEnabled = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            GestionBD.getInstance().ajouterPret(myPret, listeMateriel);
            this.Frame.Navigate(typeof(PretPage));

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            listeMateriel.RemoveAt(index);
            btnDelete.IsEnabled = false;
        }

        private void grille_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
            index = grille.SelectedIndex;
        }

        private void abMateriel_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            abMateriel.ItemsSource = GestionBD.getInstance().rechercheMateriel(abMateriel.Text);
        }

        private void abMateriel_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            myMateriel = (Materiel)args.SelectedItem;
            listeMateriel.Add(myMateriel);

            btnAdd.IsEnabled = true;
            abMateriel.Text = "";
        }
    }
}
