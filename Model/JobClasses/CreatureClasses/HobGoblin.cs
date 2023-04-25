using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaRPG.Model.JobClasses.CreatureClasses
{
    internal class HobGoblin : JobTemplate
    {
        public HobGoblin()
        {
            SetJobName("HobGoblin");
            SetHpBonus(15);
            SetStrengthBonus(5);
            SetVitalityBonus(4);
            SetDexterityBonus(3);
            SetAgilityBonus(2);
            SetIntelligenceBonus(3);
        }
    }
}
