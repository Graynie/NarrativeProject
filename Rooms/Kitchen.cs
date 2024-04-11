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
                    if (Game.husbandDead == false) { }
                    else { 
                    Console.WriteLine("Call your mom or the police");
                        switch(choice)
                        {
                            case "friend":
                                Console.WriteLine();
                                break;
                            case "mom":
                                Console.WriteLine();
                                break;
                            default:
                                Console.WriteLine();
                            break;
                        }
                    }
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
