namespace ConsoleApp1
{
    public class TestApi
    {
        public DataModel? Add()
        {
            Console.WriteLine("Start: ");
            var start = Console.ReadLine();

            Console.WriteLine("Start Inclusive(Y/N): ");
            var startInc = Console.ReadLine();

            Console.WriteLine("End:");
            var end = Console.ReadLine();

            Console.WriteLine("End Inclusive(Y/N): ");
            var endInc = Console.ReadLine();

            Console.WriteLine("Result:");
            var result = Console.ReadLine();

            try
            {
                return new DataModel(
                    int.Parse(start),
                    startInc?.ToLower() == "y",
                    int.Parse(end),
                    endInc?.ToLower() == "y",
                    int.Parse(result)
                    );
            }
            catch { Console.WriteLine("Input is incorrect!"); }
            return null;
        }

    }
}
