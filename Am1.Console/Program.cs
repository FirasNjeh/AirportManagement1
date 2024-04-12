// See https://aka.ms/new-console-template for more information

using AM1.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");

//Flight f1= new ();
//f1.FlightId = 1;
//Flight f2= new (1,new DateTime(2023/12/01));
Flight f3 = new Flight
{
     FlightId=1,
     Destination="Paris",
      FlightDate=DateTime.Now,
       
};
Plane p1 = new Plane 
{
    Capacity=100,
    PlaneType=PlaneType.Boing
};
Console.WriteLine(p1);
Console.WriteLine(f3);
