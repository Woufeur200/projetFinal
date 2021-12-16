using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class DetailsPretVue : INotifyPropertyChanged
    {
        int idPret, nbrMateriel, nbrMaterielEnCours, nbrMaterielRetourne;

        string statePret, clientName, datePret, returnDate, nomUtilisateur;

        public DetailsPretVue(int idPret, string clientName, string datePret, string returnDate, int nbrMateriel, int nbrMaterielEnCours, int nbrMaterielRetourne, string statePret, string nomUtilisateur)
        {
            this.idPret = idPret;
            this.clientName = clientName;
            this.datePret = datePret;
            this.returnDate = returnDate;
            this.nbrMateriel = nbrMateriel;
            this.nbrMaterielEnCours = nbrMaterielEnCours;
            this.nbrMaterielRetourne = nbrMaterielRetourne;
            this.statePret = statePret;
            this.nomUtilisateur = nomUtilisateur;
        }

        public int IdPret
        {
            get => idPret;
            set
            {
                idPret = value;
                this.OnPropertyChanged();
            }
        }
        public int NbrMateriel
        {
            get => nbrMateriel;
            set
            {
                nbrMateriel = value;
                this.OnPropertyChanged();
            }
        }
        public int NbrMaterielEnCours
        {
            get => nbrMaterielEnCours;
            set
            {
                nbrMaterielEnCours = value;
                this.OnPropertyChanged();
            }
        }
        public int NbrMaterielRetourne
        {
            get => nbrMaterielRetourne;
            set
            {
                nbrMaterielRetourne = value;
                this.OnPropertyChanged();
            }
        }
        public string ClientName
        {
            get => clientName;
            set
            {
                clientName = value;
                this.OnPropertyChanged();
            }
        }
        public string DatePret
        {
            get => datePret;
            set
            {
                datePret = value;
                this.OnPropertyChanged();
            }
        }
        public string ReturnDate
        {
            get => returnDate;
            set
            {
                returnDate = value;
                this.OnPropertyChanged();
            }
        }
        public string NomUtilisateur
        {
            get => nomUtilisateur;
            set
            {
                nomUtilisateur = value;
                this.OnPropertyChanged();
            }
        }
        public string StatePret
        {
            get => statePret;
            set
            {
                statePret = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
