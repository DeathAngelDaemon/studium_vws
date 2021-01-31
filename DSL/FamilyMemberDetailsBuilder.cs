namespace FamilyTree
{
    public class FamilyMemberDetailsBuilder
    {
        private readonly FamilyMemberDetails birthDetails;

        public FamilyMemberDetailsBuilder()
        {
            birthDetails = new FamilyMemberDetails();
        }

        public FamilyMemberDetailsBuilder BirthWeight(int birthWeight)
        {
            birthDetails.Weight = birthWeight;
            return this;
        }

        public FamilyMemberDetailsBuilder BirthLength(int birthLength)
        {
            birthDetails.Length = birthLength;
            return this;
        }

        internal FamilyMemberDetails Build() => birthDetails;
    }
}
