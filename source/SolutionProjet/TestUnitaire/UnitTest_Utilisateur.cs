using Application;
using System;
using System.Diagnostics;
using Xunit;

namespace TestUnitaire
{   /// <summary>
/// Classe test unitaire pour l'utilisateur 
/// </summary>
    public class UnitTest_Utilisateur
    {
        [Fact]
        public void TestProgrammeSansNom()
        {
            Programme p1 = new Programme("a", "chemin image A", "Programme PUSH");
            Debug.WriteLine(p1);
            p1.LesExercices.AddLast(new Exercice("Exercice 1", "chemin image ", new Valeur(1, 2, 3), new Valeur(4, 5, 6), new Valeur(7, 8, 9)));
            p1.LesExercices.AddLast(new Exercice("Exercice 2", "chemin image ", new Valeur(1, 2, 3), new Valeur(4, 5, 6), new Valeur(7, 8, 9)));
            p1.LesExercices.AddLast(new Exercice("Exercice 3", "chemin image ", new Valeur(1, 2, 3), new Valeur(4, 5, 6), new Valeur(7, 8, 9)));

            Assert.True(Management.CreationObjectValidator.ValidationAjoutProgramme(p1));

            
        }
    }
}
