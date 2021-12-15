using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class DetailsPret
    {
        int idDetails;
        int idPret;
        string idMat;
        string stateDet;
        string username;

        public DetailsPret()
        {
            this.IdDetails = 0;
            this.IdPret = 0;
            this.IdMat = "";
            this.StateDet = "";
            this.Username = "";
        }

        public DetailsPret(int idDetails, int idPret, string idMat, string stateDet, string username)
        {
            this.IdDetails = idDetails;
            this.IdPret = idPret;
            this.IdMat = idMat;
            this.StateDet = stateDet;
            this.Username = username;
        }
        public DetailsPret(int idPret, string idMat, string stateDet, string username)
        {
            this.IdDetails = 0;
            this.IdPret = idPret;
            this.IdMat = idMat;
            this.StateDet = stateDet;
            this.Username = username;
        }

        public int IdDetails {
            get => idDetails;
            set
            {
                idDetails = value;
                OnPropertyChanged();
            }
                
        }
        public int IdPret { 
            get => idPret;
            set
            {
                idPret = value;
                OnPropertyChanged();
            }
        }
        public string IdMat { 
            get => idMat;
            set
            {
                idMat = value;
                OnPropertyChanged();
            }
        }
        public string StateDet {
            get => stateDet;
            set
            {
                stateDet = value;
                OnPropertyChanged();
            }
        }
        public string Username { 
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString()
        {
            return this.idDetails + ";" + this.idPret + ";" + this.idMat + ";" + this.stateDet + ";" + this.username;
        }
    }
}
