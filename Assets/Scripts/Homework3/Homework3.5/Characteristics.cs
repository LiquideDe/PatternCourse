using System;

public class Characteristics : IStatProvider
{
    public enum CharacteristicsName { Strength, Agility, Intelligence}

    private int _strength, _agility, _intelligence;

    public Characteristics()
    {
        _strength = 10;
        _agility = 10;
        _intelligence = 10;
    }

    public int GetStrength => _strength;

    public int GetAgility => _agility;

    public int GetIntelligence => _intelligence;

    public void IncreaseCharacteristic(CharacteristicsName characteristicName, int value)
    {
        switch(characteristicName)
        {
            case CharacteristicsName.Agility:
                _agility += value;
                break;

            case CharacteristicsName.Strength:
                _strength += value;
                break;

            case CharacteristicsName.Intelligence:
                _intelligence += value;
                break;

            default:
                throw new ArgumentException(nameof(CharacteristicsName));
        }
    }

    public void DecreaseCharacteristic(CharacteristicsName characteristicName, int value)
    {
        switch(characteristicName)
        {
            case CharacteristicsName.Agility:
                _agility -= GetCheckedValueForDecrease(_agility, value);
                break;

            case CharacteristicsName.Intelligence:
                _intelligence -= GetCheckedValueForDecrease(_intelligence, value);
                break;

            case CharacteristicsName.Strength:
                _strength -= GetCheckedValueForDecrease(_strength, value);
                break;

            default:
                throw new ArgumentException(nameof(CharacteristicsName));
        }
    }

    public void MultiplyingCharacteristic(CharacteristicsName characteristicName, int value)
    {
        switch (characteristicName)
        {
            case CharacteristicsName.Agility:
                _agility *= value;
                break;

            case CharacteristicsName.Intelligence:
                _intelligence *= value;
                break;

            case CharacteristicsName.Strength:
                _strength *= value;
                break;

            default:
                throw new ArgumentException(nameof(CharacteristicsName));
        }
    }

    public void DividingCharacteristic(CharacteristicsName characteristicName, int value)
    {
        if(value != 0)
            switch (characteristicName)
            {
                case CharacteristicsName.Agility:
                    _agility /= value;
                    break;

                case CharacteristicsName.Intelligence:
                    _intelligence /= value;
                    break;

                case CharacteristicsName.Strength:
                    _strength /= value;
                    break;

                default:
                    throw new ArgumentException(nameof(CharacteristicsName));
            }
    }

    public string TellAboutYourself()
    {
        return $"Моя Сила {_strength}, моя Ловкость {_agility}, мой Интеллект {_intelligence}.";
    }

    private int GetCheckedValueForDecrease(int amountCharacteristic, int value)
    {
        if (value > amountCharacteristic)
            return amountCharacteristic;

        else
            return value;
    }

    
}
