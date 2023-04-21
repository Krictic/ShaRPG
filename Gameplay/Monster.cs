using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Reflection.Emit;

namespace ShaRPG.Gameplay
{
    internal class Monster : Character
    {

        // Loot (Monster-specific variable)
        private double loot;
        private double expGain;

        public Monster(string name, string biography) : base(name, biography)
        {

        }

        public void DistributeVariables(int charLvl)
        {
            // Set name and biography to random strings
            this.Name = "Random Rat";
            this.Job = "Monster";
            this.Biography = "An randomly generate rat for you to fight against!";
            this.Level = charLvl;

            //Placeholder values for irrelevant stats for monsters (should porbably find a better way)
            this.Gold = 0;
            this.StatPoints = 0;

            // Set level to a random value between 1 and 100
            Random random = new Random();

            // Set stats to random values between 1 and 10
            this.Strength = random.Next(1, Level * 6);
            this.Vitality = random.Next(1, Level * 6);
            this.Dexterity = random.Next(1, Level * 6);
            this.Agility = random.Next(1, Level * 6);
            this.Intelligence = random.Next(1, Level * 6);

            // Calculate derived stats based on the randomly generated stats (inherited from Character)
            this.CalculateStats();

            // This calculates the average values of stats
            var arr = new int[] { Strength + Vitality + Dexterity + Agility + Intelligence };
            double avg = Queryable.Average(arr.AsQueryable());

            // This calculoates the loot and exp gained from defeating the monster
            this.loot = (random.Next(1, 10) * avg) / 4;
            this.expGain = (random.Next(1, 10) * avg) / 4;

        }

        public override string ToStringDetailed()
        {
            return $"Name:{this.Name}\n"
            + $"Biography:{this.Biography}\n"
            + $"Job:{this.Job}\n"
            + $"Level:{this.Level}\n"
            + $"Stat Points:{this.StatPoints}\n"
            + $"\n========== Stats ==========n\n"
            + $"Strenght: {this.Strength}\n"
            + $"Vitality: {this.Vitality}\n"
            + $"Dexterity: {this.Dexterity}\n"
            + $"Agility: {this.Agility}\n"
            + $"Dexterity: {this.Vitality}\n"
            + $"Inteligence: {this.Intelligence}\n"
            + $"\n========== Derived Stats ==========\n"
            + $"HP: {this.Hp}\n"
            + $"MaxHP: {this.HpMax}\n"
            + $"Damage: {this.Damage}\n"
            + $"Max Damage: {this.DamageMax}\n"
            + $"Accuracy: {this.Accuracy}\n"
            + $"Defence: {this.Defence}\n"
            + $"Mana/Max Mana: {this.Mana}" + $"/ {this.ManaMax}\n"
            + $"Critical Chance: {this.CriticalChance}\n" 
            + $"Loot: {this.loot}\n"
            + $"ExpValue: {this.expGain}";
        }
    }
}
