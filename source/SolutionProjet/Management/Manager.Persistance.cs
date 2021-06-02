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

        internal List<Utilisateur> LesUsers { get; set; } = new List<Utilisateur>();
        internal ObservableCollection<Programme> LesProg { get; set; } = new ObservableCollection<Programme>();

        /// <summary>
        /// Méthode permettant de charger les données de l'application
        /// </summary>
        public void ChargeDonnees()
        {
            var data = Persistance.ChargeDonnees();
            CurrentList = data;

            /*LesUsers = data.ListeUtilisateurs.ToPOCOs();
            foreach (var user in LesUsers)
            {
                CurrentList.listComptes.Add(user.Identifiant, user);
            }
            LesProg = (ObservableCollection<Programme>)data.ListeProgramme.ToPOCOs();
            foreach ( var prog in LesProg)
            {
                CurrentList.ListProgrammes.Add(prog);
            }*/
        }

        public void SauvegardeDonnees()
        {
            Persistance.SauvegardeDonnees(CurrentList);
        }
    }
}
