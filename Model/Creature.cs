using ShaRPG.Model.JobClasses.CreatureClasses;

namespace ShaRPG.Model
{
    /// <summary>
    /// This is a class for creating new creature instances.
    /// </summary>// Just a note on this class: I wanted a class specific for creature creation because the Creature
    // class is a job class, and I wish to treat Monsters as a kind of NPC.
    internal class Creature : Character
    {

        // Loot (Creature-specific variable)
        private double loot { get; set; }
        private double expGain { get; set; }

        public double GetLoot()
        { return loot; }

        public void SetLoot(double value)
        { loot = value; }

        public double GetExpGain()
        { return expGain; }

        public void SetExpGain(double value)
        { expGain = value; }

        public Creature() : base()
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
            SetName($"Random {creatureType}");
            SetJob("Rat");
            SetBiography($"An randomly generated {creatureType} for you to fight against!");
            SetLevel(charLvl);

            //Placeholder values for irrelevant stats for monsters (should porbably find a better way)
            SetGold(0);

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
                    new Rat().ApplyBonuses(this);
                    break;
                case "creature":
                    new JobClasses.CreatureClasses.Creature().ApplyBonuses(this);
                    break;
            }
        }

        private void PoolDistribution(int charLvl)
        {
            Random random = new();
            // Set the StatPoints pool to be equivalent to the player.
            SetStatPoints(StatPointsCalculate(charLvl));
            SetLevel(charLvl);
            // Set a counting variable to guarantee that all statpoints are spent.
            int count = 0;

            // Randomly distributes the StatPoints pool
            while (count != GetStatPoints())
            {
                int variableIndex = random.Next(5);
                switch (variableIndex)
                {
                    case 0:
                        SetStrength(GetStrength() + 1);
                        count++;
                        break;
                    case 1:
                        SetVitality(GetVitality() + 1);
                        count++;
                        break;
                    case 2:
                        SetDexterity(GetDexterity() + 1);
                        count++;
                        break;
                    case 3:
                        SetAgility(GetAgility() + 1);
                        count++;
                        break;
                    case 4:
                        SetIntelligence(GetIntelligence() + 1);
                        count++;
                        break;
                    default:
                        break;
                }
            }
            SetStatPoints(0);
        }

        /// <summary>
        /// This calculates the loot and Experience gained from defeating the monster
        /// </summary>
        private void LootExpCalculate()
        {
            // This calculates the average values of stats
            var arr = new int[] { GetStrength() + GetVitality() + GetDexterity() + GetAgility() + GetIntelligence() };
            double avg = arr.AsQueryable().Average();

            Random randomLootSeed = new();
            SetLoot(randomLootSeed.Next(1, 10) * avg / 4);
            Random randomExpSeed = new();
            SetExpGain(randomExpSeed.Next(1, 10) * avg / 4);
        }

        public static string ToStringDetailed(Creature creature)
        {
            return
                $"========== Information ==========n\n"
                + $"Name:{creature.GetName()}\n"
                + $"Biography:{creature.GetBiography()}\n"
                + $"Job:{creature.GetJob()}\n"
                + $"Level:{creature.GetLevel()}\n"
                + $"Stat Points:{creature.GetStatPoints()}\n"
                + $"Exp/MaxExp:{creature.GetExperience()}/{creature.GetMaxExperience()}\n"
                + $"\n========== Stats ==========n\n"
                + $"Strenght: {creature.GetStrength()}\n"
                + $"Vitality: {creature.GetVitality()}\n"
                + $"Dexterity: {creature.GetDexterity()}\n"
                + $"Agility: {creature.GetAgility()}\n"
                + $"Inteligence: {creature.GetIntelligence()}\n"
                + $"\n========== Derived Stats ==========\n"
                + $"HP: {creature.GetHp()}\n"
                + $"MaxHP: {creature.GetHpMax()}\n"
                + $"Damage: {creature.GetDamage()}\n"
                + $"Max Damage: {creature.GetDamageMax()}\n"
                + $"Accuracy: {creature.GetAccuracy()}\n"
                + $"Defence: {creature.GetDefence()}\n"
                + $"Mana/Max Mana: {creature.GetMana()}" + $"/ {creature.GetManaMax()}\n"
                + $"Critical Chance: {creature.GetCriticalChance()}\n"
                + $"Deflection: {creature.GetDeflection()}\n"
                + $"Evasion: {creature.GetEvasion()}\n"
                + $"ExpGain: {creature.GetExpGain()}\n"
                + $"Loot: {creature.GetLoot()}";
        }
    }
}
