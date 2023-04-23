using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaRPG.Gameplay.JobClasses
{
    internal class Creature : BaseJob
    {
        public Creature()
        {
            JobName = "Creature";
            HpBonus = 5;
            StrengthBonus = 3;
            VitalityBonus = 3;
            DexterityBonus = 3;
            AgilityBonus = 3;
            IntelligenceBonus = 3;
        }
    }
}
