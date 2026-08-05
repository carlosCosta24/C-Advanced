using System;
class Program
{
    // lambda Exprisson
    static Func<int, int> Square = (X) => X * X;
    //delegate using lambda exp
    static Action Prameterless = () =>
    {
        Console.WriteLine("Delegates using lambda Exp");
    };
    static Action<int> OnePrameter = (X) =>
    {
        Console.WriteLine($"Delegates using lambda Exp with Parameter X: {X}");
    }; static Action<int,int> TwoPrameter = (X,Y) =>
    {
        Console.WriteLine($"Delegates using lambda Exp with two parameters X: {X}, Y: {Y}");
    };
    //delegate represents an operation
    delegate int Operation(int X, int Y);
    //use func and lambda exp
    static void ExcuteOperation(int X, int Y , Func<int,int,int>Operation)
    {
        int Result = Operation(X, Y);
        Console.WriteLine($"Operation Result: " + Result);
    }

    static void Main(string[] args)
    {
        

        int Result = Square(25);

        Console.WriteLine("Square Of 25 is : " + Result);
        Prameterless();
        OnePrameter(10);
        TwoPrameter(10, 80);

        //declare add and Sub operation
        Func<int,int,int> Add = (X,Y) => {  return X + Y; };
        Func<int, int, int> Sub = (X, Y) => { return X - Y; };

        ExcuteOperation(10, 20, Add);
        ExcuteOperation(20, 10, Sub);


        Console.ReadLine();

    }
}

