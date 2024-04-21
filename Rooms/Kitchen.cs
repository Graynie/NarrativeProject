using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {
        internal bool dishesClean = false;
        internal bool checkedFridge = false;
        internal bool checkedFreezer = false;
        internal bool insist = false;
        public bool LambOven;

        internal override string CreateDescription()
        {
            if (Game.gameScript == 0)
            {
                return @"You are in the Kitchen. 
You can check the [fridge] for vegetables,
check the [freezer] for meat or ice cream,
approach the [sink] to wash dishes, or go back to the [living room].";
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
or go back to the [living room].";
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
- [call] the police";
                }
                else if (Game.inventory.Contains("Marinated Leg Lamb"))
                {
                    return @" While in the kitchen : You consider your next move. What will you do?

- [think] carefully: Take a moment to process your actions and consider your options.
- [examine] your surroundings: Look around the kitchen, assessing what needs to be addressed to avoid suspicion.
- prepare an [alibi]: Begin to construct a story to account for your whereabouts and actions, creating a plausible cover for the events that transpired.
- Put the Lamb Leg in the [oven]
- [call] the police";
                }
                else
                {

                    return @" While in the kitchen : You consider your next move. What will you do?

- [think] carefully: Take a moment to process your actions and consider your options.
- [examine] your surroundings: Look around the kitchen, assessing what needs to be addressed to avoid suspicion.
- prepare an [alibi]: Begin to construct a story to account for your whereabouts and actions, creating a plausible cover for the events that transpired.
- [call] the police
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
            if (Game.gameScript == 0 || Game.gameScript == 1 || Game.gameScript == 2 || Game.gameScript == 3 || Game.gameScript == 4) {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
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
            else if(Game.gameScript == 5) {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
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
                    case "living room":
                        Console.WriteLine("You decide to go back to the living room.");
                        Game.Transition<LivingRoom>();
                        break;
                    case "phone":
                        if (insist = true)
                        {
                            Console.WriteLine(@"As you dial the emergency number, your hands tremble with nervousness and fear. You know the police need to be called, but the sight of the bloodied weapon still in your hands fills you with dread. Knowing they will notice you are the one who killed Patrick");
                            Game.Transition<BadEndingTwo>();
                        }
                        else if (Game.inventory.Contains("stained knife") || Game.inventory.Contains("stained knife") || Game.inventory.Contains("Not Marinated Lamb leg"))
                        {
                            Console.WriteLine(@"Are you sure you want to call the police, You have something that can make them suspicious of you in your inventory.Check inventory entering [i] If you still ant to call the police you can try again");
                            insist = true;
                        }
                        else if (Game.PlayerClean == false)
                        {
                            Console.WriteLine(@"Are you sure you want to call the police, You have blood iin your face maybe you can clean in the bathroom");
                        }
                        else
                        {
                            Console.WriteLine("When you decide to call the police and they arrive, you head to the front door to greet and talk to them, your heart pounding with a mixture of anxiety and relief. You hope desperately that they won't find you guilty of any wrongdoing.");
                            Game.Callpolice = true;
                            Game.gameScript = 7;
                            Console.WriteLine(@"When the police have arrived, the atmosphere in the room is tense and charged with anxiety. You stand near the front door, your heart racing as you prepare to face them. The weight of the recent events hangs heavily on your shoulders as you hope desperately that they won't find you guilty.");
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
            else { }
            }

        

        internal void RamdomCall()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 11);
            if (randomNumber == 1)
            {
                Console.WriteLine(@"-Hello, this is Mrs. Maloney. Could I please place an order for delivery?
-I need some bread. Can you tell me if you have any fresh 
croisants available today?
-No, sorry, we run out of croisants. If you want fresh ones we can make a delivery tomorrow morning, It's it okay for you?
-Yes, I would love that.
*You had made an order for fresh croisants they are gonna arrive tomorrow at 10.
");
            }
            else if (randomNumber == 2)
            {
                Console.WriteLine(@"*You Called a Friend
Hi, Betty! It's Mary. How are you today? I thought we could catch up. How's the family? 
Would you like to join me for coffee on Friday?
*Your friend is gonna visit you on Friday");
            }
            else if (randomNumber == 3)
            {
                Console.WriteLine(@"Hello, Mom. It's Helen.
How are you? Patrick is doing well. 
We had a nice time at the dinner last week. 
Do you have any tips for a roast beef recipe? 
You talked with your mom for an hour");
                Game.timeHour = 5;
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
                Console.WriteLine(@"");
            }
            else if (randomNumber == 7)
            {
                Console.WriteLine(@"");
            }
            else if (randomNumber == 8)
            {
                Console.WriteLine(@"");
            }
            else if (randomNumber == 9)
            {
                Console.WriteLine(@"");
            }
            else
            {
                Console.WriteLine(@"");
            }
        }
    }
}
