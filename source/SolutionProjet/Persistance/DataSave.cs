using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Persistance
{
    public abstract class DataSave
    {
        private string chemin;

        public DataSave(string chemin)
        {
            this.chemin = chemin;
        }
        public abstract void SauvegardeDonnees(Listes dataList);
    }
}
