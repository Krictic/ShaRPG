using ShaRPG.Gameplay;

internal class Job
{
    public abstract class BaseJob
    {
        public string JobName { get; set; }
        public int HpBonus { get; set; }
        public int StrengthBonus { get; set; }
        public int VitalityBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int AgilityBonus { get; set; }
        public int IntelligenceBonus { get; set; }

        public abstract void ApplyBonuses(Character character);
    }

    public class Warrior : BaseJob
    {
        public Warrior()
        {
            JobName = "Warrior";
            HpBonus = 10;
            StrengthBonus = 5;
            VitalityBonus = 4;
            DexterityBonus = 3;
            AgilityBonus = 2;
            IntelligenceBonus = 1;
        }

        public override void ApplyBonuses(Character character)
        {
            character.Job = JobName;
            character.Hp += HpBonus;
            character.Strength += StrengthBonus;
            character.Vitality += VitalityBonus;
            character.Dexterity += DexterityBonus;
            character.Agility += AgilityBonus;
            character.Intelligence += IntelligenceBonus;
        }
    }

    public class Archer : BaseJob
    {
        public Archer()
        {
            JobName = "Archer";
            HpBonus = 5;
            StrengthBonus = 2;
            VitalityBonus = 3;
            DexterityBonus = 6;
            AgilityBonus = 8;
            IntelligenceBonus = 2;
        }

        public override void ApplyBonuses(Character character)
        {
            character.Job = JobName;
            character.Hp += HpBonus;
            character.Strength += StrengthBonus;
            character.Vitality += VitalityBonus;
            character.Dexterity += DexterityBonus;
            character.Agility += AgilityBonus;
            character.Intelligence += IntelligenceBonus;
        }
    }
}