using NarrativeProject.Rooms;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using Newtonsoft.Json;



namespace NarrativeProject {
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SaveFile = "Save.txt";
            if (!File.Exists(SaveFile))
            {
                File.CreateText(SaveFile);
            }
            var game = new Game();
            game.Add(new Start());
            game.Add(new LivingRoom());
            game.Add(new Kitchen());
            game.Add(new Bedroom());
            game.Add(new Bathroom());
            game.Add(new BadEnding());
            game.Add(new BadEndingTwo());
            game.Add(new GoodEnding());
            game.Add(new Grocery());
            PoliceOfficer officer1 = new PoliceOfficer("Carlos", "Detective", 10);
            PoliceOfficer officer2 = new PoliceOfficer("Laura", "Inspector", 7);
            

            while (!Game.IsGameOver())
            {
                Game.CheckPoliceSuspicion();
                Game.checkTemperament();
                Game.InformationMenubar();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Game.Alert();
                Game.MethodColorGray();
                Console.WriteLine(game.CurrentRoomDescription);
                Game.MethodColorBasic();
                string choice = Console.ReadLine().ToLower() ?? "";
                Console.Clear();
                game.ReceiveChoice(choice);
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
