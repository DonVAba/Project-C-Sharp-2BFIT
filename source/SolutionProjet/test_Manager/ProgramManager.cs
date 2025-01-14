﻿using System;
using PersistanceData;
using Application;
using System.Collections.Generic;
using System.Linq;
using Management;

namespace test_Manager
{
    public class ProgramManager
    {
        static void Main(string[] args)
        {
            StubData stub = new StubData("");
            Listes list = stub.ChargeDonnees();
            Manager manager = new Manager(list);
            
            

            Console.WriteLine("\n-------------- PARTIE MANAGEMENT PROGRAMME ---------------");
            Console.WriteLine("Affichage de la liste des programmes");
            foreach(Programme prog in list.ListProgrammes)
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
            foreach(Programme prog in list.ListProgrammes)
            {
                Console.WriteLine($"{prog}  " + p1.Equals(prog));
            }
            manager.AjouterProgramme(p1);
            foreach (Programme prog in list.ListProgrammes)
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
            foreach (Programme prog in list.ListProgrammes)
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
                Console.WriteLine(list.ProgrammeChoisi.Equals(p1)); 
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
            foreach (KeyValuePair<String, Utilisateur> compte in list.listComptes)
            {
                Console.WriteLine($"Login = {compte.Key}\n Utilisateur ={compte.Value}\n ");
            }

            Console.WriteLine("\n-----------------");
            Console.WriteLine("Test ajout d'utilisateur");

            //Création d'un nouvel utilisateur qu'on ajoute ensuite dans le dictionnaire compte

            Utilisateur u1 = new Utilisateur("Chevaldonne", "Marc", new DateTime(1950, 1, 30), 190, 190, "Marc", "mdpDeMrChevaldonne");

            //Test avec un utilisateur correct
            try
            {
                manager.AjouterUtilisateurInscription(u1);
                foreach (KeyValuePair<String, Utilisateur> compte in list.listComptes)
                {
                    Console.WriteLine($"Login = {compte.Key}\n Utilisateur ={compte.Value}\n ");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            //Test avec un utilisateur null
            try
            {
                manager.AjouterUtilisateurInscription(null);
                foreach (KeyValuePair<String, Utilisateur> compte in list.listComptes)
                {
                    Console.WriteLine($"Login = {compte.Key}\n Utilisateur ={compte.Value}\n ");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //Test quand l'utilisateur existe déjà
            try
            {
                manager.AjouterUtilisateurInscription(u1);
                foreach (KeyValuePair<String, Utilisateur> compte in list.listComptes)
                {
                    Console.WriteLine($"Login = {compte.Key}\n Utilisateur ={compte.Value}\n ");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n-----------------");
            Console.WriteLine("Test Verifier Connexion");

            //Test avec login et mdp correcte
            Console.WriteLine("Test avec login et mdp correcte");
            try
            {
                Console.WriteLine(list.VerifierConnexion("Marc", "mdpDeMrChevaldonne"));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Test avec un mauvais mdp

            try
            {
                Console.WriteLine(list.VerifierConnexion("Marc", "mauvaismdp"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Test avec un mauvais login

            try
            {
                Console.WriteLine(list.VerifierConnexion("MauvaisLogin", "mdpDeMrChevaldonne"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("-------- TEST DE LA METHODE DE LANCEMENT DE PROGRAMME ----------");

            list.UtilisateurCourant = u1;
            Console.WriteLine(list.UtilisateurCourant);
            try
            {
                Console.WriteLine("1");
                manager.LancementProgramme(p1, "DEBUTANT");
                Console.WriteLine(list.ProgrammeChoisi);
                Console.WriteLine("\n" + list.UtilisateurCourant.DernierProgramme + "\n" + list.UtilisateurCourant.DiffDernierProg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
