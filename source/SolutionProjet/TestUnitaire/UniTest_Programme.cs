using Application;
using Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace TestUnitaire
{
    public class UniTest_Programme
    {
        Manager man = new Manager();
        [Fact]
        
        public void TestValiditeProgrammeSansNom()
        {   
            //Renvoie False quand un programme sans nom est instancié 
            Programme p1 = new Programme("", "chemin image A", "Programme PUSH");
            Assert.False(CreationObjectValidator.ValidationAjoutProgramme(p1));
        }

        [Fact]
        public void TestAjoutExerciceSansNom()
        {
            //Renvoie une exception quand on ajoute un exercice sans nom
            Programme p1 = new Programme("push", "Programme PUSH", "chemin image A");
            Assert.Throws<ArgumentException>(() => man.AjouterUnExercice(p1,new Exercice("", "chemin image ", new Valeur(1, 2, 3), new Valeur(4, 5, 6), new Valeur(7, 8, 9))));
            
        }

        [Fact]
        public void TestAjoutExerciceValeurVide()
        {
            //Renvoie une exception lorsqu'on ajoute un exercice sans valeur 
            Programme p1 = new Programme("push", "Programme PUSH", "chemin image A");
            Assert.Throws<ArgumentException>(() => man.AjouterUnExercice(p1, new Exercice("", "chemin image ", new Valeur(1, 2, 3), new Valeur(0, 0, 0), new Valeur(0, 0, 0))));
        }
    }
}
