using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Admin : Utilisateur
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
        public Admin(string Nom, string prenom, DateTime dateNaissance, int taille, int poids, string identifiant, string mdp) : base(Nom,prenom,dateNaissance,taille,poids,identifiant,mdp)
        {

        }
    }
}
