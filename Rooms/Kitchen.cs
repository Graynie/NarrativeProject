using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {
        internal static bool dishesClean = false;
        internal static bool checkedFridge = false;
        internal static bool checkedFreezer = false;
        internal static bool insist = false;

        internal override string CreateDescription()
        {
            if (Game.gameScript == 0)
            {
                return @"You are in the Kitchen. 
You can check the [fridge] for vegetables,
check the [freezer] for meat or ice cream,
[examine] the room, approach the [sink] to wash dishes,
or go back to the [living room].";
            }//alone at home, waiting for husband
            else if (Game.gameScript == 1)
            {
                if (LivingRoom.greetHusband == false)
                {
                    return @"You are in the Kitchen.
You have ignored your husband,here you can check the [fridge] for vegetables,
check the [freezer], for meat or ice cream, approach the [sink] to wash dishes,
call someone with the [phone], or go back to the [living room].";
                }
                else
                {
                    return @"You are in the Kitchen. 
You can check the [fridge] for vegetables, check the [freezer] for meat or ice cream,
approach the [sink] to wash dishes, call someone with the [phone],
or go back to the [living room].";
                }
            }//husband arrives, Greet him
            else if (Game.gameScript == 2|| Game.gameScript == 3|| Game.gameScript == 4)
            {
                return @"You are in the Kitchen. 
You can check the [fridge] for vegetables,
check the [freezer] for meat or ice cream, approach the [sink] to wash dishes,
check the [oven], call someone with the [phone],
or go back to the [living] room.";
            }//Patrick is sitting in his sofa
            else if (Game.gameScript == 5)
            {
                
                    return @"Patrick is in the living room.
You can check the [fridge] for vegetables,
check the [freezer] for meat or ice cream, approach the [sink] to wash dishes,
maybe cook something in the [oven]
look out the [window] to see the backyard, or go back to the [living room].";
                
            }//Kill or be left-Prepare souper
            else if (Game.gameScript == 6)
            {
                if (Game.inventory.Contains("Lamb Leg with blood"))
                {
                    return @" While in the kitchen : You consider your next move. What will you do?

- [think] carefully: Take a moment to process your actions and consider your options.
- [examine] your surroundings: Look around the kitchen, assessing what needs to be addressed to avoid suspicion.
- [Marinate] the leg Lamb to cook it and hide the murder weapon.
- Call the police with the [phone]
- GoodEnding back to the [Living] Room";
                }
                else if (Game.inventory.Contains("Marinated Leg Lamb"))
                {
                    return @" While in the kitchen : You consider your next move. What will you do?

- [think] carefully: Take a moment to process your actions and consider your options.
- [examine] your surroundings: Look around the kitchen, assessing what needs to be addressed to avoid suspicion.
- prepare an [alibi]: Begin to construct a story to account for your whereabouts and actions, creating a plausible cover for the events that transpired.
- Put the Lamb Leg in the [oven]
- GoodEnding back to the [Living] Room""
- [call] the police";
                }
                else
                {

                    return @" While in the kitchen : You consider your next move. What will you do?

- [think] carefully: Take a moment to process your actions and consider your options.
- [examine] your surroundings: Look around the kitchen, assessing what needs to be addressed to avoid suspicion.
- prepare an [alibi]: Begin to construct a story to account for your whereabouts and actions, creating a plausible cover for the events that transpired.
- [call] the police
- GoodEnding back to the [Living] Room""
";
                }
                }//Husband is dead
            else { return @"You are in the Kitchen. 
You can check the[fridge] for vegetables,
                check the[freezer] for meat or ice cream,
approach the[sink] to wash dishes, or go back to the[living room]."; }//if error happen
        }
        internal override void ReceiveChoice(string choice)
        {
            if (Game.gameScript == 0 || Game.gameScript == 1 || Game.gameScript == 2 || Game.gameScript == 3 || Game.gameScript == 4)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "save":
                        GameSaveSystem.SaveGame(Game.filePath);
                        Start.IsStartMenu = true;
                        Game.Transition<Start>();
                        break;
                    case "examine":
                        Console.WriteLine("There is knife in the countertop but you don't need it rigth now");
                        break;
                    case "oven":
                        Console.WriteLine("There is nothing in the oven");
                        break;
                    case "living":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "phone":
                        Console.WriteLine("You decide to call someone");
                        RamdomCall();
                        break;
                    case "sink":
                        if (dishesClean == false)
                        {
                            Console.WriteLine("You approach the sink and start washing dishes.");
                            dishesClean = true;
                        }
                        else
                        {
                            Console.WriteLine("There are no dishes that require cleaning.");
                        }
                        break;
                    case "freezer":
                        Console.WriteLine("Upon checking the freezer, you discover that there is meat, but no ice cream.");
                        break;
                    case "fridge":
                        Console.WriteLine("When you open the fridge, you find that there are no fresh vegetables.");
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (Game.gameScript == 5)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "save":
                        GameSaveSystem.SaveGame(Game.filePath);
                        Start.IsStartMenu = true;
                        Game.Transition<Start>();
                        break;
                    case "examine":
                        Console.WriteLine(@"There is knife in the countertop, you take it
now you have a knife in the inventory");
                        Game.AddInventory("knife");
                        break;
                    case "living room":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "phone":
                        Console.WriteLine("You decide to call someone");
                        RamdomCall();
                        break;
                    case "sink":
                        if (dishesClean == false)
                        {
                            Console.WriteLine("You approach the sink and start washing dishes.");
                            dishesClean = true;
                        }
                        else
                        {
                            Console.WriteLine("There are no dishes that require cleaning.");
                        }
                        break;
                    case "freezer":
                        Console.WriteLine("Upon checking the freezer, you discover that there is meat, but no ice cream.You take something to make souper for your husband");
                        Game.AddInventory("Lamb Leg");
                        break;
                    case "fridge":
                        Console.WriteLine("When you open the fridge, you find that there are no fresh vegetables. To do the souper you will need to go to the Grocery store");
                        break;
                    case "oven":
                        if (Game.inventory.Contains("Marinated Leg Lamb"))
                        {
                            Game.RemoveInventory("Marinated Leg Lamb");
                            Console.WriteLine(@"You put the leg of lamb in the oven, now no one will find the murder weapon, like alibi you could go buy vegetables and say you found your husband in the state that’s in the living room");
                        }
                        else
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                    case "marinate":
                        if (Game.inventory.Contains("Lamb Leg with blood"))
                        {
                            Game.RemoveInventory("Lamb Leg with blood");
                            Game.AddInventory("Marinated Leg Lamb");
                            Console.WriteLine("You have marinated the leg of lamb now you can put it in the oven");
                        }
                        else
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (Game.gameScript == 6)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "save":
                        GameSaveSystem.SaveGame(Game.filePath);
                        Start.IsStartMenu = true;
                        Game.Transition<Start>();
                        break;
                    case "living room":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "phone":
                        if (insist == true)
                        {
                            Console.WriteLine(@"As you dial the emergency number, your hands tremble with nervousness and fear. You know the police need to be called, but the sight of the bloodied weapon still in your hands fills you with dread. Knowing they will notice you are the one who killed Patrick");
                            Game.Transition<BadEndingTwo>();
                        }
                        else if (Game.inventory.Contains("stained knife") || Game.inventory.Contains("stained knife") || Game.inventory.Contains("Lamb leg with blood"))
                        {
                            Console.WriteLine(@"Are you sure you want to call the police, You have something that can make them suspicious of you in your inventory.Check inventory entering [i] If you still ant to call the police you can try again");
                            insist = true;
                        }
                        else if (Game.PlayerClean == false)
                        {
                            Console.WriteLine(@"Are you sure you want to call the police, You have blood in your face maybe you can clean in the bathroom. If you still want to call try again");
                            insist = true;
                        }
                        else
                        {
                            Console.WriteLine("When you decide to call the police and they arrive, you head to the front door to greet and talk to them, your heart pounding with a mixture of anxiety and relief. You hope desperately that they won't find you guilty of any wrongdoing.");
                            Game.Callpolice = true;
                            Game.gameScript = 7;
                            Console.WriteLine(@"When the police have arrived, the atmosphere in the room is tense and charged with anxiety. You stand near the front door, your heart racing as you prepare to face them. The weight of the recent events hangs heavily on your shoulders as you hope desperately that they won't find you guilty.");
                            Console.WriteLine(@"You tell your story tearfully, recounting how you found him on the floor when you returned from the grocery. There's a lot of whispering and questioning from the detectives, but they treat you kindly. You explain everything again, from Patrick being tired to you going to the grocer for vegetables.

“One of the detectives asked which grocer,” you answer, and the other detective leaves to investigate. He returns with notes, and there's more whispering. Amidst your sobbing, you catch fragments of their conversation — ""...acted quite normal...very cheerful...wanted to give him a good supper...peas...cheesecake...impossible that she...""
*While talking to them you put the things you were carrying down");
                            Game.Transition<LivingRoom>();
                        }
                        break;
                    case "sink":
                        if (dishesClean == false)
                        {
                            Console.WriteLine("You approach the sink and start washing dishes.");
                            dishesClean = true;
                        }
                        else
                        {
                            Console.WriteLine("There are no dishes that require cleaning.");
                        }
                        break;
                    case "freezer":
                        Console.WriteLine("Upon checking the freezer, you discover that there is meat, but no ice cream.");
                        break;
                    case "fridge":
                        Console.WriteLine("When you open the fridge, you find that there are no fresh vegetables.");
                        break;
                    case "oven":
                        if (Game.inventory.Contains("Marinated Leg Lamb"))
                        {
                            Game.RemoveInventory("Marinated Leg Lamb");
                            Console.WriteLine(@"You put the leg of lamb in the oven, now no one will find the murder weapon, like alibi you could go buy vegetables and say you found your husband in the state that’s in the living room");
                            Game.lambLegOven = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                    case "marinate":
                        if (Game.inventory.Contains("Lamb Leg with blood"))
                        {
                            Game.RemoveInventory("Lamb Leg with blood");
                            Game.AddInventory("Marinated Leg Lamb");
                            Console.WriteLine("You have marinated the leg of lamb now you can put it in the oven");
                        }
                        else
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                    case "examine":
                        if (Game.inventory.Contains("knife"))
                        {
                            Console.WriteLine(@"Upon inspecting the kitchen counter, you decide to store the knife in one of the drawers with other kitchen appliances to prevent it from protruding among the visible items in the kitchen.");
                            Game.RemoveInventory("knife");
                            Game.cleanKill=true;
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (Game.gameScript <= 7)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "save":
                        GameSaveSystem.SaveGame(Game.filePath);
                        Start.IsStartMenu = true;
                        Game.Transition<Start>();
                        break;
                    case "living room":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        Game.DecraseSanity();
                        break;
                    case "phone":
                        Console.WriteLine("");
                        Game.DecraseSanity();
                        break;
                    case "sink":
                        if (dishesClean == false)
                        {
                            Console.WriteLine("You approach the sink and start washing dishes.");
                            dishesClean = true;
                            Game.IncreaseSanity();
                        }
                        else
                        {
                            Console.WriteLine("There are no dishes that require cleaning.");
                            Game.DecraseSanity();
                        }
                        break;
                    case "freezer":
                        Console.WriteLine("This doesn't make sense at this moment, at rise suspicious to the Police officers");
                        break;
                    case "fridge":
                        Console.WriteLine("This doesn't make sense at this moment, at rise suspicious to the Police officers");
                        break;
                    case "oven":
                        if (Game.inventory.Contains("Marinated Leg Lamb"))
                        {
                            Game.RemoveInventory("Marinated Leg Lamb");
                            Console.WriteLine(@"You put the leg of lamb in the oven, now no one will find the murder weapon, like alibi you could go buy vegetables and say you found your husband in the state that’s in the living room");
                            Game.lambLegOven = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                    case "marinate":
                        if (Game.inventory.Contains("Lamb Leg with blood"))
                        {
                            Game.RemoveInventory("Lamb Leg with blood");
                            Game.AddInventory("Marinated Leg Lamb");
                            Console.WriteLine("You have marinated the leg of lamb now you can put it in the oven");
                        }
                        else
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        if (Game.gameScript <= 8 && Game.lambLegOven == true)
                        {
                            Console.WriteLine(@"Feeding the cops the leg of lamb will allow you to completely misfire the gun, making it impossible for anyone to suspect. ");
                            Game.AddInventory("Cooked Lamb Leg");
                        }
                        break;
                    case "talk":
                        if (Game.inventory.Contains("Cooked Lamb Leg"))
                        {
                            Console.WriteLine(@"""Would you do me and these others a small favor?"" Mrs.Maloney asked.
""We can try,"" Sergeant Noonan replied.
Mrs.Maloney urged them to eat the lamb in the oven, insisting it was cooked perfectly and that it would be a favor to her.
The policemen hesitated but eventually gave in to their hunger and went to the kitchen to eat.Mrs.Maloney stayed behind, 
listening to their voices as they spoke with their mouths full.");
                            PoliceOfficer officer1 = new PoliceOfficer("Carlos", "Detective", 10);
                            PoliceOfficer officer2 = new PoliceOfficer("Laura", "Inspector", 7);
                            officer1.CommentOnLegOfLamb();
                            officer2.CommentOnLegOfLamb();
                            Game.Transition<GoodEnding>();
                        }
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
                        Start.IsStartMenu = true;
                        Game.Transition<Start>();
                        break;
                    case "living room":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "phone":
                        Console.WriteLine("You decide to call someone");
                        RamdomCall();
                        break;
                    case "sink":
                        if (dishesClean == false)
                        {
                            Console.WriteLine("You approach the sink and start washing dishes.");
                            dishesClean = true;
                        }
                        else
                        {
                            Console.WriteLine("There are no dishes that require cleaning.");
                        }
                        break;
                    case "freezer":
                        Console.WriteLine("Upon checking the freezer, you discover that there is meat, but no ice cream.");
                        break;
                    case "fridge":
                        Console.WriteLine("When you open the fridge, you find that there are no fresh vegetables.");
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
        internal void RamdomCall()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 11);
            if (randomNumber == 1)
            {
                Console.WriteLine(@"-Hello, this is Mrs. Maloney. Could I please place an order for delivery?
-I need some bread. Can you tell me if you have any fresh croissants available today?
-No, sorry, we've run out of croissants. If you want fresh ones, we can make a delivery tomorrow morning. Is that okay for you?
-Yes, I would love that.
*You have made an order for fresh croissants. They are going to arrive tomorrow at 10.
");
            }
            else if (randomNumber == 2)
            {
                Console.WriteLine(@"*You Called a Friend
Hi, Betty! It's Mary. How are you today? I thought we could catch up. How's the family? 
Would you like to join me for coffee on Friday?
*Your friend is going to visit you on Friday");
            }
            else if (randomNumber == 3)
            {
                Console.WriteLine(@"Hello, Mom. It's Helen.
How are you? Patrick is doing well. 
We had a nice time at dinner last week. 
Do you have any tips for a roast beef recipe? 
You talked with your mom for an hour");
                if (Game.gameScript == 0) { Game.gameScript = 1; }
            }
            else if (randomNumber == 4)
            {
                Console.WriteLine(@"Hi, Jane! It's Mary. 
Just wanted to say hello and see how you and the family are doing. 
Are you still planning to come over for tea on Saturday?");
            }
            else if (randomNumber == 5)
            {
                Console.WriteLine(@"*You called your Doctor
Hello, this is Mary Maloney.
I have a quick question about my prescription. 
Could I stop by to discuss it this week?
*You made an appointment for Thursday.");
            }
            else if (randomNumber == 6)
            {
                Console.WriteLine(@"*You Called the Dry Cleaners
Hello, this is Mrs. Maloney. I'm calling to check if my dress is ready for pick-up.");
                Console.WriteLine("Yes, Mrs. Maloney, your dress is ready. You can pick it up anytime during our business hours.");
                Console.WriteLine("Thank you, I will be there tomorrow");
            }
            else if (randomNumber == 7)
            {
                Console.WriteLine(@"*You Called the Library
Hi, I was wondering if you have the latest Stephen King novel available?");
                Console.WriteLine("Yes, we have it in stock. You can come and pick it up anytime.");
                Console.WriteLine("Thank you, I will be there tomorrow");
            }
            else if (randomNumber == 8)
            {
                Console.WriteLine(@"*You Called the Hair Salon
Hello, I need to schedule an appointment for a haircut.");
                Console.WriteLine("Sure, we have availability tomorrow afternoon. What time works for you?");
                Console.WriteLine("Thank you, I will be there tomorrow around 3 p.m.");
                
            }
            else if (randomNumber == 9)
            {
                Console.WriteLine(@"*You Called the Pet Store
Hi, I'm looking for a specific type of cat food for a fiend. Do you have it in stock?");
                Console.WriteLine("Yes, we have it available. You can come and pick it up whenever you'd like.");
                Console.WriteLine("Thank you, I will be there tomorrow");
            }
            else
            {
                Console.WriteLine(@"*You Called the Hardware Store
Hello, do you have the paint I ordered last week ready for pick-up?");
                Console.WriteLine("Yes, your paint is ready. You can pick it up at the front desk.");
                Console.WriteLine("Thank you, I will be there tomorrow");
            }
            Game.sanity += 5;
            Console.WriteLine("*At the end of the call you hung up the phone");
        }

    }
}
