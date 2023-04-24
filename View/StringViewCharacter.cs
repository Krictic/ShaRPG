using ShaRPG.Model;
using ShaRPG.View.GUI;

namespace ShaRPG.View
{
    internal class StringViewCharacter
    {
        public static void ToDict(Character character)
        {
            Dictionary<string, object> characterDict =
                new()
                {
                    { "name", character.GetName() },
                    { "biography", character.GetBiography() },
                    { "Job", character.GetJob() },
                    { "Level", character.GetLevel() },
                    { "statPoints", character.GetStatPoints() },
                    { "Experience", character.GetExperience() },
                    { "MaxExperience", character.GetMaxExperience() },
                    { "Strength", character.GetStrength() },
                    { "Vitality", character.GetVitality() },
                    { "Dexterity", character.GetDexterity() },
                    { "Agility", character.GetAgility() },
                    { "inteligence", character.GetIntelligence() },
                    { "Hp", character.GetHp() },
                    { "hpMax", character.GetHpMax() },
                    { "Damage", character.GetDamage() },
                    { "DamageMax", character.GetDamageMax() },
                    { "Accuracy", character.GetAccuracy() },
                    { "Defence", character.GetDefence() },
                    { "Mana", character.GetMana() },
                    { "maximum Mana", character.GetManaMax() },
                    { "CriticalChance", character.GetCriticalChance() },
                    { "Deflection", character.GetDeflection() },
                    { "Evasion", character.GetEvasion() },
                    { "Gold", character.GetGold() }
                };

            Console.WriteLine(characterDict);
        }

        // Todo: Maybe I can rewrite to to return variables on demand?
        public static string ToString(Character character)
        {
            string str =
                $"Name:\t\t{character.GetName()}\n"
                + $"Job:\t\t{character.GetJob()}\n"
                + $"Level:\t\t{character.GetLevel()}\n"
                + $"Stat Points:\t{character.GetStatPoints()}\n"
                + $"Exp:\t\t{character.GetExperience()}/{character.GetMaxExperience()} {Gui.ProgressBar(character.GetExperience(), character.GetMaxExperience(), 25)}\n";

            return str;
        }

        public static string ToStringBanner(Character character)
        {
            string str =
                $"[ {character.GetName()} | Lv: {character.GetLevel()} | Job: {character.GetJob()} {Gui.ProgressBar(character.GetExperience(), character.GetMaxExperience(), 25)} ]";

            return str;
        }

        public static string ToStringDetailed(Character character)
        {
            string str =
                $"Name:{character.GetName()}\n"
                + $"Biography:{character.GetBiography()}\n"
                + $"Job:{character.GetJob()}\n"
                + $"Level:{character.GetLevel()}\n"
                + $"Stat Points:{character.GetStatPoints()}\n"
                + $"Exp/MaxExp:{character.GetExperience()}/{character.GetMaxExperience()}\n"
                + $"\n========== Stats ==========n\n"
                + $"Strenght: {character.GetStrength()}\n"
                + $"Vitality: {character.GetVitality()}\n"
                + $"Dexterity: {character.GetDexterity()}\n"
                + $"Agility: {character.GetAgility()}\n"
                + $"Inteligence: {character.GetIntelligence()}\n"
                + $"\n========== Derived Stats ==========\n"
                + $"HP: {character.GetHp()}\n"
                + $"MaxHP: {character.GetHpMax()}\n"
                + $"Damage: {character.GetDamage()}\n"
                + $"Max Damage: {character.GetDamageMax()}\n"
                + $"Accuracy: {character.GetAccuracy()}\n"
                + $"Defence: {character.GetDefence()}\n"
                + $"Mana/Max Mana: {character.GetMana()}"
                + $"/ {character.GetManaMax()}\n"
                + $"Critical Chance: {character.GetCriticalChance()}\n"
                + $"Deflection: {character.GetDeflection()}\n"
                + $"Evasion: {character.GetEvasion()}\n"
                + $"Gold: {character.GetGold()}";
            return str;
        }
    }
}