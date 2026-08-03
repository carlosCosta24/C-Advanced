using System;

public class OrderEvent : EventArgs
{
    public int OrderID { get; }
    public double OrderPrice { get; }
    public string ClientEmail { get; }

    public OrderEvent(int orderID, double orderPrice, string clientEmail)
    {
        this.OrderID = orderID;
        this.OrderPrice = orderPrice;
        this.ClientEmail = clientEmail;
    }
}

public class Order
{
    public event EventHandler<OrderEvent> OnOrderCreation;

    public void Create(int OrderID, double OrderPrice, string ClientEmail)
    {
        Console.WriteLine("Order Created Successfully, Notifying Everyone ....\n");

        if (OnOrderCreation != null)
        {
            OnOrderCreation(this, new OrderEvent(OrderID, OrderPrice, ClientEmail));
        }
    }

}
public class EmailService
{
    public void Subscribe(Order Order)
    {
        Order.OnOrderCreation += SendEmail;
    }
    public void UnSubscrib(Order Order)
    {
        Order.OnOrderCreation -= SendEmail;
    }
    public void SendEmail(object sender, OrderEvent e)
    {
        Console.WriteLine($"Email Service: Your Order Have been Processed Successfully" +
        $": Order Number: {e.OrderID}, OrderPrice: {e.OrderPrice}");
    }
}
public class SmsService
{
    public void Subscribe(Order Order)
    {
        Order.OnOrderCreation += SendSms;
    }
    public void UnSubscrib(Order Order)
    {
        Order.OnOrderCreation -= SendSms;
    }
    public void SendSms(object Sender, OrderEvent e)
    {
        Console.WriteLine($"Sms Service: Your Order Have been Processed Successfully" +
        $": Order Number: {e.OrderID}, OrderPrice: {e.OrderPrice}");
    }
}
public class ShippingService
{
    public void Subscribe(Order Order)
    {
        Order.OnOrderCreation += SendToShipping;
    }
    public void UnSubscribe(Order Order)
    {
        Order.OnOrderCreation -= SendToShipping;
    }

    public void SendToShipping(object sender, OrderEvent e)
    {
        Console.WriteLine($"Shipping Service: Your Order Have been Processed Successfully" +
        $": Order Number: {e.OrderID}, OrderPrice: {e.OrderPrice}");
    }
}
public class Program
{
    static void Main()
    {
        var Order  = new Order();

        EmailService NewEmailService = new EmailService();
        SmsService NewSmsService = new SmsService();
        ShippingService NewShippingService = new ShippingService();


        NewEmailService.Subscribe(Order);
        NewSmsService.Subscribe(Order);
        NewShippingService.Subscribe(Order);

        Order.Create(1, 550, "CarlosCosta@Email.com");

        Console.ReadLine();
    }




}