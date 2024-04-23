using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; // Added for JObject
using NarrativeProject.Rooms;
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
                    Inventory = Game.inventory,
                    Thing = Game.thing,
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
                    LambLegOven = Game.lambLegOven,
                    practice = Game.practice,
                    sucessStore = Game.sucessStore
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

                Game.inventory = saveData.GameData.Inventory;
                Game.thing = saveData.GameData.Thing;
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
                Game.practice = saveData.GameData.practice;
                Game.sucessStore = saveData.GameData.sucessStore;

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
                public List<string> Inventory { get; set; }
                public string Thing { get; set; }
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
                
                public bool sucessStore { get; internal set; }
                public bool practice { get; internal set; }
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
            internal class RoomConverter : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {
                    return typeof(Room).IsAssignableFrom(objectType);
                }

                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    JObject item = JObject.Load(reader);
                    string type = item["Type"].ToObject<string>();

                    switch (type)
                    {
                        case "LivingRoom":
                            return item.ToObject<LivingRoom>();
                        case "Kitchen":
                            return item.ToObject<Kitchen>();
                        case "Bedroom":
                            return item.ToObject<Bedroom>();
                        default:
                            return item.ToObject<LivingRoom>();
                    }
                }

                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }
            }
        }

        public static void ResetGame()
        {
            // Reset all game properties to their initial values
            Game.inventory.Clear();
            Game.thing = "";
            Game.isFinished = false;
            Game.nextRoom = "";
            Game.nameOfRoom = "";
            Game.sanity = 80;
            Game.lambLeg = false;
            Game.gameScript = 0;
            Game.husbandDead = false;
            Game.shownOnce = false;
            Game.HusbandTemperament = 5;
            Game.HusbandDrunk = 0;
            Game.TalkToHusband = false;
            Game.cleanKill = false;
            Game.HusbandLeaves = false;
            Game.DrunkPlayer = false;
            Game.insistGocery = false;
            Game.Callpolice = false;
            Game.PlayerClean = false;
            Game.notedestroyed = false;
            Game.PoliceSuspicion = 0;
            Game.TalkToOfficers = false;
            Game.lambLegOven = false;
            Game.practice = false;
            Game.sucessStore = false;

            LivingRoom.sittingOnChair = true;
            LivingRoom.greetHusband = false;
            LivingRoom.fireplaceOn = false;
            LivingRoom.randomNumber = 0;
            LivingRoom.LikeDrink = "Yes";
            LivingRoom.insist = false;
            LivingRoom.examineBody = false;
            LivingRoom.stepsUntilNext = 0;

            Kitchen.dishesClean = false;
            Kitchen.checkedFridge = false;
            Kitchen.checkedFreezer = false;
            Kitchen.insist = false;

            Bedroom.bedDone = false;
            Bedroom.bat = false;

            Start.IsStartMenu = false;
        }
    }
}

