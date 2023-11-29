using Lab10.RandomPartsWarehouse;
using static Lab10.SortParts;

namespace Lab10
{
    internal class Manager
    {
        /// <summary>
        /// Создание потоков и генерация объектов в нескольких потоках
        /// </summary>
        public static void GeneratePartsInStorehouse(Storehouse storage, string jsonPath, int arraySize, int threadNumber)
        {
            if (storage != null && !string.IsNullOrEmpty(jsonPath) && arraySize > 0 && threadNumber > 0)
            {
                int chunkSize = arraySize / threadNumber;
                Task[] tasks = new Task[threadNumber];
                for (int i = 0; i < threadNumber; i++)
                {
                    tasks[i] = PutPartsInStorehouse(storage, chunkSize);
                }
                Task.WaitAll(tasks);
                FileManager.SerializationJSON(storage, jsonPath);
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        /// <summary>
        /// Генерация и сохранение элементов в список
        /// </summary>
        private static Task PutPartsInStorehouse(Storehouse storage, int chunkSize)
        {
            if (chunkSize > 0)
            {
                for (int i = 0; i < chunkSize; i++)
                {
                    storage.AddParts(RandomParts.CreateParts());
                }
                return Task.CompletedTask;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }



        /// <summary>
        /// Параллельная сортировка
        /// </summary>
        public static void ParallelSort(Storehouse storage, CompareDelegate compareParts, int threadNumber)
        {
            if (compareParts != null && storage != null && threadNumber > 0)
            {
                Task[] tasks = new Task[threadNumber];
                List<Storehouse> sections = SplitList(storage, threadNumber);
                for (int i = 0; i < threadNumber; i++)
                {
                    tasks[i] = Task.Run(() => Sort(sections[i], compareParts));
                }

                Task.WaitAll(tasks);
                storage.WarehouseList = MergeSortedChunks(sections, compareParts);
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        /// <summary>
        /// Деления на секции массива
        /// </summary>
        public static List<Storehouse> SplitList(Storehouse storage, int sections)
        {
            if (sections < 0 || storage is null)
            {
                throw new ArgumentNullException("Element can not be null");
            }

            List<Storehouse> result = new List<Storehouse>();

            int partsPerGroup = storage.WarehouseList.Count / sections;
            int remainingParts = storage.WarehouseList.Count % sections;

            int currentIndex = 0;

            for (int i = 0; i < sections; i++)
            {
                int currentGroupSize = partsPerGroup + (i < remainingParts ? 1 : 0);

                Storehouse part = new Storehouse();
                for (int j = 0; j < currentGroupSize; j++)
                {
                    part.AddParts(storage.WarehouseList[currentIndex]);
                    currentIndex++;
                }

                result.Add(part);
            }

            return result;
        }


        /// <summary>
        /// Объединение массивов
        /// </summary>
        private static List<PartsWarehouse> MergeSortedChunks(List<Storehouse> chunks, CompareDelegate compareParts)
        {
            List<PartsWarehouse> result = new List<PartsWarehouse>();

            while (chunks.Any(chunk => chunk.WarehouseList.Count > 0))
            {
                var nonEmptyChunks = chunks.Where(chunk => chunk.WarehouseList.Count > 0).ToList();

                if (nonEmptyChunks.Count > 0)
                {
                    var minItems = nonEmptyChunks.Select(chunk => chunk.WarehouseList.First()).ToList();
                    var minItem = minItems.Min();

                    foreach (var chunk in nonEmptyChunks)
                    {
                        if (compareParts(chunk.First(), minItem))
                        {
                            result.Add(chunk.First());
                            chunk.RemoveAt(0);
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
