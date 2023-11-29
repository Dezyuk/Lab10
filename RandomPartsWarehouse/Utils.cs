namespace Lab10.RandomPartsWarehouse
{
    public class Utils
    {
        //Список деталей(взят из интернета)
        private static Random _random = new();
        private static string[] _parts = {
            "Front ventilated brake disc",
            "External CV joint without ring \"ABS\"",
            "Gas suspension shock absorber, rear \"Esen\"",
            "Front gas suspension shock absorber \"Excel-G\"",
            "Front suspension spring",
            "Rear suspension spring",
            "Shock absorber support",
            "Door plug",
            "Oil scraper cap",
            "Laying spark plug wells",
            "Stopper",
            "Front suspension silent block",
            "Subframe silent block",
            "Silent block",
            "Bolt",
            "Front stabilizer",
            "Repair kit",
            "Lower lever silent block",
            "Stabilizer bushing"
        };

        public static string getRandomName()
        {
            return _parts[_random.Next(_parts.Length)];
        }
    }
}
