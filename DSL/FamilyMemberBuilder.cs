using System;

namespace FamilyTree
{
    public class FamilyMemberBuilder
    {
        protected FamilyMember familyMember;

        public FamilyMemberBuilder()
        {
            familyMember = new FamilyMember();
        }

        public static FamilyMemberBuilder Create() => new FamilyMemberBuilder();

        public FamilyMemberBuilder NameOfTheFamilyMember(string FullName)
        {
            familyMember.FullName = FullName;
            return this;
        }

        public FamilyMemberBuilder Born(string DateOfBirth)
        {
            familyMember.DateOfBirth = Convert.ToDateTime(DateOfBirth);
            return this;
        }

        public FamilyMemberBuilder City(string Birthplace)
        {
            familyMember.Birthplace = Birthplace;
            return this;
        }

        public FamilyMemberBuilder NameOfFather(string Father)
        {
            familyMember.Father = Father;
            return this;
        }

        public FamilyMemberBuilder NameOfMother(string Mother)
        {
            familyMember.Mother = Mother;
            return this;
        }

        public FamilyMemberBuilder BirthDetails(Action<FamilyMemberDetailsBuilder> configure)
        {
            var builder = new FamilyMemberDetailsBuilder();
            configure(builder);
            familyMember.BirthDetails = builder.Build();
            return this;
        }

        public FamilyMember Build() => familyMember;
    }
}
