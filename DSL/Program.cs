using Newtonsoft.Json;
using System;

namespace FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = FamilyMemberBuilder
                .Create()
                .NameOfTheFamilyMember("Max Mustermann")
                .Born("01/01/1980")
                .City("Musterstadt")
                .NameOfFather("Moritz")
                .NameOfMother("Mia")
                .BirthDetails(builder => builder
                    .BirthWeight(3500)
                    .BirthLength(50))                
                .Build();

            Console.WriteLine("Latest Family Member:\n");
            Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented));            
        }
    }
}
