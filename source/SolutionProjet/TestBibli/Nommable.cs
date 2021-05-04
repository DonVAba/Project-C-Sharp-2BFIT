using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public abstract class Nommable
    {

        /// <summary>
        /// Nom associé à un utilisateur, programme ou exercice
        /// </summary>
        private string nom;
        public string Nom
        {
            get => nom;
            set => nom = value;
        }
        public override string ToString()
        {
            return $" Nom : {Nom}";
        }

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
