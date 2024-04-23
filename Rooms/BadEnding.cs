using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class BadEnding : Room
    {

        internal override string CreateDescription()
        {
            return @"You stand in the living room, alone with the note your husband left behind, a mix of emotions washes over you. 
The weight of his decision to leave hangs heavy in the air, mingling with the uncertainty of what lies ahead for you and your baby. 
You glance around the room, noticing the empty space where he used to sit, the familiar objects now imbued with a sense of loss.
The note in your hand serves as a stark reminder of his departure and his promise to provide for you and the baby. 
You take a deep breath, trying to steady your nerves as you contemplate the uncertain future. 
It's a bittersweet moment, filled with both sadness and a glimmer of hope for what may come next.

Ending(1/3): Not completely alone
\n Go [back] to the Title Page or [exit] Game";
        }

        internal override void ReceiveChoice(string choice)
        {
            Game.inventory.Clear();
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
