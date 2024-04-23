using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Grocery : Room
    {
        internal int storeSus = 0;
        internal int storeSteps = 0;
        internal bool ask = false;
        internal bool option = false;
        internal bool finishStore=false;

        internal override string CreateDescription()
        {

            if (Game.gameScript == 5)
            {
                if (storeSteps == 0)
                {
                    return @"You are in the grocery store, you get along with the shopkeeper ""Sam"".
- You can go back to your [home] if you have changed your mind about buying something to make dinner for your husband.
- You can [buy] the vegetables for dinner
- Or [ask] Sam for advice.";
                }
                else if (storeSteps == 1)
                {
                    return @"You are in the grocery store, you get along with the shopkeeper ""Sam"".
- You can go back to your [home] 
- You can ask what you should buy for [dessert]
- Or [ask] Sam for advice.";
                }
                else if (storeSteps == 2)
                {
                    return @"You are in the grocery store.
- You can go back to your [home] 
- [Ask] for advice";
                }
                else
                {
                    return @"You are in the grocery store.
- You can go back to your [home] ";
                }
            }
            else if (Game.gameScript == 6)
            {
                if (storeSteps == 0)
                {
                    return @"You are in the grocery store, you get along with the shopkeeper ""Sam"", but you have to make sure he is not suspicious of what you did.
- You can go back to your [home] 
- You can [buy] the vegetables for dinner, to convince him that everything is alrigth";
                }
                else if (storeSteps == 1)
                {
                    if (option)
                    {
                        return @"Sam: “Hi, good evening, Mrs. Maloney.How’re you?”
                        [1]: Tell Sam that you need to buy vegetables, because patrick is not feeling well.
                        [2]: Tell Sam what you need potatoes and peas.
";
                    }
                    else
                    {
                        return @"Sam: “Hi, Mrs. Maloney. Is everything okay? You seem a bit off.”
                        [1]: Tell Sam that you need to buy vegetables, because patrick is not feeling well.
                        [2]: Tell Sam what you need potatoes and peas.";
                    }
                }
                else if (storeSteps == 2)
                {
                    if (option)
                    {
                        return @"The man turned and reached up behind him on the shelf for the peas.
                        [1]: Tell Sam that Patrick wasn't feeling well
                        [2]: Tell Sam that Patrick decide to eat at home
";
                    }
                    else
                    {
                        return @"Sam hesitated, his eyes narrowing slightly at your hurried request.
                        [1]: Tell Sam that Patrick wasn't feeling well
                        [2]: Tell Sam that Patrick decide to eat at home
";
                    }
                }
                else if (storeSteps == 3)
                {
                    if (option)
                    {
                        return @"“Then how about meat, Mrs. Maloney?”
                        [1]: Tell him you already have everything you need
                        [2]: Tell him you have a leg of lamb
";
                    }
                    else
                    {
                        return @"Sam's eyebrows furrowed slightly. ""Is Patrick okay? It's unusual for you two to miss your Thursday night dinner."", Anyway Do you need meat too?
                        [1]: Tell him you already have everything you need
                        [2]: Tell him you have a leg of lamb
";
                    }
                }
                else if (storeSteps == 4)
                {
                    if (option)
                    {
                        return @"“Oh.”
                        [1]: Tell Sam you don't know how to cook frozen meat
                        [2]: Tell Sam you will try to cook frozen meat
";
                    }
                    else
                    {
                        return @"Sam’s expression tightened slightly. “Okay,” he said, clearly feeling uneasy.
                        [1]: Tell Sam you don't know how to cook frozen meat
                        [2]: Tell Sam you will try to cook frozen meat
";
                    }
                }
                else if (storeSteps == 5)
                {
                    if (option)
                    {
                        return @"“Personally, I don’t believe it makes any difference. 
                        [1]: Say yes
                        [2]: Agree with Sam
";
                    }
                    else
                    {
                        return @"Sam's gaze lingered on you for a moment before he nodded. ""Sure, Mrs. Maloney.You want these Idaho potatoes?""
                        [1]: Say yes
                        [2]: Agree with Sam
";
                    }
                    }
                else if (storeSteps == 6)
                {
                    if (option)
                    {
                        return @"“Sam: Mrs. Do you need anything else?”
                        [1]: Tell him to give you a suggestion 
                        [2]: Ask for a suggestion to make Patrick happier
";
                    }
                    else
                    {
                        return @"Sam: ""Anything else?"" while lloking at your expression he raised an eyebrow. “You seem a bit flustered, Mrs. Maloney. Maybe you need a moment to think?”
                        [1]: Tell him to give you a suggestion 
                        [2]: Ask for a suggestion to make Patrick happier
";
                    }
                }
                else if (storeSteps == 7)
                {
                    if (option)
                    {
                        return @"The man glanced around his shop. “How about a nice big slice of cheesecake? I know he likes that.”
                        [1]: Buy two chesscakes
                        [2]: Accept his advice
";
                    }
                    else
                    {
                        return @"With a weird expression Sam glanced around his shop. “How about a nice big slice of cheesecake? I know he likes that.”
                        [1]: Buy two chesscakes
                        [2]: Accept his advice
";
                    }
                }
                else if (storeSteps == 8)
                {
                    if (option)
                    {
                        return @"And when it was all wrapped and you had paid, you put on your brightest smile and said, “Thank you, Sam. Goodnight.”
                        You can go back [home], hoping he didn't got suspicious of your actions
";
                    }
                    else
                    {
                        return @"Sam watched her leave, his suspicion growing with every step she took.
                        You can go back [home], hoping he didn't got suspicious of your actions
";
                    }
                }
                else
                {
                    return @"You are in the grocery store.
- You can go back to your [home] ";
                }
            }
            else
            {
                    return @"You are in the grocery store.
- You can go back to your [home] ";

            }
        }

        internal override void ReceiveChoice(string choice)
        {
            if (Game.sanity < 34)
                {
                    storeSus += 3;
                }
            if (Game.gameScript == 5)
            {
                if (storeSteps == 0)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine("You decided to go back home without buying nothing");
                            Game.Transition<BadEnding>();
                            break;
                        case "buy":
                            Console.WriteLine(@"""Hi, Sam,"" you greeted, your smile forced but bright, scanning the shelves.
""I need potatoes and a can of peas,"" you rushed.
Sam nodded, grabbing the peas. ""Patrick decided we're not eating out tonight,"" she explained quickly. ""I'm stuck without any vegetables.""");
                            Game.AddInventory("potatoes");
                            Game.AddInventory("can of peas");
                            storeSteps++;
                            break;
                        case "ask":
                            Ask();
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (storeSteps == 1)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine("You decided to go back home without buying nothing more");
                            Game.Transition<BadEnding>();
                            break;
                        case "dessert":
                            Console.WriteLine(@"Sam suggested cheesecake for dessert.
""""Perfect,"""" she agreed hastily, trying to keep her tone light.
After paying and wrapping everything up, she plastered on her brightest smile. """"Thank you, Sam. Goodnight.""");
                            storeSteps++;
                            Game.AddInventory("chesscake");
                            break;
                        case "ask":
                            Ask();
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (storeSteps == 2)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine("You decided to go back home without buying nothing more");
                            Game.Transition<BadEnding>();
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        case "ask":
                            Ask();
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
                        case "home":
                            Console.WriteLine("You decided to go back home without buying nothing more");
                            Game.Transition<BadEnding>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
            }
            else if (Game.gameScript == 6)
            {
                if (storeSteps == 0)
                    {
                        switch (choice)
                        {
                            case "home":
                                Console.WriteLine(@"You decided to go back home without an alibi, your actions made Sam suspicious. Your expression make him become worried for your security, and since he knows your husband is police office he decided to call his precint. An officer arrives at the same time as you");
                                Game.Transition<BadEndingTwo>();
                                break;
                            case "buy":
                            if (!Game.practice)
                            {
                                Console.WriteLine(@"""Hi, Sam,"" she said with a forced smile, avoiding eye contact.");
                                storeSus++;
                                option = false;
                            }
                            else
                            {
                                Console.WriteLine(@"""Hullo Sam"" she said brightly, smiling at the man behind the counter.");
                                storeSus--;
                                option=true;
                            }
                            storeSteps++;
                                break;
                            case "i":
                                Game.DisplayInventory();
                                break;
                            case "save":
                                GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                                break;
                            default:
                                Console.WriteLine("Invalid command.");
                                break;
                        }
                    }
                else if (storeSteps == 1)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine(@"You decided to go back home in a weird moment, your actions made Sam suspicious. Your expression make him become worried for your security, and since he knows your husband is police office he decided to call his precint. An officer arrives at the same time as you");
                            Game.Transition<BadEndingTwo>();
                            break;
                        case "2":
                            Console.WriteLine(@"""I need some potatoes and peas, Sam. Patrick’s not feeling well, so we're staying in tonight.""");
                            storeSus++;
                            storeSteps++;
                            break;
                        case "1":
                            
                            Console.WriteLine(@"“I want some potatoes please, Sam. Yes, and I think a can of peas.”");
                            storeSus--;
                            storeSteps++;
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (storeSteps == 2)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine(@"You decided to go back home in a weird moment, your actions made Sam suspicious. Your expression make him become worried for your security, and since he knows your husband is police office he decided to call his precint. An officer arrives at the same time as you");
                            Game.Transition<BadEndingTwo>();
                            break;

                        case "1"://bad
                            Console.WriteLine(@"“Patrick’s not feeling well,” she said quickly, avoiding eye contact. “I need to cook at home tonight.”");
                            storeSus++;
                            option = false;
                            break;

                        case "2"://good
                            Console.WriteLine(@"“Patrick’s decided he’s tired and doesn’t want to eat out tonight,” she told him. “We usually go out Thursdays, you know, and now he’s caught me without any vegetables in the house.”");
                            storeSus--;
                            option = true;
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (storeSteps == 3)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine(@"You decided to go back home in a weird moment, your actions made Sam suspicious. Your expression make him become worried for your security, and since he knows your husband is police office he decided to call his precint. An officer arrives at the same time as you");
                            Game.Transition<BadEndingTwo>();
                            break;

                        case "1"://bad
                            Console.WriteLine(@"“No, thanks. I already have everything I need,” she replied, her tone slightly defensive.");
                            storeSus++;
                            option = false;
                            break;

                        case "2"://good
                            Console.WriteLine(@"“No, I’ve got meat, thanks. I got a nice leg of lamb from the freezer.”");
                            storeSus--;
                            option = true;
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (storeSteps == 4)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine(@"You decided to go back home in a weird moment, your actions made Sam suspicious. Your expression make him become worried for your security, and since he knows your husband is police office he decided to call his precint. An officer arrives at the same time as you");
                            Game.Transition<BadEndingTwo>();
                            break;

                        case "2"://Good
                            Console.WriteLine(@"“I don’t much like cooking it frozen, Sam, but I’m taking a chance on it this time. You think it’ll be all right?”");
                            storeSus--;
                            option = true;
                            break;

                        case "1"://bad
                            Console.WriteLine(@"“I hope it turns out okay. I've never cooked frozen meat before,” she said nervously.");
                            storeSus++;
                            option = false;
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (storeSteps == 5)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine(@"You decided to go back home in a weird moment, your actions made Sam suspicious. Your expression make him become worried for your security, and since he knows your husband is police office he decided to call his precint. An officer arrives at the same time as you");
                            Game.Transition<BadEndingTwo>();
                            break;

                        case "2"://Good
                            Console.WriteLine(@"“Oh yes, that’ll be fine.”");
                            storeSus--;
                            option = true;
                            break;

                        case "1"://bad
                            Console.WriteLine(@"“Yes, that’s fine,” she said quickly, her voice slightly shaky.");
                            storeSus++;
                            option = false;
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (storeSteps == 6)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine(@"You decided to go back home in a weird moment, your actions made Sam suspicious. Your expression make him become worried for your security, and since he knows your husband is police office he decided to call his precint. An officer arrives at the same time as you");
                            Game.Transition<BadEndingTwo>();
                            break;

                        case "1"://bad
                            Console.WriteLine(@"Well — what would you suggest, Sam?”");
                            storeSus++;
                            break;

                        case "2"://good
                            Console.WriteLine(@"Can you suggest something that will make him happy?");
                            storeSus--;
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (storeSteps == 7)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine(@"You decided to go back home in a weird moment, your actions made Sam suspicious. Your expression make him become worried for your security, and since he knows your husband is police office he decided to call his precint. An officer arrives at the same time as you");
                            Game.Transition<BadEndingTwo>();
                            break;

                        case "1"://Good
                            Console.WriteLine(@"“Oh yes, that’ll be fine. Two of those.”");
                            storeSus--;
                            break;

                        case "2"://bad
                            Console.WriteLine(@"“Yes, that’s fine,” she said quickly, your voice slightly shaky.");
                            storeSus++;
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (storeSteps == 8)
                {
                    switch (choice)
                    {
                        case "home":
                            Console.WriteLine(@"You decided to go back home");
                            if (storeSus > 6 && finishStore)
                            {
                                Console.WriteLine(@"As you return home Sam calls the police your actions made him suspicious that something was off .
When you arrived home the police was already there.
");
                                Game.sanity -= 40;
                                Game.Transition<BadEndingTwo>();
                            }
                            else
                            {
                                Console.WriteLine("It seem that Sam didn't notice nothing, now your interaction with him is your alibi");
                                Game.sanity += 40;
                                Game.gameScript = 7;
                                Game.sucessStore = true;
                                Game.Transition<LivingRoom>();
                            }
                            break;
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "save":
                            GameSaveSystem.SaveGame(Game.filePath);
                            Start.IsStartMenu = true;
                            Game.Transition<Start>();
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
                        case "error":
                            Game.Transition<Start>();
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                
            }
        }
        internal void Ask()
        {
            if (ask == false)
            {
                Console.WriteLine(@"""Hi, Sam,"" she greeted, her smile strained.
""Hey, Mrs. Maloney. What can I do for you?"" Sam asked.
""I... Patrick's leaving me,"" she blurted out, her voice trembling.
Sam's expression softened with concern. ""I'm so sorry to hear that. What happened?""
""He told me tonight,"" she sighed. ""I just need... I don't know what to do.""
Sam leaned in slightly. ""Do you want to talk about it?""
""I do, but I don't know where to start,"" she admitted, feeling overwhelmed. ""I will just make him dinner. I don't even know if he'll eat it.""
""Maybe he just needs some space,"" Sam suggested gently. ""You could try talking to him calmly when he's ready to listen.""
She nodded, grateful for the advice. ""Thanks, Sam. I'll try that.""");
                ask = true;
            }
            else
            {
                Console.WriteLine("You have already asked for his advice");
            }
        }
        }

    }

