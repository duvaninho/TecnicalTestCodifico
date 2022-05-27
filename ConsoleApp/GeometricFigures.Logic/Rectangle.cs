namespace GeometricFigures.Logic;

public class Rectangle : IFigure
{
    public double Base { get; private set; }
    public double Height { get; private set; }
    public Rectangle(double @base, double height)
    {
        if (@base < 0 || height < 0)
        {
            throw new ArgumentException(DomainConstants.MessageWhenNegativeRectangleParameters);
        }
        if (@base == 0 || height == 0)
        {
            throw new ArgumentException(DomainConstants.MessageWhenZeroRectangleParameters);
        }
        Base = @base;
        Height = height;
    }
    public double CalculateArea()
    {
        return Base * Height;
    }
}
