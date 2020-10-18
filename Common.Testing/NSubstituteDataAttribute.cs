using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace Common.Testing
{
	public class NSubstitudeDataAttribute : AutoDataAttribute
	{
		public NSubstitudeDataAttribute():base(()=>new Fixture().Customize(new AutoNSubstituteCustomization())) {}
	}
}
