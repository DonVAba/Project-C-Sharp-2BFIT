using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Persistance
{
    public abstract class DataLoad
    {
        private string chemin;

        public DataLoad(string chemin)
        {
            this.chemin = chemin;
        }
        public abstract Listes ChargeDonnees();
    }
}
