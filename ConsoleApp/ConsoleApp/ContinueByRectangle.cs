using GeometricFigures.Logic;
namespace ConsoleApp;

internal class ContinueByRectangle : IContinueByFigure
{
    public void Handle()
    {
        var @base = RequestBase();
        var height = RequestHeight();
        var figure = CreateRectangle(@base, height);
        if (figure != null)
        {
            Console.WriteLine($"Area: {figure.CalculateArea()}");
        }
    }
    private static IFigure? CreateRectangle(float @base, float height)
    {
        try
        {
            return new Rectangle(@base, height);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    private static float RequestHeight()
    {
        const bool isHeightValid = false;
        while (!isHeightValid)
        {
            try
            {
                Console.Write("Enter height: ");
                if (!float.TryParse(Console.ReadLine(), out var height))
                {
                    throw new FormatException("Invalid height");
                }
                if (!float.IsFinite(height))
                {
                    throw new InvalidOperationException("Invalid height");
                }
                
                return height;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    private static float RequestBase()
    {
        const bool isBaseValid = false;
        while (!isBaseValid)
        {
            try
            {
                Console.Write("Enter base: ");
                if (!float.TryParse(Console.ReadLine(), out var @base))
                {
                    throw new FormatException("Invalid base");
                }
                if (!float.IsFinite(@base))
                {
                    throw new InvalidOperationException("Invalid base");
                }
                
                return @base;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
