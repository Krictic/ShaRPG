using ShaRPG.GUI;

namespace ShaRPG.Gameplay
{
    internal class Character
    {

        // Private classes
        // Core properties
        private String name = "";
        private string biography = "";
        private string job = "Peasant";
        private int level = 1;
        private int statPoints = 3;
        private int exp = 0;
        private int expMax = 100;

        // Stats
        private int strength = 1;
        private int vitality = 1;
        private int dexterity = 1;
        private int agility = 1;
        private int intelligence = 1;

        // Derived Stats
        private int hp = 0;
        private int hpMax = 0;
        private int damage = 0;
        private int damageMax = 0;
        private int accuracy = 0;
        private int defence = 0;
        private int mana = 0;
        private int manaMax = 0;
        private double criticalChance = 0;
        private double criticalDamage = 0;

        // General
        private int gold = 100;

        // Public Setters and Getters

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

        public int Experience
        {
            get { return exp; }
            set { exp = value; }
        }

        public int maxExperience
        {
            get { return expMax; }
            set { expMax = value; }
        }

        private void CalculateExp()
        {
            this.expMax = this.level * 100;
        }

        public void CalculateStats()
        {
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
        }

        public void StatPointsCalculate(int spentPoints)
        {
            this.statPoints -= spentPoints;
        } 

        public Character(String name, string biography)
        {
            this.CalculateStats();
            this.name = name;
            this.biography = biography;

        }

        public string ToStringBanner()
        {
            string str =
                $"==============================================\n" +
                $"[ {this.name} | Lv: {this.level} | Job: {this.Job} {Gui.ProgressBar(this.exp, this.expMax, 25)} ]\n" +
                $"==============================================\n";

            return str;
        }


        // Todo: Maybe I can rewrite to to return variables on demand?
        public override String ToString()
        {
            string str =
                $"Name:\t\t{this.name}\n" +
                $"Job:\t\t{this.job}\n" +
                $"Level:\t\t{this.level}\n" +
                $"Stat Points:\t{this.statPoints}\n" +
                $"Exp:\t\t{this.exp}/{this.expMax} {Gui.ProgressBar(30, 100, 10)}\n";

            return str;
        }

        public String ToStringDetailed()
        {
            string str =
                $"Name:{this.name}\n"
                + $"Biography:{this.biography}\n"
                + $"Job:{this.job}\n"
                + $"Level:{this.level}\n"
                + $"Stat Points:{this.statPoints}\n"
                + $"Exp/MaxExp:{this.exp}/{this.expMax}\n"
                + $"\n========== Stats ==========n\n"
                + $"Strenght: {this.strength}\n"
                + $"Vitality: {this.vitality}\n"
                + $"Dexterity: {this.dexterity}\n"
                + $"Agility: {this.agility}\n"
                + $"Dexterity: {this.vitality}\n"
                + $"Inteligence: {this.vitality}\n"
                + $"\n========== Derived Stats ==========\n"
                + $"HP: {this.hp}\n"
                + $"MaxHP: {this.hpMax}\n"
                + $"Damage: {this.damage}\n"
                + $"Max Damage: {this.damageMax}\n"
                + $"Accuracy: {this.accuracy}\n"
                + $"Defence: {this.defence}\n"
                + $"Mana/Max Mana: {this.mana}" + $"/ {this.manaMax}\n"
                + $"Critical Chance: {this.criticalChance}\n"
                + $"Gold: {this.gold}";
            return str;
        }

        public void ToDict()
        {
            Dictionary<string, object> characterDict = new Dictionary<string, object>()
            {
                { "name", this.name },
                { "biography", this.biography },
                { "job", this.job },
                { "level", this.level },
                { "statPoints", this.statPoints },
                { "exp", this.exp },
                { "expMax", this.expMax },
                { "strength", this.strength },
                { "vitality", this.vitality },
                { "dexterity", this.dexterity },
                { "agility", this.agility },
                { "inteligence", this.intelligence },
                { "hp", this.hp },
                { "hpMax", this.hpMax },
                { "damage", this.damage },
                { "damageMax", this.damageMax },
                { "accuracy", this.accuracy },
                { "defence", this.defence },
                { "mana", this.mana },
                { "maximum mana", this.manaMax},
                { "criticalChance", this.criticalChance },
                { "gold", this.gold }
            };

            Console.WriteLine(characterDict);

        }

        public void AddStats()
        {
            while (this.statPoints > 0)
            {
                Gui.GetInput($"Which stat do you wish to increase? (You have {this.statPoints} left.)");
                string statSelection = Console.ReadLine().ToLower().Trim();
                switch (statSelection)
                {
                    case "strength":
                        this.strength += 1;
                        Gui.Announcement($"Your new strength is {this.strength}");
                        break;
                    case "vitality":
                        this.vitality += 1;
                        Gui.Announcement($"Your new vitality is {this.vitality}");
                        break;
                    case "dexterity":
                        this.dexterity += 1;
                        Gui.Announcement($"Your new dexterity is {this.dexterity}");
                        break;
                    case "agility":
                        this.agility += 1;
                        Gui.Announcement($"Your new agility is {this.agility}");
                        break;
                    case "intelligence":
                        this.intelligence += 1;
                        Gui.Announcement($"Your new intelligence is {this.intelligence}");
                        break;
                }
                StatPointsCalculate(1);
            }

        }

    }
}
