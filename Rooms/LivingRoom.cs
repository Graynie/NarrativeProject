using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    
    internal class LivingRoom : Room
    {
        private static int gameScript = 0;
        public static bool husbandDead = false;
        private bool sittingOnChair = true;
        public static void killHusband()
        {
            husbandDead=true;
        }
        public static int NextStepScript()
        {  return gameScript++; }
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


        internal override string CreateDescription()
        {
            if (gameScript == 0)
            {
                if (sittingOnChair == true)
                {
                    return @"You are in the Living Room. Sitting on your chair,
You can [sew] until your husband arrives,
stand up and sit on your husbands [sofa],
aproach the [drinks] car, aproach the [fireplace],
go outtside to the [Grocery] store, or go to one 
of the other rooms: [closet], [kitchen], 
[bathroom], [bedroom]";
                }
                else
                {
                    return @"You are in the Living Room. 
You can do sit on your chair and [sew] until your husband arrives,
sit on your husbands [sofa], aproach the [drinks] car, 
aproach the [fireplace], go outtside to the [Grocery] store,
or go to one of the other rooms: [closet], [kitchen], 
[bathroom], [bedroom]";
                }
            }
            else if (gameScript == 1)
            {
                return @"You are in the Living Room.
Do you want to sit on your [chair], sit on
your husbands [sofa], aproach the [drinks] 
car, aproach the [fireplace],go outtside to
the [Grocery] store, or go to one 
of the other rooms: [closet], [kitchen], 
[bathroom], [bedroom]";
            }
            else { return @"None"; }

        }
        internal override void ReceiveChoice(string choice)
        {
            if (gameScript == 0)
            {
                sittingOnChair = false;
                switch (choice)
                {
                    case "bedroom":
                        Console.WriteLine("You returned to the room.");
                        Game.Transition<Bedroom>();
                        break;
                    case "drinks":
                        Console.WriteLine("Drinks car");
                        break;
                    case "closet":
                        Console.WriteLine("You are looking at the closed is a little dirty");
                        break;
                    case "sofa":
                        Console.WriteLine("You are sitting in your husbands chair, Will he get mad?");
                        break;
                    case "kitchen":
                        Console.WriteLine("You can cook here");
                        Game.Transition<Kitchen>();
                        break;
                    case "bathroom":
                        Console.WriteLine("It looks clean");
                        Game.Transition<Bathroom>();
                        break;
                    case "fireplace":
                        Console.WriteLine("Lit the fire place");
                        break;
                    case "sew":
                        Console.WriteLine("You continue sewing a pair of baby boots");
                        NextStepScript();
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (gameScript == 1)
            {
                switch (choice)
                {
                    case "bedroom":
                        Console.WriteLine("You returned to the room.");
                        Game.Transition<Bedroom>();
                        break;
                    case "drinks":
                        Console.WriteLine("Drinks car");
                        break;
                    case "closet":
                        Console.WriteLine("You are looking at the closed is a little dirty");
                        break;
                    case "sofa":
                        Console.WriteLine("You are sitting in your husbands chair, Will he get mad?");
                        break;
                    case "kitchen":
                        Console.WriteLine("You can cook here");
                        Game.Transition<Kitchen>();
                        break;
                    case "bathroom":
                        Console.WriteLine("Take a pee");
                        Game.Transition<Bathroom>();
                        break;
                    case "fireplace":
                        Console.WriteLine("Lit the fire place");
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else
            {
                switch (choice)
                {
                    case "bedroom":
                        Console.WriteLine("You returned to the room.");
                        Game.Transition<Bedroom>();
                        break;
                    case "drinks":
                        Console.WriteLine("Drinks car");
                        break;
                    case "closet":
                        Console.WriteLine("You are looking at the closed is a little dirty");
                        break;
                    case "sofa":
                        Console.WriteLine("You are sitting in your husbands chair, Will he get mad?");
                        break;
                    case "kitchen":
                        Console.WriteLine("You can cook here");
                        Game.Transition<Kitchen>();
                        break;
                    case "bathroom":
                        Console.WriteLine("Take a pee");
                        Game.Transition<Bathroom>();
                        break;
                    case "fireplace":
                        Console.WriteLine("Lit the fire place");
                        break;
                    case "sew":
                        Console.WriteLine("You continue sewing a pair of baby boots");
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }
}

