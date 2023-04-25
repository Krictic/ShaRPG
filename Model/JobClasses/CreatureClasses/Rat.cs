using System.Security.Cryptography.X509Certificates;

namespace ShaRPG.Model.JobClasses.CreatureClasses
{
    internal class Rat : JobTemplate
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
