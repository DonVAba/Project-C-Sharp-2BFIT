using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Persistance
{
    /// <summary>
    /// Classe abstraite n'ayant qu'en attribut un chemin où les données devront être chargées
    /// </summary>
    public abstract class DataLoad
    {
        /// <summary>
        /// chemin où les données devront être chargées
        /// </summary>
        private string chemin;

        /// <summary>
        /// Constructeur de la classe recevant un chemin en paramètres
        /// </summary>
        /// <param name="chemin"></param>
        public DataLoad(string chemin)
        {
            this.chemin = chemin;
        }

        /// <summary>
        /// Méthode qui devra être rédéfini pour le chargement des données en fonction du support où elles ont étés sauvegardées
        /// </summary>
        /// <returns>Retourne une Listes (donc un dictionnaire de comptes et et une liste de tous les programmes)</returns>
        public abstract Listes ChargeDonnees();
    }
}
