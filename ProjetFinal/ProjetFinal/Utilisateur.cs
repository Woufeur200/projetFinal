using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Utilisateur
    {
        string username;
        string nom;
        string prenom;
        string password;


        public Utilisateur()
        { 
            this.username = "";
            this.nom = "";
            this.prenom = "";
            this.password = "";
        }
        public Utilisateur(string username, string nom, string prenom, string password)
        {
            this.username = username;
            this.nom = nom;
            this.prenom = prenom;
            this.Password = password;
        }

        public string Username {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }
        public string Nom { 
            get => nom;
            set
            {
                nom = value;
                OnPropertyChanged();
            }
        }
        public string Prenom
        {
            get => prenom;
            set
            {
                prenom = value;
                OnPropertyChanged();
            }
        }
        public string Password { 
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString()
        {
            return   this.username + ";" + this.nom + ";" + this.prenom + ";" + this.password;
        }
    }
}
