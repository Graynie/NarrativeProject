using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{
    using System;

    class PoliceOfficer
    {
        // Class properties
        public string Name { get; set; }
        public string Rank { get; set; }
        public int YearsOfService { get; set; }

        // Class constructor
        public PoliceOfficer(string name, string rank, int yearsOfService)
        {
            Name = name;
            Rank = rank;
            YearsOfService = yearsOfService;
        }

        // Method for reaction upon arriving at the chief's house and seeing him murdered
        public void ReactionUponSeeingMurderedChief()
        {
            string[] reactions = new[]
            {
            $"{Name}: This is horrible. I can't believe what has happened!",
            $"{Name}: What a tragic scene. I've worked with him for {YearsOfService} years, and he was a great chief.",
            $"{Name}: This is shocking. We need to find out who did this.",
            $"{Name}: This is one of the most terrible things I've seen in my {YearsOfService} years on the force."
        };

            Random random = new Random();
            int index = random.Next(reactions.Length);
            Console.WriteLine(reactions[index]);
        }

        // Method for offering condolences and reassuring the wife of the murdered chief
        public void OfferCondolencesAndReassure()
        {
            string[] messages = new[]
            {
            $"{Name}: I'm deeply sorry for your loss. He was a good man. I worked with him for {YearsOfService} years.",
            $"{Name}: This is a difficult time. Stay calm; we are here to help you.",
            $"{Name}: Please accept my deepest condolences. We will find who did this."
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
            $"{Name}: This leg of lamb is incredible! What a treat after a long day.",
            $"{Name}: This is some of the best leg of lamb I've had in years.",
            $"{Name}: It's been a tough day. This meal is a comfort."
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
            $"{Name}: This leg of lamb is quite flavorful, but something feels off...",
            $"{Name}: This meal is delicious, but I can't shake the feeling that there's something unusual about it.",
            $"{Name}: I'm enjoying this meal, but there's a peculiar taste to it.",
            $"{Name}: The seasoning is different than usual. Did someone add a special ingredient?"
        };

            Random random = new Random();
            int index = random.Next(comments.Length);
            Console.WriteLine(comments[index]);
        }
    }

   /* class Program
    {
       static void Main()
        {
            // Create instances of the PoliceOfficer class
            PoliceOfficer officer1 = new PoliceOfficer("Carlos", "Detective", 10);
            PoliceOfficer officer2 = new PoliceOfficer("Laura", "Inspector", 7);
            SpecialInvestigator officer3 = new SpecialInvestigator("Juan", "Patrol Officer", 3);

            // Officers' reactions
            officer1.ReactionUponSeeingMurderedChief();
            officer2.OfferCondolencesAndReassure();
            officer3.CommentOnLegOfLamb();
        }
    }*/

    internal class NPC
    {
    }
}
    
