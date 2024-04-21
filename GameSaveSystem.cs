using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static NarrativeProject.GameSaveSystem.GameSaveData;

namespace NarrativeProject
{
    internal static class GameSaveSystem
    {
        public static void SaveGame(string filePath)
        {
            GameSaveData saveData = new GameSaveData()
            {
                GameData = new GameSaveData.GameDataClass()
                {
                    Rooms = Game.rooms,
                    Inventory = Game.inventory,
                    Thing = Game.thing,
                    CurrentRoom = Game.currentRoom,
                    IsFinished = Game.isFinished,
                    NextRoom = Game.nextRoom,
                    NameOfRoom = Game.nameOfRoom,
                    Sanity = Game.sanity,
                    LambLeg = Game.lambLeg,
                    GameScript = Game.gameScript,
                    HusbandDead = Game.husbandDead,
                    ShownOnce = Game.shownOnce,
                    HusbandTemperament = Game.HusbandTemperament,
                    HusbandDrunk = Game.HusbandDrunk,
                    TalkToHusband = Game.TalkToHusband,
                    CleanKill = Game.cleanKill,
                    HusbandLeaves = Game.HusbandLeaves,
                    DrunkPlayer = Game.DrunkPlayer,
                    InsistGocery = Game.insistGocery,
                    CallPolice = Game.Callpolice,
                    PlayerClean = Game.PlayerClean,
                    NoteDestroyed = Game.notedestroyed,
                    PoliceSuspicion = Game.PoliceSuspicion,
                    TalkToOfficers = Game.TalkToOfficers,
                    LambLegOven = Game.lambLegOven
                },
                LivingRoomData = new LivingRoomSaveData()
                {
                    SittingOnChair = LivingRoom.sittingOnChair,
                    GreetHusband = LivingRoom.greetHusband,
                    FireplaceOn = LivingRoom.fireplaceOn,
                    RandomNumber = LivingRoom.randomNumber,
                    LikeDrink = LivingRoom.LikeDrink,
                    Insist = LivingRoom.insist,
                    ExamineBody = LivingRoom.examineBody,
                    StepsUntilNext = LivingRoom.stepsUntilNext
                },
                KitchenData = new KitchenSaveData()
                {
                    DishesClean = Kitchen.dishesClean,
                    CheckedFridge = Kitchen.checkedFridge,
                    CheckedFreezer = Kitchen.checkedFreezer,
                    Insist = Kitchen.insist
                },
                BedroomData = new BedroomSaveData()
                {
                    BedDone = Bedroom.bedDone,
                    Bat = Bedroom.bat
                },
                StartData = new StartSaveData()
                {
                    IsStartMenu = Start.IsStartMenu
                }
            };

            string jsonData = JsonConvert.SerializeObject(saveData, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Game saved successfully.");
        }

        public static bool LoadGame(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No saved game found.");
                return false;
            }

            try
            {
                string jsonData = File.ReadAllText(filePath);
                GameSaveData saveData = JsonConvert.DeserializeObject<GameSaveData>(jsonData);

                Game.rooms = saveData.GameData.Rooms;
                Game.inventory = saveData.GameData.Inventory;
                Game.thing = saveData.GameData.Thing;
                Game.currentRoom = saveData.GameData.CurrentRoom;
                Game.isFinished = saveData.GameData.IsFinished;
                Game.nextRoom = saveData.GameData.NextRoom;
                Game.nameOfRoom = saveData.GameData.NameOfRoom;
                Game.sanity = saveData.GameData.Sanity;
                Game.lambLeg = saveData.GameData.LambLeg;
                Game.gameScript = saveData.GameData.GameScript;
                Game.husbandDead = saveData.GameData.HusbandDead;
                Game.shownOnce = saveData.GameData.ShownOnce;
                Game.HusbandTemperament = saveData.GameData.HusbandTemperament;
                Game.HusbandDrunk = saveData.GameData.HusbandDrunk;
                Game.TalkToHusband = saveData.GameData.TalkToHusband;
                Game.cleanKill = saveData.GameData.CleanKill;
                Game.HusbandLeaves = saveData.GameData.HusbandLeaves;
                Game.DrunkPlayer = saveData.GameData.DrunkPlayer;
                Game.insistGocery = saveData.GameData.InsistGocery;
                Game.Callpolice = saveData.GameData.CallPolice;
                Game.PlayerClean = saveData.GameData.PlayerClean;
                Game.notedestroyed = saveData.GameData.NoteDestroyed;
                Game.PoliceSuspicion = saveData.GameData.PoliceSuspicion;
                Game.TalkToOfficers = saveData.GameData.TalkToOfficers;
                Game.lambLegOven = saveData.GameData.LambLegOven;

                LivingRoom.sittingOnChair = saveData.LivingRoomData.SittingOnChair;
                LivingRoom.greetHusband = saveData.LivingRoomData.GreetHusband;
                LivingRoom.fireplaceOn = saveData.LivingRoomData.FireplaceOn;
                LivingRoom.randomNumber = saveData.LivingRoomData.RandomNumber;
                LivingRoom.LikeDrink = saveData.LivingRoomData.LikeDrink;
                LivingRoom.insist = saveData.LivingRoomData.Insist;
                LivingRoom.examineBody = saveData.LivingRoomData.ExamineBody;
                LivingRoom.stepsUntilNext = saveData.LivingRoomData.StepsUntilNext;

                Kitchen.dishesClean = saveData.KitchenData.DishesClean;
                Kitchen.checkedFridge = saveData.KitchenData.CheckedFridge;
                Kitchen.checkedFreezer = saveData.KitchenData.CheckedFreezer;
                Kitchen.insist = saveData.KitchenData.Insist;

                Bedroom.bedDone = saveData.BedroomData.BedDone;
                Bedroom.bat = saveData.BedroomData.Bat;

                Start.IsStartMenu = saveData.StartData.IsStartMenu;

                Console.WriteLine("Game loaded successfully.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading game: {e.Message}");
                return false;
            }
        }

        internal class GameSaveData
        {
            public GameDataClass GameData { get; set; }
            public LivingRoomSaveData LivingRoomData { get; set; }
            public KitchenSaveData KitchenData { get; set; }
            public BedroomSaveData BedroomData { get; set; }
            public StartSaveData StartData { get; set; }

            public class GameDataClass
            {
                public List<Room> Rooms { get; set; }
                public List<string> Inventory { get; set; }
                public string Thing { get; set; }
                public Room CurrentRoom { get; set; }
                public bool IsFinished { get; set; }
                public string NextRoom { get; set; }
                public string NameOfRoom { get; set; }
                public int Sanity { get; set; }
                public bool LambLeg { get; set; }
                public int GameScript { get; set; }
                public bool HusbandDead { get; set; }
                public bool ShownOnce { get; set; }
                public int HusbandTemperament { get; set; }
                public int HusbandDrunk { get; internal set; }
                public bool TalkToHusband { get; internal set; }
                public bool CleanKill { get; internal set; }
                public bool HusbandLeaves { get; internal set; }
                public bool DrunkPlayer { get; internal set; }
                public bool InsistGocery { get; internal set; }
                public bool CallPolice { get; internal set; }
                public bool PlayerClean { get; internal set; }
                public bool NoteDestroyed { get; internal set; }
                public int PoliceSuspicion { get; internal set; }
                public bool TalkToOfficers { get; internal set; }
                public bool LambLegOven { get; internal set; }
            }
            internal class LivingRoomSaveData
            {
                public bool SittingOnChair { get; set; }
                public bool GreetHusband { get; set; }
                public bool FireplaceOn { get; set; }
                public int RandomNumber { get; set; }
                public string LikeDrink { get; set; }
                public bool Insist { get; set; }
                public bool ExamineBody { get; set; }
                public int StepsUntilNext { get; set; }
            }
            internal class KitchenSaveData
            {
                public bool DishesClean { get; set; }
                public bool CheckedFridge { get; set; }
                public bool CheckedFreezer { get; set; }
                public bool Insist { get; set; }
            }
            internal class BedroomSaveData
            {
                public bool BedDone { get; set; }
                public bool Bat { get; set; }
            }
            internal class StartSaveData
            {
                public bool IsStartMenu { get; set; }
            }

        }

    }
}
