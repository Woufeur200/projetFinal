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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientPage : Page
    {
        public ClientPage()
        {
            this.InitializeComponent();
            GestionBD.getInstance().getClients();
            myTableau.ItemsSource = GestionBD.getInstance().getListeClients();
        }

        private void myTableau_CellEditEnded(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridCellEditEndedEventArgs e)
        {
            GestionBD.getInstance().modifierClient((Client)myTableau.SelectedItem);
        }

        private void myTableau_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GestionBD.getInstance().ObjectSelected = myTableau.SelectedItem;
        }
    }
}
