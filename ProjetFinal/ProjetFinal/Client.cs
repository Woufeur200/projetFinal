using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Client
    {
        int idClient;
        string clientName;
        string email;
        string phone;
        string poste;
        int deskNumber;
        string type;

        public Client()
        {
            this.idClient = 0;
            this.clientName = "";
            this.email = "";
            this.phone = "";
            this.poste = "";
            this.deskNumber = 0;
            this.type = "";
        }

        public Client(int idClient, string clientName, string email, string phone, string poste, int deskNumber, string type)
        {
            this.idClient = idClient;
            this.clientName = clientName;
            this.email = email;
            this.phone = phone;
            this.poste = poste;
            this.deskNumber = deskNumber;
            this.type = type;
        }

        public Client(string clientName, string email, string phone, string poste, int deskNumber, string type)
        {
            this.idClient = 0;
            this.clientName = clientName;
            this.email = email;
            this.phone = phone;
            this.poste = poste;
            this.deskNumber = deskNumber;
            this.type = type;
        }

        public int IdClient { get => idClient; set => idClient = value; }
        public string ClientName {
            get => clientName;
            set
            {
                clientName = value;
                OnPropertyChanged();
            }
        }
        public string Email {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string Phone { 
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }
        public string Poste { 
            get => poste;
            set
            {
                poste = value;
                OnPropertyChanged();
            }
        }
        public int DeskNumber { 
            get => deskNumber;
            set
            {
                deskNumber = value;
                OnPropertyChanged();
            }
        }
        public string Type {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString()
        {
            return this.IdClient + ";" + this.clientName + ";" + this.email + ";" + this.phone + ";" + this.poste + ";" + this.deskNumber + ";" + this.type;
        }
    }
}
