using ShaRPG.Model;

internal abstract class JobTemplate
{
    private string jobName { get; set; }
    private string description { get; set; }
    private int hpBonus { get; set; }
    private int strengthBonus { get; set; }
    private int vitalityBonus { get; set; }
    private int dexterityBonus { get; set; }
    private int agilityBonus { get; set; }
    private int intelligenceBonus { get; set; }

    public string GetJobName()
    {
        return jobName;
    }

    public void SetJobName(string value)
    {
        this.jobName = value;
    }

    public string GetDescription()
    {
        return description;
    }

    public void SetDescription(string value) 
    {
        this.description = value; 
    }

    public int GetHpBonus()
    {
        return hpBonus;
    }

    public void SetHpBonus(int value)
    {
        this.hpBonus = value;
    }

    public int GetStrengthBonus()
    {
        return strengthBonus;
    }

    public void SetStrengthBonus(int value)
    {
        this.strengthBonus = value;
    }

    public int GetVitalityBonus()
    {
        return vitalityBonus;
    }

    public void SetVitalityBonus(int value)
    {
        this.vitalityBonus = value;
    }

    public int GetDexterityBonus()
    {
        return dexterityBonus;
    }

    public void SetDexterityBonus(int value)
    {
        this.dexterityBonus = value;
    }

    public int GetAgilityBonus()
    {
        return agilityBonus;
    }

    public void SetAgilityBonus(int value)
    {
        this.agilityBonus = value;
    }

    public int GetIntelligenceBonus()
    {
        return intelligenceBonus;
    }

    public void SetIntelligenceBonus(int value)
    {
        this.intelligenceBonus = value;
    }

    /// <summary>
    /// This applies the jobs bonuses to the character
    /// </summary>
    /// <param name="character">
    /// Whatever CharacterModel type object (which includes both player and NPCs such as monsters) this will apply to
    /// </param>
    public virtual void ApplyBonuses(CharacterModel character)
    {
        character.SetJob(GetJobName());
        character.SetHp(character.GetHp() + GetHpBonus());
        character.SetStrength(character.GetStrength() + GetStrengthBonus());
        character.SetVitality(character.GetVitality() + GetVitalityBonus());
        character.SetDexterity(character.GetDexterity() + GetDexterityBonus());
        character.SetAgility(character.GetAgility() + GetAgilityBonus());
        character.SetIntelligence(character.GetIntelligence() + GetIntelligenceBonus());
    }
}