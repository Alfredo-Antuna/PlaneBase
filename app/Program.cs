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
            //Search for flights
            ChangeInfo.ShowSeats("3",Context);
            ChangeInfo.BuySeat("16",Context);
            ChangeInfo.ShowSeats("3",Context);

        }
    }
}
