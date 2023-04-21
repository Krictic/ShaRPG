namespace ShaRPG.Gameplay
{
    internal class Monsters
    {
        private String name;
        private string biography;
        private int level;

        // Stats
        private int strength;
        private int vitality;
        private int dexterity;
        private int agility;
        private int intelligence;

        // Derived Stats
        private int hp;
        private int hpMax;
        private int damage;
        private int damageMax;
        private int accuracy;
        private int defence;
        private int mana;
        private int manaMax;
        private double criticalChance;
        private double criticalDamage;

        // Loot
        private double loot;
        private double expGain;
        
        // Getters and Setters
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public int Vitality
        {
            get { return vitality; }
            set { vitality = value; }
        }

        public int Dexterity
        {
            get { return dexterity; }
            set { dexterity = value; }
        }

        public int Agility
        {
            get { return agility; }
            set { agility = value; }
        }

        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public int HpMax
        {
            get { return hpMax; }
            set { hpMax = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int DamageMax
        {
            get { return damageMax; }
            set { damageMax = value; }
        }

        public int Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }

        public int Mana
        {
            get { return mana; }
            set { mana = value; }
        }

        public int ManaMax
        {
            get { return manaMax; }
            set { manaMax = value; }
        }

        public double CriticalChance
        {
            get { return criticalChance; }
            set { criticalChance = value; }
        }

        public double CriticalDamage
        {
            get { return criticalDamage; }
            set { criticalDamage = value; }
        }

        public double Loot
        {
            get { return loot; }
            set { loot = value; }
        }

        public double ExpGain
        {
            get => expGain; 
            set => expGain = value;
        }

        public void DistributeVariables(int charLvl)
        {
            // Set name and biography to random strings
            this.name = "Random Rat";
            this.biography = "An randomly generate rat for you to fight against!";

            // Set level to a random value between 1 and 100
            Random random = new Random();
            this.level = random.Next(1, charLvl);

            // Set stats to random values between 1 and 10
            this.strength = random.Next(1 , level * 6);
            this.vitality = random.Next(1 , level * 6);
            this.dexterity = random.Next(1 , level * 6);
            this.agility = random.Next(1, level * 6);
            this.intelligence = random.Next(1, level * 6);

            // Calculate derived stats based on the randomly generated stats
            this.CalculateStats();

        }

        public void CalculateStats()
        {
            Random random = new Random();
            this.hp = hpMax;
            this.hpMax = this.vitality * 10;
            this.damageMax = this.strength * 2 + this.accuracy;
            this.accuracy = this.dexterity * 2;
            this.defence = this.agility * 2;
            this.manaMax = this.intelligence * 5;

            // Crit chance cannot be higher than 100 because it's a percentage
            if (this.dexterity + this.accuracy < 100)
            {
                this.criticalChance = (this.dexterity + this.accuracy) * 1.05;
            }
            else
            {
                this.criticalChance = 100;
            }

            this.criticalChance = (accuracy + (this.damage / 2)) * 2;

            // This calculates the average values of stats
            var arr = new int[] { Strength + Vitality + Dexterity + Agility + Intelligence };
            double avg = Queryable.Average(arr.AsQueryable());


            this.loot = (random.Next(1, 10) * avg) / 4;
            this.expGain = (random.Next(1, 10) * avg) / 4;
        }
    }
}

