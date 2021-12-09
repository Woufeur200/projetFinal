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
        string idUser;

        public DetailsPret()
        {
            this.IdDetails = 0;
            this.IdPret = 0;
            this.IdMat = "";
            this.StateDet = "";
            this.IdUser = "";
        }

        public DetailsPret(int idDetails, int idPret, string idMat, string stateDet, string idUser)
        {
            this.IdDetails = idDetails;
            this.IdPret = idPret;
            this.IdMat = idMat;
            this.StateDet = stateDet;
            this.IdUser = idUser;
        }

        public int IdDetails { get => idDetails; set => idDetails = value; }
        public int IdPret { get => idPret; set => idPret = value; }
        public string IdMat { get => idMat; set => idMat = value; }
        public string StateDet { get => stateDet; set => stateDet = value; }
        public string IdUser { get => idUser; set => idUser = value; }

        public override string ToString()
        {
            return this.idDetails + ";" + this.idPret + ";" + this.idMat + ";" + this.stateDet + ";" + this.idUser;
        }
    }
}
