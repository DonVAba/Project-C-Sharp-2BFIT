using System;
using System.Collections.Generic;
using System.Text;
using Application;

namespace Persistance
{
    public abstract class IDataSave
    {
        public abstract void SauvegardeDonnees(LinkedList<Programme> listProgramme,List<Utilisateur> listUsers);
    }
}
