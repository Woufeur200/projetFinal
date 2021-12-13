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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetFinal
{
    public sealed partial class MaterielContent : ContentDialog
    {
        public MaterielContent()
        {
            this.InitializeComponent();
            this.IsPrimaryButtonEnabled = false;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(this.tBox5.Text == "")
            {
                tBox5.Text = "Aucune Note";
            }
            Materiel m = new Materiel(this.tBox1.Text, this.tBox2.Text, this.tBox3.Text, this.tBox4.Text, this.tBox5.Text);

            GestionBD.getInstance().ajouterMateriel(m);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void tBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tBox1.Text == "")
            {
                tBox1_Warning.Visibility = Visibility.Visible;
                this.IsPrimaryButtonEnabled = false;
            }

            else
            {
                tBox1_Warning.Visibility = Visibility.Collapsed;
                if (tBox1.Text != "" && tBox2.Text != "" && tBox3.Text != "" && tBox4.Text != "" && tBox5.Text != "")
                {
                    this.IsPrimaryButtonEnabled = true;
                }
            }
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
                if (tBox1.Text != "" && tBox2.Text != "" && tBox3.Text != "" && tBox4.Text != "" && tBox5.Text != "")
                {
                    this.IsPrimaryButtonEnabled = true;
                }
            }
        }

        private void tBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tBox3.Text == "")
            {
                tBox3_Warning.Visibility = Visibility.Visible;
                this.IsPrimaryButtonEnabled = false;
            }

            else
            {
                tBox3_Warning.Visibility = Visibility.Collapsed;
                if (tBox1.Text != "" && tBox2.Text != "" && tBox3.Text != "" && tBox4.Text != "" )
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
                if (tBox1.Text != "" && tBox2.Text != "" && tBox3.Text != "" && tBox4.Text != "" )
                {
                    this.IsPrimaryButtonEnabled = true;
                }
            }
        }

        private void tBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
                if (tBox1.Text != "" && tBox2.Text != "" && tBox3.Text != "" && tBox4.Text != "" )
                {
                    this.IsPrimaryButtonEnabled = true;
                }

                
            
        }
    }
}
