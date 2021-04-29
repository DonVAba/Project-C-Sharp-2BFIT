using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    class Admin : Utilisateur
    {
        /// <summary>
        /// Constructeur de la classe Admin qui dérive de la classe Utilisateur, les paramètres sont donc les mêmes
        /// </summary>
        /// <param name="Nom"></param>
        /// <param name="prenom"></param>
        /// <param name="age"></param>
        /// <param name="taille"></param>
        /// <param name="poids"></param>
        /// <param name="identifiant"></param>
        /// <param name="mdp"></param>
        public Admin(string Nom, string prenom, int age, int taille, int poids, string identifiant, string mdp) : base(Nom,prenom,age,taille,poids,identifiant,mdp)
        {

        }
    }
}
