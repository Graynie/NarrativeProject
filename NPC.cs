using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{

    internal class PoliceOfficer
    {
        // Class properties
        public static string Name { get; set; }
        public static string Rank { get; set; }
        public static int YearsOfService { get; set; }

        // Class constructor
        public PoliceOfficer(string name, string rank, int yearsOfService)
        {
            Name = name;
            Rank = rank;
            YearsOfService = yearsOfService;
        }

        // Method for reaction upon arriving at the chief's house and seeing him murdered
        public virtual void ReactionUponSeeingMurderedChief()
        {
            string[] reactions = new[]
            {
            $"{Name} ({Rank}): This is horrible. I can't believe what has happened!",
            $"{Name} ({Rank}): What a tragic scene. I've worked with him for {YearsOfService} years, and he was a great chief.",
            $"{Name} ({Rank}): This is shocking. We need to find out who did this.",
            $"{Name} ({Rank}): This is one of the most terrible things I've seen in my {YearsOfService} years on the force."
        };

            Random random = new Random();
            int index = random.Next(reactions.Length);
            Console.WriteLine(reactions[index]);
        }

        // Method for offering condolences and reassuring the wife of the murdered chief
        public virtual void OfferCondolencesAndReassure()
        {
            string[] messages = new[]
            {
            $"{Name} ({Rank}): I'm deeply sorry for your loss. He was a good man. I worked with him for {YearsOfService} years.",
            $"{Name} ({Rank}): This is a difficult time. Stay calm; we are here to help you.",
            $"{Name} ({Rank}): Please accept my deepest condolences. We will find who did this."
        };

            Random random = new Random();
            int index = random.Next(messages.Length);
            Console.WriteLine(messages[index]);
        }

        // Method for making comments when eating a leg of lamb without knowing it was the murder weapon
        public virtual void CommentOnLegOfLamb()
        {
            string[] comments = new[]
            {
            $"{Name} ({Rank}): This leg of lamb is incredible! What a treat after a long day.",
            $"{Name} ({Rank}): This is some of the best leg of lamb I've had in years.",
            $"{Name} ({Rank}): It's been a tough day. This meal is a comfort."
        };

            Random random = new Random();
            int index = random.Next(comments.Length);
            Console.WriteLine(comments[index]);
        }
    }

    // Subclass representing a specific type of police officer who overrides the CommentOnLegOfLamb method
    class SpecialInvestigator : PoliceOfficer
    {
        public SpecialInvestigator(string name, string rank, int yearsOfService)
            : base(name, rank, yearsOfService)
        {
        }

        // Overridden method for making comments when eating a leg of lamb without knowing it was the murder weapon
        public override void CommentOnLegOfLamb()
        {
            string[] comments = new[]
            {
            $"{Name} ({Rank}): This leg of lamb is quite flavorful, but something feels off...",
            $"{Name} ({Rank}): This meal is delicious, but I can't shake the feeling that there's something unusual about it.",
            $"{Name} ({Rank}): I'm enjoying this meal, but there's a peculiar taste to it.",
            $"{Name} ({Rank}): The seasoning is different than usual. Did someone add a special ingredient?"
        };

            Random random = new Random();
            int index = random.Next(comments.Length);
            Console.WriteLine(comments[index]);
        }
    }

    // ForensicOfficer class representing a forensic specialist
    class ForensicOfficer : PoliceOfficer
    {
        public ForensicOfficer(string name, string rank, int yearsOfService)
            : base(name, rank, yearsOfService)
        {
        }

        // Override reaction method for forensic officer
        public override void ReactionUponSeeingMurderedChief()
        {
            Console.WriteLine($"{Name} ({Rank}): I'll examine the body and collect evidence.");
        }
    }
}

/*            officer1.ReactionUponSeeingMurderedChief();
            officer2.OfferCondolencesAndReassure();
            officer3.CommentOnLegOfLamb();
            officer4.ReactionUponSeeingMurderedChief();*/
