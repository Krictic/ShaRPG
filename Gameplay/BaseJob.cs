using ShaRPG.Gameplay;

internal abstract class BaseJob
{

    private string jobName;
    private int hpBonus;
    private int strengthBonus;
    private int vitalityBonus;
    private int dexterityBonus;
    private int agilityBonus;
    private int intelligenceBonus;

    public string JobName { get => jobName; set => jobName = value; }
    public int HpBonus { get => hpBonus; set => hpBonus = value; }
    public int StrengthBonus { get => strengthBonus; set => strengthBonus = value; }
    public int VitalityBonus { get => vitalityBonus; set => vitalityBonus = value; }
    public int DexterityBonus { get => dexterityBonus; set => dexterityBonus = value; }
    public int AgilityBonus { get => agilityBonus; set => agilityBonus = value; }
    public int IntelligenceBonus { get => intelligenceBonus; set => intelligenceBonus = value; }

    /// <summary>
    /// This applies the jobs bonuses to the character
    /// </summary>
    /// <param name="character">
    /// Whatever Character type object (which includes both player and NPCs such as monsters) this will apply to
    /// </param>
    public virtual void ApplyBonuses(Character character)
    {
        character.SetJob(JobName);
        character.SetHp(character.GetHp() + HpBonus);
        character.SetStrength(character.GetStrength() + StrengthBonus);
        character.SetVitality(character.GetVitality() + VitalityBonus);
        character.SetDexterity(character.GetDexterity() + DexterityBonus);
        character.SetAgility(character.GetAgility() + AgilityBonus);
        character.SetIntelligence(character.GetIntelligence() + IntelligenceBonus);
    }


}