using System;
using Persistance;
using Application;
using System.Collections.Generic;
using System.Linq;
using Management;


namespace essai_Linq
{
    class ProgramLinq
    {
        static void Main(string[] args)
        {
            StubData stub = new StubData("");
            Listes listLINQ = stub.ChargeDonnees();

            //Affichage des programmes ayant 3 exercices ou plus
            IEnumerable<Programme> lesPlusDeTrois = listLINQ.listProgrammes.Where(p => p.lesExercices.Count() >= 3);
            foreach(Programme prog in lesPlusDeTrois)
            {
                Console.WriteLine(prog);
            }

            //Affichage des login commençant par b
            IEnumerable<KeyValuePair<string,Utilisateur>> lesPlusDeCinq = listLINQ.listComptes.Where(id => id.Key.StartsWith("b"));


        }
    }
}
