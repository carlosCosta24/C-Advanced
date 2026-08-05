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

        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Func:");
        int Result = Square(10);
        Console.WriteLine("Square of 10 = " + Result);

        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Actions:");
        Print();
        PrintInt(10);
        PrintSum(10, 20);


        Console.ReadLine();
    }
}