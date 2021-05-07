using Application;
using Management;
using System;
using System.Diagnostics;
using Xunit;
using System.Collections.Generic;

namespace TestUnitaire
{ 
    public class UniTest_Utilisateur
    {
        public Dictionary<string, Utilisateur> listComptes = new Dictionary<string, Utilisateur>();
        Listes listeTest = new Listes();
        
        [Fact]
        public void testUtilisateurDejaInscrit()
        {
            //Initialisation 
            Utilisateur u1 = new Utilisateur("bamartel", "bamartel", new DateTime(2003, 1, 30), 190, 190, "bamartel", "mdpDeBamartel");
            listeTest.AjouterUtilisateurInscription(u1, "bamartel");
            Utilisateur u2 = new Utilisateur("Malea", "Bastien", new DateTime(2003, 1, 30), 180, 180, "bamartel", "mdpDeBastien");

            //Ce qu'on attend 
            Assert.Throws<ArgumentException>(() => listeTest.AjouterUtilisateurInscription(u2, "bamartel"));
        }

        [Fact]
        public void ConnexionMauvaisLogs()
        {
            //Vérifie la connexion, renvoie une ArgumentException car mauvais login et mot de passe
            Utilisateur u1 = new Utilisateur("bamartel", "bamartel", new DateTime(2003, 1, 30), 190, 190, "bamartel", "mdpDeBamartel");
            listeTest.AjouterUtilisateurInscription(u1, "bamartel");
            Assert.Throws<ArgumentException>(() =>listeTest.VerifierConnexion("mauvaisLogin", "Mauvaismdp"));
        }

        
    }








}
    


