using System;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {


        internal static bool takenCleaning = false;
        internal override string CreateDescription() 
        {
            if (Game.gameScript == 0 || Game.gameScript == 1 || Game.gameScript == 2 || Game.gameScript == 3 || Game.gameScript == 4 || Game.gameScript == 5)
            {
                return @"You are in the Bathroom. 
You can check your appearance in the [mirror],
use the [toilet], or go back to the [living] room.";
            }
            else if (Game.gameScript == 6)
            {
                return @"You are in the Bathroom. 
check your appearance in the [mirror],
apply [makeup], or practice your [expression].
You can clean your face in the [sink], or your breath with [toothpaste]
There are also some cleaning liquids in the [cabinet].
";
            }//Husband is dead
            else if (Game.Callpolice)
            {
                return @"In the bathroom, you stand before the [mirror], maybe your reflection is mix of anxiety and apprehension,
but you try to compose yourself under the watchful eyes of the police.
You can also use the [toilet] or return to the [living] room, where the tension hangs thick in the air.";
            }
            else 
            {
                return @"*out of bundaries*"; 
            }//if error happen
        }

    internal override void ReceiveChoice(string choice)
        {
            if (Game.gameScript <= 0||Game.gameScript>=5)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "save":
                        GameSaveSystem.SaveGame(Game.filePath);
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
                        else if (Game.TalkToHusband)
                        {
                            Console.WriteLine("After your conversation with your husband, you look at yourself in the mirror, your expression a mix of sadness and fear, reflecting the turmoil within.");//asustad llorosa
                        }
                        else
                        {
                            Console.WriteLine("You see yourself in the mirror");
                        }
                        break;
                    case "toilet":
                        Console.WriteLine("You use the toilet.");
                        break;
                    case "living":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }

            }
            else if(Game.gameScript <=6) 
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "save":
                        GameSaveSystem.SaveGame(Game.filePath);
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
                        else if (Game.husbandDead || Game.cleanKill)
                        {
                            Console.WriteLine("After dispatching your husband with the leg of lamb, you stand in front of the mirror, trembling with fear, but there's no trace of blood on your hands or face, only the chilling realization of what you've done.");// se nota el susto
                        }
                        else if (Game.husbandDead || !Game.cleanKill)
                        {
                            Console.WriteLine("After using a weapon to dispatch your husband, you stand before the mirror, your hands trembling and your face pale with fear. Blood stains your skin, but thankfully there's no trace of it on your clothes, leaving a chilling reminder of the violence you've committed.");// salpicada de sangre
                            Game.PlayerClean = true;
                        }
                        else if (Game.TalkToHusband)
                        {
                            Console.WriteLine("After your conversation with your husband, you look at yourself in the mirror, your expression a mix of sadness and fear, reflecting the turmoil within.");//asustad llorosa
                        }
                        else
                        {
                            Console.WriteLine("You see yourself in the mirror");
                        }
                        break;
                    case "toilet":
                        Console.WriteLine("You try to use the toilet. But nothing comes out");
                        break;
                    case "sink":
                        if (Game.husbandDead || !Game.cleanKill)
                        {
                            Console.WriteLine("You meticulously wash the blood from your hands and face, trying to erase any evidence of what you've done.");// salpicada de sangre
                            Game.IncreaseSanity();
                        }
                        else
                        {
                            Console.WriteLine("You clean your hands hopping that the warm watter will calm you");
                            Game.IncreaseSanity();
                        }
                        break;
                    case "makeup":
                        if (Game.PlayerClean == false)
                        {
                            Game.DecraseSanity();
                            Console.WriteLine("You apply makeup while looking in the mirror. But your face is covered in blood");
                        }
                        else
                        {
                        Console.WriteLine("You apply makeup while looking in the mirror.");
                        }
                        break;
                    case "cabinet":
                        if (takenCleaning == false)
                        {
                            Console.WriteLine("You find some cleaning liquids in the cabinet.");
                            Game.AddInventory("Cleaning suply");
                            takenCleaning=true;
                        }
                        else
                        {
                            Console.WriteLine("The cabinet is empty");
                        }
                        break;
                    case "expression":
                        Console.WriteLine(@"You tidied up your hair, touched up the lips and face.Then you tried a smile. It came out rather peculiar.
Try again.“Hullo Sam,” you said brightly, aloud. The voice sounded peculiar too.“I want some potatoes please,
Sam. Yes, and I think a can of peas. That was better.  Both the smile and the voice were coming out better now.
You rehearsed it several times more. Until it feels more natural");
                        break;
                    case "living":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "toothpaste":
                        if (Game.DrunkPlayer)
                        {
                        Console.WriteLine("You used toothpaste to wipe your breath so they won't notice you drank.");
                        Game.DrunkPlayer =false;
                        Game.IncreaseSanity();
                        }
                        else
                        {
                            Console.WriteLine("this helps you stay calm while you thought you should do");
                            Game.IncreaseSanity();
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (Game.Callpolice)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "save":
                        GameSaveSystem.SaveGame(Game.filePath);
                        break;
                    case "mirror":
                        Console.WriteLine(@"As you gaze into the mirror, you see your reflection, your skin glowing with the radiance of pregnancy.
Your mouth appears soft, and your eyes, though placid, betray a hint of anxiety as
you contemplate whether everything is proceeding smoothly, even with the police presence in your home.");
                        break;
                    case "toilet":
                        Console.WriteLine(@"You step into the bathroom and sit on the toilet, finding a moment of relief in the midst of chaos, as if the world outside this small room momentarily fades away.");
                        break;
                    case "living":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
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
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "save":
                        GameSaveSystem.SaveGame(Game.filePath);
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
                        else
                        {
                            Console.WriteLine("You see yourself in the mirror");
                        }
                        break;
                    case "toilet":
                        Console.WriteLine("You use the toilet.");
                        break;
                    case "living":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
               
        }
    }
}
