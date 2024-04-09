using System;
using System.Runtime.Remoting.Channels;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {


        internal static bool bathDone = false;
        internal override string CreateDescription() =>
@"In your bathroom, the [bath] is filled with hot water.
The [mirror] in front of you reflects your depressed face.
You can return to your [bedroom].
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
                    if (bathDone==true)
                    {
                        Console.WriteLine("You see the numbers 6595 written on the fog on your mirror.");
                    }
                    else if(bathDone==false)
                    {
                        Console.WriteLine("You see yourself in the mirror");
                    }
                    break;
                    
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
