using System;
using Reflection;

namespace Reflection
{
    public class clsValidation
    {

        [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
        class AgeAttribute:Attribute
        {
            public int Max { get; set; }
            public int Min { get; set; }

            public string ErrorMessage {  get; set; }

            public AgeAttribute(int min, int max, string message) 
            {
                Min = min;
                Max = max;
                ErrorMessage = message;
            }
        
        }
        public class Person 
        {
            [Age(20,60,"Age Should Be Between 20 And 60")]
            public int Age { get; set; }
            public string Name { get; set; }
            public Person(int age, string name) 
            {
                Age = age;
                Name = name;
            }

        }
        public class clsChecker
        {
            

            public static void CheckPersonAge(Person Obj) 
            {
                if (ValidatePersonAge(Obj))
                {
                    Console.WriteLine("Age Is Valid");
                }
                else 
                {
                    Console.WriteLine("Not Valid -:)");
                }
                Console.ReadKey();
            }

            static bool ValidatePersonAge(Person Person) 
            {
                Type type = typeof(Person);

                foreach (var Properity in type.GetProperties()) 
                {
                    if (Attribute.IsDefined(Properity, typeof(AgeAttribute)))
                    {
                        var AgeAttribute = (AgeAttribute)Attribute.GetCustomAttribute(Properity, typeof(AgeAttribute));
                        int AgeValue = (int)Properity.GetValue(Person);

                        if (AgeValue < AgeAttribute.Min || AgeValue > AgeAttribute.Max) 
                        {
                            Console.WriteLine($"Validation Failled for Property: {Properity.Name}, Error: {AgeAttribute.ErrorMessage} ");
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}
