using NarrativeProject.Rooms;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;



namespace NarrativeProject {

    [Serializable]
    public class SaveData
    {
        public int numberToSave;
        public string stringToSave;

        public SaveData(int numberToSave, string stringToSave)
        {

            this.numberToSave = numberToSave;
            this.stringToSave = stringToSave;
        }
    }
    internal class Program
    {
        static SaveData saveData;

        static void Main(string[] args)
        {

            const string SaveFile = "Save.txt";
            if (!File.Exists(SaveFile))
            {
                File.CreateText(SaveFile);
            }



            /*File.WriteAllText("Save.txt", "Hello World");
            File.ReadAllText;*/

            var game = new Game();
            game.Add(new Start());
            game.Add(new LivingRoom());
            game.Add(new Kitchen());
            game.Add(new Bedroom());
            game.Add(new Bathroom());
            game.Add(new AtticRoom());
            game.Add(new Cellar());
            game.Add(new Closet());
            game.Add(new Garage());
            game.Add(new Grocery());


            while (!game.IsGameOver())
            {
                
                Game.CheckTime();
                Game.Alert();
                Game.InformationMenubar();
                Console.WriteLine("------------------------------------------------------------");
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
