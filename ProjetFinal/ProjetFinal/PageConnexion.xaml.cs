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
    public sealed partial class PageConnexion : Page
    {
        //MainPage objclass1 = new MainPage();
        public PageConnexion()
        {
            this.InitializeComponent();

        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {

            if (GestionBD.getInstance().login(txtUserName.Text, pwdPassword.Password) == 1)
            {
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                Frame.Navigate(typeof(PageConnexion));
            }
        }
    }
}
