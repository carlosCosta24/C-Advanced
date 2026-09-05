using System;
using Reflection;

namespace Reflection
{
/// <summary>
/// Validation class using reflection 
/// </summary>
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
        /// <summary>
        /// Person Class with custom attribute for age range 
        /// </summary>
        public class Person 
        {
            [Age(20,60,"Age Should Be Between 20 And 60")]
            /// <summary>
            /// Get and set person age
            /// </summary>
            public int Age { get; set; }
            /// <summary>
            /// Get and set person name
            /// </summary>
            public string Name { get; set; }
            public Person(int age, string name) 
            {
                Age = age;
                Name = name;
            }

        }
        public class clsChecker
        {
            
        /// <summary>
        /// Impelmentation of validation for person age
        /// Obj should be insialized before 
        /// passing as a parameter to this function
        /// </summary>
        /// <param name="Obj">class person</param>
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
            /// <summary>
            /// Using reflection to loop over the properties of class person 
            /// using type to start reflection 
            /// loop over properties check if its defined
            /// get attribute and value
            /// check if they satisfy the condition 
            /// return true or false 
            /// </summary>
            /// <param name="Person"></param>
            /// <returns></returns>
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
