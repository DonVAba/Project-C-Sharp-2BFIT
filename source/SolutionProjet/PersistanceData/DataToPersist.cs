using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using Application;

namespace PersistanceData
{
    [DataContract]
    public class DataToPersist
    {
        /// <summary>
        /// Liste d'Utilisateurs
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public List<Utilisateur> ListeUtilisateurs { get; set; } = new List<Utilisateur>();

        /// <summary>
        /// Liste de programme
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public ObservableCollection<Programme> ListeProgramme { get; set; } = new ObservableCollection<Programme>();
    }
}
