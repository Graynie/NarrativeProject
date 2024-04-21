using NarrativeProject.Rooms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace NarrativeProject
{

    internal class Game
    {
        #region "Variable"
        public static string filePath = "gameSave.json";
        public static List<Room> rooms = new List<Room>();
        public static List<string> inventory = new List<string>();
        public static string thing = "";
        public static Room currentRoom;
        public static bool IsGameOver() => isFinished;
        public static bool isFinished;
        public static string nextRoom = "";
        public static string nameOfRoom = "";
        public static int sanity = 80;
        public static bool lambLeg = false;
        public static int gameScript = 0;
        public static bool husbandDead = false;
        public static bool shownOnce = false;
        public static int HusbandTemperament = 5;
        public static int HusbandDrunk = 0;
        public static bool TalkToHusband = false;
        public static bool cleanKill = false;
        public static bool HusbandLeaves = false;
        public static bool DrunkPlayer = false;
        public static bool insistGocery = false;
        public static bool Callpolice = false;
        public static bool PlayerClean;
        public static bool notedestroyed = false;
        public static int PoliceSuspicion=0;
        public static bool TalkToOfficers;
        public static bool lambLegOven=false;
        public static bool SinkDirty = false;

        #endregion

        enum CharacterState
        {
            ExtremelyDespondent = 0,
            VeryDespondent = 10,
            Despondent = 20,
            Anxious = 30,
            Nervous = 40,
            Neutral = 50,
            Calm = 60,
            Hopeful = 70,
            Optimistic = 80,
            VeryOptimistic = 90,
            Elated = 100
        }


        #region "Methods"
        public static void killHusband()
        {
            husbandDead = true;
        }
        public static int NextStepScript()
        { return gameScript++; }
        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }
        internal string CurrentRoomDescription => currentRoom.CreateDescription();
        internal void ReceiveChoice(string choice)
        {
            if(choice == "save game")
            {
                saveGame();
            }
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
        }
        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }
        internal static void Finish()
        {
            isFinished = true;
        }
        public static void InformationMenubar()
        {

            if (Start.IsStartMenu) {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                MethodColorReverse();
                Console.WriteLine("                                             Lamb to Slaugther - The Game                                               ");
                Console.WriteLine("                                         Inspired by Roald Dahl (Short Story)                                           ");
                Console.WriteLine("                                              Code by Danielle Rodriguez                                                ");
                MethodColorBasic();
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                MethodColorReverse();
                Console.WriteLine("   Room: " + nameOfRoom+ "                                                                    State: " + DetermineCharacterState(sanity)+"                ") ;
                MethodColorBasic();
                
            }
        }
        public static void Alert()
        {
            MethodColorBlue();
            if (Start.IsStartMenu==true) { }
            else if(Game.gameScript == 0)
            {
                Console.WriteLine("Your husband will arrive at 5");
            }
            else if (Game.gameScript == 1) 
            {
                Console.WriteLine("It's 5 o'clock, Your husband have arrived");
                Console.WriteLine("You begin to listen, and a few moments later, punctually as always, you hear the tires on the gravel outside, the car door slamming, the footsteps passing the window, and the key turning in the lock.");
            }
            else if (Game.gameScript ==2)
            {
                if (inventory.Contains("coat"))
                {
                Console.WriteLine("Take your husband's coat, hang it up in the closet, and serve him a beverage as you usually do.");

                }
                else
                {
                    Console.WriteLine();
                }
            }
            else if (Game.gameScript == 5)
            {
                Console.WriteLine("Cook souper for Patrick");
            }
            else
            {
                Console.WriteLine("Alert");
            }
            MethodColorBasic();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

        }
        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nameOfRoom= room.GetType().Name.ToString();
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }
        internal static void saveGame()
        {
            /*Write data to save
            * saveData = new SaveData(200, "Danny");
            var bf = new BinaryFormatter();
            bf.Serialize(File.OpenWrite(SaveFile), saveData);*/
        }
        public static void MethodColorRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
        }//End Color1 Red
        public static void MethodColorBasic()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }//End Color1 Gray
        public static void MethodColorReverse()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }//End Color1 Gray
        public static void MethodColorGray() 
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void MethodColorBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void AddInventory(string thing) {
            inventory.Add(thing);
        }
        public static void RemoveInventory(string thing) {  inventory.Remove(thing); }
        public static void DisplayInventory() 
        {
            Console.Write("\nYou have in your inventory: ");
            if (inventory.Count > 0)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.Write(inventory[i]);
                    if (i < inventory.Count - 1)
                    {
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.WriteLine(".\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nothing.\n");
            }
        }
        public static void IncreaseSanity()
        {
            sanity += 10;
        }
        public static void DecraseSanity()
        {
            sanity -= 10;
        }
        public static void checkTemperament()
        {
            if (HusbandTemperament>80)
            {
                Game.Transition<BadEnding>();
            }
            else { }
        }
        static CharacterState DetermineCharacterState(int emotionalValue)
        {
            if (emotionalValue >= 0 && emotionalValue < 10)
            {
                return CharacterState.ExtremelyDespondent;
            }
            else if (emotionalValue >= 10 && emotionalValue < 20)
            {
                return CharacterState.VeryDespondent;
            }
            else if (emotionalValue >= 20 && emotionalValue < 30)
            {
                return CharacterState.Despondent;
            }
            else if (emotionalValue >= 30 && emotionalValue < 40)
            {
                return CharacterState.Anxious;
            }
            else if (emotionalValue >= 40 && emotionalValue < 50)
            {
                return CharacterState.Nervous;
            }
            else if (emotionalValue >= 50 && emotionalValue < 60)
            {
                return CharacterState.Neutral;
            }
            else if (emotionalValue >= 60 && emotionalValue < 70)
            {
                return CharacterState.Calm;
            }
            else if (emotionalValue >= 70 && emotionalValue < 80)
            {
                return CharacterState.Hopeful;
            }
            else if (emotionalValue >= 80 && emotionalValue < 90)
            {
                return CharacterState.Optimistic;
            }
            else if (emotionalValue >= 90 && emotionalValue < 100)
            {
                return CharacterState.VeryOptimistic;
            }
            else // emotionalValue == 100
            {
                return CharacterState.Elated;
            }
        }
        internal static void CheckPoliceSuspicion()
        {
            if (PoliceSuspicion > 6)
            {
                Console.WriteLine("Your action made the police officers seem suspicious. Later with the proofs they found out your actions");
                Game.Transition<BadEndingTwo>();
            }
            else  if(PoliceSuspicion < -1)
            {
                Console.WriteLine(); 
                Game.Transition<GoodEnding>();
            }
        }

        #endregion M
    }


}
