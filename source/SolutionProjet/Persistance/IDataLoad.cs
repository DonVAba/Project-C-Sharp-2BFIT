using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Persistance
{
    public abstract class IDataLoad
    {
        public abstract (LinkedList<Programme>, Dictionary<String, Utilisateur>) ChargeDonnees();
    }
}
