namespace Lab10
{
    /// <summary>
    /// Класс описывающий свойства запчасти.
    /// </summary>
    [Serializable]
    public class PartsWarehouse
    {

        private string _name;
        private string _id;
        private double _price;
        private uint _quantity;
        private const byte MIN_ID_LENGHT = 5;

        /// <summary>
        /// Конструктор класса PartsWarehouse.
        /// </summary>
        /// <param name="name">Название детали.</param>
        /// <param name="id">Уникальный ID.</param>
        /// <param name="price">Цена за единицу товара.</param>
        /// <param name="quantity">Количество на складе.</param>
        public PartsWarehouse(string name, string id, double price, uint quantity)
        {
            Name = name;
            Id = id;
            Price = price;
            Quantity = quantity;
        }

        public PartsWarehouse()
        {

        }

        /// <summary>
        /// Свойство название детали, возвращает Incorrect name, если пытаемся присвоить пустую строку.
        /// </summary>

        public string Name
        {
            get => _name;
            init
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value.Trim();
                }
                else
                {
                    throw new ArgumentNullException("Incorrect name.");
                }
            }
        }

        /// <summary>
        /// Свойство ID, возвращает Incorrect ID, если пытаемся присвоить пустую строку или строку менее чем и 5 символов.
        /// </summary>

        public string Id
        {
            get => _id;
            init
            {
                string newValue = value.ToUpper().Trim();
                int valueLength = newValue.ToCharArray().Length;
                if (!string.IsNullOrEmpty(value) && valueLength > MIN_ID_LENGHT)
                {
                    _id = newValue.Trim();
                }
                else
                {
                    throw new ArgumentNullException("Incorrect ID.");
                }
            }
        }
        /// <summary>
        /// Свойство цена, возвращает Incorrect price, если пытаемся передать число меньше 0, а так же округление переданного значения до 2 знаков после запятой.
        /// </summary>

        public double Price
        {
            get => _price;
            set
            {
                if (value > 0)
                {
                    _price = Math.Round(value, 2);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Incorrect price.");
                }
            }
        }

        /// <summary>
        /// Свойство количество запчастей, тип данных uint благодаря чему невозможно указать отрицательное значение или null.
        /// </summary>

        public uint Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        public override string ToString()
        {
            return $"\nName: {Name}\n" +
                   $"Id: {Id}\n" +
                   $"Price: {Price}\n" +
                   $"Quantity: {Quantity}\n";

        }
    }
}
