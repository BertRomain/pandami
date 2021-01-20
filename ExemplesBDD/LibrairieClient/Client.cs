using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrairieClient
{
    public class Client
    {
        string nom;
        string adresse;
        int numRegion;

        public int NoClient { get; set; }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }
        public int NumRegion
        {
            get { return this.numRegion; }
            set { this.numRegion = value; }
        }
        public Client()
        {

        }
        public Client (string nom, string adresse, int numRegion)
        {
            this.nom = nom;
            this.adresse = adresse;
            this.numRegion = numRegion;
        }

        public Client(int no, string nom, string adr, int reg)
        {
            this.NoClient = no;
            this.nom = nom;
            this.adresse = adr;
            this.numRegion = reg;
        }

        public void LectureDonnees()
        {
            using (ClientLinqDataContext dc = new ClientLinqDataContext())
            {
                foreach (client cli in dc.client)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} ", cli.noclient, cli.nom, cli.adresse, cli.noregion);
                }
                Console.WriteLine("--");
            }
        }

        public void LireDonnees(string nomClient)
        {
            using (ClientLinqDataContext dc = new ClientLinqDataContext())
            {
                var req = from cli in dc.client where cli.nom == nomClient select cli;
                client cliBdd = req.FirstOrDefault();
                this.nom = cliBdd.nom;
                this.NoClient = cliBdd.noclient;
                this.adresse = cliBdd.adresse;
                this.numRegion = cliBdd.noregion??0; // si mon objet à gauche est null, je retourne ma valeur à droite
            }
        }

        public void AjouterLeClient()
        {
            using (ClientLinqDataContext dc = new ClientLinqDataContext())
            {
                client cliBdd = new client();
                cliBdd.noclient = this.NoClient;
                cliBdd.nom = this.nom;
                cliBdd.adresse = this.adresse;
                cliBdd.noregion = this.numRegion;
                //client cliBdd2 = new client { noclient = this.NoClient, nom = this.nom, adresse = this.adresse, noregion = this.numRegion };
                dc.client.InsertOnSubmit(cliBdd);
                dc.SubmitChanges();
            }
        }

        public void EnregistrerModif()
        {
            using (ClientLinqDataContext dc = new ClientLinqDataContext())
            {
                var req = from cli in dc.client where cli.noclient == this.NoClient select cli;
                client cliBdd = req.FirstOrDefault();
                cliBdd.nom = this.nom;
                cliBdd.adresse = this.adresse;
                cliBdd.noregion = this.numRegion;
                dc.SubmitChanges();
            }
        }

        public void SupprimerEnBase()
        {
            using (ClientLinqDataContext dc = new ClientLinqDataContext())
            {
                var req = from cli in dc.client where cli.noclient == this.NoClient select cli;
                client cliBdd = req.FirstOrDefault();
                dc.client.DeleteOnSubmit(cliBdd);
                dc.SubmitChanges();
            }
            
        }
    }
}
