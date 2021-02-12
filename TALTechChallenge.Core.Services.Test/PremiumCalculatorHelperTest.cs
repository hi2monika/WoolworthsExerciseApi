using FluentAssertions;
using System;
using System.Collections.Generic;
using TALTechChallenge.Core.Common.Helper;
using Xunit;

namespace TALTechChallenge.Core.Helper.Test
{

    public class PremiumCalculatorHelperTest
    {
        [Theory]
        [MemberData(nameof(GetTotalRainFallTestCases))]
        public void CalcalatePremium(double deathCoverAmount, double occupationRatingFactor, int age, Action<double> assertion)
        {
            var result = PremiumCalculatorHelper.CalcalatePremium(deathCoverAmount, occupationRatingFactor, age);
            assertion(result);
        }

        public static IEnumerable<object[]> GetTotalRainFallTestCases
        {
            get
            {
                // Test case 1
                Action<double> assertion = result =>
                {

                    result.Should().Be(0.046770833333333331);
                };

                yield return new object[]
                {
                    22.45,1.0,25,assertion
                };

                // Test case 2
                Action<double> assertionTestCase2 = result =>
                {

                    result.Should().Be(0.058463541666666667);
                };

                yield return new object[]
                {
                    22.45,1.25,25,assertionTestCase2
                };

                // Test case 3
                Action<double> assertionTestCase3 = result =>
                {

                    result.Should().Be(0.070156249999999989);
                };

                yield return new object[]
                {
                    22.45,1.50,25,assertionTestCase3
                };

                // Test case 4
                Action<double> assertionTestCase4 = result =>
                {

                    result.Should().Be(0.081848958333333333);
                };

                yield return new object[]
                {
                    22.45,1.75,25,assertionTestCase4
                };
            }
        }
    }
}
