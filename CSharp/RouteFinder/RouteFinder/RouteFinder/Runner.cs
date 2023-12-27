using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinder
{
    public class Runner
    {
        public static void Main(String [] args)
        {
            Console.WriteLine("Start");
            Airport.InitializeFromTSV("C:/scratch/airportlist.txt");
        }
        public void Execute()
        {
            
        }
    }
}
