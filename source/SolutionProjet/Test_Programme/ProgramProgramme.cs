using Application;
using Persistance;
using System;
using System.Collections.Generic;

namespace Test_Programme
{
    class ProgramProgramme
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programme de test programme");
            StubData stub = new StubData();
            LinkedList<Programme> listProg = stub.ChargeListprogramme();


            //Test du ToString
            Console.WriteLine("Test ToString");
            foreach (Programme programme in listProg)
            {
                Console.WriteLine(programme);
            }

            //Test Equals 
            Console.WriteLine("Test Equals :");
            Console.WriteLine("Avec deux programme differents : " + listProg.First.Equals(listProg.Last));
            Programme prog = new Programme("PUSH", "Programme qui fait travailler les pectoraux,triceps et épaules", "chemin image programme PUSH");
            Console.WriteLine("Avec deux programme égaux : " + listProg.Contains(prog));
        }
    }
}
