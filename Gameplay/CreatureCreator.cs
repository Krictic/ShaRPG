using ShaRPG.Gameplay.JobClasses.CreatureClasses;
using System.Security.Cryptography;

namespace ShaRPG.Gameplay
{
    /// <summary>
    /// This is a class for creating new creature instances.
    /// </summary>// Just a note on this class: I wanted a class specific for creature creation because the Creature
    // class is a job class, and I wish to treat Monsters as a kind of NPC.
    internal class CreatureCreator : Character
    {

        // Loot (CreatureCreator-specific variable)
        private double loot;
        private double expGain;

        public double Loot
        {
            get { return loot; }
            set { loot = value; }
        }

        public double ExpGain
        {
            get { return expGain; }
            set { expGain = value; }
        }
       
        public CreatureCreator() : base()
        {

        }
        
        /// <summary>
        /// This is the method for giving the creature instances a their stats and job
        /// bonuses.
        /// </summary>
        /// <param name="charLvl"></param>
        /// <param name="creatureType"></param>
        public void DistributeVariables(int charLvl, string creatureType = "creature")
        {
            // Set name and biography to random strings
            Name = $"Random {creatureType}";
            Job = "Rat";
            Biography = $"An randomly generated {creatureType} for you to fight against!";
            Level = charLvl;

            //Placeholder values for irrelevant stats for monsters (should porbably find a better way)
            Gold = 0;

            // The two stats below give the creature their stats and bonuses
            PoolDistribution(charLvl);
            ApplyCreatureBonuses(creatureType);

            // Calculate derived stats based on the randomly generated stats (inherited from Character)
            CharacterCreator.CalculateCharStats(this);

            // This gives the creature instance randomly generated expGain and loot values
            LootExpCalculate();
        }

        /// <summary>
        /// This method gives the creature instance their specific bonuses
        /// </summary>
        /// <param name="creatureType">The kind of creature that will be created</param>
        private void ApplyCreatureBonuses(string creatureType)
        {
            /*
            Because every creature is a character and every character has a job
            it felt better to just give creatures jobs which gives them their own
            distinct bonuses, skills and spells. So this makes it easier to do this.
           */
            switch (creatureType.ToLower().Trim())
            {
                case "rat":
                case "r":
                case "0":
                    new Rat().ApplyBonuses(this);
                    break;
                case "creature":
                    new Creature().ApplyBonuses(this);
                    break;
            }
        }

        private void PoolDistribution(int charLvl)
        {
            Random random = new();
            // Set the StatPoints pool to be equivalent to the player.
            StatPoints = StatPointsCalculate(charLvl);
            Level = charLvl;
            // Set a counting variable to guarantee that all statpoints are spent.
            int count = 0;

            // Randomly distributes the StatPoints pool
            while (count != StatPoints)
            {
                int variableIndex = random.Next(5);
                switch (variableIndex)
                {
                    case 0:
                        Strength += 1;
                        count++;
                        break;
                    case 1:
                        Vitality += 1;
                        count++;
                        break;
                    case 2:
                        Dexterity += 1;
                        count++;
                        break;
                    case 3:
                        Agility += 1;
                        count++;
                        break;
                    case 4:
                        Intelligence += 1;
                        count++;
                        break;
                    default:
                        break;
                }
            }
            StatPoints = 0;
        }

        /// <summary>
        /// This calculates the loot and Experience gained from defeating the monster
        /// </summary>
        private void LootExpCalculate()
        {
            // This calculates the average values of stats
            var arr = new int[] { Strength + Vitality + Dexterity + Agility + Intelligence };
            double avg = Queryable.Average(arr.AsQueryable());

            Random randomLootSeed = new();
            Loot = (randomLootSeed.Next(1, 10) * avg) / 4;
            Random randomExpSeed = new();
            ExpGain = (randomExpSeed.Next(1, 10) * avg) / 4;
        }

        public override string ToStringDetailed()
        {
            return
                $"========== Information ==========n\n"
                + $"Name:{Name}\n"
                + $"Biography:{Biography}\n"
                + $"Job:{Job}\n"
                + $"Level:{Level}\n"
                + $"Stat Points:{StatPoints}\n"
                + $"Exp/MaxExp:{Experience}/{MaxExperience}\n"
                + $"\n========== Stats ==========n\n"
                + $"Strenght: {Strength}\n"
                + $"Vitality: {Vitality}\n"
                + $"Dexterity: {Dexterity}\n"
                + $"Agility: {Agility}\n"
                + $"Dexterity: {Vitality}\n"
                + $"Inteligence: {Intelligence}\n"
                + $"\n========== Derived Stats ==========\n"
                + $"HP: {Hp}\n"
                + $"MaxHP: {HpMax}\n"
                + $"Damage: {Damage}\n"
                + $"Max Damage: {DamageMax}\n"
                + $"Accuracy: {Accuracy}\n"
                + $"Defence: {Defence}\n"
                + $"Mana/Max Mana: {Mana}" + $"/ {ManaMax}\n"
                + $"Critical Chance: {CriticalChance}\n"
                + $"Deflection: {Deflection}\n"
                + $"Evasion: {Evasion}\n"
                + $"ExpGain: {expGain}\n"
                + $"Loot: {Loot}";
        }
    }
}
