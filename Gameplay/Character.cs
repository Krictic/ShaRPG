using ShaRPG.GUI;

namespace ShaRPG.Gameplay
{
    internal class Character
    {

        // Private classes
        // Core properties
        private string name = "";
        private string biography = "";
        private string job = "";
        private int level = 4;
        private int statPoints;
        double exp = 0;
        double expMax = 100;

        // Base Stats
        private int strength = 1;
        private int vitality = 1;
        private int dexterity = 1;
        private int agility = 1;
        private int intelligence = 1;

        // Secondary Stats  (derived from Base stats)
        private int hp = 0;
        private int hpMax = 0;
        private int damage = 0;
        private int damageMax = 0;
        private int accuracy = 0;
        private int defence = 0;
        private int mana = 0;
        private int manaMax = 0;
        private int deflection = 0;
        private int evasion = 0;

        // Tertiary stats (derived from secondary Stats)
        private double criticalChance = 0;
        private double criticalDamage = 0;

        // General
        private int gold = 100;

        // Indexing variable
        private Guid id;

        // Public Setters and Getters
        public Guid ID
        { 
            get { return id; }
            set { id = value; }
        }

        public int Deflection
        {
            get { return deflection; }
            set { deflection = value; }
        }

        public int Evasion
        {
            get { return evasion; }
            set { evasion = value; }
        }

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

        public string Job
        {
            get { return job; }
            set { job = value; }
        }

        public int StatPoints
        {
            get { return statPoints; }
            set { statPoints = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
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

        public double Experience
        {
            get { return exp; }
            set { exp = value; }
        }

        public double MaxExperience
        {
            get { return expMax; }
            set { expMax = value; }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        // This will calculate the expMax variable to follow a exponential progression (factor of 2)
        public double CalculateExp(int characterLevel)
        {
            if (characterLevel == 1)
            {
                return MaxExperience;
            } 
            else
            {
                int levelMultiplier = 2;
                return MaxExperience * (Math.Pow(level - 1, 2));
            }
        }

        public int CalculateBaseDamage(int st)
        {
            return st * 2;
        }

        public int CalculateHpMax(int vit)
        {
            return vit * 10;
        }

        public int CalculateAccuracy(int dex)
        {
            return dex * 2;
        }

        public int CalculateDefence(int agi)
        {
            return agi * 2;
        }

        public int CalculateManaMax(int iq)
        {
            return iq * 5;
        }

        public double CalculateCritChance(int dex, int acc)
        {
            return (dex + acc) / 3;
        }

        public double CalculateCritDamage(int dex, int iq, int dmg)
        {
            return (dex + iq + dmg) / 3;
        }

        public static int StatPointsCalculate(int Level)
        {
            int statPoints = 5 * Level;

            return statPoints;
        }

        public void StatPointsDecrement(int spentPoints)
        {
            statPoints -= spentPoints;
        } 

        public Character(string name = "Chadicus", string biography = "Maximus")
        {
            Name = name;
            Biography = biography;
        }
        public string ToStringBanner()
        {
            string str = $"[ {Name} | Lv: {Level} | Job: {Job} {Gui.ProgressBar(Experience, MaxExperience, 25)} ]";

            return str;
        }


        // Todo: Maybe I can rewrite to to return variables on demand?
        public override string ToString()
        {
            string str =
                $"Name:\t\t{Name}\n" +
                $"Job:\t\t{Job}\n" +
                $"Level:\t\t{Level}\n" +
                $"Stat Points:\t{StatPoints}\n" +
                $"Exp:\t\t{Experience}/{MaxExperience} {Gui.ProgressBar(Experience, MaxExperience, 25)}\n";

            return str;
        }

        public virtual string ToStringDetailed()
        {
            string str =
                $"Name:{Name}\n"
                + $"Biography:{Biography}\n"
                + $"Job:{Job}\n"
                + $"Level:{Level}\n"
                + $"Stat Points:{statPoints}\n"
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
                + $"MaxHP: {hpMax}\n"
                + $"Damage: {Damage}\n"
                + $"Max Damage: {DamageMax}\n"
                + $"Accuracy: {Accuracy}\n"
                + $"Defence: {Defence}\n"
                + $"Mana/Max Mana: {Mana}" + $"/ {ManaMax}\n"
                + $"Critical Chance: {CriticalChance}\n" 
                + $"Deflection: {Deflection}"
                + $"Evasion: {Evasion}"
                + $"Gold: {Gold}";
            return str;
        }

        public void ToDict()
        {
            Dictionary<string, object> characterDict = new()
            {
                { "name", Name },
                { "biography", Biography },
                { "Job", Job },
                { "Level", Level },
                { "statPoints", statPoints },
                { "Experience", Experience },
                { "MaxExperience", MaxExperience },
                { "Strength", Strength },
                { "Vitality", Vitality },
                { "Dexterity", Dexterity },
                { "Agility", Agility },
                { "inteligence", Intelligence },
                { "Hp", Hp },
                { "hpMax", HpMax },
                { "Damage", Damage },
                { "DamageMax", DamageMax },
                { "Accuracy", Accuracy },
                { "Defence", Defence },
                { "Mana", Mana },
                { "maximum Mana", ManaMax},
                { "CriticalChance", CriticalChance },
                { "Deflection", Deflection },
                { "Evasion", Evasion },
                { "Gold", Gold }
            };

            Console.WriteLine(characterDict);

        }

        public void AddStats()
        {
            while (statPoints > 0)
            {
                string statSelection = Gui.GetInputInt($"Which stat do you wish to increase? (You have {statPoints} left.)");

                switch (statSelection)
                {
                    case "Strength":
                        Strength += 1;
                        Gui.Announcement($"Your new Strength is {Strength}");
                        break;
                    case "Vitality":
                        Vitality += 1;
                        Gui.Announcement($"Your new Vitality is {Vitality}");
                        break;
                    case "Dexterity":
                        Dexterity += 1;
                        Gui.Announcement($"Your new Dexterity is {Dexterity}");
                        break;
                    case "Agility":
                        Agility += 1;
                        Gui.Announcement($"Your new Agility is {Agility}");
                        break;
                    case "Intelligence":
                        Intelligence += 1;
                        Gui.Announcement($"Your new Intelligence is {Intelligence}");
                        break;
                }
                StatPointsDecrement(1);
            }
        }

            public virtual void Attack(int Damage, int CriticalChance, int CriticalDamage, int Accuracy)
            {

            }

    }
}
