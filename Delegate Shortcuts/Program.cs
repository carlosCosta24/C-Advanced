using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //Func delegate
    static Func<int, int> Square = SquareMehtod;



    static int SquareMehtod(int X)
    {
        return X * X;
    }

    static void Main()
    {
        //Define a Predicate 
        Predicate<int> IsEvenPredicate = IsEven;
        
        //Action delegate with methods
        Action Print = PrintMethod;
        Action<int> PrintInt = PrintIntMethod;
        Action<int, int> PrintSum = PrintSumMethod;

        void PrintMethod() 
        {
            Console.WriteLine("Delegate without prameter");
        }
        void PrintIntMethod(int X)
        {
            Console.WriteLine("Recived int is: " + X); 
        }
        void PrintSumMethod(int X, int Y) 
        {
            int Sum = X + Y;
            Console.WriteLine($"Sum of {X} + {Y} is: " + Sum);
        }

        bool IsEven(int x)
        {
            return x % 2 == 0;
        }

        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Func:");
        int Result = Square(10);
        Console.WriteLine("Square of 10 = " + Result);

        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Actions:");
        Print();
        PrintInt(10);
        PrintSum(10, 20);

        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Predicate:");
        Console.WriteLine("Is 80 Even : " + IsEven(80));
        


        Console.ReadLine();
    }
}