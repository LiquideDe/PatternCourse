using Characteristic = Characteristics.CharacteristicsName;
public class PassiveAbilityStats : IStatProvider
{
    public enum AbilitiesName {Hatred, SnakeSkin, DevilsMind }

    private IStatProvider _statProvider;
    private AbilitiesName _ability;

    public PassiveAbilityStats(IStatProvider statProvider, AbilitiesName abilitiyName)
    {
        _statProvider = statProvider;
        _ability = abilitiyName;

        switch (abilitiyName)
        {
            case AbilitiesName.Hatred:
                MultiplyingCharacteristic(Characteristic.Strength, 3);
                DividingCharacteristic(Characteristic.Agility, 2);
                break;

            case AbilitiesName.SnakeSkin:
                MultiplyingCharacteristic(Characteristic.Agility, 3);
                DividingCharacteristic(Characteristic.Intelligence, 2);
                break;

            case AbilitiesName.DevilsMind:
                MultiplyingCharacteristic(Characteristic.Intelligence, 3);
                DividingCharacteristic(Characteristic.Strength, 2);
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
        return $"Моя способность {_ability}. {_statProvider.TellAboutYourself()}";
    }
}
