namespace ConsoleApp;

public class Index
{
    private readonly IDictionary<int, Action> _options = new Dictionary<int, Action>()
    {
        {
            1, () => new ContinueByCircle().Handle()
        },
        {
            2, () => new ContinueByRectangle().Handle()
        },
        {
            3, () => _pursue = false
        }
    };
    private static bool _pursue = true;
    public void Main()
    {
        while (_pursue)
        {
            Console.WriteLine("Calculation areas for geometrics figures");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Exit");

            var option = RequestOption();

            Console.Clear();

            _options[option].Invoke();

            Console.ReadKey();
            Console.Clear();
        }
        Console.ReadKey();
        Console.Clear();
    }
    private int RequestOption()
    {
        const bool isOptionValid = false;
        while (!isOptionValid)
        {
            try
            {
                Console.Write("Enter option: ");
                if (!int.TryParse(Console.ReadLine(), out var option))
                {
                    throw new FormatException("Your input is not valid");
                }
                if (!_options.ContainsKey(option))
                {
                    throw new InvalidOperationException($"The option {option} is not handle");
                }
                return option;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
