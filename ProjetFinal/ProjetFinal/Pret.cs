using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Pret
    {
        int idPret;
        int idClient;
        string datePret;
        string timePret;
        string returnDate;
        string username;
        string statePret;


        public Pret()
        {
            this.idPret = 0;
            this.idClient = 0;
            this.datePret = "";
            this.timePret = "";
            this.returnDate = "";
            this.username = "";
            this.statePret = "";
        }
        public Pret(int idPret, int idClient, string datePret, string timePret, string returnDate, string username, string statePret)
        {
            this.idPret = idPret;
            this.idClient = idClient;
            this.datePret = datePret;
            this.timePret = timePret;
            this.returnDate = returnDate;
            this.username = username;
            this.statePret = statePret;
        }
        public Pret(int idClient, string datePret, string timePret, string returnDate, string username, string statePret)
        {
            this.idPret = 0;
            this.idClient = idClient;
            this.datePret = datePret;
            this.timePret = timePret;
            this.returnDate = returnDate;
            this.username = username;
            this.statePret = statePret;
        }

        public int IdPret
        {
            get => idPret;
            set
            {
                idPret = value;
                OnPropertyChanged();
            }
        }
        public int IdClient
        {
            get => idClient;
            set
            {
                idClient = value;
                OnPropertyChanged();
            }
        }
        public string DatePret
        {
            get => datePret;
            set
            {
                datePret = value;
                OnPropertyChanged();
            }
        }
        public string TimePret
        {
            get => timePret;
            set
            {
                timePret = value;
                OnPropertyChanged();
            }
        }
        public string ReturnDate
        {
            get => returnDate;
            set
            {
                returnDate = value;
                OnPropertyChanged();
            }
        }
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }
        public string StatePret
        {
            get => statePret;
            set
            {
                statePret = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString()
        {
            return this.idPret + ";" + this.idClient + ";" + this.datePret + ";" + this.timePret + ";" + this.returnDate + ";" + this.username + ";" + this.statePret;
        }
    }
}
