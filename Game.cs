using NarrativeProject.Rooms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace NarrativeProject
{
    internal class Game
    {
        
        List<Room> rooms = new List<Room>();
        public static List<string> inventory = new List<string>();
        public static string thing = "";
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
        static int story;
        static string nameOfRoom = "";
        public static int timeHour = 16;
        static int timeMinute = 0;
        static int timeMinuteDigit = 0;
        internal static int sanity = 100;
        public static bool lambLeg = false;
        public static int gameScript = 0;
        public static bool husbandDead = false;
        internal static bool shownOnce = false;
        public static int HusbandTemperament = 5;
        public static int HusbandDrunk = 0;
        public static bool TalkToHusband = false;
        public static bool cleanKill = false;
        public static bool HusbandLeaves = false;

        public static void killHusband()
        {
            husbandDead = true;
        }
        public static void FiveMinutes() 
        {
            if (timeMinuteDigit == 0)
            {
                timeMinuteDigit = 5;
            }
            else if (timeMinuteDigit == 5)
            {
                timeMinuteDigit = 0;
                timeMinute++;
            }
        }
        public static void TenMinutes() 
        {
        
        }
        public static void NextHour() 
        {
            timeHour++;
            timeMinute = 0;
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
                Console.WriteLine("------------------------------------------------------------");
                MethodColorReverse();
                Console.WriteLine("             Lamb to Slaugther - The Game                    ");
                Console.WriteLine("         Inspired by Roald Dahl (Short Story)                ");
                MethodColorBasic();
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------");
                MethodColorReverse();
                Console.WriteLine("   Room: " + nameOfRoom+ "      Time: "+timeHour +"H"+ timeMinute  + timeMinuteDigit +"       Sanity: " +sanity+"%     ") ;
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
                Console.WriteLine("Take your husband's coat, hang it up in the closet, and serve him a beverage as you usually do.");
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
            if (timeHour >= 17 && timeHour < 18 && shownOnce == false)
            {
                MethodColorBlue();
                Console.WriteLine(@"You begin to listen, and a few moments later, punctually 
as always, you hear the tires on the gravel outside, the 
car door slamming, the footsteps passing the window, and
the key turning in the lock.");
                shownOnce = true;
                MethodColorBasic();
                NextStepScript();
            }

            else { }
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
    }

}
