using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Client
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

        public int IdClient { get => idClient; set => idClient = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Poste { get => poste; set => poste = value; }
        public int DeskNumber { get => deskNumber; set => deskNumber = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return this.IdClient + ";" + this.clientName + ";" + this.email + ";" + this.phone + ";" + this.poste + ";" + this.deskNumber + ";" + this.type;
        }
    }
}
