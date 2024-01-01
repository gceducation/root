using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RouteFinder.Airport;

namespace RouteFinder
{
    public class Runner
    {
        public static void Main(String[] args)
        {
            int i;
            Console.WriteLine("Start");
            Dictionary<String, Airport> dctAirport = Airport.InitializeFmTSV("C:/scratch/airportlist.txt");
            List<Airport> lst = dctAirport.Values.ToList();

            lst.Sort();
            StringBuilder sb = new StringBuilder();
            sb.Append("    ");
            for (i = 0; i < lst.Count; i++)
            {
                Airport airport = lst[i];
                if (i > 0)
                {
                    sb.Append(' ');
                }
                sb.Append(airport._sIATACode);
            }

            Console.WriteLine(sb.ToString());
            sb.Clear();
            for (i = 0; i < lst.Count * 4 + 4; i++)
            {
                sb.Append('-');

            }
            Console.WriteLine(sb.ToString());
            sb.Clear();
            for (i = 0; i < lst.Count; i++)
            {
                Airport ap = lst[i];
                sb.Append(ap._sIATACode);
                sb.Append(' ');

                for (int iTo = 0; iTo < lst.Count; iTo++)
                {
                    if (i != iTo)
                    {
                        Airport apTo = lst[iTo];
                        if (ap._dctAirportDep.ContainsKey(apTo._sIATACode))
                        {
                            sb.Append(" GO ");
                        }
                        else
                        {
                            sb.Append("    ");
                        }
                    }
                    else
                    {
                        sb.Append("    ");
                    }

                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            AirRoute airRoute = Airport.FindRoutes(dctAirport, "PNQ", "BOM", 0);
        }

    }
}
