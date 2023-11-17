using System;
using System.IO;
using System.Text.Json;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Event e = new Event(1, "Calgary");
            
            //Console.WriteLine(e.EventNumber);
            //Console.WriteLine(e.Location);

            string path = "events.json";
            string encoded = JsonSerializer.Serialize(e);
        

            File.WriteAllText(path, encoded);

            Console.WriteLine("Wrote to JSON file.");

            //Deserialize
            string contents = File.ReadAllText(path);

            //JsonSerializer.Deserialize(encoded, typeof(Event));
            Event decoded = JsonSerializer.Deserialize<Event>(contents);
            Console.WriteLine(decoded.EventNumber);
            Console.WriteLine(decoded.Location);

            SerialDeserializeStream();
        }

        static void SerialDeserializeStream()
        {
            string path = "name.txt";
            StreamWriter streamWriter = File.CreateText(path);
            streamWriter.WriteLine("Hbckathon");
            streamWriter.Close();

            StreamReader streamReader = File.OpenText(path);



            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            int charNum = streamReader.Read();
            char firstChar = (char)charNum;
            Console.WriteLine("First: " + firstChar);

            int middleCharPos = (int)(streamReader.BaseStream.Length / 2);
            streamReader.BaseStream.Seek(middleCharPos, SeekOrigin.Begin);
            charNum = streamReader.Read();
            char middleChar = (char)charNum;
            Console.WriteLine("Middle: " + middleChar);



            streamReader.BaseStream.Seek(0, SeekOrigin.End);
            int charNum = streamReader.Read();
            char lastChar = (char)charNum;
            Console.WriteLine("Last: " + lastChar);
        }
    }
}