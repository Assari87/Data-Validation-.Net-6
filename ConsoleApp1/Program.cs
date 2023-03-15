using ConsoleApp1;
var hr = "\n------------------------";

Console.WriteLine("Welcome to my Test!");
Console.WriteLine(hr);

var testService = new TestServices();
var testApi = new TestApi();

Console.WriteLine($"\tAdd(a)\n\tDelete(d)\n\tLoad Defaults(l)\n\tShow Table(s)\n\tTest(t)\n\tQuit(q)");
Console.WriteLine(hr);
var input = "";
do
{
    Console.WriteLine("\nWhat do you want to do? ");
    input = Console.ReadLine()?.ToLower();

    if (input == "l")
        testService.LoadDefault();
    else if (input == "s")
    {
        Console.WriteLine(testService.TableInfoStatus);

        if (!testService.IsEmpty) testService.Validate();
    }
    else if (input == "a")
    {
        var data = testApi.Add();
        if (data != null)
            testService.AddData(data);
    }
    else if (input == "d")
    {
        Console.WriteLine("\nEnter index of record? ");
        var itemIndex = Console.ReadLine();

        if (int.TryParse(itemIndex, out var value))
        {
            testService.DeleteItem(value);
        }
        else
        {
            Utility.WriteLineError("index is not a number!");
        }
    }
    else if (input == "t")
    {
        Console.WriteLine("Input C1: ");
        var c1 = Console.ReadLine();

        //var isNumber = int.TryParse(c1, out var value);
        if (int.TryParse(c1, out var value))
        {
            var result = testService.CalculateResult(value);
            Console.WriteLine($"Result = {result}");
        }
        else
        {
            Utility.WriteLineError("Input is not a number!");
        }
    }
}
while (input?.ToLower() != "q");
