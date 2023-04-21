using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseJob;

namespace ShaRPG.Gameplay.JobClasses
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