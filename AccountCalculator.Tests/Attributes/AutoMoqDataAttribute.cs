using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;

namespace AccountCalculator.Tests.Attributes
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            :base(()=>
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(
                    new AutoMoqCustomization(),
                    new SupportMutableValueTypesCustomization())
                );

                return fixture;
            })
        {

        }
    }
}
