﻿using System;
using Persistance;
using Application;
using System.Collections.Generic;
using System.Linq;
using Management;

namespace test_Manager
{
    class ProgramManager
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            StubData stub = new StubData();
            (LinkedList<Programme> stubProg, Dictionary<String, Utilisateur> stubCompte) = stub.ChargeDonnees();
            manager.listProgrammes = stubProg;
            manager.listComptes = stubCompte;

            Console.WriteLine("\n-------------- PARTIE MANAGEMENT PROGRAMME ---------------");
            Console.WriteLine("Affichage de la liste des programmes");
            foreach(Programme prog in manager.listProgrammes)
            {
                Console.WriteLine(prog);
                foreach(Exercice ex in prog.LesExercices)
                {
                    Console.WriteLine(ex);
                }
            }

            Console.WriteLine("\n--------------------");
            Console.WriteLine("Test ajout programme + equals");
            Programme p1 = new Programme("PUSH", "description d'un programmerandom", "chemin image random");
            foreach(Programme prog in manager.listProgrammes)
            {
                Console.WriteLine($"{prog}  " + p1.Equals(prog));
            }
            manager.AjouterProgramme(p1);
            foreach (Programme prog in manager.listProgrammes)
            {
                Console.WriteLine($"{prog}");
            }

            Console.WriteLine("\n--------------------");
            Console.WriteLine("Test suppression programme");
            try
            {
                manager.SupprimerProgramme(p1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (Programme prog in manager.listProgrammes)
            {
                Console.WriteLine($"{prog}");
            }


            Console.WriteLine("\n--------------------");
            Console.WriteLine("Test méthode ajout programme à la création");
            LinkedList<Exercice> listExercice = new LinkedList<Exercice>();
            listExercice.AddLast(new Exercice("Traction", "chemin img traction", new Valeur(8, 4, 80), new Valeur(10, 4, 70), new Valeur(12, 4, 60)));
            
            try
            {
                manager.AjouterListExerciceALaCreationDunProgramme(p1, listExercice);
                Console.WriteLine("True si ProgrammeChoisi a été mis à jour");
                Console.WriteLine(manager.ProgrammeChoisi.Equals(p1)); 
                foreach(Exercice ex in p1.LesExercices)
                {
                    Console.WriteLine(ex);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            Console.WriteLine("\n------- PARTIE MANEGEMENT USER------");
            Console.WriteLine("Affichage dictionnaire compte");
            foreach (KeyValuePair<String, Utilisateur> compte in manager.listComptes)
            {
                Console.WriteLine($"Login = {compte.Key}\n Utilisateur ={compte.Value}\n ");
            }

            Console.WriteLine("\n-----------------");
            Console.WriteLine("Test ajout d'utilisateur");

        }
    }
}