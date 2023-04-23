namespace ShaRPG.Gameplay.JobClasses.CreatureClasses
{
    internal class Creature : BaseJob
    {
        /// <summary>
        /// This is a beline set fo bonusess that will be applied to a generic monster
        /// but in practice, I will add some specific creature classses
        /// and this will become a placeholder.
        /// </summary>
        public Creature()
        {
            JobName = "Creature";
            HpBonus = 0;
            StrengthBonus = 0;
            VitalityBonus = 0;
            DexterityBonus = 0;
            AgilityBonus = 0;
            IntelligenceBonus = 0;
        }
    }
}
