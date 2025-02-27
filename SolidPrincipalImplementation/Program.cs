// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");

//Solid Principal Implementation in c#

// Single  Responsibility Principal 
// A Class Should have one only one reason to change 
public class ReportGenerator
{
    public string GenerateReport() => "reportData";
}
public class ReportPrinter
{
    public void Print(string report) => Console.WriteLine(report);
}

//Open-close Principal OCP
// A class should open for extension but close for modification 
// use interface or abstract classs instead of modifying exsiting code.

public abstract class PaymentProcess
{
    public abstract void ProcessPayment();
}

public class PaypalPayment : PaymentProcess
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Paypal Payment processed");
    }
}

//Liskov Sbustitution Principal LSP
// A Sub Class should be able to replace its base class without breaking functionality

public abstract class Bird
{
    public abstract void Fly();
}

public class Sparrow :Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow Flying ");
    }
}
public class Penguin : Bird
{
    //violation of LSP as Penguin can not fly
    public override void Fly()
    {
        Console.WriteLine("this implmentation is violating lSP");//// violation LSP
    }
}

//Interface Segregation Principal ISP
// Don't force class to implement methods it doesn't use

public interface IPrinter
{
    void Print();
}
public interface IScanner
{
    void Scan();
}

public class Printer : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Printing");
    }
}
// instead of using the single interface IMachine, we segregate the reponsibilites  
public class Scanner : IScanner
{
    public void Scan()
    {
        Console.WriteLine("Scanning");
    }
}

//Dependency Inversion Principal DIP
//High Level modules should not depend on low level Modules; both should depend on the abstraction 

public interface ILogger
{
    void Log (string message);
}
public class ConsoleLogger : ILogger
{
    public void Log (string message)=> Console.WriteLine(message);
}

public class UserService
{
    private readonly ILogger _logger;

    public UserService(ILogger logger)
    {
        _logger = logger;
    }

    public void CreateUser()
    {
        Console.WriteLine("User ");
        _logger.Log("usercreated");
    }
}