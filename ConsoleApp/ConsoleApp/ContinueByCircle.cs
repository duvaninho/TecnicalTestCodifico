using GeometricFigures.Logic;
namespace ConsoleApp;
internal class ContinueByCircle : IContinueByFigure
{
    public void Handle()
    {
        var radius = RequestRadius();
        IFigure? figure = CreateCircle(radius);
        if (figure != null)
        {
            Console.WriteLine($"Area: {figure.CalculateArea()}");
        }
    }
    private static double RequestRadius()
    {
        const bool isRadiusValid = false;
        while (!isRadiusValid)
        {
            Console.Write("Enter radius: ");
            try
            {
                if (!float.TryParse(Console.ReadLine(), out var radius))
                {
                    throw new FormatException("Invalid radius");
                }
                if (!float.IsFinite(radius))
                {
                    throw new InvalidOperationException("Invalid radius");
                }
                return radius;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    private static Circle? CreateCircle(double radius)
    {
        try
        {
            return new Circle(radius);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
}
