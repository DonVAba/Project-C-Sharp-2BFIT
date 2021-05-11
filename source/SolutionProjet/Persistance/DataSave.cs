using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Persistance
{
    /// <summary>
    /// Classe abstraite n'ayant qu'en attribut un chemin où les données devront être sauvegardées
    /// </summary>
    public abstract class DataSave
    {
        private string chemin;

        /// <summary>
        /// Constructeur de la classe recevant un chemin en paramètres
        /// </summary>
        /// <param name="chemin"></param>
        public DataSave(string chemin)
        {
            this.chemin = chemin;
        }

        /// <summary>
        /// Méthode reçevant une Listes en paramètres qui devra être rédifini en fonction duspport où nous voulons sauvegardés les données
        /// </summary>
        /// <param name="dataList"></param>
        public abstract void SauvegardeDonnees(Listes dataList);
    }
}
