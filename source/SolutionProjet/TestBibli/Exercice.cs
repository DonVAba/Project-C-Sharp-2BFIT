using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Exercice : Nommable
    {
        private Valeur valeurDeb;
        private Valeur valeurInter;
        private Valeur valeurExpert;

        private string cheminImage;
        public string CheminImage
        {
            get => cheminImage;
            set => cheminImage = value;
        }

        public Exercice(string Nom, string cheminImage, Valeur valeurDeb, Valeur valeurInter, Valeur valeurExpert):base(Nom)
        {
            CheminImage = cheminImage;
            this.valeurDeb = valeurDeb;
            this.valeurInter = valeurInter;
            this.valeurExpert = valeurExpert ;
        }
    }
}
