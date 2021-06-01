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

        public Listes CurrentList { get; set; }

        /// <summary>
        /// Méthode permettant de charger les données de l'application
        /// </summary>
        public void ChargeDonnees()
        {
            var data = Persistance.ChargeDonnees();
            Listes list = new Listes();
            foreach (var user in data.ListeUtilisateurs)
            {
                list.listComptes.Add(user.Identifiant, user);
            }
            foreach ( var prog in data.ListeProgramme)
            {
                prog.LesExercices = new ObservableCollection<Exercice>();
                list.ListProgrammes.Add(prog);
            }
            CurrentList = list;
        }

        public void SauvegardeDonnees()
        {
            Persistance.SauvegardeDonnees(CurrentList);
        }
    }
}
