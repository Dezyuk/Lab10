using System.Text;
using System.Text.Json;

namespace Lab10
{
    public class FileManager
    {
        /// <summary>
        /// Запись в файл в формате JSON. Проверка на то что переданный объект не пуст и что название файла заканчивается на .json
        /// </summary>
        /// <param name="storehouse">Объект который нужно сохранить</param>
        /// <param name="fileName">Название файла</param>
        /// <exception cref="Exception"></exception>
        public static void SerializationJSON(Storehouse storehouse, string fileName)
        {
            if (storehouse is not null && fileName.EndsWith(".json"))
            {
                string output = JsonSerializer.Serialize(storehouse);
                using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(output);
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Чтение файла и преобразование данных в объект.
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Storehouse DeserializationJSON(string fileName)
        {
            if (fileName.EndsWith(".json"))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string json = reader.ReadToEnd();
                        Storehouse storehouse = JsonSerializer.Deserialize<Storehouse>(json);
                        return storehouse;
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }


        /// <summary>
        /// Запись в файл в формате Binary. Проверка на то что переданный объект не пуст и что название файла заканчивается на .bin
        /// </summary>
        /// <param name="storehouse">Объект который нужно сохранить</param>
        /// <param name="fileName">Название файла</param>
        /// <exception cref="Exception"></exception>
        public static void SerializationBinary(Storehouse storehouse, string fileName)
        {
            if (storehouse is not null && fileName.EndsWith(".bin"))
            {
                using (FileStream fileStream = new(fileName, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter writer = new(fileStream, Encoding.Default))
                    {
                        foreach (PartsWarehouse part in storehouse.WarehouseList)
                        {
                            writer.Write(part.Name);
                            writer.Write(part.Id);
                            writer.Write(part.Price);
                            writer.Write(part.Quantity);
                        }
                    }
                }
            }
            else
            {
                throw new Exception();
            }

        }

        /// <summary>
        /// Чтение файла и преобразование данных в объект.
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Storehouse DeserializationBinary(string fileName)
        {
            if (fileName.EndsWith(".bin"))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        Storehouse tempStorehouse = new Storehouse();
                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                        {
                            PartsWarehouse part = new PartsWarehouse
                            {
                                Name = reader.ReadString(),
                                Id = reader.ReadString(),
                                Price = reader.ReadDouble(),
                                Quantity = reader.ReadUInt32()
                            };

                            tempStorehouse.AddParts(part);
                        }
                        return tempStorehouse;
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
