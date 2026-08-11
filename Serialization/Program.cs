using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq.Expressions;

[Serializable]
public class Person 
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int?Age { get; set; }

    static public void Serialize(string Type, Person Obj) 
    {

        switch (Type) 
        {
            case "Bin":
                //Serialize to binary
                BinaryFormatter Formatter = new BinaryFormatter();
                using (FileStream Stream = new FileStream($"{Obj.Name}.bin", FileMode.Create))
                {
                    Formatter.Serialize(Stream, Obj);
                }
                //deserialize
                using (FileStream Stream = new FileStream($"{Obj.Name}.bin", FileMode.Open))
                {
                    Person Deserialized = (Person)Formatter.Deserialize(Stream);
                    Console.WriteLine($"ID: {Deserialized.ID}, Name: {Deserialized.Name}, Age: {Deserialized.Age}");
                    Console.ReadKey();
                }
                break;
            case "Xml":
                //serialize to xml
                XmlSerializer Serializer = new XmlSerializer(typeof(Person));
                using (TextWriter Writer = new StreamWriter($"{Obj.Name}.xml"))
                {
                    Serializer.Serialize(Writer, Obj);
                }

                //deserialize 
                using (TextReader Reader = new StreamReader($"{Obj.Name}.xml"))
                {
                    Person Deserialized = (Person)Serializer.Deserialize(Reader);
                    Console.WriteLine($"ID: {Deserialized.ID}, Name: {Deserialized.Name}, Age: {Deserialized.Age}");
                    Console.ReadKey();
                }
                break;
            case "Json":
                //serialize to JSON
                DataContractJsonSerializer JSONSerializer = new DataContractJsonSerializer(typeof(Person));
                using (MemoryStream stream = new MemoryStream())
                {
                    JSONSerializer.WriteObject(stream, Obj);
                    string JsonString = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                    File.WriteAllText($"{Obj.Name}.json", JsonString);
                }
                //Deserialize 
                using (FileStream Stream = new FileStream($"{Obj.Name}.json", FileMode.Open))
                {
                    Person Deserialized = (Person)JSONSerializer.ReadObject(Stream);
                    Console.WriteLine($"ID: {Deserialized.ID}, Name: {Deserialized.Name}, Age: {Deserialized.Age}");
                    Console.ReadKey();
                }
                break;
            default:
                Console.WriteLine("Not valid Type!!");
                return;


        }
    
    } 

}

class Program
{
    static void Main()
    {
        Person Carlos = new Person { ID = 1, Name = "Carlos",Age =  28 };
        Person Koda = new Person { ID = 2, Name = "Koda", Age = 2 }; 
        Person Ricardo = new Person { ID = 1, Name = "Ricardo", Age = 48 };

        Person.Serialize("Bin", Carlos);
        Person.Serialize("Xml", Koda);
        Person.Serialize("Json", Ricardo);





    }
}

