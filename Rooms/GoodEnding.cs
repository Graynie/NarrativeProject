using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NarrativeProject.Rooms
{
    internal class GoodEnding : Room
    {

        internal override string CreateDescription()
        {
            return @"As the police arrive and enter the room, their expressions shift from curiosity to somber understanding. Their eyes scan the area, taking in the scene without any immediate suspicion.
The lead officer nods in acknowledgment, thanking you for your cooperation. They offer their condolences and suggest helping you get to your mom's house for support, but you decline, opting to stay.
As they leave, expressing gratitude for your assistance, you're left alone in the room, a sense of relief washing over you. You've managed to deceive them and evade the consequences of your actions, at least for now.

Ending(4/3): Best Ending?
Your husband has been killed and you haven't been caught.

 Go [back] to the Title Page or [exit] Game";
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "back":
                    Start.IsStartMenu = true;
                    Game.Transition<Start>();
                    break;
                case "exit":
                    Console.WriteLine("Bye");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
