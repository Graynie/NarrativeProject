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
        static int timeHour = 16;
        static int timeMinute = 00;
        internal static int sanity = 100;

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
    }
}
