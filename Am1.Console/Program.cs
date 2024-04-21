// See https://aka.ms/new-console-template for more information

using AM.Infrastructure;
using AM1.ApplicationCore.Domain;
using AM1.ApplicationCore.Interfaces;
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
    FullName = new FullName
    {
        FirstName = "firas",
        LastName = "njah",
    },
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
//appel avec le delégué
fm.FlightDetailsDel(TestData.Airbusplane);

#endregion

#region Tester ProgrammedFlightNumber
Console.WriteLine("**********ProgrammedFlightNumber********");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2021,12,31)));
#endregion

#region Tester DurationAverage
Console.WriteLine("**********DurationAverage********");
Console.WriteLine(fm.DurationAverage("Madrid"));
//appel avec le delégué
Console.WriteLine(fm.DurationAverageDel("Madrid"));

#endregion

#region Tester OrderedDurationFlights
Console.WriteLine("**********OrderedDurationFlights********");
foreach(Flight fl in fm.OrderedDurationFlights())
    Console.WriteLine(fl.EstimatedDuration);
#endregion

#region Tester SeniorTravellers
//Console.WriteLine("**********SeniorTravellers********");
//foreach(Traveller t in fm.SeniorTravellers(TestData.flight1))
//    Console.WriteLine(t.BirthDate);
#endregion

#region Tester DestinationGroupedFlight
Console.WriteLine("**********DestinationGroupedFlight********");
fm.DestinationGroupedFlight();
#endregion

#region Tester UpperFullName
Console.WriteLine("**********UpperFullName********");
p1.UpperFullName();
Console.WriteLine(p1.FullName.FirstName + " "+p1.FullName.LastName);
#endregion

#region Insertion dans la base de données
AMContext ctx= new AMContext();
IUnitOfWork uow= new UnitOfWork(ctx);
IServicePlane sp = new ServicePlane(uow);
IServiceFlight sf = new ServiceFlight(uow);
sp.Add(TestData.Airbusplane);
sf.Add(TestData.flight1);
//ctx.Set<Plane>().Add(TestData.Airbusplane);
//ctx.Planes.Add(TestData.BoingPlane);
//ctx.Flights.Add(TestData.flight1);
//ctx.Flights.Add(TestData.flight2);
//ctx.SaveChanges();
//commit enregistre TOUS(dans notre exp il va enregistrer le flight et le plane ) les changemets sur la base de données 
sf.Commit();//ou sp.Commit(); c'est la meme
Console.WriteLine("Ajout avec succes");


#endregion

#region Afficher le contenu de la table Flights
//foreach(Flight fl in ctx.Flights)
foreach (Flight fl in sf.GetMany())
    Console.WriteLine("Date: "+fl.FlightDate+" Destination: "+fl.Destination+ " Plane Capacity: "+fl.Plane.Capacity);


#endregion