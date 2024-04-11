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
        static int timeMinute = 00;
        internal static int sanity = 100;
        public static bool lambLeg = false;
        public static int gameScript = 0;
        public static bool husbandDead = false;


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
        internal void InformationMenubar()
        {if (Start.IsStartMenu) {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("             Lamb to Slaugther - The Game                    ");
                Console.WriteLine("         Inspired by Roald Dahl (Short Story)                ");
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Room: " + nameOfRoom+ " Time: "+timeHour +"H"+ timeMinute  + "0  Sanity: "+sanity+"%") ;
                
            }
        }
        internal void Alert()
        {
            MethodColor1();
            if (Start.IsStartMenu==true) { }
            else if(Game.gameScript == 0)
            {
                Console.WriteLine("Your husband will arrive at 5");
            }
            else if (Game.gameScript == 1) 
            {
                Console.WriteLine("It's 5 o'clock, Your husband have arrived");
            }
            else
            {
                Console.WriteLine("Alert");
            }
            MethodColor2();
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
        internal void CheckTime()
        {
            if(timeHour > 5&& timeHour<6)
            {
                Console.WriteLine(@"You begin to listen, and a few moments later, 
punctually as always, you hear the tires on the gravel
outside, and the car door slamming, the footsteps 
passing the window,and the key turning in the lock.");
                NextStepScript();
            }
        }
        internal static void saveGame()
        {
            /*Write data to save
            * saveData = new SaveData(200, "Danny");
            var bf = new BinaryFormatter();
            bf.Serialize(File.OpenWrite(SaveFile), saveData);*/
        }
        internal void MethodColor1()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }//End Color1 Red
        internal void MethodColor2()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }//End Color1 Gray
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
    }

}
