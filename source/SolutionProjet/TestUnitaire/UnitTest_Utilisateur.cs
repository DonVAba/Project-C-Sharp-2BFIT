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
        public void TestUtilisateurSansIdentité()
        {
            Utilisateur u1 = new Utilisateur("", "", new DateTime(2003, 1, 30), 190, 190, "bamartel", "mdpDeBamartel");
            Assert.False(CreationObjectValidator.ValidationAjoutUser(u1));
        }

        [Fact]
        public void TestMensurationTropElevee()
        {
            Utilisateur u1 = new Utilisateur("Baptiste", "Martel", new DateTime(2003, 1, 30), 300, 300, "bamartel", "mdpDeBamartel");
            Assert.False(CreationObjectValidator.ValidationAjoutUser(u1));
        }

        
    }








}
    


