using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

[Serializable]
public class Person
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int? Age { get; set; }

}
public class Serialization
{
    public enum enType { Bin = 0, Json = 1, Xml = 2 }
    public static string Serialize(Person Obj, enType Type)
    {
        string FileName;

        switch (Type)
        {
            case enType.Bin:
                //Serialize to binary
                BinaryFormatter Formatter = new BinaryFormatter();
                using (FileStream Stream = new FileStream($"{Obj.Name}.bin", FileMode.Create))
                {
                    Formatter.Serialize(Stream, Obj);
                }
                return FileName = Path.GetFileName($"{Obj.Name}.bin");

                
            case enType.Xml:
                //serialize to xml
                XmlSerializer Serializer = new XmlSerializer(typeof(Person));
                using (TextWriter Writer = new StreamWriter($"{Obj.Name}.xml"))
                {
                    Serializer.Serialize(Writer, Obj);
                }
                    return FileName = Path.GetFileName($"{Obj.Name}.xml");

            case enType.Json:
                //serialize to JSON
                DataContractJsonSerializer JSONSerializer = new DataContractJsonSerializer(typeof(Person));
                using (MemoryStream stream = new MemoryStream())
                {
                    JSONSerializer.WriteObject(stream, Obj);
                    string JsonString = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                    File.WriteAllText($"{Obj.Name}.json", JsonString);
                }
                    return FileName = Path.GetFileName($"{Obj.Name}.json");


                
            default:
                return "Error, No file serialization";




        }

    }
    public static Person Deserialize(string File, enType Type)
    {
        switch (Type)
        {
            case enType.Bin:
                BinaryFormatter Formatter = new BinaryFormatter();
                using (FileStream Stream = new FileStream(File, FileMode.Open))
                {
                    Person Deserialized = (Person)Formatter.Deserialize(Stream);
                    return Deserialized;
                }
                
            case enType.Xml:
                XmlSerializer Serializer = new XmlSerializer(typeof(Person));
                using (TextReader Reader = new StreamReader(File))
                {
                    Person Deserialized = (Person)Serializer.Deserialize(Reader);
                    return Deserialized;
                }
                
            case enType.Json:
                DataContractJsonSerializer JSONSerializer = new DataContractJsonSerializer(typeof(Person));
                using (FileStream Stream = new FileStream(File, FileMode.Open))
                {
                    Person Deserialized = (Person)JSONSerializer.ReadObject(Stream);
                    return Deserialized;
                }
                
            default:
                return null;

        }
    }

}
public class Printer 
{
    public static void Print(Person Obj)
    {
        Console.WriteLine($"ID: {Obj.ID}, Name: {Obj.Name}, Age: {Obj.Age}");
    }

}

class Program
{
    static void Main()
    {
        Person Carlos = new Person { ID = 1, Name = "Carlos", Age = 28 };
        Person Koda = new Person { ID = 2, Name = "Koda", Age = 2 };
        Person Ricardo = new Person { ID = 3, Name = "Ricardo", Age = 48 };



       Console.WriteLine(Serialization.Serialize(Carlos, Serialization.enType.Bin));
       Console.WriteLine(Serialization.Serialize(Koda, Serialization.enType.Xml));
       Console.WriteLine(Serialization.Serialize(Ricardo, Serialization.enType.Json));

        Printer.Print(Serialization.Deserialize("Carlos.bin", Serialization.enType.Bin));
        Printer.Print(Serialization.Deserialize("Koda.xml", Serialization.enType.Xml));
        Printer.Print(Serialization.Deserialize("Ricardo.json", Serialization.enType.Json));

        Console.ReadKey();






    }
}

