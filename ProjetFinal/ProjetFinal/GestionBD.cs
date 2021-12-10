using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class GestionBD
    {
        MySqlConnection con;
        static GestionBD gestionBD = null;
        ObservableCollection<Client> listeC = new ObservableCollection<Client>();
        ObservableCollection<Utilisateur> listeU = new ObservableCollection<Utilisateur>();
        internal int connexion;
        string usernameLogged;
        int logged;
        int idUser;

        public GestionBD()
        {
            this.con = new MySqlConnection("Server = cours.cegep3r.info; Database = a2021_420326ri_equipe_03; Uid = 2076261; Pwd = 2076261;"); ;
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
        /* Login */
        public int login(string username, string password)
        {
            int check = 0;
            string nom = "";
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from utilisateur WHERE username = @username AND password = @password";
            commande.Parameters.AddWithValue("@username", username);
            commande.Parameters.AddWithValue("@password", password);
            con.Open();
            commande.Prepare();



            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                check = 1;
                nom = r.GetString(3);
                idUser = r.GetInt32(0);
            }
            r.Close();
            con.Close();
            if (check == 1)
            {
                logged = 1;
                usernameLogged = nom;
                return check;
            }
            else
            {
                logged = 0;
                usernameLogged = "";
                return check;
            }



        }



        public int logout()
        {
            logged = 0;
            usernameLogged = "";
            idUser = 0;
            return logged;
        }



        /* client */
        public ObservableCollection<Client> getClients()
        {
            ObservableCollection<Client> liste = new ObservableCollection<Client>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from clients";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                liste.Add(new Client(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4), r.GetInt32(5), r.GetString(6)));
            }
            r.Close();
            con.Close();

            return listeC;
        }



        public int ajouterClient(Client c)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand("p_add_client");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            commande.Parameters.AddWithValue("@idClient", c.IdClient);
            commande.Parameters.AddWithValue("@clientName", c.ClientName);
            commande.Parameters.AddWithValue("@email", c.Email);
            commande.Parameters.AddWithValue("@phone", c.Phone);
            commande.Parameters.AddWithValue("@poste", c.Poste);
            commande.Parameters.AddWithValue("@deskNumber", c.DeskNumber);
            commande.Parameters.AddWithValue("@type", c.Type);

            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }



        public int modifierClient(Client c)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand("p_modify_client");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;


            commande.Parameters.AddWithValue("@idClient", c.IdClient);
            commande.Parameters.AddWithValue("@clientName", c.ClientName);
            commande.Parameters.AddWithValue("@email", c.Email);
            commande.Parameters.AddWithValue("@phone", c.Phone);
            commande.Parameters.AddWithValue("@poste", c.Poste);
            commande.Parameters.AddWithValue("@deskNumber", c.DeskNumber);
            commande.Parameters.AddWithValue("@type", c.Type);

            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }

        public int deleteClient(Client o)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "delete from clients where idClient = @idClient";

                commande.Parameters.AddWithValue("@idClient", o.IdClient);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();
                con.Close();

                listeC.Remove(o);

                return retour;
            }
            catch (MySqlException ex)
            {
                retour = 0;

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return retour;

        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*usager*/



        public ObservableCollection<Utilisateur> getUtilisateur()
        {
            ObservableCollection<Utilisateur> listeU = new ObservableCollection<Utilisateur>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from utilisateur";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                listeU.Add(new Utilisateur(r.GetString(0), r.GetString(1), r.GetString(2), r.GetString(3)));
            }
            r.Close();
            con.Close();

            return listeU;
        }



        public int ajouterUsager(Utilisateur c)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand("p_add_user");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            commande.Parameters.AddWithValue("@idUser", c.IdUser);
            commande.Parameters.AddWithValue("@name", c.Name);
            commande.Parameters.AddWithValue("@firstName", c.FirstName);
            commande.Parameters.AddWithValue("@password", c.Password);


            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }



        public int modifierUtilisateur(Utilisateur c)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand("p_modify_user");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            commande.Parameters.AddWithValue("@idUser", c.IdUser);
            commande.Parameters.AddWithValue("@name", c.Name);
            commande.Parameters.AddWithValue("@firstName", c.FirstName);
            commande.Parameters.AddWithValue("@password", c.Password);

            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }

        public int deleteUtilisateur(Utilisateur o)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "delete from utilisateur where idUser = @idUser";

                commande.Parameters.AddWithValue("@idUser", o.IdUser);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();
                con.Close();

                listeU.Remove(o);

                return retour;
            }
            catch (MySqlException ex)
            {
                retour = 0;

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return retour;

        }
    }
}
