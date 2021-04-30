using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Programme : Nommable, IEquatable<Programme>
    {
        /// <summary>
        /// Difficulté par défaut
        /// </summary>
        public const string Diff_Par_Defaut = "DEBUTANT";

        /// <summary>
        /// Liste des exercices contenus dans le programme
        /// </summary>
        private List<Exercice> lesExercices;
        
        
        /// <summary>
        /// Description du programme
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Nombre d'exercice d'un programme (à moitié facultatif car il va êtr affiché)
        /// </summary>
        private int nbExercices;

        public int NbExercices
        {
            get => nbExercices;
            set
            {
                if (value > 0)
                {
                    nbExercices = value;
                }
            }
            
        }

        /// <summary>
        /// Chemin de l'image associé au programme
        /// </summary>
        private string cheminImage;

        public string CheminImage
        {
            get => cheminImage;
            set => cheminImage = value;
        }

        /// <summary>
        /// Niveau de difficulté du programme
        /// </summary>
        private Difficulte nvDifficulte;

        /// <summary>
        /// COnstructeur de la classe Programme
        /// </summary>
        /// <param name="description"></param>
        /// <param name="nbExercices"></param>
        /// <param name="cheminImage"></param>
        /// <param name="nom"></param>
        /// <param name="diff">Difficulté du programme qui va être converti en énum Difficulté</param>
        public Programme(string description, int nbExercices, string cheminImage, string nom, string diff) : base(nom)
        {
            Description = description;
            NbExercices = nbExercices;
            CheminImage = cheminImage;
            Enum.TryParse(diff.ToUpper(), out Difficulte nvDifficulte);
            lesExercices = new List<Exercice>();
        }

        /// <summary>
        /// Deuxième constructeur si aucune difficulté n'est rentrée en paramaètres
        /// </summary>
        /// <param name="description"></param>
        /// <param name="nbExercices"></param>
        /// <param name="cheminImage"></param>
        /// <param name="nom"></param>
        public Programme(string description, int nbExercices, string cheminImage, string nom) : this(description, nbExercices, cheminImage, nom, Diff_Par_Defaut)
        {
            
        }

        /// <summary>
        /// Méthode de paramérage de la chaine de caractère renvoyé si une instance de cette classe veut être écrite sur une COnsole ou Debug
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return  $"Description : {Description} nbExercices : {NbExercices} chemin Image : {CheminImage}";
        }

        /// <summary>
        /// Méthode qui compare 2 programmes entre eux
        /// </summary>
        /// <param name="other">Programme à comparer</param>
        /// <returns></returns>
        public bool Equals(Programme other)
        {
            return this.Equals(other.Nom);
        }

        /// <summary>
        /// Méthode qui vérifie que l'objet passé en paramètre est un programme et qui appelle la méthode Equals avec un Programme passé en paramètres
        /// </summary>
        /// <param name="value">Objet à comparer</param>
        /// <returns></returns>
        public override bool Equals(Object value)
        {
            if(!(value is Programme))
            {
                throw new ArgumentException("Error : l'objet passé en paramètre n'est pas un programme");
            }
            return Equals(value as Programme);
        }

        /// <summary>
        /// Méthode renvoyant le HashCode du programme instancié
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}
