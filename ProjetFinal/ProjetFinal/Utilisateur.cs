using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Utilisateur
    {
        string idUser;
        string name;
        string firstName;
        string password;


        public Utilisateur()
        {
            this.IdUser = "";
            this.Name = "";
            this.FirstName = "";
            this.Password = "";
        }
        public Utilisateur(string idUser, string name, string firstName, string password)
        {
            this.IdUser = idUser;
            this.Name = name;
            this.FirstName = firstName;
            this.Password = password;
        }

        public string IdUser { get => idUser; set => idUser = value; }
        public string Name { get => name; set => name = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return this.idUser + ";" + this.name + ";" + this.firstName + ";" + this.password;
        }
    }
}
