using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Cellar : Room
    {
        internal override string CreateDescription()
        {
            throw new NotImplementedException();
        }

        internal override void ReceiveChoice(string choice)
        {
            switch(choice){
                case "Freezer":
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;

            }
        }
    }
}
