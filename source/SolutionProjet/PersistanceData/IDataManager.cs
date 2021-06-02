using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace PersistanceData
{
    public interface IDataManager
    {
        Listes ChargeDonnees();
        void SauvegardeDonnees(Listes list);
    }
}
