using Rad301_Mock_Exam_2023_DataModel_ppowell;
using Tracker.WebAPIClient;

namespace Rad301_Mock_Exam_2023_Console_App_ppowell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "ppowell", StudentName: "Paul Powell", activityName: "Rad301 Mock Exam 2023", Task: "Running Console App");
            list_passangers(2);
            list_flight_revenue();
            add_new_flight_and_passenger();
        }

        static void list_passangers(int FlightID)
        {
            using (var context = new FlightContext())
            {
                var passengers = context.Passengers
                    .Where(p => p.FlightId == FlightID)
                    .ToList();

                var destination = context.Flights
                    .Where(f => f.FlightId == FlightID)
                    .Select(f => f.Destination)
                    .FirstOrDefault();

                if (passengers.Any())
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"Passenger List for Flight {FlightID}:");
                    Console.WriteLine("=================================");

                    foreach (var passenger in passengers)
                    {
                        Console.WriteLine($"Name: {passenger.Name}, Ticket Type: {passenger.TicketType}, Destination: {destination}");
                    }
                }
                else
                {
                    Console.WriteLine($"No passengers found for Flight {FlightID}.");
                }
            }
        }

        static void list_flight_revenue()
        {
            using (var context = new FlightContext())
            {
                var flights = context.Flights.ToList();

                if (flights.Any())
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"Flight List");
                    Console.WriteLine("=================================");

                    foreach (var flight in flights)
                    {
                        decimal totalRevenue = context.Passengers
                            .Where(p => p.FlightId == flight.FlightId)
                            .Sum(p => p.TicketPrice + p.BaggageCharge);

                        Console.WriteLine();
                        Console.WriteLine($"Number: {flight.FlightNumber}, Destination: {flight.Destination}, " +
                                          $"Departure Date: {flight.DepartureDate}, Total Revenue: {totalRevenue:c}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"No flights found");
                }
            }
        }

        static void add_new_flight_and_passenger()
        {
            using (var context = new FlightContext())
            {
                var newFlight = new Flight
                {
                    FlightNumber = "DU-002",
                    DepartureDate = DateTime.Parse("29/06/2022 11:00"),
                    Origin = "Dublin",
                    Destination = "Sydney",
                    Country = "Australia",
                    MaxSeats = 210
                };

                context.Flights.Add(newFlight);
                context.SaveChanges();

                var newPassenger = new Passenger
                {
                    Name = "Martha Rotter",
                    TicketType = "Business",
                    TicketPrice = 399.0m,
                    BaggageCharge = 30.00m,
                    FlightId = newFlight.FlightId
                };

                context.Passengers.Add(newPassenger);
                context.SaveChanges();
            }
        }
    }
}