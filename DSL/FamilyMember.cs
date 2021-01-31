using System;

namespace FamilyTree
{
    public class FamilyMember
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Birthplace { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        public FamilyMemberDetails BirthDetails { get; set; }
    }
}
