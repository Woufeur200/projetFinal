﻿using System;
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
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btForward_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btClient_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(ClientPage));
        }

        private void btMateriel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btPret_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btUtilisateur_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
