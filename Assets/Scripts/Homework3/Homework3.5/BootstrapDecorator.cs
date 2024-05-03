using System.Collections.Generic;
using UnityEngine;

public class BootstrapDecorator : MonoBehaviour
{
    private List<CharacterWithCharacteristics> _characters = new List<CharacterWithCharacteristics>();

    void Start()
    {
        Debug.Log($"Создадим простого орка, вора эльфа, человека мага с навыком дьявольского ума");
        _characters.Add(new CharacterWithCharacteristics( RaceStats.Races.Ork));
        _characters.Add(new CharacterWithCharacteristics(RaceStats.Races.Elf, ClassStats.ClassNames.Thief));
        _characters.Add(new CharacterWithCharacteristics(RaceStats.Races.Human, ClassStats.ClassNames.Mage, PassiveAbilityStats.AbilitiesName.DevilsMind));

        foreach(CharacterWithCharacteristics character in _characters)
        {
            Debug.Log(character.TellAboutYourself());
        }
    }

}
