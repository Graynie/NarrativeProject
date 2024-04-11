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
        private bool sittingOnChair = true;
        private bool greetHusband = false;
        internal override string CreateDescription()
        {
            if (Game.gameScript == 0)
            {
                if (sittingOnChair == true)
                {
                    return @"You are in the Living Room. Sitting on your chair,
You can [sew] until your husband arrives, or [stand] up";
                }
                else
                {
                    return @"You are in the Living Room. 
You can do sit on your [chair], sit on your husband's [sofa],
aproach the [drinks] car, aproach the [fireplace], go outtside
to the [Grocery] store, or go to one of the other rooms: 
[closet], [kitchen], [bathroom], [bedroom]";
                }
            }
            else if (Game.gameScript == 1)
            {
                if (greetHusband == false)
                {
                    return @"You are in the Living Room.
You can [Greet] your husband, sit on your [chair],
sit on your husbands [sofa], aproach the [drinks] 
car, aproach the [fireplace],go outtside to the 
[Grocery] store, or go to one of the other rooms:
[closet], [kitchen], [bathroom], [bedroom]";
                }
                else if (sittingOnChair == true)
                {
                    return @"You are in the Living Room. Sitting on your chair,
You can [sew], or [stand] up";
                }
                else {
                    return @"You are in the Living Room. 
You can do sit on your [chair], sit on your husband's [sofa],
aproach the [drinks] car, aproach the [fireplace], go outtside
to the [Grocery] store, or go to one of the other rooms: 
[closet], [kitchen], [bathroom], [bedroom]";
                }
            }
            else if(Game.gameScript == 5)
            {
                if (Game.lambLeg == true) 
                {
                    return @"You are in the Living Room.
You can [aproach] your husband, sit in your [chair], sit on
your husbands [sofa], aproach the [drinks] 
car, aproach the [fireplace],go outtside to
the [Grocery] store, or go to one 
of the other rooms: [closet], [kitchen], 
[bathroom], [bedroom]";
                }
                else
                {
                    return @"You are in the Living Room.
Do you want to sit on your [chair], sit on
your husbands [sofa], aproach the [drinks] 
car, aproach the [fireplace],go outtside to
the [Grocery] store, or go to one 
of the other rooms: [closet], [kitchen], 
[bathroom], [bedroom]";
                }
            }
            else { return @"None"; }

        }
        internal override void ReceiveChoice(string choice)
        {
            if (Game.gameScript == 0)
            {
                if (sittingOnChair == true)
                {
                    switch (choice)
                    {
                        case "sew":
                            Console.WriteLine("You continue sewing a pair of boots for a baby");
                            Game.timeHour = 5;
                            break;
                        case "stand":
                            sittingOnChair = false;
                            Console.WriteLine("No escrito aun");
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
                            Console.WriteLine("It looks clean");
                            Game.Transition<Bathroom>();
                            break;
                        case "fireplace":
                            Console.WriteLine("Lit the fire place");
                            break;
                        case "chair":
                            Console.WriteLine("You are confortably sitting in your chair");

                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
            }
            else if (Game.gameScript == 1)
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

