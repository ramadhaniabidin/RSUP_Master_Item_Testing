using RSUP_Master_Item.Logics;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        TestClass testClass = new TestClass();
        List<string> units = new List<string>{ "Butir", "Kg"};
        testClass.CreateMasterItemFromQuery(units);
    }
}