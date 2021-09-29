using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lib
{
    



    public class Flight
    {

        [Key]
        public int ID {get;set;}
        public string Aircraft {get;set;}
        public string Departure {get;set;}
        public string Arrival {get;set;}
        public int FirstClass{get;set;}
        public int EconomyClass {get;set;}
        public int BusinessClass{get;set;}
        public List<Seat> Seats {get; set;} = new List<Seat>();

        
    }
}