using FluentAssertions;
using NUnit.Framework;
namespace GeometricFigures.Logic.Tests;

public class CalculateCircleAreaTests
{
    [TestCase(100, 31415.93)]
    [TestCase(20, 1256.64)]
    [TestCase(3, 28.27)]
    public void CalculateCircleArea(decimal areaExpected, decimal radius)
    {
        var circle = GivenCircleWithRadius(radius);

        var area = WhenCalculatingCircleArea(circle);

        ThenAreaMustBeLikeExpected(areaExpected, area);
    }

    private static object[] _expectedMessages =
    {
        new object[]
        {
            -1M, DomainConstants.MessageWhenNegativeRadius
        },
        new object[]
        {
            0M, DomainConstants.MessageWhenZeroRadius
        },
    };
    [TestCaseSource(nameof(_expectedMessages))]
    public void CalculateAreaWhereInvalidArgument(decimal radius, string messageExpected)
    {
        var circle = GivenCircleWithRadius(-1);

        var ex = Assert.Catch(() => WhenCalculatingCircleArea(circle));

        ThenErrorMessageShouldBeLikeExepected(messageExpected, ex);
    }
    private static void ThenErrorMessageShouldBeLikeExepected(string messageExpected, Exception? ex)
    {
        ex.Message.Should().Be(messageExpected);
    }
    private static void ThenAreaMustBeLikeExpected(decimal areaExpected, decimal area)
    {
        Round(area).Should().Be(Round(areaExpected));
    }
    private static decimal Round(decimal area)
    {
        return Math.Round(area, Constants.Round);
    }
    private static decimal WhenCalculatingCircleArea(IFigure circle)
    {
        return circle.CalculateArea();
    }
    private static IFigure GivenCircleWithRadius(decimal radius)
    {
        return new Circle(radius: radius);
    }
}
