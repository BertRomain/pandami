using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManipulationBddFramework;
using LibrairieClient;
using ManipulationEF;

namespace ConsoleTestBDD
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            AccesBdd testConnexion = new AccesBdd();
      
            string monClient = testConnexion.GetPremierClient();
            //Console.WriteLine("Mon 1er client est : " + monClient);
            //testConnexion.LireClients();
            //testConnexion.LireUneTable("client");
            //Console.WriteLine("MAJ en cours...");
            //Client monNouveauClient = new Client(11, "COCO", "1 boulevard Argentin", 3);
            //testConnexion.MajAdresseCli(monNouveauClient);
            //testConnexion.LireUneTable("client");
            //testConnexion.NouveauDatasetClient();
            
            Client test = new Client();
            test.LireDonnees("Maradona");
            test.LectureDonnees();
            //test.NumRegion = 1;
            //test.EnregistrerModif();
            test.SupprimerEnBase();
            test.LectureDonnees();
            */

            AccessBddEF ef = new AccessBddEF();
            ef.GetNomAndRegionFromBdd();
            string entree = Console.ReadLine();
        }
    }
}
