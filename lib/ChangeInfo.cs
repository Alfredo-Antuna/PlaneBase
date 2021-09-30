using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace lib
{
    public static class ChangeInfo
    {
        public static void AddFlight(string inputAircraft,string inputDeparture,string inputArrival,int inputFirstClass,int inputEconomyClass,int inputBusinessClass, Context Context)
        {
            
            //create Flight
            Flight CreatedFlight =
             new Flight {Aircraft = inputAircraft,Departure = inputDeparture, Arrival = inputArrival,FirstClass = inputFirstClass, EconomyClass = inputEconomyClass,BusinessClass = inputBusinessClass };
            var NewSeats = new List<Seat>();
            for(int Count = 1;Count<=inputEconomyClass;Count++)
            {
                NewSeats.Add(new Seat(){ Name = $"B{Count}", Cost = 8,Class = "EcomonyClass",CustomerType = "Empty",Flight = CreatedFlight});
            }
            for(int Count = 1;Count<=inputFirstClass;Count++)
            {
                NewSeats.Add(new Seat(){ Name = $"A{Count}", Cost = 15,Class = "FirstClass",CustomerType = "Empty",Flight = CreatedFlight});
            }
            for(int Count = 1;Count<=inputBusinessClass;Count++)
            {
                NewSeats.Add(new Seat(){ Name = $"C{Count}", Cost = 10,Class = "BusinessClass",CustomerType = "Empty",Flight = CreatedFlight});
            }

            CreatedFlight.Seats.AddRange(NewSeats);
            Context.AddRange(CreatedFlight.Seats);
            Context.SaveChanges();
        }
        public static void SearchFlight(string SearchType,string SearchWord, Context Context)
        {
            switch (SearchType)
            {
                case "Aircraft":
                {
                    var results = Context.Flights.Where(Flight => Flight.Aircraft == SearchWord);
                    foreach (var flight in results)
                    {
                        Console.WriteLine($"ID:{flight.ID} - Aircraft: {flight.Aircraft} Departure: {flight.Departure} - Arrival: {flight.Arrival}");
                        Console.WriteLine($"Total Seats[FirstClass: {flight.FirstClass} - BusinessClass: { flight.BusinessClass} - EconomyClass: {flight.EconomyClass}");
                    }
                    break;
                }
                case "Departure":
                {
                    var results = Context.Flights.Where(Flight => Flight.Departure == SearchWord);
                    foreach (var flight in results)
                    {
                        Console.WriteLine($"ID:{flight.ID} - Aircraft: {flight.Aircraft} Departure: {flight.Departure} - Arrival: {flight.Arrival}");
                        Console.WriteLine($"Total Seats[FirstClass: {flight.FirstClass} - BusinessClass: { flight.BusinessClass} - EconomyClass: {flight.EconomyClass}");
                    }
                    break;
                }
                case "Arrival":
                {
                   var results = Context.Flights.Where(Flight => Flight.Arrival == SearchWord);
                    foreach (var flight in results)
                    {
                        Console.WriteLine($"ID:{flight.ID} - Aircraft: {flight.Aircraft} Departure: {flight.Departure} - Arrival: {flight.Arrival}");
                        Console.WriteLine($"Total Seats[FirstClass: {flight.FirstClass} - BusinessClass: { flight.BusinessClass} - EconomyClass: {flight.EconomyClass}");
                    }
                    break;
                }
                case "ID":
                {
                    var results = Context.Flights.Where(Flight => Flight.ID == Convert.ToInt32(SearchWord));
                    foreach (var flight in results)
                    {
                        Console.WriteLine($"ID:{flight.ID} - Aircraft: {flight.Aircraft} Departure: {flight.Departure} - Arrival: {flight.Arrival}");
                        Console.WriteLine($"Total Seats[FirstClass: {flight.FirstClass} - BusinessClass: { flight.BusinessClass} - EconomyClass: {flight.EconomyClass}");
                    }
                    break;
                }
                
            }
        }
        public static void ShowFlights(Context Context)
        {
            var results = Context.Flights;
            foreach (var flight in results)
            {
                Console.WriteLine($"ID:{flight.ID} - Aircraft: {flight.Aircraft} Departure: {flight.Departure} - Arrival: {flight.Arrival}");
                Console.WriteLine($"Total Seats[FirstClass: {flight.FirstClass} - BusinessClass: { flight.BusinessClass} - EconomyClass: {flight.EconomyClass}");
            }
        }
        public static void ShowSeats(string ID,Context Context)
        {
            var result = Context.Flights.Where(flight => flight.ID == Convert.ToInt32(ID)).Include(fli => fli.Seats).First();
            Console.WriteLine($"Total Seats[FirstClass: {result.FirstClass} - BusinessClass: { result.BusinessClass} - EconomyClass: {result.EconomyClass}");
            Console.WriteLine($"Available Seats:");
            foreach (var seat in result.Seats)
            {
                
                if(seat.Occupied == 0)
                {
                    Console.WriteLine($"Name:{seat.Name} - ID:{seat.ID} - Vacancy:AVAILABLE - Cost:{seat.Cost} - Class:{seat.Class}" );
                }
              
            }
                        
                    
        }
        public static void BuySeat(string ID,Context Context)
        {
            var result = Context.Seats.Where(seat => seat.ID == Convert.ToInt32(ID)).First();
            if(result.Occupied == 0)
            {
                result.Occupied = 1;
                Context.SaveChanges();
            }else
            {
                Console.WriteLine("SEAT IS OCCUPIED PLEASE PICK ANOTHER");
            }

        }
        public static decimal ShowFlightFullPercent(String ID,Context Context)
        {
            int totalSeats = 0;
            int OccupiedSeats = 0;
            var result = Context.Flights.Where(flight => flight.ID == Convert.ToInt32(ID)).Include(fli => fli.Seats).First();
            totalSeats = result.EconomyClass + result.BusinessClass + result.FirstClass;
            foreach (var chair in result.Seats)
            {
                if(chair.Occupied == 1){OccupiedSeats++;}
            }
            var percent = (decimal)OccupiedSeats/(decimal)totalSeats;
            return Math.Round(percent,2)* 100;

        }
        public static int ShowChildCount(Context Context)
        {
            var results = Context.Seats.Where(seat => seat.CustomerType == "Child");
            
            return results.Count();
        }
        public static int ShowTotalRevenue(Context Context)
        {
            
            int totalRevenue = 0;
            var results = Context.Seats.Where(seat => seat.Occupied == 1);
            foreach (var seat in results)
            {
                totalRevenue += seat.Cost;
            }
            return totalRevenue;

        }
    }
}