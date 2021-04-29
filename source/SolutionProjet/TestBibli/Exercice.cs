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


        public string CheminImage { get; set; }

        public Exercice(string Nom, string cheminImage, Valeur valeurDeb, Valeur valeurInter, Valeur valeurExpert):base(Nom)
        {
            CheminImage = cheminImage;
            this.valeurDeb = valeurDeb;
            this.valeurInter = valeurInter;
            this.valeurExpert = valeurExpert ;
        }
    }
}
