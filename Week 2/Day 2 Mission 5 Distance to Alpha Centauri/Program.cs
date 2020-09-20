using System;

namespace Mission_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // GOAL: Display the distance to Alpha Centauri in parsecs with more than 2 decimal places. //
            // light year distance 4.365±0.007

            double parsecMetre = 30856775813100000;
            double lightyearMetre = 9460730472580800;

            double lightyearINparsec = lightyearMetre / parsecMetre;
            double parsecINlightyear = parsecMetre / lightyearMetre;

            double lightyearDistance = 4.365;
            double parsecDistance = lightyearDistance * lightyearINparsec;
            Console.WriteLine(parsecDistance);

        }
    }
}
