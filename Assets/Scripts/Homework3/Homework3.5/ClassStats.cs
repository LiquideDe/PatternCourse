using Characteristic = Characteristics.CharacteristicsName;
public class ClassStats : IStatProvider
{
    public enum ClassNames { Warrior, Mage, Thief }

    private ClassNames _class;
    private IStatProvider _statProvider;

    public ClassStats(IStatProvider statProvider, ClassNames className)
    {
        _statProvider = statProvider;
        _class = className;

        switch (className)
        {
            case ClassNames.Warrior:
                MultiplyingCharacteristic(Characteristic.Strength, 2);
                IncreaseCharacteristic(Characteristic.Agility, 5);
                break;

            case ClassNames.Mage:
                MultiplyingCharacteristic(Characteristic.Intelligence, 2);
                IncreaseCharacteristic(Characteristic.Agility, 5);
                break;

            case ClassNames.Thief:
                MultiplyingCharacteristic(Characteristic.Agility, 2);
                IncreaseCharacteristic(Characteristic.Strength, 5);
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
        return $"Я великий {_class}. {_statProvider.TellAboutYourself()}";
    }
}
