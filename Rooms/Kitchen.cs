using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {

        internal override string CreateDescription()
        {
            throw new NotImplementedException();
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "Fridge":
                    Console.WriteLine("Frizzing");
                    break;
                case "Phone":
                    Console.WriteLine("Call your mom or the police");
                    break;
                case "oven":
                    Console.WriteLine("Ovening, haha , no, joke, XD");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;

            }
        }
    }
}
