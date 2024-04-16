using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {

        internal override string CreateDescription()
        {
            return @"In your kitchen, the [oven] is empty and clean.
Call someone with the [phone].
Check the [fridge]
You can return to your [Living] room.";
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "Fridge":
                    Console.WriteLine("Frizzing");
                    break;
                case "Phone":
                    if (Game.husbandDead == false) { }
                    else { 
                    Console.WriteLine("Call your mom or the police");
                        switch(choice)
                        {
                            case "friend":
                                Console.WriteLine();
                                break;
                            case "mom":
                                Console.WriteLine();
                                break;
                            default:
                                Console.WriteLine();
                            break;
                        }
                    }
                    break;
                case "oven":
                    Console.WriteLine("Ovening, haha , no, joke, XD");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;

            }
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
