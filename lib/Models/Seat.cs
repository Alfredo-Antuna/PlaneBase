using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace lib
{
    public class Seat
    {
        [Key]
        public string ID {get;set;}
        public Flight Flight {get;set;}
        public int Occupied  {get;set;}
        public int Cost {get;set;}
        public string CustomerType {get;set;}
        public string Class {get;set;}


    }
}