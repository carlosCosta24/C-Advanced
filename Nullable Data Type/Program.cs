using System;

class Program
{
    static void Main()
    {
        //Declare Nullable
        Nullable<int> Age = null;

        bool? Sex = null;

        if(Age.HasValue)
        {
            Console.WriteLine("Value of Age is: " + Age.Value);
        }else
        {
            Console.WriteLine("Age is null");
        }

        //using null-coalescing
        int Result = Age ?? 0;
        //using null conditional operator 
        string Male = Sex?.ToString();

        //parameter with null inside functions
        void Fun(string Name, Nullable <int> BirthYear)
        {
            Console.WriteLine("Name is: " + Name);
            if (BirthYear.HasValue) 
            {
                Console.WriteLine("Was born in year: " + BirthYear.ToString());
            }else{
                Console.WriteLine("Year of Birth is Null");
            }
        }
        void Identity (string Name, char? Type)
        {
            Console.WriteLine("Name is: " + Name);
            if (Type.HasValue)
            {
                Console.WriteLine("Sex is: " + Type.ToString());
            }
            else
            {
                Console.WriteLine("Sex is Null");
            }
        }

        Fun("Carlos", 1900);
        Identity("Koda", null);
        Identity("Koda", 'M');
        Console.WriteLine("Value of Age using null-coalescing is: " + Result);
        Console.WriteLine("Is Male: " + (Male?? "null"));
        Console.ReadKey();

    }
}

