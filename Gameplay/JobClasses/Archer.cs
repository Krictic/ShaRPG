using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseJob;

namespace ShaRPG.Gameplay.JobClasses
{
    internal class Archer : BaseJob
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
    }
}
