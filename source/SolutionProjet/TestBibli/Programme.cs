using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Programme : Nommable
    {
        
        
        
        public string Description
        {
            get;
            private set;
        }

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

        private string cheminImage;

        public string CheminImage
        {
            get => cheminImage;
            set => cheminImage = value;
        }

        public Programme(string description, int nbExercices, string cheminImage)
        {
            Description = description;
            NbExercices = nbExercices;
            CheminImage = cheminImage;
        }

        public override string ToString()
        {
            return  $"Description : {Description} nbExercices : {NbExercices} chemin Image : {CheminImage}";
        }

    }
}
