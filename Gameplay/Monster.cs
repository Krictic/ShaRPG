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

            // Set level to a random value between 1 and 100
            Random random = new Random();
            poolDistribution(charLvl, random);

            // Calculate derived stats based on the randomly generated stats (inherited from Character)
            this.CalculateStats();
            lootExpCalculate(random);

        }

        private void poolDistribution(int charLvl, Random random)
        {
            // Set the StatPoints pool to be equivalent to the player.
            this.StatPoints = this.statPointsCalculate(charLvl);

            // Randomly distributes the StatPoints pool
            for (int i = 0; i < StatPoints; i++)
            {
                int variableIndex = random.Next(5);

                switch (variableIndex)
                {
                    case 0:
                        this.Strength++;
                        break;
                    case 1:
                        this.Vitality++;
                        break;
                    case 2:
                        this.Dexterity++;
                        break;
                    case 3:
                        this.Agility++;
                        break;
                    case 4:
                        this.Intelligence++;
                        break;
                    default:
                        break;
                }
            }
        }

        private void lootExpCalculate(Random random)
        {
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
