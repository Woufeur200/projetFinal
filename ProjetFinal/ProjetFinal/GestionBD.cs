using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ProjetFinal
{
    class GestionBD
    {
        MySqlConnection con;
        static GestionBD gestionBD = null;
        ObservableCollection<Client> listeC = new ObservableCollection<Client>();
        ObservableCollection<Utilisateur> listeU = new ObservableCollection<Utilisateur>();
        ObservableCollection<Materiel> listeM = new ObservableCollection<Materiel>();
        ObservableCollection<Pret> listeP = new ObservableCollection<Pret>();
        ObservableCollection<DetailsPret> listeDP = new ObservableCollection<DetailsPret>();
        ObservableCollection<DetailsPretVue> listeDPV = new ObservableCollection<DetailsPretVue>();


        Object objectSelected;

        //internal int connexion;
        string usernameLogged;
        int logged;
        string username;


        public GestionBD()
        {
            //this.con = new MySqlConnection("Server = cours.cegep3r.info; Database = a2021_420326ri_equipe_03; Uid = 2076261; Pwd = 2076261;");
            this.con = new MySqlConnection("Server = localhost; Database = prog; Uid = root; Pwd = root;");

        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public object ObjectSelected {
            get => objectSelected;
            set
            {
                objectSelected = value;
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* Login */
        public int login(string username, string password)
        {
            int check = 0;
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from utilisateur WHERE username = @username AND password = md5(@password)";
            commande.Parameters.AddWithValue("@username", username);
            commande.Parameters.AddWithValue("@password", password);
            con.Open();
            commande.Prepare();



            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                check = 1;
                username = r.GetString(0);
            }
            r.Close();
            con.Close();
            if (check == 1)
            {
                logged = 1;
                usernameLogged = username;
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
            return logged;
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* client */
        public ObservableCollection<Client> getClients()
        {
            listeC.Clear();

            MySqlCommand commande = new MySqlCommand("p_view_clients");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                listeC.Add(new Client(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4), r.GetInt32(5), r.GetString(6)));
            }
            r.Close();
            con.Close();

            return listeC;
        }

        public ObservableCollection<Client> getListeClients()
        {
            return listeC;
        }

        public int ajouterClient(Client c)
        {
            int retour = 0;

            try
            {
                
                MySqlCommand commande = new MySqlCommand("p_add_client");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("clientName", c.ClientName);
                commande.Parameters.AddWithValue("email", c.Email);
                commande.Parameters.AddWithValue("phone", c.Phone);
                commande.Parameters.AddWithValue("poste", c.Poste);
                commande.Parameters.AddWithValue("deskNumber", c.DeskNumber);
                commande.Parameters.AddWithValue("type", c.Type);

                con.Close();
                con.Open();
                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();

                if(r.Read())
                {
                    c.IdClient = r.GetInt32(0);
                } 

                con.Close();

                listeC.Add(c);

                return retour;
            }
            catch(MySqlException ex)
            {
                retour = 0;

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return retour;


        }

        public int modifierClient(Client c)
        {
            int retour = 0;
            try
            {

                MySqlCommand commande = new MySqlCommand("p_modify_client");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;


                commande.Parameters.AddWithValue("idClient", c.IdClient);
                commande.Parameters.AddWithValue("clientName", c.ClientName);
                commande.Parameters.AddWithValue("email", c.Email);
                commande.Parameters.AddWithValue("phone", c.Phone);
                commande.Parameters.AddWithValue("poste", c.Poste);
                commande.Parameters.AddWithValue("deskNumber", c.DeskNumber);
                commande.Parameters.AddWithValue("type", c.Type);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();
                con.Close();


                return retour;
            }
            catch(MySqlException ex)
            {
                retour = 0;

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return retour;
        }

        public int deleteClient(Client o)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("p_delete_client");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("idClientV", o.IdClient);

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

        public List<Client> rechercheClient(String client)
        {
            List<Client> results = new List<Client>();
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "SELECT * FROM clients WHERE phone like '%" + client + "%'";

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while(r.Read()){
                    results.Add(new Client(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4), r.GetInt32(5), r.GetString(6)));
                }
                r.Close();
                con.Close();

                return results;
            }
            catch(MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                return results;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*usager*/
        public ObservableCollection<Utilisateur> getUtilisateur()
        {
            listeU.Clear();
            MySqlCommand commande = new MySqlCommand("p_view_utilisateur");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

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

        public ObservableCollection<Utilisateur> getListeUtilisateurs()
        {
            return listeU;
        }

        public int ajouterUtilisateur(Utilisateur u)
        {
            int retour = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand("p_add_utilisateur");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@username", u.Username);
                commande.Parameters.AddWithValue("@nom", u.Nom);
                commande.Parameters.AddWithValue("@prenom", u.Prenom);
                commande.Parameters.AddWithValue("@password", u.Password);


                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();
                con.Close();
                listeU.Add(u);
                return retour;
            }
            catch(MySqlException ex)
            {
                retour = 0;
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return retour;
           
        }

        public int modifierUtilisateur(Utilisateur u)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand("p_modify_utilisateur");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            commande.Parameters.AddWithValue("nom", u.Nom);
            commande.Parameters.AddWithValue("prenom", u.Prenom);
            commande.Parameters.AddWithValue("password", u.Password);

            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }

        public int deleteUtilisateur(Utilisateur u)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("p_delete_utilisateur");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("usernameV", u.Username);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();
                con.Close();

                listeU.Remove(u);

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

        public string getUsername()
        {
            return usernameLogged;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*Materiel*/
        public ObservableCollection<Materiel> getMateriels()
        {
            listeM.Clear();


            MySqlCommand commande = new MySqlCommand("p_view_materiels");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                listeM.Add(new Materiel(r.GetString(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4)));
            }
            r.Close();
            con.Close();

            return listeM;
        }

        public ObservableCollection<Materiel> getListeMateriels()
        {
            return listeM;
        }

        public int ajouterMateriel(Materiel m)
        {
            int retour = 0;

            try
            {

                MySqlCommand commande = new MySqlCommand("p_add_materiel");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("idMat", m.IdMat);
                commande.Parameters.AddWithValue("brand", m.Brand);
                commande.Parameters.AddWithValue("model", m.Model);
                commande.Parameters.AddWithValue("state", m.State);
                commande.Parameters.AddWithValue("note", m.Note);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();
                con.Close();

                listeM.Add(m);

                return retour;
            } 
            catch(MySqlException ex)
            {
                retour = 0;

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return retour;

        }

        public int modifierMateriel(Materiel m)
        {
            int retour = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand("p_modify_materiel");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("brand", m.Brand);
                commande.Parameters.AddWithValue("model", m.Model);
                commande.Parameters.AddWithValue("state", m.State);
                commande.Parameters.AddWithValue("note", m.Note);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch(MySqlException ex)
            {
                retour = 0;

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return retour;
        }

        public int deleteMateriel(Materiel m)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("p_delete_materiel");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("idMatV", m.IdMat);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();
                con.Close();

                listeM.Remove(m);

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

        public List<Materiel> rechercheMateriel(String materiel)
        {
            List<Materiel> results = new List<Materiel>();
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "SELECT * FROM materiel WHERE brand like '%" + materiel + "%'";

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    results.Add(new Materiel(r.GetString(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4)));
                }
                r.Close();
                con.Close();

                return results;
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                return results;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*Pret*/
        public ObservableCollection<Pret> getPrets()
        {
            listeP.Clear();

            MySqlCommand commande = new MySqlCommand("p_view_pret");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                listeP.Add(new Pret(r.GetInt32(0), r.GetInt32(1), r.GetString(2), r.GetString(3), r.GetString(4),r.GetString(5),r.GetString(6)));
            }
            r.Close();
            con.Close();

            return listeP;
        }

        public ObservableCollection<DetailsPretVue> getPretsVue()
        {
            listeDPV.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from detailsPretVue";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                listeDPV.Add(new DetailsPretVue(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetInt32(4), r.GetInt32(5), r.GetInt32(6),r.GetString(7),r.GetString(8)));
            }
            r.Close();
            con.Close();

            return listeDPV;
        }


        public ObservableCollection<Pret> getListePrets()
        {
            return listeP;
        }

        public ObservableCollection<DetailsPretVue> getListePretsVue()
        {
            return listeDPV;
        }

        public int ajouterPret(Pret p, ObservableCollection<Materiel> m)
        {
            int retour = 0;
            try
            {

                MySqlCommand commande = new MySqlCommand("p_add_pret");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("idClient", p.IdClient);
                commande.Parameters.AddWithValue("datePret", p.DatePret);
                commande.Parameters.AddWithValue("timePret", p.TimePret);
                commande.Parameters.AddWithValue("returnDate", p.ReturnDate);
                commande.Parameters.AddWithValue("username", usernameLogged);
                commande.Parameters.AddWithValue("statePret", p.StatePret);

                con.Open();
                commande.Prepare();

                MySqlDataReader r = commande.ExecuteReader();
                r.Read();
                int id = r.GetInt32(0);
                r.Close();

                foreach (Materiel item in m)
                {
                    MySqlCommand commandeDP = new MySqlCommand("p_add_detailspret");
                    commandeDP.Connection = con;
                    commandeDP.CommandType = System.Data.CommandType.StoredProcedure;

                    commandeDP.Parameters.AddWithValue("idPret", id);
                    commandeDP.Parameters.AddWithValue("idMat", item.IdMat);
                    commandeDP.Parameters.AddWithValue("stateDet", "Emprunté");
                    commandeDP.Parameters.AddWithValue("username", usernameLogged);

                    commandeDP.ExecuteNonQuery();
                }


                con.Close();

                listeP.Add(p);

                return retour;

            }
            catch(MySqlException ex)
            {
                retour = 0;
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return retour;
            
        }

        public int modifierPret(Pret p)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand("p_modify_pret");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;



            commande.Parameters.AddWithValue("@idPret", p.IdPret);
            commande.Parameters.AddWithValue("@idClient", p.IdClient);
            commande.Parameters.AddWithValue("@datePret", p.DatePret);
            commande.Parameters.AddWithValue("@timePret", p.TimePret);
            commande.Parameters.AddWithValue("@returnDate", p.ReturnDate);
            commande.Parameters.AddWithValue("@username", p.Username);
            commande.Parameters.AddWithValue("@statePret", p.StatePret);

            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }

        public int deletePret(Pret p)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("p_delete_pret");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@idPret", p.IdPret);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();
                con.Close();

                listeP.Remove(p);

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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*Details Pret */
        public ObservableCollection<DetailsPret> getDetailsPrets()
        {
            listeDP.Clear();

            MySqlCommand commande = new MySqlCommand("p_view_detailsPret");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                listeDP.Add(new DetailsPret(r.GetInt32(0), r.GetInt32(1), r.GetString(2), r.GetString(3), r.GetString(4)));
            }
            r.Close();
            con.Close();

            return listeDP;
        }

        public ObservableCollection<DetailsPret> getListeDetailsPret()
        {
            return listeDP;
        }

        public ObservableCollection<DetailsPret> getListePret()
        {
            return listeDP;
        }
    }
}
