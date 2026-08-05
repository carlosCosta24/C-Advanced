using System;
using System.IO;
using System.Runtime.CompilerServices;

public class Logger
{ 
    public delegate void LogAction(string Message);

    private LogAction _LogAction;

    public Logger(LogAction logAction)
    {
        _LogAction = logAction;
    }
    public void Log(string Message)
    {
        _LogAction(Message);
    }
}

public class Program{
    public static void LogToScreen(string Message) 
    {

        Console.WriteLine(Message);
        Console.ReadLine();
    }
    public static void LogToFile(string Message)
    {
        string FileName = "LogFile.txt";
        using (StreamWriter Writer = new StreamWriter(FileName, true)) 
        {
            Writer.WriteLine(Message);
        }
    }
    public static void Main(string[] args)
    {
        Logger ScreenLogger = new Logger(LogToScreen);
        Logger FileLogger= new Logger(LogToFile);

        ScreenLogger.Log("Screen Logger");
        FileLogger.Log("Log to file");

        Console.ReadLine();
    }
}
    

