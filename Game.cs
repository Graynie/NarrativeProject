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

        List<Room> rooms = new List<Room>();
        public static List<string> inventory = new List<string>();
        public static string thing = "";
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
        static string nameOfRoom = "";
        public static int timeHour = 16;
        static int timeMinute = 0;
        static int timeMinuteDigit = 0;
        internal static int sanity = 80;
        public static bool lambLeg = false;
        public static int gameScript = 0;
        public static bool husbandDead = false;
        internal static bool shownOnce = false;
        public static int HusbandTemperament = 5;
        public static int HusbandDrunk = 0;
        public static bool TalkToHusband = false;
        public static bool cleanKill = false;
        public static bool HusbandLeaves = false;
        public static bool DrunkPlayer = false;
        public static bool insistGocery = false;
        public static bool Callpolice = false;
        internal static bool PlayerClean;

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
        public static void AddTime(int h,int m, int m2) 
        {
            timeHour+=h;
            timeMinute+= m;
            timeMinuteDigit+=m2;
        }
        public static void SetTime(int h,int m,int m2)
        {
            h = timeHour;
            m = timeMinute;
            m2 =timeMinuteDigit;
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
                Console.WriteLine("                                                  Lamb to Slaugther - The Game                                          ");
                Console.WriteLine("                                              Inspired by Roald Dahl (Short Story)                                      ");
                Console.WriteLine("                                                   Code by Danielle Rodriguez                                           ");
                MethodColorBasic();
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                MethodColorReverse();
                Console.WriteLine("   Room: " + nameOfRoom+ "                       Time: "+timeHour +"H"+ timeMinute  + timeMinuteDigit +"                            State: " + DetermineCharacterState(sanity)+"                      ") ;
                MethodColorBasic();
                
            }
        }
        public static void Alert()
        {
            MethodColorRed();
            if (Start.IsStartMenu==true) { }
            else if(Game.gameScript == 0)
            {
                Console.WriteLine("Your husband will arrive at 5");
            }
            else if (Game.gameScript == 1) 
            {
                Console.WriteLine("It's 5 o'clock, Your husband have arrived");
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
        public static void CheckTime()
        {
            if (timeMinute >= 6)
            {
                timeMinute = 0;
                timeHour++;
            }
            else if (timeHour == 24)
            {
                timeHour = 0;
            }
            else { }
            MethodColorGray();
            if (timeHour >= 17 && timeHour < 18 && shownOnce == false)
            {
                Console.WriteLine(@"You begin to listen, and a few moments later, punctually 
as always, you hear the tires on the gravel outside, the 
car door slamming, the footsteps passing the window, and
the key turning in the lock.");
                shownOnce = true;
                NextStepScript();
            }
            else 
            {
                
            }
                MethodColorBasic();
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
            if (inventory.Count > 0) { 
                for (int i = 0; i < inventory.Count - 1; i++)
                {
                    Console.WriteLine(inventory[i]);
                    if (i == inventory.Count - 1) {
                        Console.WriteLine("."); }
                    else { Console.WriteLine(", "); }
                }
            }
            else
            {
                Console.WriteLine("Nothing");
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
        public static void checkEnding() { }

        #endregion M
    }

}
