using Lab10;

internal class Program
{
    private static void Main(string[] args)
    {
        string jsonPath = "storage_threads.json";
        Storehouse storage = new Storehouse();
        TaskManager.GeneratePartsInStorehouse(storage, jsonPath, 1000000, 4);

        //Console.WriteLine("-----------------------\nSort by Ascending Cost:\n");
        //TaskManager.ParallelSort(storage, OrderByNameLeft, 4);
        //Console.WriteLine(storage);

    }
}