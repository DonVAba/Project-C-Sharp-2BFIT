using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace PersistanceData
{
    /// <summary>
    /// Interface qui implémentera notre différents sérializers/stubs
    /// </summary>
    public interface IDataManager
    {
        Listes ChargeDonnees();
        void SauvegardeDonnees(Listes list);
    }
}
