using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Application
{
    [DataContract]
    public abstract class Nommable : INotifyPropertyChanged
    {
        
        /// <summary>
        /// Nom associé à un utilisateur, programme ou exercice
        /// </summary>
        private string nom;
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Nom
        {
            get => nom;
            set 
            { 
                if(nom != value)
                {
                    nom = value;
                    OnPropertyChanged("Nom");
                }
            }

        }
        public override string ToString()
        {
            return $" {Nom}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Constructeur de classe nommable
        /// </summary>
        /// <param name="nom"></param>
        public Nommable(string nom)
        {
            Nom = nom;
        }
    }
}
