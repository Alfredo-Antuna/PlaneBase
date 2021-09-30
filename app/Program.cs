using System;
using lib;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            using var Context = new Context();
            var cliControl = true;
            ChangeInfo.ShowFlights(Context);
            while(cliControl)
            {
                Console.WriteLine(@"
                Input 0 for Admin Options
                Input 1 to Purchase Seat
                press Enter to exit
                ");
                var option = Console.ReadLine();

                switch (option)
                {
                    
                    case "0":
                    {
                        Console.WriteLine(@"
                        Input 0 to see how full each flight is (in percentage)
                        Input 1 to see how many kids in total have seats across all flights
                        Input 2 to see see the total amount of revenue per flight
                        Input 3 Create a Flight
                        ");
                        option = Console.ReadLine();
                        if(option == "0")
                        {
                            Console.WriteLine("Input Flight id to view");
                            var id = Console.ReadLine();
                            Console.WriteLine(ChangeInfo.ShowFlightFullPercent(id,Context) +"%");
                        }
                        else if(option == "1")
                        {
                             Console.WriteLine(ChangeInfo.ShowChildCount(Context));
                        }
                        else if (option == "2")
                        {
                             Console.WriteLine(ChangeInfo.ShowTotalRevenue(Context));
                        }
                        else if (option == "3")
                        {
                            Console.WriteLine("Input [Aircraft Departure Arrival FirstClassSeats EconomyClassSeats BusinessClassSeats]");
                                var input = Console.ReadLine();
                                var inputParsed = input.Split(" ");
                                ChangeInfo.AddFlight(inputParsed[0],inputParsed[1],inputParsed[2],Convert.ToInt32(inputParsed[3]),Convert.ToInt32(inputParsed[4]),Convert.ToInt32(inputParsed[5]),Context);
                        }
                         
                        
                        break;


                        //AddFlight(string inputAircraft,string inputDeparture,string inputArrival,int inputFirstClass,int inputEconomyClass,int inputBusinessClass
                    }
                
                    case "1":
                    {
                        var customerLoopControl = true;


                        while(customerLoopControl)
                        {
                            //ChangeInfo.ShowFlights(Context);
                            Console.WriteLine(@"
                            Input 0 to Search Flights
                            Input 1 to Buy a seat by Id
                            Press enter to go back
                            ");
                            option = Console.ReadLine();
                            if(option == "0")
                            {
                                Console.WriteLine("Input Search Option[Aircraft,Arrival,Departure], SearchWord");
                                var search = Console.ReadLine();
                                var searchParsed = search.Split(" ");
                                ChangeInfo.SearchFlight(searchParsed[0],searchParsed[1],Context);
                            }
                            else if(option == "1")
                            {
                                Console.WriteLine("Input Flight Id to see Available seats");
                                var search = Console.ReadLine();
                                ChangeInfo.ShowSeats(search,Context);
                                Console.WriteLine("Input Seat Id to purchase");
                                search = Console.ReadLine();
                                ChangeInfo.BuySeat(search,Context);
                            }
                            else
                            {
                                customerLoopControl = false;
                            }  
                        }
                        break;
                    }
                
                    case "":
                    {
                        cliControl = false;
                        break;
                    }
                }


            }

        }
    }
}
