namespace Lab10
{
    public class SortParts
    {
        public delegate bool CompareDelegate(PartsWarehouse left, PartsWarehouse right);

        /// <summary>
        /// Сортировка массива
        /// </summary>
        /// <param name="storehouse">Список деталей</param>
        /// <param name="compareDelegate">Делегат</param>
        public static void Sort(Storehouse storehouse, CompareDelegate compareDelegate)
        {
            if (storehouse != null && compareDelegate != null)
            {
                for (int i = 0; i < storehouse.WarehouseList.LongCount() - 1; i++)
                {
                    for (int j = 0; j < storehouse.WarehouseList.LongCount() - 1; j++)
                    {
                        if (compareDelegate(storehouse.WarehouseList[j], storehouse.WarehouseList[j + 1]))
                        {
                            (storehouse.WarehouseList[j], storehouse.WarehouseList[j + 1]) = (storehouse.WarehouseList[j + 1], storehouse.WarehouseList[j]);
                        }

                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
                
        }
      

        public static bool OrderByNameLeft(PartsWarehouse left, PartsWarehouse right)
        {
            if (left != null && right != null)
            {
                return string.Compare(left.Name, right.Name, StringComparison.Ordinal) > 0;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
        public static bool OrderByDescendingNameLeft(PartsWarehouse left, PartsWarehouse right)
        {
            if (left != null && right != null)
            {
                return string.Compare(left.Name, right.Name, StringComparison.Ordinal) < 0;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        public static bool OrderByIdLeft(PartsWarehouse left, PartsWarehouse right)
        {
            if (left != null && right != null)
            {
                return string.Compare(left.Id, right.Id, StringComparison.Ordinal) > 0;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
        public static bool OrderByDescendingIdLeft(PartsWarehouse left, PartsWarehouse right)
        {
            if (left != null && right != null)
            {
                return string.Compare(left.Id, right.Id, StringComparison.Ordinal) < 0;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        public static bool OrderByPriceLeft(PartsWarehouse left, PartsWarehouse right)
        {
            if (left != null && right != null)
            {
                return left.Price > right.Price;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
        public static bool OrderByDescendingPriceLeft(PartsWarehouse left, PartsWarehouse right)
        {
            if (left != null && right != null)
            {
                return left.Price < right.Price;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        public static bool OrderByQuantityLeft(PartsWarehouse left, PartsWarehouse right)
        {
            if (left != null && right != null)
            {
                return left.Quantity > right.Quantity;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
        public static bool OrderByDescendingQuantityLeft(PartsWarehouse left, PartsWarehouse right)
        {
            if (left != null && right != null)
            {
                return left.Quantity < right.Quantity;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


    }
}
