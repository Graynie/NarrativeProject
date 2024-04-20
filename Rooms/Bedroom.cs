using System;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {
        internal bool bedDone=false;
        internal bool bat=false;

        internal override string CreateDescription()
        { 

            if (Game.gameScript == 0)
            {
                return @"You are in the Bedroom. 
You can take a [nap] until your husband arrives,
examine the [room] to find hidden items,
or go back to the [living] room.";
            }
            else if (Game.gameScript == 1 || Game.gameScript == 2 || Game.gameScript == 3 || Game.gameScript == 4 || Game.gameScript == 5)
            {
                if (!bedDone)
                {
                    return @"You are in the Bedroom. 
You can examine the [room] to find hidden items,
make the [bed], or go back to the [living] room.";
                }
                else
                {
                    return @"You are in the Bedroom. 
You can examine the [room] to find hidden items, or go back to the [living] room.";
                }
            }
            else if (Game.gameScript == 6)
            {
                return @"You are in the Bedroom. 
You can examine the [room] to find hidden items,
make the [bed], or go back to the [living] room.";
            }
            else if (Game.Callpolice)
            {
                return @"In the Bedroom, alone you can try to [calm] down the mix of anxiety and apprehension.
 or return to the [living] room, where the tension hangs thick in the air.";
            }
            else
            {
                return @" @""You are in the Bedroom. 
You can examine the [room] to find hidden items, or go back to the [living] room";
            }
        }


        internal override void ReceiveChoice(string choice)
        {
            if (Game.gameScript == 0)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "living":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "examine":
                        Console.WriteLine("You carefully examine the room, searching for any hidden items.");
                        if (Game.inventory.Contains("bat"))
                        {
                            Console.WriteLine("you already checked and found a baseball bat, now there is nothing.");
                        }
                        else
                        {
                            Console.WriteLine("you found a baseball bat under the bed, but you don't need it.");
                        }
                        break;
                    case "nap":
                        Console.WriteLine("You settle into bed, hoping to pass the time until your husband arrives.");
                        Game.gameScript = 1;
                        Game.SetTime(17,0,0);
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (Game.gameScript == 1 || Game.gameScript == 2 || Game.gameScript == 3 || Game.gameScript == 4 )
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "living":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "examine":
                        Console.WriteLine("You carefully examine the room, searching for any hidden items.");
                        Console.WriteLine("you found a baseball bat under the bed, but you don't need it.");
                        break;
                    case "bed":
                        if (bedDone == false)
                        {
                            Console.WriteLine("You make the bed, smoothing out the covers with care.");
                            bedDone = true;
                        }
                        else
                        {
                            Console.WriteLine("The bed is already made, there's no need to do it again.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }

            else if (Game.gameScript == 5)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "living":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "examine":
                        Console.WriteLine("You carefully examine the room, searching for any hidden items.");
                        if (bat==false)
                        {
                            Console.WriteLine("you already checked and found a baseball bat, now there is nothing.");
                        }
                        else
                        {
                            Console.WriteLine("you found a baseball bat under the bed, You take it (it is now in your inventory)");
                            Game.AddInventory("Baseball bat");
                            bat = true;
                        }
                        break;
                    case "nap":
                        Console.WriteLine("You settle into bed, hoping to pass the time");
                        Game.gameScript = 1;
                        Game.AddTime(1, 0, 0);
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (Game.gameScript == 6)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "living":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "examine":
                        Console.WriteLine("You carefully examine the room, searching for any hidden items.");
                        Console.WriteLine("But there is nothing useful.");
                        break;
                    case "nap":
                        Console.WriteLine("You settle into bed, hoping to pass the time");
                        Game.gameScript = 1;
                        Game.AddTime(1, 0, 0);
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }//Husband is dead
            }
            else if (Game.Callpolice)
            {

            }
            else 
            {
            
            }

        }
    }
}
