using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace NarrativeProject
{
    internal class Game
    {
        
        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        public static bool IsStartMenu;
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
            if (Game.gameScript == 1) 
            {
                Console.WriteLine("It's 5 o'clock, Your husband have arrived");
            }
            else
            {
                Console.WriteLine("Alert");
            }
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
        }//End Color1 Gray
        internal void MethodColor2()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }//End Color1 Gray
    }

}
