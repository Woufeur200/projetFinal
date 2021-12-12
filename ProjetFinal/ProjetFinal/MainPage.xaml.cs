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
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if(whatFrame.Equals("C"))
            {
                //GestionBD.getInstance().deleteClient((Client)myTableau.SelectedItem);
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {

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
            mainFrame.Navigate(typeof(ClientPage));
        }

        private void btMateriel_Click(object sender, RoutedEventArgs e)
        {
            whatFrame = "M";
            mainFrame.Navigate(typeof(MaterielPage));
        }

        private void btPret_Click(object sender, RoutedEventArgs e)
        {
            whatFrame = "P";
            mainFrame.Navigate(typeof(PretPage));
        }

        private void btUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            whatFrame = "U";
            mainFrame.Navigate(typeof(UtilisateurPage));
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            GestionBD.getInstance().logout();
            Frame.Navigate(typeof(PageConnexion));
        }
    }
}
