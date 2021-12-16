using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjetFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string whatFrame = "";
        public MainPage()
        {
            this.InitializeComponent();
            btRemove.Visibility = Visibility.Collapsed;
            mainFrame.Navigate(typeof(PretPage));
        }

        private async void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (whatFrame.Equals("C"))
            {
                ContentDialog contentDialogClient = new ClientContent();
                await contentDialogClient.ShowAsync();
            }
            else if (whatFrame.Equals("M"))
            {
                ContentDialog contentDialogMateriel = new MaterielContent();
                await contentDialogMateriel.ShowAsync();
            }
            else if (whatFrame.Equals("U"))
            {
                ContentDialog contentDialogUtilisateur = new UtilisateurContent();
                await contentDialogUtilisateur.ShowAsync();
            }
            else if (whatFrame.Equals("P"))
            {
                mainFrame.Navigate(typeof(PretAjouter));
            }
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if(whatFrame.Equals("C"))
            {
                Client c = (Client)GestionBD.getInstance().ObjectSelected;
                GestionBD.getInstance().deleteClient(c);
            }
            else if (whatFrame.Equals("M"))
            {
                Materiel m = (Materiel)GestionBD.getInstance().ObjectSelected;
                GestionBD.getInstance().deleteMateriel(m);
            }
            else if (whatFrame.Equals("U"))
            {
                Utilisateur u = (Utilisateur)GestionBD.getInstance().ObjectSelected;
                GestionBD.getInstance().deleteUtilisateur(u);
            }
            else if (whatFrame.Equals("P"))
            {
                Pret p = (Pret)GestionBD.getInstance().ObjectSelected;
                GestionBD.getInstance().deletePret(p);
            }
        }


        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.CanGoBack)
            {
                mainFrame.GoBack();
            }

        }

        private void btClient_Click(object sender, RoutedEventArgs e)
        {
            whatFrame = "C";
            btRemove.Visibility = Visibility.Visible;
            mainFrame.Navigate(typeof(ClientPage));
        }

        private void btMateriel_Click(object sender, RoutedEventArgs e)
        {
            whatFrame = "M";
            btRemove.Visibility = Visibility.Visible;
            mainFrame.Navigate(typeof(MaterielPage));
        }

        private void btPret_Click(object sender, RoutedEventArgs e)
        {
            whatFrame = "P";
            btRemove.Visibility = Visibility.Collapsed;
            mainFrame.Navigate(typeof(PretPage));
        }

        private void btUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            whatFrame = "U";
            btRemove.Visibility = Visibility.Visible;

            mainFrame.Navigate(typeof(UtilisateurPage));
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            GestionBD.getInstance().logout();
            Frame.Navigate(typeof(PageConnexion));
        }
    }
}
