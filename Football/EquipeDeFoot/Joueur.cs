using System;
using System.Collections.Generic;
using System.Text;

namespace EquipeDeFoot
{
    public class Joueur
    {
        int numero = 0;
        string nom;
        string poste;

        public int Numero
        {
            get { return this.numero; }
        }

        public string Poste
        {
            get { return this.poste; }
        }

        public string Nom
        { 
            get { return this.nom; }
            set { this.nom = value; }
        }

        public Joueur()
        {

        }

        public Joueur(int numero)
        {
            this.numero = numero;
        }

        public Joueur(int numero, string nom, string poste)
        {
            this.numero = numero;
            this.nom = nom;
            this.poste = poste;
        }
    }
}
