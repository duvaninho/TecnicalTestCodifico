using FluentAssertions;
using NUnit.Framework;
namespace GeometricFigures.Logic.Tests;

public class CalculateCircleAreaTests
{
    [TestCase(100, 31415.93)]
    [TestCase(20, 1256.64)]
    [TestCase(3, 28.27)]
    public void CalculateCircleArea(double radius, double areaExpected)
    {
        var circle = GivenCircleWithRadius(radius);

        var area = WhenCalculatingCircleArea(circle);

        ThenAreaMustBeLikeExpected(areaExpected, area);
    }

    private static object[] _expectedMessages =
    {
        new object[]
        {
            -1d, DomainConstants.MessageWhenNegativeRadius
        },
        new object[]
        {
            0d, DomainConstants.MessageWhenZeroRadius
        },
    };
    [TestCaseSource(nameof(_expectedMessages))]
    public void CalculateAreaWhereInvalidArgument(double radius, string messageExpected)
    {
        var circle = GivenCircleWithRadius(radius);

        var ex = Assert.Catch(() => WhenCalculatingCircleArea(circle));

        ThenErrorMessageShouldBeLikeExepected(messageExpected, ex);
    }
    private static void ThenErrorMessageShouldBeLikeExepected(string messageExpected, Exception? ex)
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
    private static double WhenCalculatingCircleArea(IFigure circle)
    {
        return circle.CalculateArea();
    }
    private static IFigure GivenCircleWithRadius(double radius)
    {
        return new Circle(radius: radius);
    }
}
