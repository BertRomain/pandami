using System;
using System.Collections.Generic;
using System.Linq;
using EquipeDeFoot;
using EquipeIndexee;

namespace Football
{
    class Program
    {
        static void Exemple()
        {
            EquipeFoot<Joueur> equipeHumaine = new EquipeFoot<Joueur>("Paris St Germain");

            for (int i = 1; i < 12; i++)
            {
                equipeHumaine.Ajouter(new Joueur(i));
            }

            EquipeFoot<Robot> equipeTerminator = new EquipeFoot<Robot>("Star Wars");

            for (int i = 1; i < 12; i++)
            {
                equipeTerminator.Ajouter(new Robot(i));
            }
        }

        static void ExempleIndex()
        {
            EquipeDeFootIndexee psg = new EquipeDeFootIndexee();
            psg.Acheter(new Joueur(1, "Maradona", "attaquant"));
            psg.Acheter(new Joueur(10, "Zidane", "attaquant"));
            psg.Acheter(new Joueur(7, "Lloris", "gardien"));

            // Accéder un 1er joueur acheté
            Joueur monPremierAchat = psg[0];

            // Extraire mes attaquants
            List<Joueur> mesAttaquants = psg["attaquant"];

            // Remplacer mon 2ème achat
            psg[1] = new Joueur(11, "Ronaldo", "défenseur");
            
            // Test ajout code GitHub
            psg[2] = new Joueur(15, "Stéphane", "prof");
            
            // test conflit GIT
            bool monTest = true; // ligne modifiée manuellement depuis Visual Studio

        }

        static void ExempleLinq()
        {
            List<Joueur> psg = new List<Joueur>();
            psg.Add(new Joueur(15, "Maradona", "attaquant"));
            psg.Add(new Joueur(10, "Zidane", "attaquant"));
            psg.Add(new Joueur(7, "Lloris", "gardien"));
            psg.Add(new Joueur(1, "Deschamps", "attaquant"));

            List<Joueur> mesAttaquants = psg.Where(j => j.Poste == "attaquant").ToList<Joueur>();
            int nbGardiens = psg.Where(j => j.Poste == "gardien").Count();

            // Remplir une liste de joueurs en sélectionnant les attaquants, triés par ordre de dossard
            // 4 alternatives :
            // 1°) Linq avec méthode Where
            List<Joueur> mesAttaquantParDossard = psg.Where(j => j.Poste == "attaquant").OrderBy(j => j.Numero).ToList();

            // 2°) Linq vers objet var -> IEnumerable<Joueur> explicite, puis conversion en liste
            var listeJoueursAttaquants = from joueur in psg
                                  where joueur.Poste == "attaquant"
                                  orderby joueur.Numero
                                  select new Joueur(joueur.Numero, joueur.Nom, joueur.Poste);
            mesAttaquantParDossard = listeJoueursAttaquants.ToList();

            // 3°) Linq vers IEnumerable<Joueur> implicite pour conversion en liste
            IEnumerable<Joueur> listeAttaquants = from joueur in psg
                                                  where joueur.Poste == "attaquant"
                                                  orderby joueur.Numero
                                                  select joueur;
            mesAttaquantParDossard = listeAttaquants.ToList();

            // 4°) Linq vers liste de joueur en une ligne
            mesAttaquantParDossard = (from joueur in psg
                                      where joueur.Poste == "attaquant"
                                      orderby joueur.Numero
                                      select joueur).ToList();

            // Cumul de critères
            List<Joueur> mesAttaquantsAvecE = psg.Where(j => j.Poste == "attaquant").Where(joueur => joueur.Nom.Contains("e")).OrderBy(jj => jj.Numero).ToList();

            mesAttaquantsAvecE = (from jj in psg
                                  where jj.Poste == "attaquant" && jj.Nom.Contains("e")
                                  orderby jj.Numero descending
                                  select jj).ToList();

            List<Joueur> desAttaquantsOuNomAvecS = (from e in psg
                                                    where e.Poste == "attaquant" || e.Nom.Contains("s")
                                                    orderby e.Numero
                                                    select e).ToList();
            List<Joueur> desAttaquantsEtNomAvecS = (from e in psg
                                                    where e.Poste == "attaquant" && e.Nom.Contains("s")
                                                    orderby e.Numero
                                                    select e).ToList();
        }

        static void Main(string[] args)
        {
            ExempleLinq();

            
        }
    }
}
