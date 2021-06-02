using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application
{
    public class Valeur
    {
        /// <summary>
        /// Nombre de séries d'un exercice
        /// </summary>
        private int nbSeries;
        public int NbSeries
        {
            get
            {
                return nbSeries;
            }
            set
            {
                if (value>0)
                {
                    nbSeries = value;
                }
            }
        }

        /// <summary>
        /// Nombre de répétitions par séries
        /// </summary>
        private int nbReps;
        public int NbReps
        {
            get
            {
                return nbReps;
            }
            set
            {
                if (value > 0)
                {
                    nbReps = value;
                }
            }
        }

        /// <summary>
        /// Temps de repos entre deux séries
        /// </summary>
        private int tpsRepos;
        public int TpsRepos
        {
            get
            {
                return tpsRepos;
            }
            set
            {
                if (value > 0)
                {
                    tpsRepos = value;
                }
            }
        }

        /// <summary>
        /// Constructeur de la classe Valeur
        /// </summary>
        /// <param name="nbSeries"> Nombre de séries </param>
        /// <param name="nbReps">Nombre de répétition par séries </param>
        /// <param name="tpsRepos"> Temps de repos entre deux séries </param>
        public Valeur(int nbSeries, int nbReps, int tpsRepos)
        {
            NbSeries = nbSeries;
            NbReps = nbReps;
            TpsRepos = tpsRepos;
        }

        /// <summary>
        /// Méthode renvoyant une forme écrite d'une Valeur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"NbSeries : {NbSeries} ; NbReps : {NbReps} ; Temps Repos : {TpsRepos}";
        }
    }
}
