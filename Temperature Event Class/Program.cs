using System;

public class TemperatureChangedEventArgs : EventArgs
{
    public double OldTemperature { get; }
    public double NewTemperature { get; }
    public double Diffrence {  get; }

    public TemperatureChangedEventArgs(double oldTemperature, double newTemperature)
    {
        this.OldTemperature = oldTemperature;
        this.NewTemperature = newTemperature;
        this.Diffrence = newTemperature - oldTemperature;
    }
}

public class Thermostat
{
    public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

    private double OldTemp;
    private double CurrentTemp;

    public void SetTemperature(double NewTemp)
    {
        if(NewTemp != CurrentTemp)
        {
            OldTemp = CurrentTemp;
            CurrentTemp = NewTemp;
            OnTempertureChanged(OldTemp, CurrentTemp);
            
        }
    }
    private void OnTempertureChanged(double OldTemp, double CurrentTemp)
    {
        OnTemperatureChanged(new TemperatureChangedEventArgs(OldTemp, CurrentTemp));
    }
    protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
    {
        TemperatureChanged?.Invoke(this, e);
    }
}
public class Display
{
    public void subscribe(Thermostat thermostate)
    {
        thermostate.TemperatureChanged += HandelTemperatureChange;
    }
    public void HandelTemperatureChange(object sender , TemperatureChangedEventArgs e)
    {
        Console.WriteLine("\nTemperature Changed:");
        Console.WriteLine($"New Temperature: {e.NewTemperature}");
        Console.WriteLine($"Old Temperature: {e.OldTemperature}");
        Console.WriteLine($"Temperature Differance: {e.Diffrence}");

    }
}

public class program 
{
    static void Main()
    {
        Thermostat thermostate = new Thermostat();
        Display display = new Display();

        display.subscribe(thermostate);

        thermostate.SetTemperature(10);
        thermostate.SetTemperature(20);
        thermostate.SetTemperature(30);

        Console.ReadLine();


    }
}