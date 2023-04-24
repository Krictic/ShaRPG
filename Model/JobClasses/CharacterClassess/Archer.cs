namespace ShaRPG.Model.JobClasses.CharacterClassess
{
    internal class Archer : BaseJob
    {
        public Archer()
        {
            SetJobName("Archer");
            SetHpBonus(5);
            SetStrengthBonus(2);
            SetVitalityBonus(3);
            SetDexterityBonus(6);
            SetAgilityBonus(8);
            SetIntelligenceBonus(2);
        }
    }
}
