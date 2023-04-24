namespace ShaRPG.Model.JobClasses.CreatureClasses
{
    internal class Goblin : BaseJob
    {
        public Goblin()
        {
            {
                SetJobName("Goblin");
                SetHpBonus(5);
                SetStrengthBonus(3);
                SetVitalityBonus(2);
                SetDexterityBonus(4);
                SetAgilityBonus(5);
                SetIntelligenceBonus(1);
            }
        }
    }
}
