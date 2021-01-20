using System;
using System.Collections;

namespace EquipeDeFoot
{
    public class EquipeFoot<typeJoueur>
    {
        private string nom;
        private ArrayList equipe = new ArrayList();

        public EquipeFoot(string nom)
        {
            this.nom = nom;
        }

        public void Ajouter(typeJoueur joueur)
        {
            equipe.Add(joueur);
        }

    }
}
