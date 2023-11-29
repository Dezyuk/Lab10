using System.Text;

namespace Lab10.RandomPartsWarehouse
{
    public class RandomParts
    {
        //Небольшой блок для создания объектов для тестирования
        public static PartsWarehouse CreateParts()
        {
            Random r = new Random();
            PartsWarehouse part = new PartsWarehouse(
                 Utils.getRandomName(),
                 getRandomId(),
                 r.NextDouble() + (r.Next(50, 500)*10),
                 (uint)r.Next(1, 20)
                );

            return part;
        }
        private static string getRandomId()
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < r.Next(6, 10); i++)
            {
                int temp = r.Next(0, 2);
                sb.Append((char)(temp == 0 ? (r.Next(48, 58)) : (r.Next(65, 91))));
            }
            return sb.ToString();
        }
    }

}
