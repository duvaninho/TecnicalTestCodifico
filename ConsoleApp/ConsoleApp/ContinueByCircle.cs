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
                var radius = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                return radius;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid radius");
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
