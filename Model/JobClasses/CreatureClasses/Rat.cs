namespace ShaRPG.Model.JobClasses.CreatureClasses
{
    internal class Rat : BaseJob
    {
        public Rat()
        {
            SetJobName("Rat");
            SetHpBonus(-5);
            SetStrengthBonus(3);
            SetVitalityBonus(1);
            SetDexterityBonus(4);
            SetAgilityBonus(7);
            SetIntelligenceBonus(0);
        }
    }
}
