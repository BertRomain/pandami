using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LibrairieClient;

namespace ManipulationBddFramework
{
    public class AccesBdd
    {
        SqlConnection cnx;
        public SqlConnection Cnx
        {
            get { return this.cnx; }
        }

        public AccesBdd()
        {
            this.cnx = new SqlConnection();
        }

        bool OuvreConnection()
        {
            bool ouvertureOk = false;
            
            this.cnx.ConnectionString = ConfigurationManager.ConnectionStrings["baseLocale"]?.ConnectionString;
            // si ConfigurationManager.ConnectionStrings["baseLocale"] est null, alors, je retourne null, sinon je continue et je retourne la valeur de ConnectionString
            // Récupération d'un app setting : ConfigurationManager.ConfigurationSettings.AppSettings["NumeroSalle"];
            try
            {
                this.cnx.Open();
                ouvertureOk = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erreur ouverture SQL : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur autre sur l'ouverture : " + e.Message);
            }
            return ouvertureOk;
        }

        void FermetureBDD()
        {
            this.cnx.Close();
        }

        public string GetPremierClient()
        {
            string nomClient;
            string requeteSQL = "SELECT TOP (1) nom FROM client";
            //requeteSQL = "SELECT COUNT(*) FROM client";
            SqlCommand cmd = new SqlCommand();
            this.OuvreConnection();
            cmd.Connection = this.cnx;
            cmd.CommandText = requeteSQL;
            cmd.CommandType = System.Data.CommandType.Text;
            nomClient = cmd.ExecuteScalar().ToString();
            this.FermetureBDD();
            return nomClient;
        }

        public void LireClients()
        {
            string maRequete = "SELECT nom FROM client";
            SqlCommand cmd = new SqlCommand();
            this.OuvreConnection();
            cmd.Connection = this.cnx;
            cmd.CommandText = maRequete;
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader resultat = cmd.ExecuteReader();
            // traitement resultat... voir méthode LireMaTable()
            resultat.Close();
            this.FermetureBDD();
        }

        public void LireMaTableClient()
        {
            string requete = "SELECT noclient, nom, adresse, noregion FROM client";
            
            SqlCommand cmd = new SqlCommand(requete, this.cnx);
            this.OuvreConnection();
            SqlDataReader resultat = cmd.ExecuteReader();
            if (!resultat.HasRows)
            {
                Console.WriteLine("Pas de résultat à ma requete : " + requete);
            }
            while (resultat.Read())
            {
                Console.WriteLine("Num Client : {0} - Nom : {1} - Adresse : {2} - Région : {3}",
                    (int)resultat["noclient"], (string)resultat["nom"], (string)resultat["adresse"], (int)resultat["noregion"]);
            }
            resultat.Close();
            this.FermetureBDD();
        }

        public void LireUneTable(string nomTable)
        {
            string requete = "SELECT * FROM " + nomTable;
            SqlCommand cmd = new SqlCommand(requete, this.cnx);
            this.OuvreConnection();
            SqlDataReader resultat = cmd.ExecuteReader();
            if (!resultat.HasRows)
            {
                Console.WriteLine("La requete sur la table {0} ne retourne rien", nomTable);
            }
            int nbColonnes = resultat.FieldCount;
            for (int c = 0; c < nbColonnes; c++)
            {
                Console.Write("{0}\t", resultat.GetName(c));
            }
            Console.WriteLine("");
            string valeurLue;
            while (resultat.Read())
            {
                for (int c = 0; c < nbColonnes; c++)
                {
                    switch (resultat.GetFieldType(c).ToString())
                    {
                        case "System.String":
                            valeurLue = resultat.GetString(c);
                            break;
                        case "System.Int32":
                            valeurLue = resultat.GetInt32(c).ToString();
                            break;
                        default:
                            valeurLue = "inconnue";
                            break;
                    }
                    Console.Write("{0}\t", valeurLue);
                }
                Console.WriteLine("");
            }
            resultat.Close();
            this.FermetureBDD();
        }

        int RecupDernierNumCli()
        {
            int num;
            SqlCommand cmd = new SqlCommand("SELECT MAX(noclient) FROM client", this.cnx);
            this.OuvreConnection();
            num = (int)cmd.ExecuteScalar();
            this.FermetureBDD();
            return num;
        }

        public void InsererNouveauClient(Client monNouveauClient)
        {
            int nouveauNumCli = RecupDernierNumCli();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.cnx;
            
            string requete = String.Format("INSERT INTO client (noclient, nom, adresse, noregion) VALUES ({0}, '{1}', '{2}', {3})",
                ++nouveauNumCli,
                monNouveauClient.Nom,
                monNouveauClient.Adresse,
                monNouveauClient.NumRegion.ToString());
            cmd.CommandText = requete;
            this.OuvreConnection();
            int nbLigneAffectees = cmd.ExecuteNonQuery();
            this.FermetureBDD();
        }

        public void MajAdresseCli(Client monClientModifie)
        {
            SqlCommand cmd = new SqlCommand();
            this.OuvreConnection();
            string requete = String.Format("UPDATE client SET adresse = '{0}' WHERE noclient = @NoClient", monClientModifie.Adresse);
            SqlParameter pNoCli = new SqlParameter("@NoClient", monClientModifie.NoClient);
            cmd.Connection = this.cnx;
            cmd.CommandText = requete;
            cmd.Parameters.Add(pNoCli);
            int nbLigneAffectees = cmd.ExecuteNonQuery();
            this.FermetureBDD();
        }

        void AfficherTable(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("{0}\t{1}\t{2}", dr["noclient"].ToString(), dr["nom"].ToString(), dr["adresse"].ToString());
            }
        }

        public void NouveauDatasetClient()
        {
            this.OuvreConnection();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = new SqlCommand("SELECT noclient, nom, adresse, noregion FROM client", this.cnx);
            DataSet monDataSet = new DataSet();
            ad.Fill(monDataSet, "toto");

            DataTable maTableCli = monDataSet.Tables["toto"];

            // INSERT
            DataRow dr = monDataSet.Tables["toto"].NewRow();
            dr["noclient"] = 15;
            dr["nom"] = "Lloris";
            dr["adresse"] = "impasse du foot";
            dr["noregion"] = 9;
            monDataSet.Tables["toto"].Rows.Add(dr);

            // UPDATE
            DataRow drModif = monDataSet.Tables["toto"].Rows[1];
            drModif.BeginEdit();
            drModif["nom"] = "Stephane";
            drModif.EndEdit();

            // DELETE
            monDataSet.Tables["toto"].Rows[3].Delete();

            monDataSet.WriteXml(@"toto.xml");
        }
    }
}
