using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Materiel
    {
        string idMat;
        string brand;
        string model;
        string state;
        string note;


        public Materiel()
        {
            this.IdMat = "";
            this.Brand = "";
            this.Model = "";
            this.State = "";
            this.Note = "";
        }
        public Materiel(string idMat, string brand, string model, string state, string note)
        {
            this.IdMat = idMat;
            this.Brand = brand;
            this.Model = model;
            this.State = state;
            this.Note = note;
        }

        public string IdMat { get => idMat; set => idMat = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string State { get => state; set => state = value; }
        public string Note { get => note; set => note = value; }

        public override string ToString()
        {
            return this.IdMat + ";" + this.Brand + ";" + this.Model + ";" + this.State + ";" + this.Note;
        }
    }
}
