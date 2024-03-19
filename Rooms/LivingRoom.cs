using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class LivingRoom : Room
    {
        internal override string CreateDescription() =>
@"You are in the Living Room.
Do you want to [finish] the game
or go back to the [bedroom]";
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
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

