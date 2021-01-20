using System;
using System.Collections.Generic;
using System.Linq;
using EquipeDeFoot;

namespace EquipeIndexee
{
    public class EquipeDeFootIndexee
    {
        private List<Joueur> equipe = new List<Joueur>();

        public Joueur this[int idx]
        {
            get { return equipe[idx]; }
            set { equipe[idx] = value; }
        }

        public List<Joueur> this[string poste]
        {
            get { return equipe.Where(leJoueur => leJoueur.Poste == poste).ToList<Joueur>(); }
        }

        public void Acheter(Joueur nouveauJoueur)
        {
            equipe.Add(nouveauJoueur);
        }
    }
}
