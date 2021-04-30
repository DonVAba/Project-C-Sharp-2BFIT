using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Exercice : Nommable
    {
        /// <summary>
        /// Valeur d'un exerice (Temps de repos, Nombre de séries, répétitions, si la difficulté choisie est "DEBUTANT"
        /// </summary>
        private Valeur valeurDeb;
        public Valeur ValeurDeb { get; set; }

        /// <summary>
        /// Valeur d'un exerice (Temps de repos, Nombre de séries, répétitions, si la difficulté choisie est "INTERMEDIAIRE"
        /// </summary>
        private Valeur valeurInter;
        public Valeur ValeurInter { get; set; }

        /// <summary>
        /// Valeur d'un exerice (Temps de repos, Nombre de séries, répétitions, si la difficulté choisie est "INTERMEDIAIRE"
        /// </summary>
        private Valeur valeurExpert;
        public Valeur ValeurExpert { get; set; }

        /// <summary>
        /// Valeur qui varie en fonction du niveau de difficulté choisi du programme
        /// </summary>
        public Valeur ValeurCourante { get; set; }


        /// <summary>
        /// Chemin de l'image associé à l'exercice
        /// </summary>
        public string CheminImage { get; set; }

        /// <summary>
        /// Constructeur de la classe Exercice
        /// </summary>
        /// <param name="Nom">Nom de l'exercice</param>
        /// <param name="cheminImage"> Chemin de l'image associé</param>
        /// <param name="valeurDeb"> Valeur choisie si la difficulté du programme dans lequel il est contenu est "DEBUTANT"</param>
        /// <param name="valeurInter">Valeur choisie si la difficulté du programme dans lequel il est contenu est "INTERMEDIAIRE"</param>
        /// <param name="valeurExpert">Valeur choisie si la difficulté du programme dans lequel il est contenu est "EXPERT"</param>
        public Exercice(string Nom, string cheminImage, Valeur valeurDeb, Valeur valeurInter, Valeur valeurExpert, Difficulte diff) : base(Nom)
        {
            CheminImage = cheminImage;
            this.valeurDeb = valeurDeb;
            this.valeurInter = valeurInter;
            this.valeurExpert = valeurExpert;

            if (diff.ToString().Equals("DEBUTANT"))
            {
                ValeurCourante = ValeurDeb;
            }
            if (diff.ToString().Equals("INTERMEDIAIRE"))
            {
                ValeurCourante = ValeurInter;
            }
            if (diff.ToString().Equals("EXPERT"))
            {
                ValeurCourante = ValeurExpert;
            }
        }

    }
}
