using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class BadEndingTwo : Room
    {

        internal override string CreateDescription()
        {
            return @"As the police arrive and enter the living room, their expressions shift from curiosity to grim realization. Their eyes narrow as they take in the scene—the lifeless body of your husband.
The lead officer's gaze locks onto you, suspicion etched on his face as he begins to piece together what has happened.
You feel a knot form in your stomach as the weight of their scrutiny bears down on you, knowing that they have caught onto the truth:
you are the one who killed your husband. The room feels suffocatingly silent as the gravity of the situation sinks in, and you brace yourself for the inevitable consequences of your actions.
Reason why you failed:" +Failed()+ "\n Go [back] to the Title Page or [exit] Game";
            
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
        internal string Failed()
        {
            string text = "";
            if (!Game.PlayerClean)
            {
                text += "\n";
            }
            else if (Game.inventory.Contains("Lamb Leg with blood"))
            {
                text += "\n- For having a Lamb Leg with blood with you when the police arrived";
            }
            else if (Game.inventory.Contains("stained baseball bat"))
            {
                text += "\n- For having a stained with blood baseball bat with you when the police arrived";
            }
            else if (Game.inventory.Contains("stained knife"))
            {
                text += "\n- For having a stained with blood knife with you when the police arrived";
            }
            else if (Game.inventory.Contains("note"))
            {
                text += "\n- For having a stained with blood knife with you when the police arrived";
            }
            else if (Game.notedestroyed && Game.inventory.Contains("note"))
            {
                text += "\n- The policemen found out that you had a note in your posession, fastly you became a suspect of homicide";
            }
            else if (Game.DrunkPlayer)
            {
                text += "\nYou were visibly drunk that made them easier to detect your lies";
            }
            else if (Game.SinkDirty)
            {
                text += "\nYou left the sink stained with blood";
            }
            else
            {

            }
            return text;
        }
    }
}
