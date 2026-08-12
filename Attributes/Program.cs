#define Custom
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Attributes
{
    // define a debug att

    [Conditional("DEBUG")]
    public static void DebugFun()
    {
        Console.WriteLine("This fun is executed only in debug mode");
    }
    [Obsolete("This fun will be removed in the next version!")]
    public static void ObsoleteFun()
    {
        Console.WriteLine("This fun is obsolete and will be deprecated in the future versions");
    }
    [Conditional("Custom")]
    public static void CustomFun() 
    {
        Console.WriteLine("This fun is executed if and only if Cutsom attribute is included");
    }

    public static void Main() 
    {
        DebugFun();
        ObsoleteFun();
        CustomFun();
        Console.ReadKey();


    }
}

