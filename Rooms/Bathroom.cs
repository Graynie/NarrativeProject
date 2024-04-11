using System;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {


        internal static bool bathDone = false;
        internal override string CreateDescription() =>
@"In your bathroom, the [bathtub] is empty and clean.
The [mirror] can show you reflection
You can return to your [Living] room.
";

        internal override void ReceiveChoice(string choice)
        {
           
            switch (choice)
            {

                case "bath":
                    Console.WriteLine("You relax in the bath.");
                   bathDone = true;
                    break;
                case "mirror":
                    if (!Game.husbandDead)
                    {
                        Console.WriteLine(@"You see yourself in the mirror.Your skin — for this
your sixth month with child — had acquired a
wonderful translucent quality, your mouth looking
soft, and your eyes, showing a placid look,
that seem larger darker than before.");
                    }
                    else if(bathDone==false)
                    {
                        Console.WriteLine("You see yourself in the mirror");
                    }
                    else
                    {
                        Console.WriteLine(@"You tidied up your hair, touched up the lips and face.
Then you tried a smile. It came out rather peculiar.
Try again.
“Hullo Sam,” you said brightly, aloud. The voice sounded peculiar too
“I want some potatoes please, Sam. Yes, and I think a can of peas.”
That was better.  Both the smile and the voice were coming out better 
now. You rehearsed it several times more. Until it feels more natural");
                    }
                    //How to open an url
                    //System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://pbs.twimg.com/media/GKYY1tdagAAbZrb?format=jpg&name=medium", UseShellExecute = true });
                    //How to open a file in your PC
                    System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "Images\\DreamOptsLogoLigther.png", UseShellExecute = true });
                    break;
                    
                case "living":
                    Console.WriteLine("You return to your Living Room.");
                    Game.Transition<LivingRoom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
