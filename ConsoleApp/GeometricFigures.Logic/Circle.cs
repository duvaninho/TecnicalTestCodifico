namespace GeometricFigures.Logic;

public class Circle : IFigure
{
    public double Radius { get; private set; }
    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException(DomainConstants.MessageWhenNegativeRadius);
        }
        if (radius == 0)
        {
            throw new ArgumentException(DomainConstants.MessageWhenZeroRadius);
        }
        Radius = radius;
    }
    public double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius,2);
    }
}