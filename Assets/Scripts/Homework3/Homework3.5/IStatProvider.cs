public interface IStatProvider
{
    public int GetStrength { get; }

    public int GetAgility { get; }

    public int GetIntelligence { get; }

    void IncreaseCharacteristic(Characteristics.CharacteristicsName characteristicName,int value);

    void DecreaseCharacteristic(Characteristics.CharacteristicsName characteristicName, int value);

    void MultiplyingCharacteristic(Characteristics.CharacteristicsName characteristicName, int value);

    void DividingCharacteristic(Characteristics.CharacteristicsName characteristicName, int value);

    string TellAboutYourself();
}
