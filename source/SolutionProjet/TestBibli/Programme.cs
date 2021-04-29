using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Programme : Nommable
    {
        /// <summary>
        /// Difficulté par défaut
        /// </summary>
        private const string Diff_Par_Defaut = "DEBUTANT";

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

        public override string ToString()
        {
            return  $"Description : {Description} nbExercices : {NbExercices} chemin Image : {CheminImage}";
        }

    }
}
