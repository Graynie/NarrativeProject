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
        internal bool insist = false;
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
You can sit on your [chair], sit on your husband's [sofa],
aproach the [drinks] car, aproach the [fireplace], go 
outtside to the [Grocery] store, or go to one of the other 
rooms: [closet], [kitchen], [bathroom], [bedroom]";
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
                if (sittingOnChair)
                {
                    return @"You can continue and [ignore] him, or [stand] up";
                }
                else
                {
                    return @"You can try talking with your [husband], prepare a
[drink] for him, lit the [fireplace], or go to another room: 
[kitchen], [bathroom], [bedroom], or sit in your [chair] ";
                }
            }
            else if (Game.gameScript == 3)
            {
                return @"[continue]";
            }
            else if (Game.gameScript == 4)
            {
                return @"[continued]";
            }
            else if (Game.gameScript == 5)
            {
                if (sittingOnChair) 
                {
                    return @"""You are seated in the living room.
Patrick is standing over by the window with his back to you.
- [talk] to your husband from your seat
- [observe] your husband's actions from your seat
- [look] around the living room from your seat
- get [up] and move around the room
- approach the [drinks] cart (if you're feeling bold)
- [adjust] your seating position for comfort
- [think] about your next move";
                }
                else
                {
                    return @"Patrick is standing over by the window with his back to you
You can [aproach] your husband, sit in your [chair], sit on
your husbands [sofa], aproach the [drinks] 
car, aproach the [fireplace],go outside to
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
                            Console.WriteLine("You can't drink alcoholic drinks");
                            break;
                        case "closet":
                            Console.WriteLine("You are looking at the closed, it is a little messy");
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
                            sittingOnChair = true;
                            break;
                        case "grocery":
                            Console.WriteLine("You don't seem to need anything from the store");
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
                            Game.HusbandTemperament -= 20;
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                else if (sittingOnChair == false)
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
                            Console.WriteLine(@"This time of day is always a blissful time for you. 
You know he doesn’t want to speak much right after arriving home from work.
You are content to sit quietly and enjoy his company after spending long 
hours alone in the house. Occasionally, you both enjoy a drink.");
                            break;
                        case "bedroom":
                            Console.WriteLine("You walked to the bedroom,Your husband probably feels ignored");
                            Game.gameScript = 2;
                            Console.WriteLine(@"This time of day is always a blissful time for you. 
But today you seam to be ignoring him, probably beacause
You know he doesn’t want to speak much right after arriving home from work.
Normally you are content to sit quietly and enjoy his company after spending long 
hours alone in the house. Occasionally, you both enjoy a drink.");
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
                            Console.WriteLine(@"This time of day is always a blissful time for you. 
But today you seam to be ignoring him, probably beacause
You know he doesn’t want to speak much right after arriving home from work.
Normally you are content to sit quietly and enjoy his company after spending long 
hours alone in the house. Occasionally, you both enjoy a drink.");
                            break;
                        case "closet":
                            Console.WriteLine(@"Your husband looks weirdly at you, but 
continuing his way and sitting on his sofa
*You are looking at the closed it is a little dirty");
                            Game.HusbandTemperament += 5;
                            Game.gameScript = 2;
                            Console.WriteLine(@"This time of day is always a blissful time for you. 
But today you seam to be ignoring him, probably beacause
You know he doesn’t want to speak much right after arriving home from work.
Normally you are content to sit quietly and enjoy his company after spending long 
hours alone in the house. Occasionally, you both enjoy a drink.");
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
                {
                    switch (choice)
                    {
                        case "i":
                            Game.DisplayInventory();
                            break;

                        case "ignore":
                            Console.WriteLine(@"Your husband has an odd look on his face, but ultimately chooses to unwind on his sofa. Despite his hesitation, it appears he has something to say to you.");
                            Game.gameScript = 3;
                            Console.WriteLine(@"""If you’re too tired to eat out"""", You said to him,"""" it’s still not too late.
There’s plenty of meat and other things in the freezer, 
so you can stay right here and not even have to leave the chair.""""
You watched him, waiting for him to respond with a smile or a nod, but he didn't show any reaction.
""""Anyway,"""" you continued, """"I'll get you some cheese and crackers to start.""""
""""I don't want it,"""" he replied.");
                            Game.HusbandTemperament -= 10;
                            break;
                        case "stand":
                            Console.WriteLine();
                            sittingOnChair = false;
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
                                    Console.WriteLine(@"""If you’re too tired to eat out"""", You said to him,"""" it’s still not too late.
There’s plenty of meat and other things in the freezer, 
so you can stay right here and not even have to leave the chair.""""
You watched him, waiting for him to respond with a smile or a nod, but he didn't show any reaction.
""""Anyway,"""" you continued, """"I'll get you some cheese and crackers to start.""""
""""I don't want it,"""" he replied.");
                                }
                            }
                            break;
                        case "drink":
                            Console.WriteLine("You have made a drink for you husband. This time it is a" + RandomDrink());
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
                                Console.WriteLine(@"""If you’re too tired to eat out"""", You said to him,"""" it’s still not too late.
There’s plenty of meat and other things in the freezer, 
so you can stay right here and not even have to leave the chair.""""
You watched him, waiting for him to respond with a smile or a nod, but he didn't show any reaction.
""""Anyway,"""" you continued, """"I'll get you some cheese and crackers to start.""""
""""I don't want it,"""" he replied.");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
            }
            else if (Game.gameScript == 3)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "continue":
                        Game.gameScript = 4;
                        Console.WriteLine(@"You start to feel frightened when he tells you to sit down. You sit back slowly, watching him with large, confused eyes. 
""""Listen,"""" he says. """"I need to tell you something.""""
""""What is it, darling? What's wrong?"""" you ask.
He stays still.
""""This will be a shock,"""" he continues. """"But I've thought a lot about it and decided I must tell you now. I hope you don't blame me too much.""""
He tells you quickly, in four or five minutes. You sit very still, watching him with a sense of dazed horror as his words distance him from you.
""""So there it is,"""" he adds. """"I know this is a bad time to tell you, but I had no choice. I'll give you money and make sure you're taken care of. Please,
let's keep this quiet for my job's sake.""""[continue]");
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (Game.gameScript == 4)
            {
                switch (choice)
                {
                    case "i":
                        Game.DisplayInventory();
                        break;
                    case "continue":
                        Game.gameScript = 5;
                        Console.WriteLine(@"Your first instinct is to disbelieve everything he said, to reject it all.
You wonder if he even spoke or if you imagined it all. 
Maybe if you just carry on as if you hadn't heard anything, you might wake up later to find it never happened.
""I'll get supper,"" you whisper, and this time, he doesn't stop you.");
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            else if (Game.gameScript == 5)
            {
                if (sittingOnChair)
                {
                    switch (choice)
                    {
                        case "i":
                            Game.DisplayInventory();
                            break;
                        case "talk":
                            Console.WriteLine(@"You try to speak to Patrick,
but he remains distant and unresponsive. 
His decision seems final, and you struggle 
to find words to bridge the gap between you.
His gaze remains fixed on the window, 
a clear sign that he does not want to engage 
in conversation.");
                            Game.sanity -= 5;
                            break;
                        case "observe":
                            Console.WriteLine(@"You watch Patrick closely, 
trying to gauge his mood and intentions. 
His posture is tense, and his expression 
is a mix of determination and detachment. 
It's clear he has made up his mind, 
leaving you feeling uncertain about what 
to do next.");
                            Game.sanity -= 5;
                            break;
                        case "look":
                            Console.WriteLine(@"You take a moment to look around the
living room, searching for anything that might
offer comfort or clarity. The room seems familiar
yet alien, reflecting the sudden upheaval in your
life. You notice the usual objects—fireplace, 
drinks cart—but they provide little solace in 
this moment.");
                            Game.sanity -= 3;
                            break;
                        case "up":
                            Console.WriteLine(@"You stand up and begin to pace the room, 
trying to clear your mind. Patrick doesn't acknowledge your movements,
as if he's already disconnected himself emotionally.
You sense a widening chasm between you as you
consider your next move.");
                            sittingOnChair = false;
                            break;
                        case "adjust":
                            Console.WriteLine(@"You shift in your seat, 
attempting to find some physical comfort in the midst
of emotional turmoil. The silence in the room is almost
unbearable, punctuated only by the sound of your own breathing.
You know you must make a decision soon.");
                            Game.sanity += 3;
                            break;
                        case "think":
                            Console.WriteLine(@"You take a moment to gather your thoughts,
trying to process the situation.
Patrick's declaration has thrown you off balance,
but you know you must consider your next steps carefully.
Your mind races as you weigh the possible outcomes and repercussions.");
                            Game.sanity += 5;
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
                        case "aproach":
                            if (Game.inventory.Contains("Lamb leg"))
                            {
                                Console.WriteLine(@"You quietly rise from your seat, weapon in hand, 
and approach Patrick from behind.
He remains focused on the view outside the window,
unaware of your actions. As you get closer,
your heart races with a mix of fear and determination.
Before Patrick can sense your presence,
you strike him with the weapon. He collapses immediately,
his body falling to the floor with a heavy thud.
The room is suddenly filled with silence,
leaving you standing over him, weapon in hand.");
                                Game.cleanKill = true;
                                Game.husbandDead = true;
                                Game.gameScript = 6;
                            }
                            else if (Game.inventory.Contains(" basseball bat"))
                            {
                                Console.WriteLine(@"You move toward Patrick, holding the weapon firmly in your grip.
As you close the distance, he turns to face you,
his expression one of confusion and concern. 
Without a word, you raise the weapon and strike,
ending Patrick's life.");
                                Game.cleanKill = false;
                                Game.husbandDead = true;
                                Game.gameScript = 6;
                            }
                            else if (Game.inventory.Contains("Knife"))
                            {
                                Console.WriteLine(@"You quietly stand up, concealing the knife in your hand,
and move toward Patrick as he gazes out the window. 
He remains unaware of your approach. With a swift motion,
you strike Patrick from behind with the knife.
He gasps in shock but quickly falls to the floor,
blood spreading across his back. You stand over his lifeless body,
the knife in your hand. The room is eerily silent, 
and the gravity of your actions begins to sink in.
Your next decisions will shape your journey. 
Will you leave the scene as it is,
or will you try to clean up and dispose of the evidence?""");
                                Game.cleanKill = false;
                                Game.husbandDead = true;
                                Game.gameScript = 6;
                            }
                            else
                            {

                                if (insist == false)
                                {
                                    Console.WriteLine(@"You cautiously approach Patrick, 
trying to gauge his mood. 
His back remains turned to you, and he seems lost in his thoughts.
As you get closer, you feel a sense of tension between you,
unsure how he might react to your presence.
You decide is not a good idea to aproach him at this moment");
                                    insist = true;
                                }
                                else
                                {
                                    Console.WriteLine(@"“For God’s sake,” he said, but not turning round. “Don’t make supper for me. I’m going out”");
                                    Game.HusbandLeaves = true;
                                    Game.Transition<BadEnding>();
                                }
                            }
                            break;
                        case "closet":
                            Console.WriteLine(@"You head to the closet, a place of refuge and storage.
As you stand surrounded by clothes and boxes,
you feel a strange comfort in the familiarity.
But you know hiding away won't change the situation with Patrick.");
                            break;
                        case "kitchen":
                            Console.WriteLine(@"You walk to the kitchen, seeking solace in the heart of the home.
The smell of lingering meals brings back memories,
but the emptiness of the room echoes the uncertainty
of your future with Patrick.");
                            Game.sanity += 5;
                            Game.HusbandTemperament += 5;
                            Game.Transition<Kitchen>();
                            break;
                        case "bedroom":
                            Console.WriteLine(@"You go to the bedroom, a place that once symbolized intimacy and comfort.
Now, it feels tainted by the tension between you and Patrick.
As you sit on the bed, you ponder what your next move should be.");
                            Game.sanity += 5;
                            Game.HusbandTemperament += 5;
                            Game.Transition<Bedroom>();
                            break;
                        case "bathroom":
                            Console.WriteLine(@"You retreat to the bathroom, where you can be alone with your thoughts.
The quiet space gives you a chance to process the recent events,
but the reality of Patrick's decision still looms large in your mind.");
                            Game.sanity += 5;
                            Game.HusbandTemperament += 5;
                            Game.Transition<Bathroom>();
                            break;
                        case "grocery":
                            Console.WriteLine(@"You consider leaving the house and going to the grocery store.
The thought of escaping the tension at home is tempting,
but you know you can't avoid the situation forever.
Patrick remains by the window, seemingly unbothered
by your potential departure.");
                            Game.sanity += 15;
                            Game.HusbandTemperament += 15;
                            Game.Transition<Grocery>();
                            break;
                        case "fireplace":
                            if (fireplaceOn == true)
                            {
                                Console.WriteLine(@"You approach the fireplace, drawn to its warmth.
The fire offers a fleeting comfort, but it also serves as a reminder
of the life you had with Patrick, now on the verge of collapse.
You watch the flames dance, your mind racing with possibilities.");
                                Game.sanity += 5;
                            }
                            else
                            {
                                fireplace();
                            }
                            break;
                        case "drinks":
                            Console.WriteLine(@"You walk over to the drinks cart, searching for a distraction.
You pour yourself a drink, the sound of the liquid filling the glass
echoing in the tense silence of the room. Patrick doesn't react,
but you hope the drink will help steady your nerves.");
                            Game.sanity += 5;
                            Game.HusbandTemperament += 15;
                            break;
                        case "sofa":
                            Console.WriteLine(@"You decide to sit on your husband's sofa, seeking a connection 
to him through the shared space. The sofa feels cold and distant,
echoing the emotional divide that now exists between you. 
Patrick doesn't seem to notice or care.");
                            Game.sanity -= 5;
                            Game.HusbandTemperament += 5;
                            break;
                        case "chair":
                            Console.WriteLine(@"You sit back in your chair, feeling a mix of resignation and 
determination. The seat provides a familiar comfort, but the emotional 
distance between you and Patrick feels almost insurmountable in this moment.");
                            sittingOnChair = true;
                            Game.sanity += 10;
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
            }
            else if (Game.gameScript == 7)
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
                            Console.WriteLine("You have made a drink for you husband. This time it is a" + RandomDrink());

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
        
        //Ramdom assigned drink every time player aproach drink car

        internal string RandomDrink()
        {
            string[] drinks = new[]
            {
                "Old Fashioned", "Martini", "Whiskey Sour", "Manhattan", "Scotch on the Rocks",
                "Tom Collins", "Daiquiri", "Mint Julep", "Rum and Coke", "Pina Colada"
            };

            Random random = new Random();
            randomNumber = random.Next(drinks.Length);

            Game.AddInventory("drink");

            return drinks[randomNumber];
        }
        internal string LikedDrink()
        {
            // Dictionary mapping each random number to a response and temperament adjustment
            Dictionary<int, (string response, int temperamentAdjustment)> responses = new Dictionary<int, (string response, int temperamentAdjustment)>
            {
                { 0, ("Your husband is delighted with your choice of drink.", 20) },
                { 1, ("Your husband seems quite pleased with your choice of drink.", 15) },
                { 2, ("Your husband appreciates your choice of drink.", 10) },
                { 3, ("Your husband is content with your choice of drink.", 5) },
                { 4, ("Your husband thinks your choice of drink is agreeable.", 0) },
                { 5, ("Your husband finds your choice of drink acceptable.", 0) },
                { 6, ("Your husband is indifferent to your choice of drink.", -5) },
                { 7, ("Your husband isn't particularly keen on your choice of drink.", -10) },
                { 8, ("Your husband seems to disapprove of your choice of drink.", -15) },
                { 9, ("Your husband is quite displeased with your choice of drink.", -20) }
            };

            // Retrieve the response and temperament adjustment based on the random number
            var (response, temperamentAdjustment) = responses[randomNumber];

            // Apply the temperament adjustment
            Game.HusbandTemperament += temperamentAdjustment;

            // Return the response
            return response;
        }
    }
}

