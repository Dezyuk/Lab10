using Lab10.RandomPartsWarehouse;
using Lab10;
using static Lab10.SortParts;

internal class Program
{
    private static void Main(string[] args)
    {
        string jsonPath = "storage_threads.json";
        Storehouse storage = new Storehouse();
        Manager.GeneratePartsInStorehouse(storage, jsonPath, 1000000, 4);

        //Console.WriteLine("-----------------------\nSort by Ascending Cost:\n");
        //Manager.ParallelSort(storage, OrderByNameLeft, 4);
        //Console.WriteLine(storage);

    }
}