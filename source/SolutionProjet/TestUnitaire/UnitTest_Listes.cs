using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Application;

namespace TestUnitaire
{
    public class UnitTest_Listes
    {
        Listes l = new Listes();
        [Fact]
        public void TestRechercheUtilisateur()
        {
            Assert.Null(l.RechercherUtilisateur("gvrgergerg"));
        }

        [Fact]
        public void testUtilisateurDejaInscrit()
        {
            Utilisateur u1 = new Utilisateur("bamartel", "bamartel", new DateTime(2003, 1, 30), 190, 190, "bamartel", "mdpDeBamartel");
            l.AjouterUtilisateurInscription(u1, "bamartel");

            Utilisateur u2 = new Utilisateur("Malea", "Bastien", new DateTime(2003, 1, 30), 180, 180, "bamartel", "mdpDeBastien");
            Assert.Throws<ArgumentException>(() => l.AjouterUtilisateurInscription(u2, "bamartel"));
        }

        [Fact]
        public void ConnexionMauvaisLogs()
        {
            //Vérifie la connexion, renvoie une ArgumentException car mauvais login et mot de passe
            Utilisateur u1 = new Utilisateur("bamartel", "bamartel", new DateTime(2003, 1, 30), 190, 190, "bamartel", "mdpDeBamartel");
            Assert.Throws<ArgumentException>(() => l.VerifierConnexion("mauvaisLogin", "Mauvaismdp"));
        }


    }
}
