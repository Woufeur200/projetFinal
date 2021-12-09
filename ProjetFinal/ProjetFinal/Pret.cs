using System;
using System.Collections.Generic;
using System.Linq;
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
        string idUser;
        string statePret;


        public Pret()
        {
            this.idPret = 0;
            this.idClient = 0;
            this.datePret = "";
            this.timePret = "";
            this.returnDate = "";
            this.idUser = "";
            this.statePret = "";
        }
        public Pret(int idPret, int idClient, string datePret, string timePret, string returnDate, string idUser, string statePret)
        {
            this.idPret = idPret;
            this.idClient = idClient;
            this.datePret = datePret;
            this.timePret = timePret;
            this.returnDate = returnDate;
            this.idUser = idUser;
            this.statePret = statePret;
        }

        public override string ToString()
        {
            return this.idPret + ";" + this.idClient + ";" + this.datePret + ";" + this.timePret + ";" + this.returnDate + ";" + this.idUser + ";" + this.statePret;
        }
    }
}
