using FluentAssertions;
using NUnit.Framework;
namespace GeometricFigures.Logic.Tests
{
    public class CalculateRectangleAreaTests
    {
        [TestCase(10, 10, 100)]
        [TestCase(20, 3, 60)]
        [TestCase(3, 6, 18)]
        public void CalculateRectangleArea(double @base, double height, double areaExpected)
        {
            var rectangle = GivenRectangleWithBaseAndHeight(@base, height);

            var area = WhenCalculatingRectangleArea(rectangle);

            ThenAreaMustBeLikeExpected(areaExpected, area);
        }

        private static object[] _expectedMessages =
        {
            new object[]
            {
                -1d, 2d, DomainConstants.MessageWhenNegativeRectangleParameters
            },
            new object[]
            {
                0d, 3d, DomainConstants.MessageWhenZeroRectangleParameters
            },
        };
        [TestCaseSource(nameof(_expectedMessages))]
        public void CalculateAreaWhereInvalidArgument(double @base, double height, string messageExpected)
        {
            var ex = Assert.Catch(() => GivenRectangleWithBaseAndHeight(@base, height));

            ThenErrorMessageShouldBeLikeExpected(messageExpected, ex);
        }
        private static void ThenErrorMessageShouldBeLikeExpected(string messageExpected, Exception? ex)
        {
            ex.Message.Should().Be(messageExpected);
        }
        private static void ThenAreaMustBeLikeExpected(double areaExpected, double area)
        {
            Round(area).Should().Be(Round(areaExpected));
        }
        private static double Round(double area)
        {
            return Math.Round(area, Constants.Round);
        }
        private static double WhenCalculatingRectangleArea(IFigure circle)
        {
            return circle.CalculateArea();
        }
        private static IFigure GivenRectangleWithBaseAndHeight(double @base, double height)
        {
            return new Rectangle(@base, height);
        }
    }
}
