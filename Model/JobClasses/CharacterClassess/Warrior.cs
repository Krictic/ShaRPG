namespace ShaRPG.Model.JobClasses.CharacterClassess
{
    internal class Warrior : BaseJob
    {
        public Warrior()
        {
            SetJobName("Warrior");
            SetHpBonus(10);
            SetStrengthBonus(5);
            SetVitalityBonus(4);
            SetDexterityBonus(3);
            SetAgilityBonus(2);
            SetIntelligenceBonus(1);
        }
    }
}