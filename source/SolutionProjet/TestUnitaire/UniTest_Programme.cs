using Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace TestUnitaire
{
    public class UniTest_Programme
    {
        [Fact]

        public void testProgrammeSansNom()
        {
            //Erreur lors du test "Object reference not set to an instance of an object" 
            //Faut instancier qqchose mais jsp quoi
            Programme p1 = new Programme("a", "chemin image A", "Programme PUSH");
            Debug.WriteLine(p1);
            p1.LesExercices.AddLast(new Exercice("Exercice 1", "chemin image ", new Valeur(1, 2, 3), new Valeur(4, 5, 6), new Valeur(7, 8, 9)));
            p1.LesExercices.AddLast(new Exercice("Exercice 2", "chemin image ", new Valeur(1, 2, 3), new Valeur(4, 5, 6), new Valeur(7, 8, 9)));
            p1.LesExercices.AddLast(new Exercice("Exercice 3", "chemin image ", new Valeur(1, 2, 3), new Valeur(4, 5, 6), new Valeur(7, 8, 9)));

            Assert.True(Management.CreationObjectValidator.ValidationAjoutProgramme(p1));
        }

    }
}
