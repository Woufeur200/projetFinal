using System;
using System.Collections.Generic;
using System.Linq;
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

        public int IdDetails { get => idDetails; set => idDetails = value; }
        public int IdPret { get => idPret; set => idPret = value; }
        public string IdMat { get => idMat; set => idMat = value; }
        public string StateDet { get => stateDet; set => stateDet = value; }
        public string Username { get => username; set => username = value; }

        public override string ToString()
        {
            return this.idDetails + ";" + this.idPret + ";" + this.idMat + ";" + this.stateDet + ";" + this.username;
        }
    }
}
