using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Valeur
    {
        private int nbSeries;
        private int nbExercices;
        private int tpsRepos;

        public Valeur(int nbSeries, int nbExercices, int tpsRepos)
        {
            this.nbSeries = nbSeries;
            this.nbExercices = nbExercices;
            this.tpsRepos = tpsRepos;
        }
    }
}
