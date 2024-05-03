using Characteristic = Characteristics.CharacteristicsName;
public class RaceStats : IStatProvider
{    
    public enum Races { Elf, Ork, Human }

    private IStatProvider _statProvider;
    private Races _race;

    public RaceStats(IStatProvider statProvider, Races race)
    {
        _statProvider = statProvider;
        _race = race;

        switch (race)
        {
            case Races.Elf:
                IncreaseCharacteristic(Characteristic.Agility, 2);
                IncreaseCharacteristic(Characteristic.Intelligence, 1);
                DecreaseCharacteristic(Characteristic.Strength, 2);
                break;

            case Races.Human:
                IncreaseCharacteristic(Characteristic.Intelligence, 2);
                IncreaseCharacteristic(Characteristic.Strength, 1);
                DecreaseCharacteristic(Characteristic.Agility, 2);
                break;

            case Races.Ork:
                IncreaseCharacteristic(Characteristic.Strength, 2);
                IncreaseCharacteristic(Characteristic.Agility, 1);
                DecreaseCharacteristic(Characteristic.Intelligence, 2);
                break;
        }
    }

    public int GetStrength => _statProvider.GetStrength;

    public int GetAgility => _statProvider.GetAgility;

    public int GetIntelligence => _statProvider.GetIntelligence;

    public void IncreaseCharacteristic(Characteristic characteristicName, int value) => _statProvider.IncreaseCharacteristic(characteristicName, value);

    public void DecreaseCharacteristic(Characteristic characteristicName, int value) => _statProvider.DecreaseCharacteristic(characteristicName, value);

    public void MultiplyingCharacteristic(Characteristic characteristicName, int value) => _statProvider.MultiplyingCharacteristic(characteristicName, value);

    public void DividingCharacteristic(Characteristic characteristicName, int value) => _statProvider.DividingCharacteristic(characteristicName, value);

    public string TellAboutYourself()
    {
        return $"ß {_race}. {_statProvider.TellAboutYourself()}";
    }
}
