using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace PersistanceData
{
    public interface IDataManager
    {
        DataToPersist ChargeDonnees();
        void SauvegardeDonnees(Listes list);
    }
}
