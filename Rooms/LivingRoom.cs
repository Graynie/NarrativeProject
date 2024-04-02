using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class LivingRoom : Room
    {
        // You start the game here, there is a fire place,
        // a table with alcohol drinks, the door to the closet,
        // to the kitchen, to the bedroom, and to the bathroom.
        // also two chairs or sofa one is yours and the other is
        // your husband's. when you sit in your chair you can
        // continue sewing or reading a book. if you sit in your
        // husband's, before to get home, you can act as him
        // little mocking, or inspect the chair confortable
        // not confortable, in the closet you can clean the
        // dust or order the jackets by color or separate the ones
        // that are yours and your husbands, take a drink(if you
        // take to much drinks you will fall sleep and the game will
        // end with nothing happening if it is before your husband
        // arrives, your husband getting angry leaving you rigth away without
        // letting you do anything, or if after killing him you get caugth


        internal override string CreateDescription() { 

return @"You are Mary Maloney, waiting for her husband to
come home from work.You are in the Living Room.
Do you want to sit on your [chair]
Sit on your husbands [sofa]
Aproach the drinks car [bedroom]
Go to the [closet]
Go to the [kitchen]
Go to the [bathroom]
Aproach the [fireplace]
or go to the [bedroom]";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bedroom":
                    Console.WriteLine("You returned to the room.");
                    Game.Transition<Bedroom>();
                    break;
                case "finish":
                    Console.WriteLine("Game Done :)");
                    Game.Finish();
                    break;
                case "drinks":
                    Console.WriteLine("Drinks car");
                    break;
                case "closet":
                    Console.WriteLine("You are looking at the closed is a little dirty");
                    break;
                case "chair":
                    Console.WriteLine("you are sitting you can start sewing or read something");
                    break;
                case "sofa":
                    Console.WriteLine("You are sitting in your husbands chair, Will he get mad?");
                    break;
                case "kitchen":
                    Console.WriteLine("You can cook here");
                    break;
                case "bathroom":
                    Console.WriteLine("Take a pee");
                    break;
                case "fireplace":
                    Console.WriteLine("Lit the fire place");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

