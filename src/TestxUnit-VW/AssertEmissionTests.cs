namespace TestxUnit_VW
{
    using Xunit;
    using Assert = Xunit.VW.Assert;

    public class AssertEmissionTests
	{
		[Fact]
		public void EmissionTests()
		{
			const int Emissions = 9001;
			const int LegalLimit = 1337;
			
			Assert.NotInRange(Emissions, 0, LegalLimit);			
		}
	}
}