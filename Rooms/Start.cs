using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Start : Room
    {
        public static bool IsStartMenu = true;

        internal override string CreateDescription()
        {
            
            return
@"You play as Mary Maloney who is waiting for her husband to come home from work. Since is Tuesday you will go out to 
dinner as usual.

*Remember you can always check your Inventory by writing [i]
*or [save] your game anytime.


-----------------------------------------------Choose your option-------------------------------------------------------
                      [Start]       -         Play a [saved] File            -          [Exit] Game";
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "start":
                    GameSaveSystem.ResetGame();
                    Console.WriteLine(
@"You awaken in your quaint suburban home, the evening sun casting long shadows across the room. Your husband, Patrick, 
will arrive at 5 o'clock as everyday");
                    IsStartMenu = false;
                    Game.Transition<LivingRoom>();
                    break;
                case "saved":
                    GameSaveSystem.LoadGame(Game.filePath);
                    Game.Transition<LivingRoom>();
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
