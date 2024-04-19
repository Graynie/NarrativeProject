using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Grocery : Room
    {

        internal override string CreateDescription()
        {
            
            if (Game.gameScript == 5)
            {
                return "";
            }
            else
            {
                return @"You can buy stuff here, but be careful the owner can get 
suspicious of what you did";
            }
        }

        internal override void ReceiveChoice(string choice)
        {
            if (Game.gameScript == 5)
            {
                switch (choice)
                {
                    case "home":
                        Console.WriteLine("");
                        Game.Transition<BadEnding>();
                        break;
                    case "ask":
                        Game.Transition<LivingRoom>();
                        break;
                        default:
                        break;
                }
            }
        }
    }
}
