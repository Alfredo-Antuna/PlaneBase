using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace lib
{
    public class Seat
    {
        [Key]
        public int ID {get;set;}
        public string Name {get;set;}
        public Flight Flight {get;set;}
        public int Occupied  {get;set;}
        public int Cost {get;set;}
        public string CustomerType {get;set;}
        public string Class {get;set;}


    }
}