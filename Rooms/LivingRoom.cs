using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{

    internal class LivingRoom : Room
    {
        private bool sittingOnChair = true;
        private bool greetHusband = false;
        internal bool fireplaceOn = false;
        internal int randomNumber = 0;
        internal string LikeDrink = "Yes";
        internal override string CreateDescription()
        {
            if (Game.gameScript == 0)
            {
                if (sittingOnChair == true)
                {
                    return @"You are in the Living Room. Sitting on your chair,
You can [sew] until your husband arrives, or [stand] up";
                }
                else
                {
                    return @"You are in the Living Room. 
You can do sit on your [chair], sit on your husband's [sofa],
aproach the [drinks] car, aproach the [fireplace], go outtside
to the [Grocery] store, or go to one of the other rooms: 
[closet], [kitchen], [bathroom], [bedroom]";
                }
            }
            else if (Game.gameScript == 1)
            {
                if (greetHusband == false && sittingOnChair == false)
                {
                    return @"You are in the Living Room.
You can [Greet] your husband, sit on your [chair],
sit on your husbands [sofa], aproach the [drinks] 
car, aproach the [fireplace],go outtside to the 
[Grocery] store, or go to one of the other rooms:
[closet], [kitchen], [bathroom], [bedroom].";
                }
                else if (greetHusband == false && sittingOnChair == true)
                {
                    return @"You are in the Living Room.
You can stand up and [Greet] your husband, or 
[ignore] him and continue sewing.";
                }
                else if (greetHusband == true && sittingOnChair == true && Game.husbandDead == true)
                {
                    return @"You are in the Living Room. Sitting on your chair,
You can [sew], or [stand] up";
                }
                else
                {
                    return @"You are in the Living Room. 
You can do sit on your [chair], sit on your husband's [sofa],
aproach the [drinks] car, aproach the [fireplace], go outtside
to the [Grocery] store, or go to one of the other rooms: 
[closet], [kitchen], [bathroom], [bedroom]";
                }
            }
            else if (Game.gameScript == 2)
            {
 return @"This time of day is always a blissful time for you. 
You know he doesn’t want to speak much right after arriving home from work.
You are content to sit quietly and enjoy his company after spending long 
hours alone in the house. Occasionally, you both enjoy a drink."; 

            }
            else if(Game.gameScript == 3)
            {
                return @"If you’re too tired to eat out"", You said to him,"" it’s still not too late.
There’s plenty of meat and other things in the freezer, 
so you can stay right here and not even have to leave the chair.""
You watched him, waiting for him to respond with a smile or a nod, but he didn't show any reaction.
""Anyway,"" you continued, ""I'll get you some cheese and crackers to start.""
""I don't want it,"" he replied.[continue]";
            }
            else if(Game.gameScript == 4)
            {
                return @"You start to feel frightened when he tells you to sit down. You sit back slowly, watching him with large, confused eyes. 
""Listen,"" he says. ""I need to tell you something.""
""What is it, darling? What's wrong?"" you ask.
He stays still.
""This will be a shock,"" he continues. ""But I've thought a lot about it and decided I must tell you now. I hope you don't blame me too much.""
He tells you quickly, in four or five minutes. You sit very still, watching him with a sense of dazed horror as his words distance him from you.
""So there it is,"" he adds. ""I know this is a bad time to tell you, but I had no choice. I'll give you money and make sure you're taken care of. Please, let's keep this quiet for my job's sake.""[continue]";
            }
            else if (Game.gameScript == 5)
            {
                return @"";
            }
            else if (Game.gameScript == 7)
            {
                if (Game.lambLeg == true)
                {
                    return @"You are in the Living Room.
You can [aproach] your husband, sit in your [chair], sit on
your husbands [sofa], aproach the [drinks] 
car, aproach the [fireplace],go outtside to
the [Grocery] store, or go to one 
of the other rooms: [closet], [kitchen], 
[bathroom], [bedroom]";
                }
                else
                {
                    return @"You are in the Living Room.
Do you want to sit on your [chair], sit on
your husbands [sofa], aproach the [drinks] 
car, aproach the [fireplace],go outtside to
the [Grocery] store, or go to one 
of the other rooms: [closet], [kitchen], 
[bathroom], [bedroom]";
                }
            }
            else { return @"None"; }
        }
        internal override void ReceiveChoice(string choice)
        {
            if (Game.gameScript == 0)
            {
                if (sittingOnChair == true)
                {
                    switch (choice)
                    {
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "sew":
                            Console.WriteLine("You continue sewing a pair of boots for a baby");
                            Game.timeHour++;
                            break;
                        case "stand":
                            sittingOnChair = false;
                            Console.WriteLine(@"As you carry your not yet born baby, you feel a bit dizzy and
                                 your belly is heavy.");
                            Game.FiveMinutes();
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
                        case "bedroom":
                            Console.WriteLine("You returned to the room.");
                            Game.Transition<Bedroom>();
                            break;
                        case "drinks":
                            Console.WriteLine("Drinks car");
                            break;
                        case "closet":
                            Console.WriteLine("You are looking at the closed is a little dirty");
                            break;
                        case "sofa":
                            Console.WriteLine("You are sitting in your husbands chair, Will he get mad?");
                            break;
                        case "kitchen":
                            Console.WriteLine("You can cook here");
                            Game.Transition<Kitchen>();
                            break;
                        case "bathroom":
                            Console.WriteLine("The bathroom looks clean, you cleaned it in the morning");
                            Game.Transition<Bathroom>();
                            break;
                        case "fireplace":
                            Console.WriteLine("Lit the fire place");
                            break;
                        case "chair":
                            Console.WriteLine("You are confortably sitting in your chair");
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
            }
            else if (Game.gameScript == 1)
            {
                if (sittingOnChair == true)
                {
                    switch (choice)
                    {
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "greet":
                            Console.WriteLine(@"You kiss your Husband, Patrick.
“Hullo darling,” you say.
“Hullo darling,” he answers.
You took his coat");
                            sittingOnChair = false;
                            Game.AddInventory("coat");
                            Game.gameScript = 2;
                            break;
                        case "ignore":
                            Console.WriteLine(@"Your husband looks weirdly at you, but 
continuos his way puttiing his coat at the closet, and sitting 
on his sofa");
                            Game.gameScript = 2;
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                if (sittingOnChair == false)
                {
                    switch (choice)
                    {
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "chair":
                            Console.WriteLine(@"Your husband looks weirdly at you, but 
continuing his way puttiing his coat at the closet, 
and sitting on his sofa");
                            Game.HusbandTemperament += 5;
                            Game.gameScript = 2;
                            break;
                        case "bedroom":
                            Console.WriteLine("You walked to the bedroom,Your husband probably feels ignored");
                            Game.gameScript = 2;
                            Game.HusbandTemperament += 5;
                            Game.Transition<Bedroom>();
                            break;
                        case "drinks":
                            Console.WriteLine(@"Your husband looks weirdly at you, but 
continuing his way putting his coat at the closet, 
and sitting on his sofa
*You can't pour you a drink, you are pregnant ");
                            Game.HusbandTemperament += 5;
                            Game.gameScript = 2;
                            break;
                        case "closet":
                            Console.WriteLine(@"Your husband looks weirdly at you, but 
continuing his way and sitting on his sofa
*You are looking at the closed it is a little dirty");
                            Game.HusbandTemperament += 5;
                            Game.gameScript = 2;
                            break;
                        case "sofa":
                            Console.WriteLine("*You shouldn't do that he is at home");
                            break;
                        case "kitchen":
                            Console.WriteLine("You don't need to cook today your are supposed to go out to dinner with your husband, He probably feels ignored");
                            Game.HusbandTemperament += 5;
                            Game.Transition<Kitchen>();
                            break;
                        case "bathroom":
                            Console.WriteLine("The bathroom seams clean,Your husband probably feels ignored"); Game.HusbandTemperament += 5;
                            Game.HusbandTemperament += 5;
                            Game.Transition<Bathroom>();
                            break;
                        case "fireplace":
                            fireplace();
                            break;
                        case "greet":
                            sittingOnChair = false;
                            Console.WriteLine(@"You kiss your Husband, Patrick.
“Hullo darling,” you say.
“Hullo darling,” he answers.
You took his coat");
                            Game.HusbandTemperament -= 5;
                            Game.AddInventory("coat");
                            Game.NextStepScript();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
            }
            else if (Game.gameScript == 2)
            {
                if (sittingOnChair == true)
                    switch (choice)
                    {
                        case "i":
                            Game.DisplayInventory();
                            break;

                        case "ignore":
                            Console.WriteLine(@"Your husband has an odd look on his face, but ultimately chooses to unwind on his sofa. Despite his hesitation, it appears he has something to say to you.");
                            Game.gameScript = 3;
                            Game.HusbandTemperament += 10;
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                else
                {
                    switch (choice)
                    {
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "bedroom":
                            Console.WriteLine("You returned to the room, your husband is waiting for you in the living room. Maybe you can get his slippers");
                            Game.Transition<Bedroom>();
                            break;
                        case "husband":
                            if (Game.inventory.Contains("drink"))
                            {
                                Console.WriteLine("You gave your husband a drink");
                                Console.WriteLine(LikedDrink());
                                Game.RemoveInventory("drink");
                                Game.HusbandDrunk += 10;
                            }
                            else if (Game.inventory.Contains("slipers"))
                            {
                                Console.WriteLine("You gave your husband his slippers, he seems more confortable");
                                Game.HusbandTemperament += 20;
                            }
                            else
                            {
                                Console.WriteLine("Your husband seems tired");
                                Game.HusbandTemperament -= 5;
                                if (Game.HusbandTemperament < 0)
                                {
                                    Game.gameScript = 3;
                                }
                            }
                            break;
                        case "drinks":
                            Console.WriteLine("You have made a drink for you husband. This time it is a" + RamdomDrink());
                            break;
                        case "closet":
                            if (Game.inventory.Contains("coat"))
                            {
                                Console.WriteLine("You hang the coat on the closet");
                                Game.RemoveInventory("coat");
                            }
                            else
                            {
                                Console.WriteLine("You are looking at the closed is a little dirty");
                            }
                            break;
                        case "kitchen":
                            if (Game.TalkToHusband == true)
                            {
                                Console.WriteLine($"You can cook your husband's souper here");
                            }
                            else
                            {
                                Console.WriteLine("You don't need to cook today your are supposed to go out to dinner with your husband, He is waiting in the living room.");
                                Game.HusbandTemperament -= 5;
                            }
                            Game.Transition<Kitchen>();
                            break;
                        case "bathroom":
                            Console.WriteLine("The bathroom looks clean, you cleaned it in the morning. Your husband is waiting in the living room.");
                            Game.HusbandTemperament -= 5;
                            Game.Transition<Bathroom>();
                            break;
                        case "fireplace":
                            fireplace();
                            break;
                        case "chair":
                            Console.WriteLine("You are confortably sitting in your chair");
                            if (Game.HusbandDrunk > 5)
                            {
                                Game.gameScript = 3;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }

            }
            else if(Game.gameScript == 3)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "continue":
                        Game.gameScript = 4;
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (Game.gameScript == 5)
            {
                if (sittingOnChair == true)
                    switch (choice)
                    {
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "talk":
                            Console.WriteLine();
                            break;
                        case "ignore":
                            Console.WriteLine(@"Your husband has an odd look on his face, but ultimately chooses to unwind on his sofa. Despite his hesitation, it appears he has something to say to you.");
                            Game.gameScript = 3;
                            Game.HusbandTemperament += 10;
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                else
                {
                    switch (choice)
                    {
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "bedroom":
                            Console.WriteLine("You returned to the room, your husband is waiting for you in the living room.");
                            Game.HusbandTemperament += 5;
                            Game.Transition<Bedroom>();
                            break;
                        case "husband":
                            if (Game.inventory.Contains("drink"))
                            {
                                Console.WriteLine("You gave your husband a drink");
                                Console.WriteLine(LikedDrink());
                                Game.RemoveInventory("drink");
                                Game.HusbandDrunk += 10;
                            }
                            else
                            {
                                Console.WriteLine("Your husband seems tired");
                                Game.HusbandTemperament -= 5;
                                if (Game.HusbandTemperament < 0)
                                {
                                    Game.gameScript = 3;
                                }
                            }
                            break;
                        case "drinks":
                            Console.WriteLine("You have made a drink for you husband. This time it is a" + RamdomDrink());

                            break;
                        case "closet":
                            if (Game.inventory.Contains("coat"))
                            {
                                Console.WriteLine("You hang the coat on the closet");
                                Game.RemoveInventory("coat");
                            }
                            else
                            {
                                Console.WriteLine("You are looking at the closed is a little dirty");
                            }
                            break;
                        case "kitchen":
                            if (Game.TalkToHusband == true)
                            {
                                Console.WriteLine($"You can cook your husband's souper here");
                            }
                            else
                            {
                                Console.WriteLine("You don't need to cook today your are supposed to go out to dinner with your husband, He is waiting in the living room.");
                                Game.HusbandTemperament -= 5;
                            }
                            Game.Transition<Kitchen>();
                            break;
                        case "bathroom":
                            Console.WriteLine("The bathroom looks clean, you cleaned it in the morning. Your husband is waiting in the living room.");
                            Game.HusbandTemperament -= 5;
                            Game.Transition<Bathroom>();
                            break;
                        case "fireplace":
                            fireplace();
                            break;
                        case "chair":
                            Console.WriteLine("You are confortably sitting in your chair");
                            if (Game.HusbandDrunk > 5)
                            {
                                Game.gameScript = 3;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
            }
            else
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "bedroom":
                        Console.WriteLine("You returned to the room.");
                        Game.Transition<Bedroom>();
                        break;
                    case "drinks":
                        Console.WriteLine("Drinks car");
                        break;
                    case "closet":
                        Console.WriteLine("You are looking at the closed is a little dirty");
                        break;
                    case "sofa":
                        Console.WriteLine("You are sitting in your husbands chair, Will he get mad?");
                        break;
                    case "kitchen":
                        Console.WriteLine("You can cook here");
                        Game.Transition<Kitchen>();
                        break;
                    case "bathroom":
                        Console.WriteLine("Take a pee");
                        Game.Transition<Bathroom>();
                        break;
                    case "fireplace":
                        Console.WriteLine("Lit the fire place");
                        break;
                    case "sew":
                        Console.WriteLine("You continue sewing a pair of baby boots");
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        internal void fireplace()
        {
            if (fireplaceOn == true)
            {
                fireplaceOn = false;
                Console.WriteLine("you put out the fireplace");
            }
            else
            {
                fireplaceOn = true;
                Console.WriteLine("You lit the fireplace");
            }
        }

        internal string RamdomDrink()
        {
            Random random = new Random();
            
            int randomNumber = random.Next(1, 11);
            Game.AddInventory("drink");
            if (randomNumber == 1)
            {
                return "Old Fashioned";
            }
            else if (randomNumber == 2)
            {
                return "Martini";
            }
            else if (randomNumber == 3)
            {
                return "Whiskey Sour";
            }
            else if (randomNumber == 4)
            {
                return "Manhattan";
            }
            else if (randomNumber == 5)
            {
                return "Scotch on the Rocks";
            }
            else if (randomNumber == 6)
            {
                return "Tom Collins";
            }
            else if (randomNumber == 7)
            {
                return "Daiquiri";
            }
            else if (randomNumber == 8)
            {
                return "Mint Julep";
            }
            else if (randomNumber == 9)
            {
                return "Rum and Coke";
            }
            else
            {
                return "Pina Colada";
            }
        }
        internal string LikedDrink()
        {
            if (randomNumber == 1)
            {
                LikeDrink = "Your husband is delighted with your choice of drink.";
                Game.HusbandTemperament += 20;
            }
            else if (randomNumber == 2)
            {
                LikeDrink = "Your husband seems quite pleased with your choice of drink.";
                Game.HusbandTemperament += 15;
            }
            else if (randomNumber == 3)
            {
                LikeDrink = "Your husband appreciates your choice of drink.";
                Game.HusbandTemperament += 10;
            }
            else if (randomNumber == 4)
            {
                LikeDrink = "Your husband is content with your choice of drink.";
                Game.HusbandTemperament += 5;
            }
            else if (randomNumber == 5)
            {
                LikeDrink = "Your husband thinks your choice of drink is agreeable.";
                Game.HusbandTemperament += 0;
            }
            else if (randomNumber == 6)
            {
                LikeDrink = "Your husband finds your choice of drink acceptable.";
                Game.HusbandTemperament += 0;
            }
            else if (randomNumber == 7)
            {
                LikeDrink = "Your husband is indifferent to your choice of drink.";
                Game.HusbandTemperament -= 5;
            }
            else if (randomNumber == 8)
            {
                LikeDrink = "Your husband isn't particularly keen on your choice of drink.";
                Game.HusbandTemperament -= 10;
            }
            else if (randomNumber == 9)
            {
                LikeDrink = "Your husband seems to disapprove of your choice of drink.";
                Game.HusbandTemperament -= 15;
            }
            else
            {
                LikeDrink = "Your husband is quite displeased with your choice of drink.";
                Game.HusbandTemperament -= 20;
            }
            return LikeDrink;
        }
    }
}

