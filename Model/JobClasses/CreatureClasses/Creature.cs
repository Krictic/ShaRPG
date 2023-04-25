namespace ShaRPG.Model.JobClasses.CreatureClasses
{
    internal class Creature : JobTemplate
    {
        /// <summary>
        /// This is a beline set fo bonusess that will be applied to a generic monster
        /// but in practice, I will add some specific creature classses
        /// and this will become a placeholder.
        /// </summary>
        public Creature()
        {
            SetJobName("CreatureModel");
            SetHpBonus(0);
            SetStrengthBonus(0);
            SetVitalityBonus(0);
            SetDexterityBonus(0);
            SetAgilityBonus(0);
            SetIntelligenceBonus(0);
        }
    }
}
