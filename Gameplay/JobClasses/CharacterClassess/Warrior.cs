namespace ShaRPG.Gameplay.JobClasses.CharacterClassess
{
    internal class Warrior : BaseJob
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
    }
}