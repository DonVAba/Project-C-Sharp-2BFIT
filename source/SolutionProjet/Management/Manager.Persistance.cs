using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Application;
using PersistanceData;

namespace Management
{
    public partial class Manager
    {
        /// <summary>
        /// Variable qui contient les données
        /// </summary>
        public IDataManager Persistance { get; set; }

        public Listes CurrentList { get; set; } = new Listes();


        /// <summary>
        /// Méthode permettant de charger les données de l'application
        /// </summary>
        public void ChargeDonnees()
        {
            var data = Persistance.ChargeDonnees();
            CurrentList = data;

        }

        /// <summary>
        /// Méthode permettant de sauvegarder les données
        /// </summary>
        public void SauvegardeDonnees()
        {
            Persistance.SauvegardeDonnees(CurrentList);
        }
    }
}
