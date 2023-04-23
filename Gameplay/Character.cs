﻿using ShaRPG.GUI;

namespace ShaRPG.Gameplay
{
    internal class Character
    {

        // Private classes
        // Core properties
        private string name { get; set; }
        private string biography { get; set; }
        private string job { get; set; }
        private int level { get; set; }  = 4;
        private int statPoints { get; set; }
        double exp { get; set; }  = 0;
        double expMax { get; set; }  = 100;

        // Base Stats
        private int strength { get; set; }  = 1;
        private int vitality { get; set; }  = 1;
        private int dexterity { get; set; }  = 1;
        private int agility { get; set; } = 1;
        private int intelligence { get; set; } = 1;

        // Secondary Stats  (derived from Base stats)
        private int hp { get; set; } = 0;
        private int hpMax { get; set; } = 0;
        private int damage { get; set; } = 0;
        private int damageMax { get; set; } = 0;
        private int accuracy { get; set; } = 0;
        private int defence { get; set; } = 0;
        private int mana { get; set; } = 0;
        private int manaMax { get; set; } = 0;
        private int deflection { get; set; } = 0;
        private int evasion { get; set; } = 0;

        // Tertiary stats (derived from secondary Stats)
        private double criticalChance { get; set; } = 0;
        private double criticalDamage { get; set; } = 0;

        // General
        private int gold { get; set; } = 100;

        // Indexing variable
        private Guid id { get; set; }

        // Public Setters and Getters

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string Name)
        {
            this.name = Name;
        }

        public Guid GetID()
        {
            return this.id;
        }

        public void SetID(Guid ID)
        {
            this.id = ID;
        }

        public string GetBiography()
        {
            return biography;
        }

        public void SetBiography(string biography)
        {
            this.biography = biography;
        }

        public string GetJob()
        { return job; }

        public void SetJob(string job)
        { this.job = job; }

        public int GetStatPoints()
        { return statPoints; }

        public void SetStatPoints(int value)
        { statPoints = value; }

        public int GetLevel()
        { return level; }

        public void SetLevel(int value)
        { level = value; }

        public int GetStrength()
        { return strength; }

        public void SetStrength(int value)
        { strength = value; }

        public int GetVitality()
        { return vitality; }

        public void SetVitality(int value)
        { vitality = value; }

        public int GetDexterity()
        { return dexterity; }

        public void SetDexterity(int value)
        { dexterity = value; }

        public int GetAgility()
        { return agility; }

        public void SetAgility(int value)
        { agility = value; }

        public int GetIntelligence()
        { return intelligence; }

        public void SetIntelligence(int value)
        { intelligence = value; }

        public int GetHp()
        { return hp; }

        public void SetHp(int value)
        { hp = value; }

        public int GetHpMax()
        { return hpMax; }

        public void SetHpMax(int value)
        { hpMax = value; }

        public int GetDamage()
        { return damage; }

        public void SetDamage(int value)
        { damage = value; }

        public int GetDamageMax()
        { return damageMax; }

        public void SetDamageMax(int value)
        { damageMax = value; }

        public int GetAccuracy()
        { return accuracy; }

        public void SetAccuracy(int value)
        { accuracy = value; }

        public int GetDefence()
        { return defence; }

        public void SetDefence(int value)
        { defence = value; }

        public int GetMana()
        { return mana; }

        public void SetMana(int value)
        { mana = value; }

        public int GetManaMax()
        { return manaMax; }

        public void SetManaMax(int value)
        { manaMax = value; }

        public double GetCriticalChance()
        { return criticalChance; }

        public void SetCriticalChance(double value)
        { criticalChance = value; }

        public double GetCriticalDamage()
        { return criticalDamage; }

        public void SetCriticalDamage(double value)
        { criticalDamage = value; }

        public int GetDeflection()
        {
            return this.deflection;
        }

        public void SetDeflection(int deflection)
        {
            this.deflection = deflection;
        }

        public int GetEvasion()
        {
            return this.deflection;
        }

        public void SetEvasion(int deflection)
        {
            this.deflection = deflection;
        }

        public double GetExperience()
        { return exp; }

        public void SetExperience(double value)
        { exp = value; }

        public double GetMaxExperience()
        { return expMax; }

        public void SetMaxExperience(double value)
        { expMax = value; }

        public int GetGold()
        { return gold; }

        public void SetGold(int value)
        { gold = value; }

        // This will calculate the expMax variable to follow a exponential progression (factor of 2)
        public double CalculateExp(int characterLevel)
        {
            if (characterLevel == 1)
            {
                return GetMaxExperience();
            } 
            else
            {
                return GetMaxExperience() * (Math.Pow(level - 1, 2));
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
            int malus = GetStatPoints() - spentPoints;
            SetStatPoints(malus);
        } 

        public Character(string name = "Chadicus", string biography = "Maximus")
        {
            SetName(name);
            SetBiography(biography);
        }
        public string ToStringBanner()
        {
            string str = $"[ {GetName()} | Lv: {GetLevel()} | Job: {GetJob()} {Gui.ProgressBar(GetExperience(), GetMaxExperience(), 25)} ]";

            return str;
        }


        // Todo: Maybe I can rewrite to to return variables on demand?
        public override string ToString()
        {
            string str =
                $"Name:\t\t{GetName()}\n" +
                $"Job:\t\t{GetJob()}\n" +
                $"Level:\t\t{GetLevel()}\n" +
                $"Stat Points:\t{GetStatPoints()}\n" +
                $"Exp:\t\t{GetExperience()}/{GetMaxExperience()} {Gui.ProgressBar(GetExperience(), GetMaxExperience(), 25)}\n";

            return str;
        }

        public virtual string ToStringDetailed()
        {
            string str =
                $"Name:{GetName()}\n"
                + $"Biography:{GetBiography()}\n"
                + $"Job:{GetJob()}\n"
                + $"Level:{GetLevel()}\n"
                + $"Stat Points:{statPoints}\n"
                + $"Exp/MaxExp:{GetExperience()}/{GetMaxExperience()}\n"
                + $"\n========== Stats ==========n\n"
                + $"Strenght: {GetStrength()}\n"
                + $"Vitality: {GetVitality()}\n"
                + $"Dexterity: {GetDexterity()}\n"
                + $"Agility: {GetAgility()}\n"
                + $"Dexterity: {GetVitality()}\n"
                + $"Inteligence: {GetIntelligence()}\n"
                + $"\n========== Derived Stats ==========\n"
                + $"HP: {GetHp()}\n"
                + $"MaxHP: {GetHpMax()}\n"
                + $"Damage: {GetDamage()}\n"
                + $"Max Damage: {GetDamageMax()}\n"
                + $"Accuracy: {GetAccuracy()}\n"
                + $"Defence: {GetDefence()}\n"
                + $"Mana/Max Mana: {GetMana()}" + $"/ {GetManaMax()}\n"
                + $"Critical Chance: {GetCriticalChance()}\n" 
                + $"Deflection: {GetDeflection()}\n"
                + $"Evasion: {GetEvasion()}\n"
                + $"Gold: {GetGold()}";
            return str;
        }

        public void ToDict()
        {
            Dictionary<string, object> characterDict = new()
            {
                { "name", GetName() },
                { "biography", GetBiography() },
                { "Job", GetJob() },
                { "Level", GetLevel() },
                { "statPoints", statPoints },
                { "Experience", GetExperience() },
                { "MaxExperience", GetMaxExperience() },
                { "Strength", GetStrength() },
                { "Vitality", GetVitality() },
                { "Dexterity", GetDexterity() },
                { "Agility", GetAgility() },
                { "inteligence", GetIntelligence() },
                { "Hp", GetHp() },
                { "hpMax", GetHpMax() },
                { "Damage", GetDamage() },
                { "DamageMax", GetDamageMax() },
                { "Accuracy", GetAccuracy() },
                { "Defence", GetDefence() },
                { "Mana", GetMana() },
                { "maximum Mana", GetManaMax()},
                { "CriticalChance", GetCriticalChance() },
                { "Deflection", GetDeflection() },
                { "Evasion", GetEvasion() },
                { "Gold", GetGold() }
            };

            Console.WriteLine(characterDict);

        }

        public void AddStats(Character character)
        {
            while (character.GetStatPoints() > 0)
            {
                string statSelection = Gui.GetInputInt($"Which stat do you wish to increase? (You have {character.GetStatPoints()} left.)").ToLower().Trim();
                bool valid = true;
                switch (statSelection)
                {
                    case "st":
                    case "str":
                    case "strength":
                        SetStrength(character.GetStrength() + 1);
                        Gui.Announcement($"Your new Strength is {GetStrength()}");
                        break;
                    case "vt":
                    case "vit":
                    case "vitality":
                        SetVitality(character.GetVitality() + 1);
                        Gui.Announcement($"Your new Vitality is {GetVitality()}");
                        break;
                    case "dx":
                    case "dex":
                    case "dexterity":
                        SetDexterity(character.GetDexterity() + 1);
                        Gui.Announcement($"Your new Dexterity is {GetDexterity()}");
                        break;
                    case "ag":
                    case "agi":
                    case "agility":
                        SetAgility(character.GetAgility() + 1);
                        Gui.Announcement($"Your new Agility is {GetAgility()}");
                        break;
                    case "iq":
                    case "int":
                    case "intelligence":
                        SetIntelligence(character.GetIntelligence() + 1);
                        Gui.Announcement($"Your new Intelligence is {GetIntelligence()}");
                        break;
                    default:
                        valid = false;
                        Gui.Alert("Choose a valid attirbute.");
                        break;
                }
                if (valid)
                {
                    character.StatPointsDecrement(1);
                }
                else
                {
                    continue;
                }
                
            }
        }

            public virtual void Attack(int Damage, int CriticalChance, int CriticalDamage, int Accuracy)
            {

            }

    }
}
