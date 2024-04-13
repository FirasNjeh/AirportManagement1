// See https://aka.ms/new-console-template for more information

using AM1.ApplicationCore.Domain;
using AM1.ApplicationCore.Services;

Console.WriteLine("Hello, World!");
#region Constructeur
//Flight f1= new ();
//f1.FlightId = 1;
//Flight f2= new (1,new DateTime(2023/12/01));
#endregion

#region Initialiseur d'objet
Flight f3 = new Flight
{
     FlightId=1,
     Destination="Paris",
      FlightDate=DateTime.Now,
       
};
Plane plane1 = new Plane 
{
    Capacity=100,
    PlaneType=PlaneType.Boing
};
Console.WriteLine(plane1);
Console.WriteLine(f3);
#endregion

#region Tester CheckProfile
Passenger p1 = new Passenger
{
    FirstName = "Firas",
    LastName = "Njah",
    EmailAddress = "firas.njeh@esprit.tn"
};
Console.WriteLine(p1.CheckProfile("Firas", "Njah"));
Console.WriteLine(p1.CheckProfile("Firas", "Njah", "f"));
#endregion

#region Tester PassengerType
Staff s1 = new Staff();
Traveller t1 = new Traveller();
p1.PassengerType();
s1.PassengerType();
t1.PassengerType();
#endregion

#region Tester FlightDates
Console.WriteLine("*********GetFlightDates*********");

FlightMethods fm =new FlightMethods();
fm.Flights = TestData.listFlights;
foreach(DateTime d in fm.GetFlightDates("Paris"))
    Console.WriteLine(d);
#endregion

#region Tester Flights
Console.WriteLine("*********GetFlights*********");

fm.GetFlights("EstimatedDuration", "105");
#endregion

#region Tester ShowFlightDetails
Console.WriteLine("*********ShowFlightDetails*********");
fm.ShowFlightDetails(TestData.Airbusplane);
#endregion

#region Tester ProgrammedFlightNumber
Console.WriteLine("**********ProgrammedFlightNumber********");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2021,12,31)));
#endregion

#region Tester DurationAverage
Console.WriteLine("**********DurationAverage********");
Console.WriteLine(fm.DurationAverage("Madrid"));
#endregion

#region Tester OrderedDurationFlights
Console.WriteLine("**********OrderedDurationFlights********");
foreach(Flight fl in fm.OrderedDurationFlights())
    Console.WriteLine(fl.EstimatedDuration);
#endregion

#region Tester SeniorTravellers
Console.WriteLine("**********SeniorTravellers********");
foreach(Traveller t in fm.SeniorTravellers(TestData.flight1))
    Console.WriteLine(t.BirthDate);
#endregion

#region Tester DestinationGroupedFlight
Console.WriteLine("**********DestinationGroupedFlight********");
fm.DestinationGroupedFlight();
#endregion
