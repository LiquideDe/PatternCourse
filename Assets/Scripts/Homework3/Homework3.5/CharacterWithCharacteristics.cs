public class CharacterWithCharacteristics
{
    private IStatProvider _characteristics;

    public CharacterWithCharacteristics(RaceStats.Races race)
    {
        _characteristics = new RaceStats(new Characteristics(), race);
    }

    public CharacterWithCharacteristics(RaceStats.Races race, ClassStats.ClassNames className)
    {
        _characteristics = new ClassStats(new RaceStats(new Characteristics(), race), className);
    }

    public CharacterWithCharacteristics(RaceStats.Races race, ClassStats.ClassNames className, PassiveAbilityStats.AbilitiesName ability)
    {
        _characteristics = new PassiveAbilityStats(new ClassStats(new RaceStats(new Characteristics(), race), className), ability);
    }

    public string TellAboutYourself()
    {
        return _characteristics.TellAboutYourself();
    }
}
