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

    public virtual void ApplyBonuses(Character character)
    {
        character.Job = JobName;
        character.Hp += HpBonus;
        character.Strength += StrengthBonus;
        character.Vitality += VitalityBonus;
        character.Dexterity += DexterityBonus;
        character.Agility += AgilityBonus;
        character.Intelligence += IntelligenceBonus;
    }


}