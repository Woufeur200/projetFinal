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
using System.Text.RegularExpressions;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetFinal
{
    public sealed partial class ClientContent : ContentDialog
    {
            string expression = "cegeptr.qc.ca$";
        public ClientContent()
        {
            this.InitializeComponent();
            this.IsPrimaryButtonEnabled = false;
            tBox6.Visibility = Visibility.Collapsed;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Client f;
            if (GetSelectedComboboxText() == "Employé")
                f = new Client (this.tBox2.Text, this.tBox3.Text, this.tBox4.Text, this.tBox5.Text, Int32.Parse(this.tBox6.Text),GetSelectedComboboxText());
            else
                f = new Client (this.tBox2.Text, this.tBox3.Text, this.tBox4.Text, this.tBox5.Text, GetSelectedComboboxText());
            GestionBD.getInstance().ajouterClient(f);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
        private void tBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tBox2.Text == "")
            {
                tBox2_Warning.Visibility = Visibility.Visible;
                this.IsPrimaryButtonEnabled = false;
            }
            else
            {
                tBox2_Warning.Visibility = Visibility.Collapsed;
                if (tBox3.Text != "" && tBox4.Text != "")
                {
                    this.IsPrimaryButtonEnabled = true;
                }

            }
            if (Regex.IsMatch(tBox3.Text, expression))
                tBox3_Warning.Visibility = Visibility.Collapsed;
            else
                tBox3_Warning.Visibility = Visibility.Visible;
        }

        private void tBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (tBox3.Text == "")
            {
                tBox3_Warning.Text = "L'email ne peux pas être vide.";
                tBox3_Warning.Visibility = Visibility.Visible;
                this.IsPrimaryButtonEnabled = false;
            }
            else
            {
                tBox3_Warning.Visibility = Visibility.Collapsed;
                if (tBox2.Text != "" && tBox4.Text != "" )
                {
                    this.IsPrimaryButtonEnabled = true;
                }

            }
        }

        private void tBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tBox4.Text == "")
            {
                tBox4_Warning.Visibility = Visibility.Visible;
                this.IsPrimaryButtonEnabled = false;
            }
            else
            {
                tBox4_Warning.Visibility = Visibility.Collapsed;
                if (tBox2.Text != "" && tBox3.Text != "" )
                {
                    this.IsPrimaryButtonEnabled = true;
                }

            }
        }

        private void tBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tBox5.Text == "")
            {
                tBox5_Warning.Visibility = Visibility.Visible;
                this.IsPrimaryButtonEnabled = false;
            }
            else
            {
                tBox5_Warning.Visibility = Visibility.Collapsed;
                if (tBox2.Text != "" && tBox3.Text != "" )
                {
                    this.IsPrimaryButtonEnabled = true;
                }

            }
        }

        private void tBox6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tBox6.Text == "")
            {
                tBox6_Warning.Visibility = Visibility.Visible;
                this.IsPrimaryButtonEnabled = false;
            }
            else
            {
                tBox6_Warning.Visibility = Visibility.Collapsed;
                if (tBox2.Text != "" && tBox3.Text != "" && tBox4.Text != "")
                {
                    this.IsPrimaryButtonEnabled = true;
                }

            }
        }
        public string GetSelectedComboboxText()
        {
            var item = (this.tBox7.SelectedItem as ComboBoxItem);
            return item.Content.ToString();
        }
        private void tBox7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GetSelectedComboboxText() == "Employé")
                tBox6.Visibility = Visibility.Visible;
            else
                tBox6.Visibility = Visibility.Collapsed;

        }
    }
}
